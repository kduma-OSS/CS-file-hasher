using FileHasher.Library;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace FileHasher.GUI.WinForms
{
    public partial class MainForm : Form
    {
        private readonly ObservableCollection<FileTask> _tasks = [];

        public MainForm(List<string> files)
        {
            InitializeComponent();
            _tasks.CollectionChanged += TasksUpdated;

            foreach (var file in files)
            {
                if (!File.Exists(file))
                    continue;

                var extension = Path.GetExtension(file);
                _tasks.Add(new FileTask(file, (extension != ".ph" && extension != ".md5" && extension != ".sha1") ? FileTask.Type.Hash : FileTask.Type.Verify));
            }
        }

        private void TasksUpdated(object? sender, NotifyCollectionChangedEventArgs e)
        {
            TasksUpdated();
        }

        private void TasksUpdated()
        {
            listView1.Items.Clear();


            ListViewItem? itemView = null;
            foreach (var task in _tasks)
            {
                var item = new ListViewItem([
                    Path.GetFileName(task.FilePath),
                    task.TaskType.ToString(),
                    task.TaskStatusString,
                    ]);

                switch (task.TaskStatus)
                {
                    case FileTask.Status.Completed:
                        item.BackColor = Color.LightGreen;
                        break;
                    case FileTask.Status.Failed:
                        item.BackColor = Color.LightCoral;
                        break;
                    case FileTask.Status.Working:
                        itemView = item;
                        break;
                }

                listView1.Items.Add(item);
            }

            itemView ??= listView1.Items.Count > 0 ? listView1.Items[^1] : null;

            itemView?.EnsureVisible();

            StartWorkIfIdle();
        }

        private void FLoad(object sender, EventArgs e)
        {
            // This method is intentionally left empty.
            // Required as a Form Load event handler; no action needed on load.
        }

        private void FDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void FDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null)
                return;

            if (!e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetData(DataFormats.FileDrop) is not string[] files) return;
            
            
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file);
                _tasks.Add(new FileTask(file, (extension != ".ph" && extension != ".md5" && extension != ".sha1") ? FileTask.Type.Hash : FileTask.Type.Verify));
            }
        }

        private void StartWorkIfIdle()
        {
            if (backgroundWorker1.IsBusy)
                return;

            if (_tasks.Any(t => t.TaskStatus == FileTask.Status.Working))
                return;

            if (_tasks.All(t => t.TaskStatus != FileTask.Status.Pending))
                return;

            var task = _tasks.First(t => t.TaskStatus == FileTask.Status.Pending);
            task.TaskStatus = FileTask.Status.Working;

            backgroundWorker1.RunWorkerAsync(task);
        }

        private void WDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (e.Argument is not FileTask task)
                return;

            Hash? hash;
            
            switch (task.TaskType)
            {
                case FileTask.Type.Hash:
                {
                    hash = Hasher.File(task.FilePath);

                    using (var stream = new FileStream($"{task.FilePath}.ph", FileMode.Create, FileAccess.Write, FileShare.Read, 4096, FileOptions.SequentialScan))
                    {
                        stream.Write(hash.Pack());
                    }

                    e.Result = FileTask.Status.Completed;
                    break;
                }
                case FileTask.Type.Verify:
                {
                    var extension = Path.GetExtension(task.FilePath);
                    var baseFile = $"{Path.GetDirectoryName(task.FilePath)}{Path.DirectorySeparatorChar}{Path.GetFileNameWithoutExtension(task.FilePath)}";

                    
                    var valid = false;
                    switch (extension)
                    {
                        case ".ph":
                            using (var stream = new FileStream(task.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 1024))
                            {
                                var currentHashFile = Hash.Unpack(stream);
                                valid = Checker.File(baseFile, currentHashFile);
                            }
                            break;
                        case ".md5":
                            hash = Hasher.File(baseFile);
                            valid = hash.Md5 == File.ReadAllText(task.FilePath);
                            break;
                        case ".sha1":
                            hash = Hasher.File(baseFile);
                            valid = hash.Sha1 == File.ReadAllText(task.FilePath);
                            break;
                    }

                    e.Result = valid ? FileTask.Status.Completed : FileTask.Status.Failed;
                    break;
                }
            }
        }

        private void WProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            var task = _tasks.First(t => t.TaskStatus == FileTask.Status.Working);
            task.Progress = e.ProgressPercentage;

            TasksUpdated();
        }

        private void WRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result is not FileTask.Status status)
                return;

            var task = _tasks.First(t => t.TaskStatus == FileTask.Status.Working);
            task.TaskStatus = status;

            TasksUpdated();
            StartWorkIfIdle();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK) return;
            
            foreach (var file in ofd.FileNames)
            {
                var extension = Path.GetExtension(file);
                _tasks.Add(new FileTask(file, (extension != ".ph" && extension != ".md5" && extension != ".sha1") ? FileTask.Type.Hash : FileTask.Type.Verify));
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var aboutBox = new AboutBox();
            
            aboutBox.ShowDialog(this);
        }
    }
}

using System.ComponentModel;

namespace FileHasher.GUI.WinForms
{
    public class FileTask : INotifyPropertyChanged
    {
        private string _filePath;
        private Type _taskType;
        private Status _status = Status.Pending;
        private int _progress = 0;

        public FileTask(string filePath, Type taskType)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            _taskType = taskType;
        }

        public string FilePath
        {
            get => _filePath;
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    OnPropertyChanged(nameof(FilePath));
                }
            }
        }

        public Type TaskType
        {
            get => _taskType;
            set
            {
                if (_taskType != value)
                {
                    _taskType = value;
                    OnPropertyChanged(nameof(TaskType));
                }
            }
        }

        public Status TaskStatus
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(TaskStatus));
                }
            }
        }

        public string TaskStatusString
        {
            get
            {
                if (_status == Status.Working)
                {
                    return $"{_status} ({_progress}%)";
                }

                return _status.ToString();
            }
        }

        public int Progress
        {
            get => _progress;
            set
            {
                if (_progress != value)
                {
                    _progress = value;
                    OnPropertyChanged(nameof(Progress));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public enum Type
        {
            Hash, Verify
        }

        public enum Status
        {
            Pending, Working, Completed, Failed
        }
    }
}

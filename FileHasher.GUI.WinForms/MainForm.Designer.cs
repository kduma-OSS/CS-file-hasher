namespace FileHasher.GUI.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            listView1 = new ListView();
            columnHeaderFileName = new ColumnHeader();
            columnHeaderType = new ColumnHeader();
            columnHeaderProgress = new ColumnHeader();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            toolStripContainer1 = new ToolStripContainer();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            otwórzToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            zakończToolStripMenuItem = new ToolStripMenuItem();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Alignment = ListViewAlignment.Default;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeaderFileName, columnHeaderType, columnHeaderProgress });
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(800, 426);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeaderFileName
            // 
            columnHeaderFileName.Text = "File Name";
            columnHeaderFileName.Width = 300;
            // 
            // columnHeaderType
            // 
            columnHeaderType.Text = "Task Type";
            columnHeaderType.TextAlign = HorizontalAlignment.Center;
            columnHeaderType.Width = 100;
            // 
            // columnHeaderProgress
            // 
            columnHeaderProgress.Text = "Progress";
            columnHeaderProgress.TextAlign = HorizontalAlignment.Center;
            columnHeaderProgress.Width = 100;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += WDoWork;
            backgroundWorker1.ProgressChanged += WProgressChanged;
            backgroundWorker1.RunWorkerCompleted += WRunWorkerCompleted;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(listView1);
            toolStripContainer1.ContentPanel.Size = new Size(800, 426);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(800, 450);
            toolStripContainer1.TabIndex = 1;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(menuStrip1);
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { otwórzToolStripMenuItem, toolStripSeparator2, zakończToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // otwórzToolStripMenuItem
            // 
            otwórzToolStripMenuItem.Image = (Image)resources.GetObject("otwórzToolStripMenuItem.Image");
            otwórzToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            otwórzToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            otwórzToolStripMenuItem.Size = new Size(146, 22);
            otwórzToolStripMenuItem.Text = "&Open";
            otwórzToolStripMenuItem.Click += otwórzToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(143, 6);
            // 
            // zakończToolStripMenuItem
            // 
            zakończToolStripMenuItem.Name = "zakończToolStripMenuItem";
            zakończToolStripMenuItem.Size = new Size(146, 22);
            zakończToolStripMenuItem.Text = "&Exit";
            zakończToolStripMenuItem.Click += zakończToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStripContainer1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "File Hasher";
            Load += FLoad;
            DragDrop += FDragDrop;
            DragEnter += FDragEnter;
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeaderFileName;
        private ColumnHeader columnHeaderType;
        private ColumnHeader columnHeaderProgress;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripContainer toolStripContainer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem otwórzToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem zakończToolStripMenuItem;
    }
}

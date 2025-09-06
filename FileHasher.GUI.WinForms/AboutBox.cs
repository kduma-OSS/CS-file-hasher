using System.Reflection;

namespace FileHasher.GUI.WinForms
{
    internal partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            labelVersion.Text = $@"Version: {FileVersion} ({AssemblyVersion})";
        }

        #region Assembly Attribute Accessors

        private static string? AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        private static string? FileVersion => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;

        #endregion
    }
}

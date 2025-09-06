using System.Reflection;

namespace FileHasher.GUI.WinForms
{
    internal partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            labelVersion.Text = $@"Version: {Version} ({AssemblyVersion})";
        }

        #region Assembly Attribute Accessors

        private static string? AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        private static string? Version => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

        #endregion
    }
}

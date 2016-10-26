using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace MC10Editor
{
    /// <summary>
    /// Interaction logic for ProgressDialog.xaml
    /// </summary>
    public partial class ProgressDialog : MetroWindow
    {
        public ProgressDialog()
        {
            InitializeComponent();
        }

        private void buttonLaunch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("minecraft://");
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show("There was an error while launching Minecraft " + ex.Message, "Cannot launch Minecraft", MessageBoxButton.OK);
                return;
            }
        }

        // Prevent ObjectDisposedEvent
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            e.Cancel = true;
            this.Hide();
        }
    }
}

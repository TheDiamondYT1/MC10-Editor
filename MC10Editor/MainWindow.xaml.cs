using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;
using MC10Editor.Utils;
using System;
using System.IO;
using System.Windows.Controls;

namespace MC10Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        static ProgressDialog p = new ProgressDialog();

        public MainWindow()
        {
            InitializeComponent();

            string[] worldDir = Directory.GetDirectories(Paths.GetWorldsPath());
            foreach (string world in worldDir)
            {
                FileInfo worldInfo = new FileInfo(world);

                try
                {
                    string name = File.ReadAllText(Paths.GetWorldsPath() + worldInfo.Name + "\\levelname.txt");
                    listView.Items.Add(new ListViewItem { Content = name });
                } catch (Exception ex)
                {
                    MessageBox.Show("There was an error while loading worlds: " + ex.Message, "Cannot load worlds", MessageBoxButton.OK);
                }      
            }
        }

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void openMinecraftButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("minecraft://"); // TODO: change to a better solution
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectButton.Content.Equals("Select")) // If we haven't selected the Resource Pack yet
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Select Resource Pack";
                dialog.InitialDirectory = (bool) installCheckbox.IsChecked ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : Paths.GetResourcesPath();
                dialog.DefaultExt = ".zip";
                dialog.Filter = "ZIP Files |*.zip|MCPack Files|*.mcpack|All Files|*.*";

                if(dialog.ShowDialog() == true)
                {
                    textureLocBox.Text = dialog.FileName;
                    selectButton.Content = (bool) installCheckbox.IsChecked ? "Install" : "Export";
                }
            } else if (selectButton.Content.Equals("Install"))
            {
                p.Show();
                try
                {
                    FileInfo fi = new FileInfo(textureLocBox.Text);
                    fi.CopyTo(Paths.GetResourcesPath() + @"\" + Path.GetFileName(textureLocBox.Text), true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while copying the file: " + ex.Message, "Cannot copy file", MessageBoxButton.OK);
                }
                CopyFinished();
            }
        }

        private void CopyFinished()
        {
            p.labelCopying.FontSize = 10;
            p.labelCopying.Content = "Texture installed.";
            p.Title = "Install Success";
            p.buttonLaunch.Visibility = Visibility.Visible;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

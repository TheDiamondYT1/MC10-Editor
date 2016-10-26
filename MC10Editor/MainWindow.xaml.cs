using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;
using MC10Editor.Utils;
using System;

namespace MC10Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
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
                dialog.InitialDirectory = (bool)installCheckbox.IsChecked ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : Paths.GetResourcesPath();
                dialog.DefaultExt = ".zip";
                dialog.Filter = "ZIP Files |*.zip|All Files|*.*";

                var result = dialog.ShowDialog();

                if(result == true)
                {
                    textureLocBox.Text = dialog.FileName;
                    selectButton.Content = (bool) installCheckbox.IsChecked ? "Install" : "Export";
                }
            } else if (selectButton.Content.Equals("Install"))
            {
                
            }
        }
    }
}

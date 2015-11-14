using EncryptAES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EncryptMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes and Properties

        public AESManager Factory { get; set; }

        #endregion

        #region Initialize

        public MainWindow()
        {
            InitializeComponent();
        }

        public void InitializeFactory()
        {
            Factory = new AESManager();
            Factory.Initialize();
        }

        #endregion

        #region Events Catch

        #endregion

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            string password = pbPassword.Password;
            string filePath = tbSource.Text;

            if (this.Factory == null)
                InitializeFactory();
            this.Factory.Password = password;
            this.Factory.FilePath = filePath;
            if (this.Factory.EncryptFile())
                lblResult.Content = "Fichier crypté avec succès !";
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            string password = pbPassword.Password;
            string filePath = tbSource.Text;

            if (this.Factory == null)
                InitializeFactory();
            this.Factory.Password = password;
            this.Factory.FilePath = filePath;

            if (this.Factory.DecryptFile())
                lblResult.Content = "Fichier décrypté avec succès !";
        }

        private void btnPath_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                tbSource.Text = filename;
            }
        }
    }
}

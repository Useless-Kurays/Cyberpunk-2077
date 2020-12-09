using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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


namespace Cyberpunk_2077
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string path = System.IO.Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, "video.mp4");

            FileInfo file = new FileInfo(path);
            using (FileStream stream = new FileStream(file.FullName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite, 4096))
            {
                byte[] bytes = Properties.Resources.Cyberpunk;
                stream.Write(bytes, 0, bytes.Length);
            }

            media.Source = new Uri(path, UriKind.Absolute);
            media.Play();
        }

        private void Media_Ended(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Cannot launch DirectX12!", "Engine Error", MessageBoxButton.OK, MessageBoxImage.Error);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            switch (result)
            {
                case MessageBoxResult.Yes:
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    break;
            }
        }

        
    }
}

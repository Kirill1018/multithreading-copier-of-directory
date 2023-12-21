using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Multithreading_copier_of_directory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string[] file_nam1, file_nam2, file_nam3, file_nam4, file_nam5, file_nam6;
        public static FileInfo info;
        public static OpenFileDialog dialog;
        public static string name;
        public static int read_, length1, length2, length3, length4, length_2, length_3, length_4, length_5;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == true)
            {
                file_nam1 = dialog.FileNames;
                info = new FileInfo(dialog.FileName);
                string dir_source = info.DirectoryName;
                box.Text = dir_source;
            }
        }

        private void button__Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog_ = new Microsoft.Win32.SaveFileDialog();
            dialog_.FileName = file_nam1[0];
            Nullable<bool> dial = dialog_.ShowDialog();
            if (dial == true)
            {
                name = dialog_.FileName;
                info = new FileInfo(dialog_.FileName);
                string name_ = info.DirectoryName;
                box_.Text = name_;
            }
        }
        private void butt_Click(object sender, RoutedEventArgs e)
        {
            length2 = file_nam1.Length / 3;
            length3 = file_nam1.Length % 3;
            file_nam2 = new string[length2];
            file_nam3 = new string[length2];
            file_nam4 = new string[length2];
            file_nam5 = new string[length3];
            for (int i = 0; i < length2; i++) file_nam2[i] = file_nam1[i];
            for (int i = 0; i < length2; i++) file_nam3[i] = file_nam1[i + length2];
            for (int i = 0; i < length2; i++) file_nam4[i] = file_nam1[i + 2 * length2];
            for (int i = 0; i < length3; i++) file_nam5[i] = file_nam1[i + 3 * length3];
            Copy(file_nam2);
            Copy(file_nam3);
            Copy(file_nam4);
            Copy(file_nam5);
        }
        public void Copy(string[] file_nam6)
        {
            if (file_nam6 == file_nam2)
            {
                for (int i = 0; i < length2; i++)
                {
                    using (var input = new FileStream(file_nam2[i], FileMode.Open, FileAccess.Read)) using (var output = new FileStream(System.IO.Path.Combine(box_.Text, System.IO.Path.GetFileName(file_nam2[i])), FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024];
                        int read;
                        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, read);
                            bar1.Value = 100 * read / file_nam2[i].Length;
                            block3.Text = file_nam2[i].ToString();
                            block6.Text = $"{read} / {file_nam2[i].Length} Б";
                            read_ += read;
                            length_2 += file_nam2[i].Length;
                        }
                    }
                }
            }
            else if (file_nam6 == file_nam3)
            {
                for (int i = 0; i < length2; i++)
                {
                    using (var input = new FileStream(file_nam3[i], FileMode.Open, FileAccess.Read)) using (var output = new FileStream(System.IO.Path.Combine(box_.Text, System.IO.Path.GetFileName(file_nam3[i])), FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024];
                        int read;
                        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, read);
                            bar2.Value = 100 * read / file_nam3[i].Length;
                            block4.Text = file_nam3[i].ToString();
                            block7.Text = $"{read} / {file_nam3[i].Length} Б";
                            read_ += read;
                            length_3 += file_nam3[i].Length;
                        }
                    }
                }
            }
            else if (file_nam6 == file_nam4)
            {
                for (int i = 0; i < length2; i++)
                {
                    using (var input = new FileStream(file_nam4[i], FileMode.Open, FileAccess.Read)) using (var output = new FileStream(System.IO.Path.Combine(box_.Text, System.IO.Path.GetFileName(file_nam4[i])), FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024];
                        int read;
                        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, read);
                            bar3.Value = 100 * read / file_nam4[i].Length;
                            block5.Text = file_nam4[i].ToString();
                            block8.Text = $"{read} / {file_nam4[i].Length} Б";
                            read_ += read;
                            length_4 += file_nam4[i].Length;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < length3; i++)
                {
                    using (var input = new FileStream(file_nam5[i], FileMode.Open, FileAccess.Read)) using (var output = new FileStream(System.IO.Path.Combine(box_.Text, System.IO.Path.GetFileName(file_nam5[i])), FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024];
                        int read;
                        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, read);
                            read_ += read;
                            length_5 += file_nam4[i].Length;
                        }
                    }
                }
            }
            length4 = length_2 + length_3 + length_4 + length_5;
            bar4.Value = 100 * read_ / length4;
        }
    }       
}
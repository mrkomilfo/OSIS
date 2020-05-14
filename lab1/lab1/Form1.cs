using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace lab1
{
    public partial class Form1 : Form
    {
        private const string mountDir = "D:\\СП\\lab1\\repo\\";// "D:\\СП\\lab1\\repo\\";

        void showInfo(int tabs, string dirPath)
        {
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo curDir in dirs)
            {               
                for (int i = 0; i < tabs; i++)
                {
                    textBox.Text += "     ";
                }
                textBox.Text += curDir.Name + "\r\n";
                showInfo(tabs+1, Path.Combine(dirPath, curDir.Name));
            }

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo curFile in files)
            {
                for (int i = 0; i < tabs; i++)
                {
                    textBox.Text += "     ";
                }
                textBox.Text += curFile.Name + "\r\n";
            }
        }

        void showDir()
        {
            listBox.Items.Clear();
            DirectoryInfo dir = null;
            try
            {
                dir = new DirectoryInfo(mountDir + pathBox.Text);
            }
            catch (ArgumentException)
            {
                wrongPathError();
                return;
            }
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo curDir in dirs)
            {
                listBox.Items.Add(curDir);
            }

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo curFile in files)
            {
                listBox.Items.Add(curFile);
            }
        }

        void wrongPathError()
        {
            MessageBox.Show("Указан неверный путь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public Form1()
        {
            InitializeComponent();
            showDir();
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(mountDir, pathBox.Text, listBox.SelectedItem.ToString());
            string newName = Interaction.InputBox("Укажите новое название", "Переименование", "", -1, -1);

            if (Path.GetExtension(path) == "" && (!newName.Contains('.') || newName[0] == '.'))
            {
                Directory.Move(path, Path.Combine(mountDir, pathBox.Text, newName));
            }
            else if (Path.GetExtension(path) != "" && newName.Contains('.') && newName[0] != '.')
            {
                File.Move(path,  Path.Combine(mountDir, pathBox.Text, newName));
            }
            showDir();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (pathBox.Text.Length == 0)
            {
                return;
            }
            if (pathBox.Text[pathBox.Text.Length - 1] == '\\')
            {
                pathBox.Text = pathBox.Text.Remove(pathBox.Text.Length - 1, 1);               
            }
            while (pathBox.Text.Length != 0 && pathBox.Text[pathBox.Text.Length - 1] != '\\')
            {
                pathBox.Text = pathBox.Text.Remove(pathBox.Text.Length - 1, 1);
            }
            showDir();
        }   

        private void createButton_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Укажите название нового файла/директории", "Создание", "", -1,-1);
            if (name.Contains('.') && name[0] != '.')
            {
                FileInfo file = new FileInfo(Path.Combine(mountDir, pathBox.Text, name));
                file.Create();
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(Path.Combine(mountDir, pathBox.Text, name));
                dir.Create();
            }
            showDir();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string path = Interaction.InputBox("Укажите путь файла", "Добавление файла", "", -1, -1);
            if (Path.GetExtension(path) != "")
            {
                FileInfo file = new FileInfo(path);
                file.CopyTo(Path.Combine(mountDir, pathBox.Text));
                showDir();
            }
            else
            {
                wrongPathError();
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            showDir();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            showDir();
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(mountDir, pathBox.Text, listBox.SelectedItem.ToString());
            string newPath = Interaction.InputBox("Укажите путь для перемещения", "Перемещение", "", -1, -1);

            if (Path.GetExtension(path) == "" && Path.GetExtension(newPath) == "")
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                dir.MoveTo(Path.Combine(mountDir, newPath, listBox.SelectedItem.ToString()));
            }
            else if (Path.GetExtension(path) != "" && Path.GetExtension(newPath) == "")
            {
                FileInfo file = new FileInfo(path);
                file.MoveTo(Path.Combine(mountDir, newPath, listBox.SelectedItem.ToString()));
            }
            showDir();
        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Path.GetExtension(Path.Combine(mountDir, pathBox.Text, listBox.SelectedItem.ToString())) == "")
            {
                pathBox.Text = Path.Combine(pathBox.Text, listBox.SelectedItem.ToString());
                showDir();
            }
            else
            {
                Process.Start(Path.Combine(mountDir, pathBox.Text, listBox.SelectedItem.ToString()));
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            showInfo(0, mountDir);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(mountDir, pathBox.Text, listBox.SelectedItem.ToString());
            if (Path.GetExtension(path) == "")
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                dir.Delete(true);
            }
            else if (Path.GetExtension(path) != "")
            {
                FileInfo file = new FileInfo(path);
                file.Delete();
            }
            showDir();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(mountDir, pathBox.Text, listBox.SelectedItem.ToString());
            string newPath = Interaction.InputBox("Укажите путь для копирования", "Копирование файла", "", -1, -1);

            if (Path.GetExtension(path) != "" && Path.GetExtension(newPath) == "")
            {
                FileInfo file = new FileInfo(path);
                file.CopyTo(Path.Combine(mountDir, newPath, listBox.SelectedItem.ToString()), true);
            }
            showDir();
        }
    }
}

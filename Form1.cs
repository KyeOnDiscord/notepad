using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace NotepadRecreation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.ShowDialog();
            try
            {
                textBox1.Text = File.ReadAllText(a.FileName);
            }
            catch
            {}
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Assembly.GetEntryAssembly().Location);
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.WordWrap == false)
            {
                textBox1.WordWrap = true;
            }
            else
            {
                textBox1.WordWrap = false;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog a = new FontDialog();
            a.ShowDialog();
            textBox1.Font = a.Font;
            Properties.Settings.Default.font = a.Font;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Font = Properties.Settings.Default.font;
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://go.microsoft.com/fwlink/?LinkId=834783");
        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notepad is already perfect as it is, no need for feedback :)", "Notepad");
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ProMasterBoy/notepad");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button actually suppose to do something?");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog a = new SaveFileDialog();
            a.Filter = "Text Documents (*.txt)|*.txt|All files (*.*)|*.*";
            a.DefaultExt = "txt";
            a.ShowDialog();
            if (a.FileName != "")
            {
                using (StreamWriter aaa = new StreamWriter(a.FileName))
                {
                    aaa.Write(textBox1.Text);
                }
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using laba1lib;
using System.Diagnostics;
namespace laba1form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Form1 curform;
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private static String basepath = @"D:\University\3course\5semester\SPP\labs\laba1\textfiles\";
        private static Stopwatch stopWatch = new Stopwatch();
        public static void LogTime(string message)
        {
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            curform.richTextBox1.Text += Environment.NewLine + message +" "+ elapsedTime;
            curform.richTextBox1.Update();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    long lines = Convert.ToInt64(numericUpDown1.Value);
                    String path = saveFileDialog1.FileName;
                    LogTime("Starting generation");
                    stopWatch.Restart();
                    Generator.Generate(lines, path);
                    LogTime("Generation complete");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            curform = (Form1)Form.ActiveForm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String path = openFileDialog1.FileName;
                    stopWatch.Restart();
                    LogTime("Starting splitting and sorting");
                    List<String> filenames = Sorter.SplitAndSort(path, basepath);
                    LogTime("Merge started");
                    Sorter.MergeSortedFiles(filenames, path + "1");
                    LogTime("File merge completed");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
    }
}

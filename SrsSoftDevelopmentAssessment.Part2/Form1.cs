using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace SrsSoftDevelopmentAssessment.Part2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBox1.Text = dialog.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please select a starting folder.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please select a searching phrase.");
                return;
            }

            PerformSearch();
        }

        private void PerformSearch()
        {
            new Thread(() =>
            {
                foreach (string fileName in Directory.GetFiles(textBox1.Text, "*.txt", checkBox1.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
                {
                    // TODO: change to support case insensitive searching
                    if (File.ReadAllText(fileName).Contains(textBox2.Text))
                    {
                        dataGridView1.Invoke(new Action(() =>
                        {
                            dataGridView1.Rows.Add(fileName);
                        }));
                    }
                }
            }).Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_WF_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            //labelOutput.Text = textBoxInput.Text;
            labelOutput.ForeColor = Color.Aqua;
            //или можно задать цвет:
            //var color = new Color();
            //color = Color.FromArgb(255, 0, 255, 0);
            //labelOutput.ForeColor = color;
            //labelOutput.Text = (Math.Pow(Convert.ToInt32(textBoxInput.Text), 2)).ToString();
            
            try
            {
                var number = Convert.ToInt32(textBoxInput.Text);
                Math.Pow(number, 2);
                var result = Math.Pow(number, 2).ToString();
                labelOutput.Text = result;  
            }
            catch
            {
                var messange = "Не удалось преобразовать в число";
                MessageBox.Show(messange);    
                labelOutput.Text = messange;
            }     
        }

        private void btnOpen_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "Текстовые (шаблон *.txt)|*.txt" +
                "|Исходники (шаблон *.cs)|*.cs" +
                "|Все (шаблон *.*)|*.*";
            var result = openFileDialog.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    richTextViewer.Text = sr.ReadToEnd();
                }                    
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace OOPlab4._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, 
            EventArgs e)
        {
            if (numericUpDown1.Value > 10)
                numericUpDown1.Value = 10;
            if (numericUpDown1.Value == 0)
                numericUpDown1.Value = 1;
            trackBar1.Value = (Int32)numericUpDown1.Value - 1;
            textBox1.Text = trackBar1.Value.ToString();
            richTextBox1.Text = textBox1.Text;
            comboBox1.SelectedIndex = trackBar1.Value;
            button1.Text = (trackBar1.Value + 1).ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            richTextBox1.Text = textBox1.Text;
            numericUpDown1.Value = trackBar1.Value + 1;
            comboBox1.SelectedIndex = trackBar1.Value;
            button1.Text = (trackBar1.Value + 1).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, 
            EventArgs e)
        {
            trackBar1.Value = comboBox1.SelectedIndex;
            textBox1.Text = trackBar1.Value.ToString();
            richTextBox1.Text = textBox1.Text;
            numericUpDown1.Value = trackBar1.Value + 1;
            button1.Text = (trackBar1.Value + 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value < 9)
                trackBar1.Value++;
            else
                trackBar1.Value = 0;
            textBox1.Text = trackBar1.Value.ToString();
            richTextBox1.Text = textBox1.Text;
            numericUpDown1.Value = trackBar1.Value + 1;
            comboBox1.SelectedIndex = trackBar1.Value;
        }

        private void richTextBox1_KeyDown(object sender, 
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (Int32.Parse(richTextBox1.Text) > 9)
                    {
                        trackBar1.Value = 9;
                        richTextBox1.Text = "9";
                    }
                    else if (Int32.Parse(richTextBox1.Text) < 0)
                    {
                        richTextBox1.Text = "0";
                        trackBar1.Value = 0;
                    }
                    else
                        trackBar1.Value = 
                            Int32.Parse(richTextBox1.Text);
                }
                catch (FormatException)
                {
                    richTextBox1.Text = "0";
                    trackBar1.Value = 0;
                }
                textBox1.Text = trackBar1.Value.ToString();
                numericUpDown1.Value = trackBar1.Value + 1;
                comboBox1.SelectedIndex = trackBar1.Value;
                button1.Text = (trackBar1.Value + 1).ToString();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (Int32.Parse(textBox1.Text) > 9)
                    {
                        trackBar1.Value = 9;
                        textBox1.Text = "9";
                    }
                    else if (Int32.Parse(textBox1.Text) < 0)
                    {
                        textBox1.Text = "0";
                        trackBar1.Value = 0;
                    }
                    else
                        trackBar1.Value = Int32.Parse(textBox1.Text);
                }
                catch (FormatException)
                {
                    textBox1.Text = "0";
                    trackBar1.Value = 0;
                }
                richTextBox1.Text = trackBar1.Value.ToString();
                numericUpDown1.Value = trackBar1.Value + 1;
                comboBox1.SelectedIndex = trackBar1.Value;
                button1.Text = (trackBar1.Value + 1).ToString();
            }
        }

        private Form Form2;
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 = new Form2();
            this.Hide();
            Form2.ShowDialog();
            this.Close();
        }
    }
}

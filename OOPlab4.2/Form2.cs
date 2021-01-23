using System;
using System.Windows.Forms;

namespace OOPlab4._2
{
    public partial class Form2 : Form
    {
        private Model m;

        public Form2()
        {
            InitializeComponent();

            m = new Model();
            m.observers += new System.EventHandler
                (this.UpdateFromModel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ++m.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            m.Value = trackBar1.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, 
            EventArgs e)
        {
            m.Value = (Int32)numericUpDown1.Value - 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, 
            EventArgs e)
        {
            m.Value = comboBox1.SelectedIndex;
        }

        private void richTextBox1_KeyDown(object sender, 
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    m.Value = Int32.Parse(richTextBox1.Text);
                }
                catch (FormatException)
                {
                    m.Value = 0;
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    m.Value = Int32.Parse(textBox1.Text);
                }
                catch (FormatException)
                {
                    m.Value = 0;
                }
            }
        }

        private void UpdateFromModel(object sender, EventArgs e)
        {
            richTextBox1.Text = m.Value.ToString();
            textBox1.Text = m.Value.ToString();
            trackBar1.Value = m.Value;
            numericUpDown1.Value = m.Value + 1;
            comboBox1.SelectedIndex = m.Value;
            button1.Text = (m.Value + 1).ToString();
        }

    }

    public class Model
    {
        private int value;

        public System.EventHandler observers;

        public int Value
        {
            get => value;
            set
            {
                if (value > 9)
                    this.value = 9;
                else if (value < 0)
                    this.value = 0;
                else
                    this.value = value;
                observers.Invoke(this, null);
            }
        }
    }
}

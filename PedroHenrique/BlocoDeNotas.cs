using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedroHenrique
{
    public partial class BlocoDeNotas : Form
    {
        public BlocoDeNotas()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Arquivo txt |*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader leitor = new System.IO.StreamReader(openFileDialog1.FileName);
                richTextBox1.Text = leitor.ReadToEnd();
                leitor.Close();

            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Salvar Como";
            saveFileDialog1.InitialDirectory = "C\\";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Arquivo |*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) ;
            {
                System.IO.StreamWriter gravar = new System.IO.StreamWriter(saveFileDialog1.FileName);
                gravar.Write(richTextBox1.Text);
                gravar.Close();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectedText == "")
            {
                MessageBox.Show("Selecione o texto");
            }
            else
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Clipboard.GetText();
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }
    }
}

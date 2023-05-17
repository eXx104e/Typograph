using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typograph
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMessage.Text.Equals(""))
            {
                buttonPrint.Enabled = false;
                buttonCopy.Enabled = false;
            }
            else
            {
                buttonPrint.Enabled = true;
                buttonCopy.Enabled = true;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            buttonPrint.Enabled = false;
            buttonCopy.Enabled = false;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы точно хотите оттипографировать текст?", "Подтверждение", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                string tempString = textBoxMessage.Text;


                //tempString = TypografMethods.CorrectPlusMinusSign(tempString);
                tempString = TypographMethods.CanNotUseHyphenInTheDigitalRange(tempString);
                //tempString = TypografMethods.CorrectEllipsisSymbol(tempString);
                tempString = TypographMethods.ReplacingProgrammaticQuotesWithRegularOnes(tempString);

                //tempString = TypografMethods.ReverseWordsInSentence(tempString);
                //tempString = TypografMethods.SpecialWordElephant(tempString);

                textBoxMessage.Text = tempString;
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxMessage.Text);

            MessageBox.Show("Текст скопирован");
        }
    }
}

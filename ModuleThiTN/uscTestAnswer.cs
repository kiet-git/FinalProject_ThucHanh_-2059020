using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModuleSoanDe;

namespace ModuleThiTN
{
    public partial class uscTestAnswer : UserControl
    {
        Question question;

        public delegate void uscTestAnswer_CheckedHandler();
        public event uscTestAnswer_CheckedHandler uscTestAnswer_Checked;

        public uscTestAnswer(Question q)
        {
            InitializeComponent();

            setQuestion(q);
        }

        public void setQuestion(Question q)
        {
            question = q;

            panelAnswer.SetAutoScrollMargin(0, 10 * question.AnswerCollection.Size);
            panelAnswer.Controls.Clear();

            int xPos = 13;
            int yPos = 12;
            for (int i = 0; i < question.AnswerCollection.Size; i++)
            {
                RadioButton radio = new RadioButton()
                {
                    Text = question.AnswerCollection.getAnswer(i)
                };
                radio.Name = $"{i}";
                radio.AutoSize = true;
                radio.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                radio.Location = new Point(xPos, yPos);
                radio.CheckedChanged += radio_CheckedChanged;

                if(question.ChosenIndex == i)
                {
                    radio.Checked = true;
                }

                panelAnswer.Controls.Add(radio);
                yPos += 30;
            }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            if(r.Checked == true)
            {
                uscTestAnswer_Checked();
                question.ChosenIndex = int.Parse(r.Name);
            }
        }
    }
}

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

        public uscTestAnswer(Question q)
        {
            InitializeComponent();

            setQuestion(q);
        }

        public void setQuestion(Question q)
        {
            question = q;

            panelAnswer.SetAutoScrollMargin(0, 20 * question.AnswerCollection.Size);
            panelAnswer.Controls.Clear();

            int xPos = 13;
            int yPos = 12;
            foreach (var a in question.AnswerCollection.ListOfAnswers)
            {
                RadioButton radio = new RadioButton()
                {
                    Text = a.Answer
                };
                radio.AutoSize = true;
                radio.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                radio.Location = new Point(xPos, yPos);
                panelAnswer.Controls.Add(radio);
                yPos += 30;
            }
        }
    }
}

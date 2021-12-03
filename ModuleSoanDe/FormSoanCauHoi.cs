using System;
using System.IO;
using System.Windows.Forms;

namespace ModuleSoanDe
{
    public partial class FormSoanCauHoi : Form
    {
        QuestionCollection questionCollection = new QuestionCollection(new NormalXMLExecuter());

        string defaultPath = @"dataQuestion.xml";

        int selectedIndex = -1;
        bool isSaved = true;

        public FormSoanCauHoi()
        {
            InitializeComponent();
            questionCollection.readXML(defaultPath);
            questionCollection.setDatasource(listBoxQuestions);
        }

        private void btnAddQ_Click(object sender, EventArgs e)
        {
            questionCollection.addQuestion();
            listBoxQuestions.SelectedIndex = -1;
            isSaved = false;
        }

        private void btnUpdateQ_Click(object sender, EventArgs e)
        {
            if(selectedIndex > -1)
            {
                questionCollection.updateQuestion(selectedIndex);
                isSaved = false;
            }
        }

        private void btnDeleteQ_Click(object sender, EventArgs e)
        {
            if(selectedIndex > -1)
            {
                questionCollection.deleteQuestion(selectedIndex);
                listBoxQuestions.SelectedIndex = -1;
                isSaved = false;
            }
        }

        private void listBoxQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = listBoxQuestions.SelectedIndex;
        }

        private void writeToXML()
        {
            if (isSaved || questionCollection.Size == 0)
            {
                return;
            }

            questionCollection.writeToXML(defaultPath);

            MessageBox.Show(
                 "Your data is saved successfully",
                 "Information!",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information);

            isSaved = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {  
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            writeToXML();
        }

        private void FormSoanCauHoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
               "Do you want to save your data?",
               "Information!",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                writeToXML();
            }
        }
    }
}

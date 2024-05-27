using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_TheroyTest
{
    public partial class CtrlQuestion : UserControl
    {
        private clsTheoryTestQuestion _Question;
        private bool _IsAnswerChosen = false;
        private RadioButton _CurrentlyCheckedRB;
      
        public delegate void AnswerChosenEventHandler(object sender);
        public AnswerChosenEventHandler AnswerChosen;

        public delegate void AnswerClearedEventHandler(object sender);
        public AnswerChosenEventHandler AnswerCleared;
        public clsTheoryTestQuestion Question { get { return _Question; } } 
        public bool IsCorrectAnswerChecked {  get { return _CurrentlyCheckedRB != null ? (_CurrentlyCheckedRB.Tag != null) : false; } }
        
       
        public CtrlQuestion()
        {
            InitializeComponent();
        }

        private void _UpdateCorrectRadioBtnAnswerTag()
        {
            switch (_Question.NumberOfCorrectAnswer)
            {
                case 1:
                    rbAnswer1.Tag = "Correct";
                    break;

                case 2:
                    rbAnswer2.Tag = "Correct";
                    break;

                case 3:
                    rbAnswer3.Tag = "Correct";
                    break;
            }
        }

        public void FillInfo(int QuestionID)
        {
            _Question = clsTheoryTestQuestion.GetQuestion(QuestionID);

            if (_Question != null)
            {
                lblQuestionText.Text = _Question.QuestionText;
                rbAnswer1.Text = _Question.Answer1;
                rbAnswer2.Text = _Question.Answer2;
                rbAnswer3.Text = _Question.Answer3;

                _UpdateCorrectRadioBtnAnswerTag();
            }
            else
            {
                MessageBox.Show("Error in fetching question", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadImage(string ImagePath)
        {
            pbQuestionImage.Location = new Point(lblQuestionText.Right + 5, pbQuestionImage.Location.Y);
            pbQuestionImage.Visible = true;
            pbQuestionImage.ImageLocation = ImagePath;
        }

        private void rbAnswer_CheckedChanged(object sender, EventArgs e)
        {
            if (!_IsAnswerChosen)
            {
                _IsAnswerChosen = true;
                AnswerChosen?.Invoke(this);
            }

            _CurrentlyCheckedRB = sender as RadioButton;
        }

        private void btnClearAnswer_Click(object sender, EventArgs e)
        {
            if (_CurrentlyCheckedRB == null)
                return;

            _CurrentlyCheckedRB.Checked = false;
            _CurrentlyCheckedRB = null;
            _IsAnswerChosen = false;
            AnswerCleared?.Invoke(this);
        }
    }
}

using DVLD_Business;
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

namespace DVLD_TheroyTest
{
    public partial class frmTheoryTest : Form
    {
        private int AppointmentID;
        private int[] QuestionsIDs;
        private Button CurrentActiveQuestionBtn;
        private CtrlQuestion[] CtrlsQuestions;
        private CtrlQuestion CurrentShownCtrl;
        private int RemainingMinutes;
        private int RemainingSeconds;
        private bool DidTimeEnd = false;
        private readonly Color DarkBlue = Color.FromArgb(0, 20, 55);
        public frmTheoryTest(int AppointmentID)
        {
            InitializeComponent();

            this.AppointmentID = AppointmentID;
        }

        private void ActivateBtn(Button btn)
        {
            btn.ForeColor = Color.Orange;
            CurrentActiveQuestionBtn = btn;
        }

        private void DeactivateBtn(Button btn)
        {
            btn.ForeColor = Color.Gainsboro;
        }

        private void CreateQuestionsBtns(int NumberOfQuestions)
        {
            int xAxisIncrement = 0;

            for (int i = 1; i <= NumberOfQuestions; i++)
            {
                Button btn = new Button();
                pnlQuestionsBtns.Controls.Add(btn);
                btn.Size = new Size(37, 33);
                btn.BackColor = DarkBlue;
                btn.ForeColor = Color.Gainsboro;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.Black;
                btn.Location = new Point(12 + xAxisIncrement, 47);
                btn.Font  = new Font(btn.Font.FontFamily, 12);
                btn.Text = i.ToString();
                btn.TabIndex = i - 1;
                btn.Name = $"btnQuestion{i}";
                btn.Tag = i;
                btn.Click += btnQuestion_Click;
                xAxisIncrement += 78;
            }
        }

        private void CreateAndShowNewQuestionControl(int QuestionNumber)
        {
            CtrlQuestion Ctrl = new CtrlQuestion();

            Ctrl.FillInfo(QuestionsIDs[QuestionNumber - 1]);
            Ctrl.Name = $"CtrlQuestion{QuestionNumber}";
            Ctrl.Visible = false;
            pnlQuestion.Controls.Add(Ctrl);
            Ctrl.Location = new Point(0, 3);
            Ctrl.Visible = true;
            Ctrl.AnswerChosen += AnswerChosen;
            Ctrl.AnswerCleared += AnswerCleared;
            CurrentShownCtrl = Ctrl;

            if (Ctrl.Question.ImagePath != null)
            {
                string ImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Ctrl.Question.ImagePath);

                if (File.Exists(ImagePath))
                {
                    Ctrl.LoadImage(ImagePath);
                }
                else
                {
                    MessageBox.Show("Image not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            CtrlsQuestions[QuestionNumber - 1] = Ctrl;
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {   
            if (AppointmentID == -1)
            {
                MessageBox.Show("Invalid appointment ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblHiPerson.Text = $"Hi {clsGlobal.LogedPerson.FirstName} {clsGlobal.LogedPerson.LastName}";
            QuestionsIDs = clsTheoryTestQuestion.GetAllQuestionsIDs();

            if (QuestionsIDs.Length == 0)
            {
                MessageBox.Show("No questions to show", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CtrlsQuestions = new CtrlQuestion[QuestionsIDs.Length];
            CreateQuestionsBtns(QuestionsIDs.Length);
            ActivateBtn(pnlQuestionsBtns.Controls["btnQuestion1"] as Button);
            CreateAndShowNewQuestionControl(1);

            RemainingMinutes = 40;
            RemainingSeconds = 0;

            string Minutes = (RemainingMinutes >= 10 ? RemainingMinutes.ToString() : $"0{RemainingMinutes}");
            lblTimer.Text = $"{Minutes}:{RemainingSeconds}0";
        }

        private void btnQuestion_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;
            int BtnTag = Convert.ToInt32(Btn.Tag);

            if (Btn == CurrentActiveQuestionBtn)
                return;

            DeactivateBtn(CurrentActiveQuestionBtn);
            ActivateBtn(Btn);

            CurrentShownCtrl.Visible = false;
            
            if (CtrlsQuestions[BtnTag - 1] != null)
            {
                CtrlsQuestions[BtnTag - 1].Visible = true;
                CurrentShownCtrl = CtrlsQuestions[BtnTag - 1];
            }
            else
            {
                CreateAndShowNewQuestionControl(BtnTag);
            }

          
            if (BtnTag == QuestionsIDs.Length)
                btnNext.Enabled = false;
            else if (!btnNext.Enabled)
                btnNext.Enabled = true;

            if (BtnTag == 1)
                btnPrevious.Enabled = false;
            else if (!btnPrevious.Enabled)
                btnPrevious.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int NumberOfNextBtn = Convert.ToInt32(CurrentActiveQuestionBtn.Tag) + 1;
            Button NextBtn = (Button)pnlQuestionsBtns.Controls[$"btnQuestion{NumberOfNextBtn}"];
            NextBtn.PerformClick();     
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int NumberOfPreviousBtn = Convert.ToInt32(CurrentActiveQuestionBtn.Tag) - 1;
            Button PreviousBtn = (Button)pnlQuestionsBtns.Controls[$"btnQuestion{NumberOfPreviousBtn}"];
            PreviousBtn.PerformClick();          
        }

        private void AnswerChosen(object sender)
        {
            CurrentActiveQuestionBtn.BackColor = Color.Green;
        }

        private void AnswerCleared(object sender)
        {
            CurrentActiveQuestionBtn.BackColor = DarkBlue;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (!DidTimeEnd)
            {
                if (MessageBox.Show("Are you sure you want to submit?. You can not return to the test after submitting.", "Confirmation",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }

            int Score = 0;

            foreach (CtrlQuestion CtrlQu in CtrlsQuestions)
            {
                if (CtrlQu == null)
                    continue;

                if (CtrlQu.IsCorrectAnswerChecked)
                    Score++;
            }

            clsTakenTheoryTest TakenTest = new clsTakenTheoryTest
            {
                AppointmentID = AppointmentID,
                Result = clsTakenTheoryTest.IsGradePass(Score, QuestionsIDs.Length),
                Grade = Score,
                CreatedByUserID = null
            };

            if (TakenTest.Save())
            {
                MessageBox.Show("Test submitted successfully", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RemainingSeconds--;

            if (RemainingSeconds == -1)
            {
                RemainingMinutes--;
                RemainingSeconds = 59;
            }

            string Minutes = (RemainingMinutes >= 10 ? RemainingMinutes.ToString() : $"0{RemainingMinutes}");
            string Seconds = (RemainingSeconds >= 10 ? RemainingSeconds.ToString() : $"0{RemainingSeconds}");

            lblTimer.Text = $"{Minutes}:{Seconds}";

            if (RemainingMinutes == 0 && RemainingSeconds == 0)
            {
                timer1.Stop();
                DidTimeEnd = true;
                btnFinish_Click(null, null);
            }
        }
    }
}

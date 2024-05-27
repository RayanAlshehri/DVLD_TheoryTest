using CommonClasses;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_TheroyTest
{
    public partial class frmAvailableTest : Form
    {
        CtrlTestInformation CtrlShownTestInfo;
        bool FormClosedByBackBtn = false;
        public frmAvailableTest()
        {
            InitializeComponent();
        }

        private void frmAvailableTest_Load(object sender, EventArgs e)
        {
            lblNoTests.Visible = false;
            lblLogedPersonName.Text = "Welcome " + clsGlobal.LogedPerson.FirstName + " " + clsGlobal.LogedPerson.LastName;

            int TestAppointmentID = clsGlobal.LogedPerson.GetTodayUpcomingTheoryTestAppointmentIDForPerson();

            if (TestAppointmentID != -1)
            {
                CtrlTestInformation TestInfo = new CtrlTestInformation();

                TestInfo.FillInfo(TestAppointmentID);
                TestInfo.Visible = false;
                this.Controls.Add(TestInfo);
                TestInfo.Location = new Point(clsDesign.GetControlXcenterPosition(ClientSize.Width, TestInfo.Width), 180);
                TestInfo.Visible = true;
                TestInfo.TakeTestClick += TakeTest_Click;
                CtrlShownTestInfo = TestInfo;
            }
            else
            {
                lblNoTests.Visible = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(CtrlShownTestInfo);
            frmAvailableTest_Load(null, null);
        }

        private void TakeTest_Click(object sender, CtrlTestInformation.TakeTestClickEventArgs e)
        {
            clsTestAppoinment Appointment = clsTestAppoinment.Find(e.AppointmentID);

            if (Appointment.Save())
            {
                frmTheoryTest frm = new frmTheoryTest(e.AppointmentID);
                frm.ShowDialog();
                this.Controls.Remove(CtrlShownTestInfo);
                frmAvailableTest_Load(null, null);
            }
            else
            {
                MessageBox.Show("Error in taking test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAvailableTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!FormClosedByBackBtn)
                Environment.Exit(0);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormClosedByBackBtn = true;
            Close();

            frmLogin frm = new frmLogin();
            frm.Show();
        }
    }
}

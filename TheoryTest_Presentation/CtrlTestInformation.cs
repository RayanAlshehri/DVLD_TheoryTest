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
using CommonClasses;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;


namespace DVLD_TheroyTest
{
    public partial class CtrlTestInformation : UserControl
    {
        private clsTestAppoinment _Appointment;
        public class TakeTestClickEventArgs : EventArgs
        { 
            public int AppointmentID { get; }
            public TakeTestClickEventArgs(int AppointmentID)
            {
                this.AppointmentID = AppointmentID;
            }
        }

        public event EventHandler<TakeTestClickEventArgs> TakeTestClick;
        public CtrlTestInformation()
        {
            InitializeComponent();
        }

        private string GetStatus()
        {
            return _Appointment.TestDate > DateTime.Now ? $"Unavailable" : "Available";
        }

        public void FillInfo(int TestAppointmentID)
        {
            _Appointment = clsTestAppoinment.Find(TestAppointmentID);

            if (_Appointment != null )
            {
                lblLicenseClass.Text = _Appointment.LocalLicenseApplication.LicenseClassInfo.Name;
                lblNumberOfQuestions.Text = clsTheoryTestQuestion.GetNumberOfQuestions().ToString();
                lblTestDateTime.Text = clsUtility.FormatDateToDMYHM(_Appointment.TestDate);
                lblStatus.Text = GetStatus();
                
                btnTakeTest.Enabled = _Appointment.TestDate.Subtract(DateTime.Now).TotalMinutes <= 0;
            }
            else
            {
                MessageBox.Show("Test appointment not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTakeTest_Click(object sender, EventArgs e)
        {
            TakeTestClick?.Invoke(this, new TakeTestClickEventArgs(_Appointment.ID));
        }
    }
}

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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void tbNationalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b');
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNationalNumber.Text))
            {
                MessageBox.Show("Enter national number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsPerson Person = clsPerson.Find(tbNationalNumber.Text.Trim());

            if (Person == null)
            {
                MessageBox.Show("Invalid national number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsGlobal.LogedPerson = Person;
            frmAvailableTest frm = new frmAvailableTest();

            this.Hide();
            frm.Show();

            tbNationalNumber.Clear();
        }
    }
}

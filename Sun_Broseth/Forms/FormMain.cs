using Sun_Broseth.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sun_Broseth
{
    public partial class FormMain : Form
    {
        FormCustomer formCustomer;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void mCustomerList_Click(object sender, EventArgs e)
        {
            if (formCustomer == null)
            {
                formCustomer = new FormCustomer(this);
                formCustomer.TopLevel = false;

                formCustomer.FormBorderStyle = FormBorderStyle.None;
                formCustomer.Dock = DockStyle.Fill;

                pnMain.Controls.Add(formCustomer);
                formCustomer.Show();
                formCustomer.BringToFront();
            }
            else
            {
                formCustomer.BringToFront();
            }
        }

        private void mCustomerList_MouseEnter(object sender, EventArgs e)
        {
            mCustomerList.BackColor = Color.Black;
            lblCustomerList.ForeColor = Color.White;
        }
        private void mCustomerList_MouseLeave(object sender, EventArgs e)
        {
            mCustomerList.BackColor = Color.Gainsboro;
            lblCustomerList.ForeColor = Color.Black;
        }

        private void mDashboard_Click(object sender, EventArgs e)
        {
            mDashboard.BackColor = Color.Black;
            lblDashboard.ForeColor = Color.White;
        }

        private void mDashboard_MouseLeave(object sender, EventArgs e)
        {
            mDashboard.BackColor = Color.Gainsboro;
            lblDashboard.ForeColor = Color.Black;
        }

        private void mDashboard_MouseEnter(object sender, EventArgs e)
        {
            mDashboard.BackColor = Color.Black;
            lblDashboard.ForeColor = Color.White;
        }

        private void mCreditOfficer_Click(object sender, EventArgs e)
        {
            mCreditOfficer.BackColor = Color.Black;
            lblCreditOfficer.ForeColor = Color.White;
        }

        private void mCreditOfficer_MouseEnter(object sender, EventArgs e)
        {
            mCreditOfficer.BackColor = Color.Black;
            lblCreditOfficer.ForeColor = Color.White;
        }

        private void mCreditOfficer_MouseLeave(object sender, EventArgs e)
        {
            mCreditOfficer.BackColor = Color.Gainsboro;
            lblCreditOfficer.ForeColor = Color.Black;
        }

        private void mCollateral_Click(object sender, EventArgs e)
        {
            mCollateral.BackColor = Color.Black;
            lblCollateral.ForeColor = Color.White;
        }

        private void mCollateral_MouseLeave(object sender, EventArgs e)
        {
            mCollateral.BackColor = Color.Gainsboro;
            lblCollateral.ForeColor = Color.Black;
        }

        private void mCollateral_MouseEnter(object sender, EventArgs e)
        {
            mCollateral.BackColor = Color.Black;
            lblCollateral.ForeColor = Color.White;
        }

        private void mLoan_Click(object sender, EventArgs e)
        {
            mLoan.BackColor = Color.Black;
            lblLoan.ForeColor = Color.White;
        }

        private void mLoan_MouseEnter(object sender, EventArgs e)
        {
            mLoan.BackColor = Color.Black;
            lblLoan.ForeColor = Color.White;
        }

        private void mLoan_MouseLeave(object sender, EventArgs e)
        {
            mLoan.BackColor = Color.Gainsboro;
            lblLoan.ForeColor = Color.Black;
        }

        private void mUserManagement_Click(object sender, EventArgs e)
        {
            mUserManagement.BackColor = Color.Black;
            lblUserManagement.ForeColor = Color.White;
        }

        private void mUserManagement_MouseLeave(object sender, EventArgs e)
        {
            mUserManagement.BackColor = Color.Gainsboro;
            lblUserManagement.ForeColor = Color.Black;
        }

        private void mUserManagement_MouseEnter(object sender, EventArgs e)
        {
            mUserManagement.BackColor = Color.Black;
            lblUserManagement.ForeColor = Color.White;
        }
    }
}

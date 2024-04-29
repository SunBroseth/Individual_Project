using Sun_Broseth.Data;
using Sun_Broseth.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sun_Broseth.Forms
{
    public partial class FormCustomerAddEdit : Form
    {
        Customer _customer;
        bool newcustomer;
        public FormCustomerAddEdit(Customer customer)
        {
            InitializeComponent();
            cboSex.Items.Add("M");
            cboSex.Items.Add("F");
            cboSex.SelectedIndex = 0;
            if (customer == null)
            {
                this._customer = new Customer();
                lblTitle.Text = "New Customer";
                this.newcustomer = true;
                txtCustomerName.Focus();
            }
            else
            {
                this._customer = customer;
                this.newcustomer = false;
                lblTitle.Text = "Edit Customer";
                InitializeData();
            }
        }
        void InitializeData()
        {
            txtCustomerName.Text = _customer.CustomerName;
            cboSex.Text = _customer.Sex.ToString();
            dtpDOB.Text = _customer.DOB.ToString();
            txtPOB.Text = _customer.POB;
            txtPhone.Text = _customer.Phone;
            txtEmail.Text = _customer.Email;
        }
        private bool DoValidation()
        {
            bool result = true;
            if (txtCustomerName.Text.Trim() == "")
            {
                epCustomerName.SetError(txtCustomerName, "Please enter customer name");
                result = false;
            }
            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DoValidation())
            {
                _customer.CustomerName = txtCustomerName.Text.Trim();
                _customer.Sex = cboSex.Text.Trim().Length > 0 ? cboSex.Text.Trim()[0] : 'U';
                _customer.DOB = DateTime.Parse(dtpDOB.Text.Trim());
                _customer.POB = txtPOB.Text.Trim();
                _customer.Phone = txtPhone.Text.Trim();
                _customer.Email = txtEmail.Text.Trim();

                if (newcustomer)
                {
                    CustomerService.Add(_customer);
                }
                else
                {
                    CustomerService.Update(_customer);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}

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
    public partial class FormCustomer : Form
    {
        DataTable dtCustomer;
        FormMain formMain;
        public FormCustomer(FormMain formMain)
        {
            this.formMain = formMain;
            InitializeComponent();
            InitializeData();
            
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            dgCustomers.Refresh();
        }
        private void InitializeData()
        {
            dtCustomer = CustomerService.GetAll();
            dgCustomers.DataSource = dtCustomer;
            dgCustomers.Columns[0].Visible = false;
            dgCustomers.Columns[1].Visible = true;
            dgCustomers.Columns[1].HeaderText = "Customer Name";
            dgCustomers.Columns[1].Width = 200;
            dgCustomers.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgCustomers.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgCustomers.Columns[2].Visible = false;
            dgCustomers.Columns[3].Visible = false;
            dgCustomers.Columns[4].Visible = false;
            dgCustomers.Columns[5].Visible = false;
            dgCustomers.Columns[6].Visible = false;
        }

        private void dgCustomers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                e.Handled = true;
                using (Brush b = new SolidBrush(dgCustomers.DefaultCellStyle.BackColor))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }
                using (Pen p = new Pen(Brushes.Black))
                {
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    p.Color = Color.FromArgb(33, 37, 41);
                    e.Graphics.DrawLine(p, new Point(0, e.CellBounds.Bottom - 1), new Point(e.CellBounds.Right, e.CellBounds.Bottom - 1));
                    e.Graphics.DrawLine(p, new Point(0, 0), new Point(e.CellBounds.Right, 0));
                }
                e.PaintContent(e.ClipBounds);
            }
        }

        private void dgCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgCustomers.SelectedRows[0];
                int customerId = Convert.ToInt32(selectedRow.Cells["CustomerId"].Value);
                Customer customer = CustomerService.Get(customerId);
                if (customer != null)
                {
                    txtCustomerName.Text = customer.CustomerName;
                    txtSex.Text = customer.Sex.ToString();
                    txtDOB.Text = customer.DOB.ToString("MM/dd/yyyy");
                    txtPOB.Text = customer.POB;
                    txtPhone.Text = customer.Phone;
                    txtEmail.Text = customer.Email;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormCustomerAddEdit formAddEdit = new FormCustomerAddEdit(null);
            if (formAddEdit.ShowDialog() == DialogResult.OK)
            {
                InitializeData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgCustomers.SelectedRows.Count > 0)
            {
                int customerid = Convert.ToInt32(dgCustomers.SelectedRows[0].Cells["CustomerId"].Value.ToString());
                Customer customer = CustomerService.Get(customerid);
                if (customer == null)
                {
                    MessageBox.Show("Cannot find customer");
                }
                else
                {
                    FormCustomerAddEdit formAddEdit = new FormCustomerAddEdit(customer);
                    if (formAddEdit.ShowDialog() == DialogResult.OK)
                    {
                        InitializeData();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(this, "Confirmation!\nDo you really want to delete this record?", "Confirmation",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                int customerid = Convert.ToInt32(dgCustomers.SelectedRows[0].Cells["CustomerId"].Value.ToString());

                CustomerService.Delete(customerid);
                DataRow[] rowsToDelete = dtCustomer.Select($"CustomerId = {customerid}");
                foreach (var row in rowsToDelete)
                {
                    dtCustomer.Rows.Remove(row);
                }
                clear();
                MessageBox.Show("Customer had deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void clear()
        {
            txtCustomerName.Clear();
            txtSex.Clear();
            txtDOB.Clear();
            txtPOB.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            //txtAddress.Clear();
        }
    }
}

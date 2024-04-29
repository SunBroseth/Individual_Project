using Oracle.ManagedDataAccess.Client;
using Sun_Broseth.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sun_Broseth.Data
{
    internal class CustomerService
    {
        public static DataTable GetAll()
        {
            OracleCommand command = new OracleCommand("CustomerGet", LoanContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public static Customer Get(int customerid)
        {
            Customer customer = null;
            OracleCommand command = new OracleCommand("CustomerGet", LoanContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("P_CustomerId", customerid);

            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    customer = new Customer();
                    customer.CustomerId = Convert.ToInt32(reader["CustomerId"].ToString());
                    customer.CustomerName = reader["CustomerName"].ToString();
                    string sexString = reader["Sex"].ToString().Trim();
                    customer.Sex = sexString.Length > 0 ? sexString[0] : 'U';
                    customer.DOB=Convert.ToDateTime(reader["DoB"].ToString());
                    customer.POB = reader["POB"].ToString();
                    customer.Phone = reader["Phone"].ToString();
                    customer.Email = reader["Email"].ToString();
                }
            }

            return customer;
        }

        public static void Add(Customer customer)
        {
            try
            {
                OracleCommand command = new OracleCommand("CustomerAdd", LoanContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_CustomerName", customer.CustomerName);
                command.Parameters.Add("P_CustomerName", customer.Sex);
                command.Parameters.Add("P_CustomerName", customer.DOB);
                command.Parameters.Add("P_CustomerName", customer.POB);
                command.Parameters.Add("P_Phone", customer.Phone);
                command.Parameters.Add("P_Email", customer.Email);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Update(Customer customer)
        {
            try
            {
                OracleCommand command = new OracleCommand("CustomerUpdate", LoanContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_CustomerId", customer.CustomerId);
                command.Parameters.Add("P_CustomerName", customer.CustomerName);
                command.Parameters.Add("P_CustomerName", customer.Sex);
                command.Parameters.Add("P_CustomerName", customer.DOB);
                command.Parameters.Add("P_CustomerName", customer.POB);
                command.Parameters.Add("P_Phone", customer.Phone);
                command.Parameters.Add("P_Email", customer.Email);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Delete(int customerid)
        {
            try
            {
                OracleCommand command = new OracleCommand("CustomerDelete", LoanContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_CustomerId", customerid);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

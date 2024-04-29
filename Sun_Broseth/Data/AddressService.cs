using Oracle.ManagedDataAccess.Client;
using Sun_Broseth.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sun_Broseth.Data
{
    internal class AddressService
    {
        public static DataTable GetAll()
        {
            OracleCommand command = new OracleCommand("AddressGet", LoanContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static Address GetByCustomerId(int customerId)
        {
            Address address = null;
            using (var connection = new SqlConnection("YourConnectionString"))
            {
                string query = "SELECT * FROM Address WHERE CustomerId = @CustomerId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            address = new Address
                            {
                                AddressId = Convert.ToInt32(reader["AddressId"]),
                                AddressName = reader["AddressName"].ToString(),
                                // Other address fields...
                            };
                        }
                    }
                }
            }
            return address;
        }
        public static Address Get(int addressid)
        {
            Address address = null;
            OracleCommand command = new OracleCommand("AddressGet", LoanContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("P_AddressId", addressid);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                address = new Address();
                address.AddressId = Convert.ToInt32(reader["AddressId"].ToString());
                address.CustomerId = Convert.ToInt32(reader["CustomerId"].ToString());
                address.AddressName = reader["AddressName"].ToString();
            }
            return address;
        }

        public static void Add(Address address)
        {
            try
            {
                OracleCommand command = new OracleCommand("AddressAdd", LoanContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_CompanyName", address.CustomerId);
                command.Parameters.Add("P_CustomerName", address.AddressName);
                

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Update(Address address)
        {
            try
            {
                OracleCommand command = new OracleCommand("AddressUpdate", LoanContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_AddressId", address.AddressId);
                command.Parameters.Add("P_CustomerId", address.CustomerId);
                command.Parameters.Add("P_AddressName", address.AddressName);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Delete(int addressid)
        {
            try
            {
                OracleCommand command = new OracleCommand("CustomerDelete", LoanContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_AddressId", addressid);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAccounting.Lib.Utility;

namespace DataMigrationUtility.DataMigrationUtilityCodes
{
    class FuelScaleChargeTablesDataMigration
    {
        static string cs = AppSettingsUtil.ConnectionStringMasterDB;
        static string cs1 = AppSettingsUtil.ConnectionStringSourceDB;
        static string cs2 = AppSettingsUtil.ConnectionStringClientDB;
        static object data;
        static string datas;


        public static void FuelScaleChargeProfileDataMigration()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT Title,FromDate,ToDate from fuelscalechargeprofile", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    data = reader.GetValue(i);
                                    if (datas != "")
                                        datas += ",";

                                    if (data.GetType() == typeof(DateTime))
                                    {
                                        // Changing the format of date
                                        var date = (DateTime)data;
                                        datas += "'" + date.ToString("yyyy-MM-dd") + "'";
                                    }
                                    else
                                    {
                                        datas += '"' + Convert.ToString(data) + '"';
                                    }
                                }
                                var q = "INSERT INTO fuelscalechargeprofile(Title,FromDate,ToDate) Values(" + datas + ");";
                                RunQuery(q);
                            }
                        }
                    }
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }
        }

        public static void FuelScaleChargeDetailsDataMigration()
        {
            object capacity;
            object profileIdFuelScaleChargeDetails;

            try
            {
                using (MySqlConnection connection5 = new MySqlConnection(cs1))
                {
                    connection5.Open();
                    using (MySqlCommand command5 = new MySqlCommand("SELECT DISTINCT FuelScaleChargeProfileID FROM fuelscalechargedetails ORDER BY FuelScaleChargeProfileID ASC", connection5))
                    {
                        using (MySqlDataReader reader5 = command5.ExecuteReader())
                        {
                            while (reader5.Read())
                            {
                                profileIdFuelScaleChargeDetails = reader5.GetValue(0);
                                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                                {
                                    connection1.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT Capacity FROM fuelscalechargedetails Where FuelScaleChargeProfileID = " + profileIdFuelScaleChargeDetails + " ORDER BY Capacity ASC", connection1))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                capacity = reader1.GetValue(0);
                                                using (MySqlConnection connection = new MySqlConnection(cs1))
                                                {
                                                    connection.Open();
                                                    using (MySqlCommand command = new MySqlCommand("SELECT Capacity,ScaleCharge,VATDue from fuelscalechargedetails Where Period = 12 AND Capacity =" + capacity + " AND FuelScaleChargeProfileID = " + profileIdFuelScaleChargeDetails, connection))
                                                    {
                                                        using (MySqlDataReader reader = command.ExecuteReader())
                                                        {
                                                            while (reader.Read())
                                                            {
                                                                datas = "";
                                                                for (int i = 0; i < reader.FieldCount; i++)
                                                                {
                                                                    data = reader.GetValue(i);
                                                                    if (datas != "")
                                                                        datas += ",";
                                                                    datas += '"' + Convert.ToString(data) + '"';
                                                                }
                                                                var q = "INSERT INTO fuelscalechargedetails(Capacity,ScaleCharge12Month,VATDue12Month) Values(" + datas + ");";
                                                                RunQuery(q);
                                                                using (MySqlConnection connection6 = new MySqlConnection(cs))
                                                                {
                                                                    connection6.Open();
                                                                    object masterFuelScaleChargeProfileId;
                                                                    using (MySqlCommand command6 = new MySqlCommand("SELECT MasterFuelProfileID FROM temporaryfuelscalechargeprofileidassociation Where SourceFuelProfileID = " + profileIdFuelScaleChargeDetails, connection6))
                                                                    {
                                                                        using (MySqlDataReader reader6 = command6.ExecuteReader())
                                                                        {
                                                                            while (reader6.Read())
                                                                            {
                                                                                data = reader6.GetValue(0);
                                                                                masterFuelScaleChargeProfileId = '"' + Convert.ToString(data) + '"';
                                                                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                                                                {
                                                                                    connection2.Open();
                                                                                    string ScaleCharge3Month, VATDue3Month;
                                                                                    using (MySqlCommand command2 = new MySqlCommand("SELECT ScaleCharge,VATDue from fuelscalechargedetails Where Period = 3 AND Capacity = " + capacity + " AND FuelScaleChargeProfileID = " + profileIdFuelScaleChargeDetails, connection2))
                                                                                    {
                                                                                        using (MySqlDataReader reader2 = command2.ExecuteReader())
                                                                                        {
                                                                                            while (reader2.Read())
                                                                                            {
                                                                                                ScaleCharge3Month = "";
                                                                                                VATDue3Month = "";
                                                                                                for (int i = 0; i < reader2.FieldCount; i++)
                                                                                                {
                                                                                                    data = reader2.GetValue(i);
                                                                                                    if (i == 0)
                                                                                                        ScaleCharge3Month = '"' + Convert.ToString(data) + '"';
                                                                                                    if (i == 1)
                                                                                                        VATDue3Month = '"' + Convert.ToString(data) + '"';
                                                                                                }
                                                                                                using (MySqlConnection connection3 = new MySqlConnection(cs))
                                                                                                {
                                                                                                    connection3.Open();
                                                                                                    string fuelScaleChargeDetailsId;
                                                                                                    using (MySqlCommand command3 = new MySqlCommand("SELECT FuelScaleChargeDetailsID FROM fuelscalechargedetails ORDER BY FuelScaleChargeDetailsID DESC LIMIT 1", connection3))
                                                                                                    {
                                                                                                        using (MySqlDataReader reader3 = command3.ExecuteReader())
                                                                                                        {
                                                                                                            while (reader3.Read())
                                                                                                            {
                                                                                                                fuelScaleChargeDetailsId = "";
                                                                                                                data = reader3.GetValue(0);
                                                                                                                fuelScaleChargeDetailsId = '"' + Convert.ToString(data) + '"';
                                                                                                                var q1 = "UPDATE fuelscalechargedetails SET FuelScaleChargeProfileID = " + masterFuelScaleChargeProfileId + "," + "ScaleCharge3Month = " + ScaleCharge3Month + "," + "VATDue3Month =" + VATDue3Month + " Where FuelScaleChargeDetailsID = " + fuelScaleChargeDetailsId + " AND ScaleCharge3Month IS NULL AND VATDue3Month IS NULL";
                                                                                                                RunQuery(q1);
                                                                                                                using (MySqlConnection connection4 = new MySqlConnection(cs1))
                                                                                                                {
                                                                                                                    connection4.Open();
                                                                                                                    string VATDue1Month, ScaleCharge1Month;
                                                                                                                    using (MySqlCommand command4 = new MySqlCommand("SELECT ScaleCharge,VATDue from fuelscalechargedetails Where Period = 1 AND Capacity = " + capacity + " AND FuelScaleChargeProfileID = " + profileIdFuelScaleChargeDetails, connection4))
                                                                                                                    {
                                                                                                                        using (MySqlDataReader reader4 = command4.ExecuteReader())
                                                                                                                        {
                                                                                                                            while (reader4.Read())
                                                                                                                            {
                                                                                                                                ScaleCharge1Month = "";
                                                                                                                                VATDue1Month = "";
                                                                                                                                for (int i = 0; i < reader4.FieldCount; i++)
                                                                                                                                {
                                                                                                                                    data = reader4.GetValue(i);
                                                                                                                                    if (i == 0)
                                                                                                                                        ScaleCharge1Month = '"' + Convert.ToString(data) + '"';
                                                                                                                                    if (i == 1)
                                                                                                                                        VATDue1Month = '"' + Convert.ToString(data) + '"';
                                                                                                                                }
                                                                                                                                var q2 = "UPDATE fuelscalechargedetails SET ScaleCharge1Month = " + ScaleCharge1Month + "," + "VATDue1Month =" + VATDue1Month + " Where FuelScaleChargeDetailsID = " + fuelScaleChargeDetailsId + " AND ScaleCharge1Month IS NULL AND VATDue1Month IS NULL";
                                                                                                                                RunQuery(q2);
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }
        }

        private static void RunQuery(string query)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteReader();
                    }
                }
            }

            catch (Exception ex)
            {
                Program.ErrorLoggingForQueries(ex,query);
            }
        }
    }
}

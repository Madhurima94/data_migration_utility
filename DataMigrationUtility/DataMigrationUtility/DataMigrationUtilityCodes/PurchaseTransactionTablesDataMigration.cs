using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAccounting.Lib.Utility;

namespace DataMigrationUtility.DataMigrationUtilityCodes
{
    class PurchaseTransactionTablesDataMigration
    {
        static string cs = AppSettingsUtil.ConnectionStringMasterDB;
        static string cs1 = AppSettingsUtil.ConnectionStringSourceDB;
        static string cs2 = AppSettingsUtil.ConnectionStringClientDB;
        static object ClientId;
        static object AccountantId;
        static object AccountId;
        static object MasterDBClientId;
        static string datas;
        static object data;
        static object MasterClientId;
        static object TransactionId;
        static object PurchaseId;
        static object ClientDBCustomerId;
        static object ClientDBSupplierId;
        static object SourceDBCustomerId;
        static object SourceDBSupplierId;
        static List<object> clientIdListMasterDatabase = new List<object>();

        public static void GetMasterClientIdListForPurchaseTransaction()
        {
            object data;
            string datas = "";

            try
            {
                using (MySqlConnection connection7 = new MySqlConnection(cs))
                {
                    connection7.Open();
                    using (MySqlCommand command7 = new MySqlCommand("SELECT AccountantID FROM accountant Where Name = 'Riddhima Gupta'", connection7))
                    {
                        using (MySqlDataReader reader7 = command7.ExecuteReader())
                        {
                            while (reader7.Read())
                            {
                                datas = "";
                                data = reader7.GetValue(0);
                                datas += '"' + Convert.ToString(data) + '"';
                                AccountantId = datas;
                            }
                        }
                    }
                }

                using (MySqlConnection connection6 = new MySqlConnection(cs1))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT TransactionID FROM transaction Where Type = 'Purchase' ", connection6))
                    {
                        using (MySqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                data = reader.GetValue(0);
                                datas += '"' + Convert.ToString(data) + '"';
                                TransactionId = datas;
                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command2 = new MySqlCommand("SELECT AccountID FROM transaction Where TransactionID =" + TransactionId, connection2))
                                    {
                                        using (MySqlDataReader reader2 = command2.ExecuteReader())
                                        {
                                            while (reader2.Read())
                                            {
                                                datas = "";
                                                data = reader2.GetValue(0);
                                                datas += '"' + Convert.ToString(data) + '"';
                                                AccountId = datas;
                                                using (MySqlConnection connection = new MySqlConnection(cs))
                                                {
                                                    connection.Open();
                                                    using (MySqlCommand command = new MySqlCommand("SELECT ClientID FROM temporaryoldnewclientidsassociation Where AccountID = " + AccountId, connection))
                                                    {
                                                        using (MySqlDataReader reader1 = command.ExecuteReader())
                                                        {
                                                            while (reader1.Read())
                                                            {
                                                                MasterClientId = reader1.GetValue(0);
                                                                clientIdListMasterDatabase.Add(MasterClientId);
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

        public static void PurchaseTransactionTableDataMigration()
        {
            int index = 0;
            try
            {
                GetMasterClientIdListForPurchaseTransaction();

                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT TransactionID FROM purchasetransaction ORDER BY TransactionID ASC", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                TransactionId = reader.GetValue(0);
                                MasterDBClientId = clientIdListMasterDatabase.ElementAt(index++);
                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT purchasetransaction.OrderNumber,purchasetransaction.PurchaseType,purchasetransaction.IsCapitalExpenditure,purchasetransaction.Notes,transaction.Date,transaction.GrossAmount,transaction.VATReportingDate,transaction.ReferenceNo,transaction.IsImport,transaction.PaymentDate,transaction.ChequeNumber,transaction.BankName,transaction.AcNumber,transaction.CCType,transaction.IsEC,transaction.IsPaid FROM purchasetransaction LEFT JOIN transaction ON purchasetransaction.TransactionID = transaction.TransactionID Where purchasetransaction.TransactionID =" + TransactionId, connection2))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                datas = "";
                                                for (int i = 0; i < reader1.FieldCount; i++)
                                                {
                                                    data = reader1.GetValue(i);
                                                    if (datas != "")
                                                        datas += ",";
                                                    if (data.GetType() == typeof(DateTime))
                                                    {
                                                        // Changing the format of date
                                                        var date = (DateTime)data;
                                                        datas += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                                    }
                                                    else
                                                    {
                                                        datas += '"' + Convert.ToString(data) + '"';
                                                    }
                                                }
                                                object value;
                                                string values;
                                                object info;
                                                string infos;
                                                using (MySqlConnection connection3 = new MySqlConnection(cs1))
                                                {
                                                    connection3.Open();
                                                    using (MySqlCommand command3 = new MySqlCommand("SELECT SupplierID FROM purchasetransaction Where TransactionID =" + TransactionId, connection3))
                                                    {
                                                        using (MySqlDataReader reader3 = command3.ExecuteReader())
                                                        {
                                                            while (reader3.Read())
                                                            {
                                                                values = "";
                                                                value = reader3.GetValue(0);
                                                                if (values != "")
                                                                    values += ",";
                                                                values += '"' + Convert.ToString(value) + '"';
                                                                SourceDBSupplierId = values;
                                                                string cs20 = cs2 + MasterDBClientId;
                                                                using (MySqlConnection connection8 = new MySqlConnection(cs20))
                                                                {
                                                                    connection8.Open();
                                                                    using (MySqlCommand command8 = new MySqlCommand("SELECT ClientSupplierID FROM temporarysupplieridassociation Where SourceSupplierID =" + SourceDBSupplierId, connection8))
                                                                    {
                                                                        using (MySqlDataReader reader8 = command8.ExecuteReader())
                                                                        {
                                                                            while (reader8.Read())
                                                                            {
                                                                                infos = "";
                                                                                info = reader8.GetValue(0);
                                                                                infos += '"' + Convert.ToString(info) + '"';
                                                                                ClientDBSupplierId = infos;
                                                                                var reportTypeId = (int)AppSettingsUtil.REPORT_TYPE.DATA_REPORT;
                                                                                var q = "INSERT INTO purchase(InvoiceNumber,PaymentMethod,IsCapitalExpenditure,Notes,InvoiceDate,TotalGrossAmount,VATReportingDate,ReferenceNumber,IsImport,PaymentDate,ChequeNumber,Bank,AccountNumber,CreditCardType,IsEC,IsPaid,AccountantID,ReportTypeID,SupplierID,ScannedInvoiceID) Values(" + datas + "," + AccountantId + "," + reportTypeId + "," + ClientDBSupplierId + "," + 0 + "); ";
                                                                                RunQueryClientDatabase(q);
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                string cs5 = cs2 + MasterDBClientId;
                                                object purchaseTransactionId;
                                                using (MySqlConnection connection5 = new MySqlConnection(cs1))
                                                {
                                                    connection5.Open();
                                                    using (MySqlCommand command15 = new MySqlCommand("SELECT PurchaseTransactionID FROM purchasetransaction Where TransactionID =" + TransactionId, connection5))
                                                    {
                                                        using (MySqlDataReader reader15 = command15.ExecuteReader())
                                                        {
                                                            while (reader15.Read())
                                                            {
                                                                purchaseTransactionId = reader15.GetValue(0);
                                                                PurchaseTransactionItemTableDataMigration(purchaseTransactionId, TransactionId, MasterDBClientId);
                                                            }
                                                        }
                                                    }
                                                }
                                                object purchaseItemMemoryPurchaseTransactionID;
                                                using (MySqlConnection connection5 = new MySqlConnection(cs1))
                                                {
                                                    connection5.Open();
                                                    using (MySqlCommand command15 = new MySqlCommand("SELECT PurchaseTransactionID FROM purchasetransaction Where TransactionID =" + TransactionId, connection5))
                                                    {
                                                        using (MySqlDataReader reader15 = command15.ExecuteReader())
                                                        {
                                                            while (reader15.Read())
                                                            {
                                                                purchaseItemMemoryPurchaseTransactionID = reader15.GetValue(0);
                                                                PurchaseTransactionItemMemoryTableDataMigration(purchaseItemMemoryPurchaseTransactionID, TransactionId, MasterDBClientId);
                                                            }
                                                        }
                                                    }
                                                }
                                                string cs6 = cs2 + MasterDBClientId;
                                                using (MySqlConnection connection4 = new MySqlConnection(cs5))
                                                {
                                                    connection4.Open();
                                                    using (MySqlCommand command4 = new MySqlCommand("SELECT PurchaseID FROM purchase ORDER BY PurchaseID DESC LIMIT 1", connection4))
                                                    {
                                                        using (MySqlDataReader reader4 = command4.ExecuteReader())
                                                        {
                                                            while (reader4.Read())
                                                            {
                                                                datas = "";
                                                                data = reader4.GetValue(0);
                                                                if (datas != "")
                                                                    datas += ",";
                                                                datas += '"' + Convert.ToString(data) + '"';
                                                                PurchaseId = datas;
                                                                var encodedID = AppSettingsUtil.Encode(Convert.ToString(PurchaseId));
                                                                var encodedIDValue = '"' + Convert.ToString(encodedID) + '"';
                                                                var q3 = "UPDATE purchase set EncodedPurchaseID =  " + encodedIDValue + " Where PurchaseID = " + PurchaseId + " ";
                                                                RunQueryClientDatabase(q3);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                TransactionTableDataMigration(TransactionId, MasterDBClientId);
                                TransactionHistoryTableDataMigration(TransactionId, MasterDBClientId);
                                TransactionVATTableDataMigration(TransactionId, MasterDBClientId);
                                TransactionVATHistoryTableDataMigration(TransactionId, MasterDBClientId);
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

        private static void TransactionTableDataMigration(object transactionId, object masterDBClientId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT Type,CreateDate,Status,GUID FROM transaction Where TransactionID =" + transactionId, connection))
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
                                        datas += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                    }
                                    else
                                    {
                                        datas += '"' + Convert.ToString(data) + '"';
                                    }
                                }
                                var person = (int)AppSettingsUtil.TRANSACTION_PERSON.Accountant;
                                string cs3 = cs2 + masterDBClientId;
                                string values;
                                object value;
                                object transactionTypeId;
                                using (MySqlConnection connection1 = new MySqlConnection(cs3))
                                {
                                    connection1.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT PurchaseID FROM purchase ORDER BY PurchaseID DESC LIMIT 1", connection1))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                values = "";
                                                value = reader1.GetValue(0);
                                                values += '"' + Convert.ToString(value) + '"';
                                                transactionTypeId = values;
                                                var q = "INSERT INTO transaction(TransactionType,TransactionDate,Status,GUID,AccountantID,TransactionPerson,TransactionTypeID) Values(" + datas + "," + AccountantId + "," + person + "," + transactionTypeId + "); ";
                                                RunQueryClientDatabase(q);
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

        private static void TransactionHistoryTableDataMigration(object transactionId, object masterDBClientId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT Type,Status,CreateDate,GUID FROM transactionhistory Where TransactionID =" + transactionId, connection))
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
                                        datas += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                    }
                                    else
                                    {
                                        datas += '"' + Convert.ToString(data) + '"';
                                    }
                                }
                                var person = (int)AppSettingsUtil.TRANSACTION_PERSON.Accountant;
                                string cs3 = cs2 + masterDBClientId;
                                string cs4 = cs2 + masterDBClientId;
                                string values;
                                object value;
                                object transactionTypeId;
                                string transactionIdValues;
                                object transactionIdValue;
                                object transactionHistoryTransactionId;
                                using (MySqlConnection connection1 = new MySqlConnection(cs3))
                                {
                                    connection1.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT PurchaseID FROM purchase ORDER BY PurchaseID DESC LIMIT 1", connection1))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                values = "";
                                                value = reader1.GetValue(0);
                                                values += '"' + Convert.ToString(value) + '"';
                                                transactionTypeId = values;
                                                using (MySqlConnection connection2 = new MySqlConnection(cs4))
                                                {
                                                    connection2.Open();
                                                    using (MySqlCommand command2 = new MySqlCommand("SELECT TransactionID FROM transaction ORDER BY TransactionID DESC LIMIT 1", connection2))
                                                    {
                                                        using (MySqlDataReader reader2 = command2.ExecuteReader())
                                                        {
                                                            while (reader2.Read())
                                                            {
                                                                transactionIdValues = "";
                                                                transactionIdValue = reader2.GetValue(0);
                                                                transactionIdValues = '"' + Convert.ToString(transactionIdValue) + '"';
                                                                transactionHistoryTransactionId = transactionIdValues;
                                                                var q = "INSERT INTO transactionhistory(TransactionType,Status,TransactionDate,GUID,AccountantID,TransactionPerson,TransactionTypeID,TransactionID) Values(" + datas + "," + AccountantId + "," + person + "," + transactionTypeId + "," + transactionHistoryTransactionId + "); ";
                                                                RunQueryClientDatabase(q);
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

        private static void TransactionVATTableDataMigration(object transactionId, object masterDBClientId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT VATAmount,GrossAmount,NettAmount,RateType FROM transactionvat Where TransactionID =" + transactionId, connection))
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
                                        datas += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                    }
                                    else
                                    {
                                        datas += '"' + Convert.ToString(data) + '"';
                                    }
                                }
                                string cs4 = cs2 + masterDBClientId;
                                string transactionIdValues;
                                object transactionIdValue;
                                object transactionVATTransactionId;
                                using (MySqlConnection connection2 = new MySqlConnection(cs4))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command2 = new MySqlCommand("SELECT TransactionID FROM transaction ORDER BY TransactionID DESC LIMIT 1", connection2))
                                    {
                                        using (MySqlDataReader reader2 = command2.ExecuteReader())
                                        {
                                            while (reader2.Read())
                                            {
                                                transactionIdValues = "";
                                                transactionIdValue = reader2.GetValue(0);
                                                transactionIdValues = '"' + Convert.ToString(transactionIdValue) + '"';
                                                transactionVATTransactionId = transactionIdValues;
                                                var q = "INSERT INTO transactionvat(VATAmount,GrossAmount,NettAmount,VATRate,TransactionID) Values(" + datas + "," + transactionVATTransactionId + "); ";
                                                RunQueryClientDatabase(q);
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

        private static void TransactionVATHistoryTableDataMigration(object transactionId, object masterDBClientId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT VATAmount,GrossAmount,NettAmount,RateType FROM transactionvathistory Where TransactionID =" + transactionId, connection))
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
                                        datas += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                    }
                                    else
                                    {
                                        datas += '"' + Convert.ToString(data) + '"';
                                    }
                                }
                                string cs3 = cs2 + masterDBClientId;
                                string cs4 = cs2 + masterDBClientId;
                                string values;
                                object value;
                                object transactionHistoryId;
                                string transactionIdValues;
                                object transactionIdValue;
                                object transactionVATHistoryTransactionId;
                                using (MySqlConnection connection1 = new MySqlConnection(cs3))
                                {
                                    connection1.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT TransactionHistoryID FROM transactionhistory ORDER BY TransactionHistoryID DESC LIMIT 1", connection1))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                values = "";
                                                value = reader1.GetValue(0);
                                                values += '"' + Convert.ToString(value) + '"';
                                                transactionHistoryId = values;
                                                using (MySqlConnection connection2 = new MySqlConnection(cs4))
                                                {
                                                    connection2.Open();
                                                    using (MySqlCommand command2 = new MySqlCommand("SELECT TransactionID FROM transaction ORDER BY TransactionID DESC LIMIT 1", connection2))
                                                    {
                                                        using (MySqlDataReader reader2 = command2.ExecuteReader())
                                                        {
                                                            while (reader2.Read())
                                                            {
                                                                transactionIdValues = "";
                                                                transactionIdValue = reader2.GetValue(0);
                                                                transactionIdValues = '"' + Convert.ToString(transactionIdValue) + '"';
                                                                transactionVATHistoryTransactionId = transactionIdValues;
                                                                var q = "INSERT INTO transactionvathistory(VATAmount,GrossAmount,NettAmount,VATRate,TransactionHistoryID,TransactionID) Values(" + datas + "," + transactionHistoryId + "," + transactionVATHistoryTransactionId + "); ";
                                                                RunQueryClientDatabase(q);
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

        private static void PurchaseTransactionItemTableDataMigration(object purchaseTransactionItemId, object transactionId, object masterDBClientId)
        {
            string cs7 = cs2 + masterDBClientId;
            try
            {
                using (MySqlConnection connection7 = new MySqlConnection(cs7))
                {
                    connection7.Open();
                    object purchaseItemPurchaseID;
                    using (MySqlCommand command7 = new MySqlCommand("SELECT PurchaseID FROM purchase ORDER BY PurchaseID DESC LIMIT 1", connection7))
                    {
                        using (MySqlDataReader reader7 = command7.ExecuteReader())
                        {
                            while (reader7.Read())
                            {
                                purchaseItemPurchaseID = reader7.GetValue(0);
                                using (MySqlConnection connection = new MySqlConnection(cs1))
                                {
                                    connection.Open();
                                    using (MySqlCommand command = new MySqlCommand("SELECT Description,InvoiceNumber,InvoiceDate,Remark FROM purchasetransactionitem where PurchaseTransactionID =" + purchaseTransactionItemId, connection))
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
                                                var q1 = "INSERT INTO purchaseitem(ItemDescription,InvoiceNumber,InvoiceDate,Remarks,PurchaseID) Values(" + datas + "," + purchaseItemPurchaseID + "); ";
                                                RunQueryClientDatabase(q1);
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

        private static void PurchaseTransactionItemMemoryTableDataMigration(object purchaseTransactionMemoryPurchaseTransactionID, object transactionId, object masterDBClientId)
        {
            string cs7 = cs2 + masterDBClientId;

            try
            {
                using (MySqlConnection connection7 = new MySqlConnection(cs7))
                {
                    connection7.Open();
                    object purchaseItemMemoryPurchaseID;
                    using (MySqlCommand command7 = new MySqlCommand("SELECT PurchaseID FROM purchase ORDER BY PurchaseID DESC LIMIT 1", connection7))
                    {
                        using (MySqlDataReader reader7 = command7.ExecuteReader())
                        {
                            while (reader7.Read())
                            {
                                purchaseItemMemoryPurchaseID = reader7.GetValue(0);
                                using (MySqlConnection connection = new MySqlConnection(cs1))
                                {
                                    connection.Open();
                                    using (MySqlCommand command = new MySqlCommand("SELECT InvoiceNumber,InvoiceDate,Description,Remarks FROM purchasetransactionitemhistory where PurchaseTransactionID =" + purchaseTransactionMemoryPurchaseTransactionID, connection))
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
                                                        datas += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                                    }
                                                    else
                                                    {
                                                        datas += '"' + Convert.ToString(data) + '"';
                                                    }
                                                }
                                                var q1 = "INSERT INTO purchaseitemmemory(InvoiceNumber,InvoiceDate,ItemDescription,Remarks,PurchaseID) Values(" + datas + "," + purchaseItemMemoryPurchaseID + "); ";
                                                RunQueryClientDatabase(q1);
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

        private static void RunQueryClientDatabase(string query)
        {
            string cs5 = cs2 + MasterDBClientId;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs5))
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

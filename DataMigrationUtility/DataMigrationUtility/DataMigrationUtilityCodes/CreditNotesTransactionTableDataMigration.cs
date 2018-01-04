using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAccounting.Lib.Utility;

namespace DataMigrationUtility.DataMigrationUtilityCodes
{
    class CreditNotesTransactionTableDataMigration
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
        static object CreditNoteId;
        static object ClientDBCustomerId;
        static object ClientDBSupplierId;
        static object SourceDBCustomerId;
        static object SourceDBSupplierId;
        static List<object> clientIdListMasterDatabase = new List<object>();

        public static void GetMasterClientIdListForCreditNotesTransaction()
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
                    using (MySqlCommand command1 = new MySqlCommand("SELECT TransactionID FROM transaction Where Type = 'CreditNote' ORDER BY TransactionID ASC", connection6))
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
                                                                FecthBankDetailsAndInsertInClientBankTable(AccountId, MasterClientId);
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

        public static void CreditNoteTransactionTableDataMigration()
        {
            int index = 0;

            try
            {
                GetMasterClientIdListForCreditNotesTransaction();

                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT TransactionID FROM creditnotestransaction ORDER BY TransactionID ASC", connection))
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
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT creditnotestransaction.TransactionType,creditnotestransaction.ReferenceNumber,creditnotestransaction.PaymentType,creditnotestransaction.Notes,transaction.Date,transaction.GrossAmount,transaction.VATReportingDate,transaction.ReferenceNo,transaction.PaymentDate,transaction.ChequeNumber,transaction.BankName,transaction.AcNumber,transaction.CCType,transaction.IsEC,transaction.IsPaid FROM creditnotestransaction LEFT JOIN transaction ON creditnotestransaction.TransactionID = transaction.TransactionID Where creditnotestransaction.TransactionID =" + TransactionId, connection2))
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
                                                    else if (data.ToString() == "Purchases")
                                                    {
                                                        data = "Purchase";
                                                        datas += '"' + Convert.ToString(data) + '"';
                                                    }
                                                    else if (data.ToString() == "Expenses")
                                                    {
                                                        data = "Expense";
                                                        datas += '"' + Convert.ToString(data) + '"';
                                                    }
                                                    else
                                                    {
                                                        datas += '"' + Convert.ToString(data) + '"';
                                                    }
                                                }
                                                var reportTypeID = (int)AppSettingsUtil.REPORT_TYPE.CREDITNOTE_REPORT;
                                                var q = "INSERT INTO creditnote(TransactionType,CreditNoteNumber,PaymentMethod,Notes,CreditNoteDate,TotalGrossAmount,VATReportingDate,ReferenceNumber,PaymentDate,ChequeNumber,Bank,AccountNumber,CreditCardType,IsEC,IsPaid,AccountantID,ReportTypeID,ScannedInvoiceID) Values(" + datas + "," + AccountantId + "," + reportTypeID + "," + 0 + "); ";
                                                RunQueryClientDatabase(q);
                                                string cs5 = cs2 + MasterDBClientId;
                                                string cs6 = cs2 + MasterDBClientId;
                                                using (MySqlConnection connection4 = new MySqlConnection(cs5))
                                                {
                                                    connection4.Open();
                                                    using (MySqlCommand command4 = new MySqlCommand("SELECT CreditNoteID FROM creditnote Where SupplierID IS NULL AND CustomerID IS NULL ORDER BY CreditNoteID ASC", connection4))
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
                                                                CreditNoteId = datas;
                                                                var encodedID = AppSettingsUtil.Encode(Convert.ToString(CreditNoteId));
                                                                var encodedIDValue = '"' + encodedID + '"';

                                                                using (MySqlConnection connection3 = new MySqlConnection(cs1))
                                                                {
                                                                    connection3.Open();
                                                                    using (MySqlCommand command3 = new MySqlCommand("SELECT CustomerSupplierID FROM creditnotestransaction Where TransactionID =" + TransactionId + " AND (TransactionType = 'Purchases' OR TransactionType = 'Expenses')", connection3))
                                                                    {
                                                                        using (MySqlDataReader reader3 = command3.ExecuteReader())
                                                                        {
                                                                            while (reader3.Read())
                                                                            {
                                                                                datas = "";
                                                                                data = reader3.GetValue(0);
                                                                                if (datas != "")
                                                                                    datas += ",";
                                                                                datas += '"' + Convert.ToString(data) + '"';
                                                                                SourceDBSupplierId = datas;
                                                                                using (MySqlConnection connection8 = new MySqlConnection(cs6))
                                                                                {
                                                                                    connection8.Open();
                                                                                    using (MySqlCommand command8 = new MySqlCommand("SELECT ClientSupplierID FROM temporarysupplieridassociation Where SourceSupplierID =" + SourceDBSupplierId, connection8))
                                                                                    {
                                                                                        using (MySqlDataReader reader8 = command8.ExecuteReader())
                                                                                        {
                                                                                            while (reader8.Read())
                                                                                            {
                                                                                                datas = "";
                                                                                                data = reader8.GetValue(0);
                                                                                                datas += '"' + Convert.ToString(data) + '"';
                                                                                                ClientDBSupplierId = datas;
                                                                                                var q3 = "UPDATE creditnote set SupplierID =  " + ClientDBSupplierId + "Where CreditNoteID = " + CreditNoteId + " ";
                                                                                                RunQueryClientDatabase(q3);
                                                                                                var q4 = "UPDATE creditnote set EncodedID = " + encodedIDValue + " Where CreditNoteID = " + CreditNoteId + " ";
                                                                                                RunQueryClientDatabase(q4);
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                using (MySqlConnection connection5 = new MySqlConnection(cs1))
                                                                {
                                                                    connection5.Open();
                                                                    using (MySqlCommand command5 = new MySqlCommand("SELECT CustomerSupplierID FROM creditnotestransaction Where TransactionID =" + TransactionId + " AND TransactionType = 'Sales' ", connection5))
                                                                    {
                                                                        using (MySqlDataReader reader5 = command5.ExecuteReader())
                                                                        {
                                                                            while (reader5.Read())
                                                                            {
                                                                                datas = "";
                                                                                data = reader5.GetValue(0);
                                                                                if (datas != "")
                                                                                    datas += ",";
                                                                                datas += '"' + Convert.ToString(data) + '"';
                                                                                SourceDBCustomerId = datas;
                                                                                using (MySqlConnection connection9 = new MySqlConnection(cs6))
                                                                                {
                                                                                    connection9.Open();
                                                                                    using (MySqlCommand command9 = new MySqlCommand("SELECT ClientCustomerID FROM temporarycustomeridassociation Where SourceCustomerID =" + SourceDBCustomerId, connection9))
                                                                                    {
                                                                                        using (MySqlDataReader reader9 = command9.ExecuteReader())
                                                                                        {
                                                                                            while (reader9.Read())
                                                                                            {
                                                                                                datas = "";
                                                                                                data = reader9.GetValue(0);
                                                                                                datas += '"' + Convert.ToString(data) + '"';
                                                                                                ClientDBCustomerId = datas;
                                                                                                var q3 = "UPDATE creditnote set SupplierID =  " + ClientDBCustomerId + "Where CreditNoteID = " + CreditNoteId + " ";
                                                                                                RunQueryClientDatabase(q3);
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
                                TransactionTableDataMigration(TransactionId, MasterDBClientId);
                                TransactionHistoryTableDataMigration(TransactionId, MasterDBClientId);
                                TransactionVATTableDataMigration(TransactionId, MasterDBClientId);
                                TransactionVATHistoryTableDataMigration(TransactionId, MasterDBClientId);
                                CreditNoteVATDetailsTableDataEntry(TransactionId, MasterDBClientId);
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
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT CreditNoteID FROM creditnote ORDER BY CreditNoteID DESC LIMIT 1", connection1))
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
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT CreditNoteID FROM creditnote ORDER BY CreditNoteID DESC LIMIT 1", connection1))
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

        private static void CreditNoteVATDetailsTableDataEntry(object transactionId, object masterDBClientId)
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
                                string creditNodeIdValues;
                                object creditNodeIdValue;
                                object creditNodeVATDetailsCreditNodeId;
                                using (MySqlConnection connection2 = new MySqlConnection(cs4))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command2 = new MySqlCommand("SELECT CreditNoteID FROM creditnote ORDER BY CreditNoteID DESC LIMIT 1", connection2))
                                    {
                                        using (MySqlDataReader reader2 = command2.ExecuteReader())
                                        {
                                            while (reader2.Read())
                                            {
                                                creditNodeIdValues = "";
                                                creditNodeIdValue = reader2.GetValue(0);
                                                creditNodeIdValues = '"' + Convert.ToString(creditNodeIdValue) + '"';
                                                creditNodeVATDetailsCreditNodeId = creditNodeIdValues;
                                                var q = "INSERT INTO creditnotevatdetails(VATAmount,GrossAmount,NettAmount,VATRateType,CreditNoteID) Values(" + datas + "," + creditNodeVATDetailsCreditNodeId + "); ";
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

        public static void FecthBankDetailsAndInsertInClientBankTable(object accountId, object masterDBClientId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    string bankName;
                    string accountNumber;
                    MasterDBClientId = masterDBClientId;
                    using (MySqlCommand command = new MySqlCommand("SELECT distinct BankName,AcNumber FROM transaction Where AccountID =" + accountId + " AND (BankName !='' AND AcNumber !='')", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                bankName = "";
                                accountNumber = "";
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    data = reader.GetValue(i);
                                    if (datas != "")
                                        datas += ",";
                                    datas += '"' + Convert.ToString(data) + '"';
                                    bankName += '"' + Convert.ToString(reader.GetValue(0)) + '"';
                                    accountNumber += '"' + Convert.ToString(reader.GetValue(1)) + '"';
                                }
                                var q = "INSERT INTO bank(BankName,AccountNumber) Values(" + datas + ")";
                                RunQueryClientDatabase(q);
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

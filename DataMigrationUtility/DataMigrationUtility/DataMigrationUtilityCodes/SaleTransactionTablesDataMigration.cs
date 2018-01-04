using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAccounting.Lib.Utility;

namespace DataMigrationUtility.DataMigrationUtilityCodes
{
    class SaleTransactionTablesDataMigration
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
        static object SalesId;
        static object ClientDBCustomerId;
        static object ClientDBSupplierId;
        static object SourceDBCustomerId;
        static object SourceDBSupplierId;
        static object cafeSandwichBarTransactionId;
        static  object pharmacyTransactionId;
        static List<object> clientIdListMasterDatabase = new List<object>();

        public static void GetMasterClientIdListForSaleTransaction()
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
                    using (MySqlCommand command1 = new MySqlCommand("SELECT TransactionID FROM transaction Where Type = 'SaleDailyTaking' ORDER BY TransactionID ASC", connection6))
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

        public static void GetMasterClientIdListForNormalSaleTransaction()
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
                    using (MySqlCommand command1 = new MySqlCommand("SELECT TransactionID FROM transaction Where Type = 'Sale' ORDER BY TransactionID ASC", connection6))
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

        public static void SaleTransactionTableDataMigration()
        {
            int index = 0;
            string Notes, SaleType, InvoiceNumber, Cash, Cheque, CreditNotes, CreditSales, OwnConsumption, DGTGross, PracticePayment, TaxablePracticePayment, TaxableOtherIncome, NHSchequeReceived, VATNonTaxablePracticePayment, PrivatePrescription, NHSPrescription, CafeHotAmount, CafeHotPercentage, CafeColdAmount, CafeColdPercentage, Date, GrossAmount, VATReportingDate, ReferenceNo, PaymentDate, ChequeNumber, BankName, AcNumber, CCType, IsEC, IsPaid;
            decimal totalAmount = 0;
            decimal totalPercentage = 0;
            decimal cafeHotAmountValue, cafeHotAmountPercentage, cafeColdAmountValue, cafeColdAmountPercentage;
            object saleDailyTakingTransactionId;

            try
            {
                GetMasterClientIdListForSaleTransaction();
                using (MySqlConnection connection20 = new MySqlConnection(cs1))
                {
                    connection20.Open();
                    using (MySqlCommand command20 = new MySqlCommand("SELECT TransactionID FROM transaction Where Type = 'SaleDailyTaking' ORDER BY TransactionID ASC", connection20))
                    {
                        using (MySqlDataReader reader20 = command20.ExecuteReader())
                        {
                            while (reader20.Read())
                            {
                                saleDailyTakingTransactionId = reader20.GetValue(0);
                                using (MySqlConnection connection = new MySqlConnection(cs1))
                                {
                                    connection.Open();
                                    using (MySqlCommand command = new MySqlCommand("SELECT TransactionID FROM saletransaction Where TransactionID =" + saleDailyTakingTransactionId, connection))
                                    {
                                        using (MySqlDataReader reader = command.ExecuteReader())
                                        {
                                            while (reader.Read())
                                            {
                                                datas = "";
                                                cafeHotAmountValue = 0;
                                                cafeColdAmountValue = 0;
                                                cafeColdAmountPercentage = 0;
                                                cafeHotAmountPercentage = 0;
                                                TransactionId = reader.GetValue(0);
                                                MasterDBClientId = clientIdListMasterDatabase.ElementAt(index++);
                                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                                {
                                                    connection2.Open();
                                                    using (MySqlCommand command1 = new MySqlCommand("SELECT saletransaction.Notes,saletransaction.SaleType,saletransaction.InvoiceNumber,saletransaction.Cash,saletransaction.Cheque,saletransaction.CreditNotes,saletransaction.CreditSales,saletransaction.OwnConsumption,saletransaction.DGTGross,saletransaction.PracticePayment,saletransaction.TaxablePracticePayment,saletransaction.TaxableOtherIncome,saletransaction.NHSChequeReceived,saletransaction.VATOnTaxablePracticePayment,saletransaction.PrivatePrescription,saletransaction.NHSPrescription,saletransaction.CafeHotAmount,saletransaction.CafeHotPercentage,saletransaction.CafeColdAmount,saletransaction.CafeColdPercentage,transaction.Date,transaction.GrossAmount,transaction.VATReportingDate,transaction.ReferenceNo,transaction.PaymentDate,transaction.ChequeNumber,transaction.BankName,transaction.AcNumber,transaction.CCType,transaction.IsEC,transaction.IsPaid FROM saletransaction LEFT JOIN transaction ON saletransaction.TransactionID = transaction.TransactionID Where saletransaction.TransactionID =" + TransactionId, connection2))
                                                    {
                                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                                        {
                                                            while (reader1.Read())
                                                            {
                                                                Notes = "";
                                                                SaleType = "";
                                                                InvoiceNumber = "";
                                                                Cash = "";
                                                                Cheque = "";
                                                                CreditNotes = "";
                                                                CreditSales = "";
                                                                OwnConsumption = "";
                                                                DGTGross = "";
                                                                PracticePayment = "";
                                                                TaxablePracticePayment = "";
                                                                TaxableOtherIncome = "";
                                                                NHSchequeReceived = "";
                                                                VATNonTaxablePracticePayment = "";
                                                                PrivatePrescription = "";
                                                                NHSPrescription = "";
                                                                CafeHotAmount = "";
                                                                CafeHotPercentage = "";
                                                                CafeColdAmount = "";
                                                                CafeColdPercentage = "";
                                                                Date = "";
                                                                GrossAmount = "";
                                                                VATReportingDate = "";
                                                                ReferenceNo = "";
                                                                PaymentDate = "";
                                                                ChequeNumber = "";
                                                                BankName = "";
                                                                AcNumber = "";
                                                                CCType = "";
                                                                IsEC = "";
                                                                IsPaid = "";
                                                                for (int i = 0; i < reader1.FieldCount; i++)
                                                                {
                                                                    data = reader1.GetValue(i);
                                                                    if (i == 0)
                                                                        Notes += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 1)
                                                                        SaleType += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 2)
                                                                        InvoiceNumber += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 3)
                                                                        Cash += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 4)
                                                                        Cheque += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 5)
                                                                        CreditNotes += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 6)
                                                                        CreditSales += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 7)
                                                                        OwnConsumption += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 8)
                                                                        DGTGross += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 9)
                                                                        PracticePayment += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 10)
                                                                        TaxablePracticePayment += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 11)
                                                                        TaxableOtherIncome += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 12)
                                                                        NHSchequeReceived += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 13)
                                                                        VATNonTaxablePracticePayment += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 14)
                                                                        PrivatePrescription += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 15)
                                                                        NHSPrescription += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 16)
                                                                    {
                                                                        cafeHotAmountValue = (decimal)data;
                                                                        CafeHotAmount += '"' + Convert.ToString(data) + '"';
                                                                    }
                                                                    if (i == 17)
                                                                    {
                                                                        cafeHotAmountPercentage = (decimal)data;
                                                                        CafeHotPercentage += '"' + Convert.ToString(data) + '"';
                                                                    }
                                                                    if (i == 18)
                                                                    {
                                                                        cafeColdAmountValue = (decimal)data;
                                                                        CafeColdAmount += '"' + Convert.ToString(data) + '"';
                                                                    }
                                                                    if (i == 19)
                                                                    {
                                                                        cafeColdAmountPercentage = (decimal)data;
                                                                        CafeColdPercentage += '"' + Convert.ToString(data) + '"';
                                                                    }
                                                                    if (i == 20)
                                                                    {
                                                                        // Changing the format of date
                                                                        var date = (DateTime)data;
                                                                        Date += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                                                    }
                                                                    if (i == 21)
                                                                        GrossAmount += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 22)
                                                                    {
                                                                        // Changing the format of date
                                                                        var date = (DateTime)data;
                                                                        VATReportingDate += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                                                    }
                                                                    if (i == 23)
                                                                        ReferenceNo += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 24)
                                                                    {
                                                                        // Changing the format of date
                                                                        var date = (DateTime)data;
                                                                        PaymentDate += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                                                    }
                                                                    if (i == 25)
                                                                        ChequeNumber += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 26)
                                                                        BankName += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 27)
                                                                        AcNumber += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 28)
                                                                        CCType += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 29)
                                                                        IsEC += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 30)
                                                                        IsPaid += '"' + Convert.ToString(data) + '"';
                                                                    totalAmount = cafeHotAmountValue + cafeColdAmountValue;
                                                                    totalPercentage = cafeColdAmountValue + cafeColdAmountPercentage;
                                                                }
                                                                string cs6 = cs2 + MasterDBClientId;
                                                                using (MySqlConnection connection3 = new MySqlConnection(cs1))
                                                                {
                                                                    connection3.Open();
                                                                    using (MySqlCommand command3 = new MySqlCommand("SELECT CustomerID FROM saletransaction Where TransactionID =" + TransactionId, connection3))
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
                                                                                SourceDBCustomerId = datas;
                                                                                using (MySqlConnection connection8 = new MySqlConnection(cs6))
                                                                                {
                                                                                    connection8.Open();
                                                                                    using (MySqlCommand command8 = new MySqlCommand("SELECT ClientCustomerID FROM temporarycustomeridassociation Where SourceCustomerID =" + SourceDBCustomerId, connection8))
                                                                                    {
                                                                                        using (MySqlDataReader reader8 = command8.ExecuteReader())
                                                                                        {
                                                                                            while (reader8.Read())
                                                                                            {
                                                                                                datas = "";
                                                                                                data = reader8.GetValue(0);
                                                                                                datas += '"' + Convert.ToString(data) + '"';
                                                                                                ClientDBCustomerId = datas;
                                                                                                var reportTypeId = (int)AppSettingsUtil.REPORT_TYPE.DATA_REPORT;
                                                                                                var salesStatus = (int)AppSettingsUtil.SALES_STATUS.ACTIVE;
                                                                                                var q = "INSERT INTO sales(Notes,PaymentMethod,InvoiceNumber,Cash,Cheque,CreditCards,CreditSales,OwnConsumption,DGTValue,InvoiceDate,TotalGrossAmount,VATReportingDate,ReferenceNumber,PaymentDate,ChequeNumber,Bank,AccountNumber,CreditCardType,IsEC,IsPaid,AccountantID,ReportTypeID,CustomerID,Status,ScannedInvoiceID) Values(" + Notes + "," + SaleType + "," + InvoiceNumber + "," + Cash + "," + Cheque + "," + CreditNotes + "," + CreditSales + "," + OwnConsumption + "," + DGTGross + "," + Date + "," + GrossAmount + "," + VATReportingDate + "," + ReferenceNo + "," + PaymentDate + "," + ChequeNumber + "," + BankName + "," + AcNumber + "," + CCType + "," + IsEC + "," + IsPaid + "," + AccountantId + "," + reportTypeId + "," + ClientDBCustomerId + "," + salesStatus + "," + 0 + "); ";
                                                                                                RunQueryClientDatabase(q);
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }

                                                                string cs7 = cs2 + MasterDBClientId;
                                                                string cs8 = cs2 + MasterDBClientId;
                                                                string cs9 = cs2 + MasterDBClientId;
                                                                string values;
                                                                object value;

                                                                object cafeSandwichBarAccountId;
                                                                object cafeSandwichBarSalesId;
                                                                object pharmacyAccountId;
                                                                object cafesandwichbarTransactionIdSaleItems = 0;
                                                                object pharmacyTransactionIdSaleItems = 0;

                                                                object pharmacySalesId;
                                                                using (MySqlConnection connection12 = new MySqlConnection(cs1))
                                                                {
                                                                    connection12.Open();
                                                                    using (MySqlCommand command12 = new MySqlCommand("SELECT AccountID FROM account Where IndustryTypeID = 8", connection12))
                                                                    {
                                                                        using (MySqlDataReader reader12 = command12.ExecuteReader())
                                                                        {
                                                                            while (reader12.Read())
                                                                            {
                                                                                data = reader12.GetValue(0);
                                                                                cafeSandwichBarAccountId = data = reader12.GetValue(0);
                                                                                using (MySqlConnection connection14 = new MySqlConnection(cs1))
                                                                                {
                                                                                    connection14.Open();
                                                                                    using (MySqlCommand command14 = new MySqlCommand("SELECT TransactionID FROM transaction Where AccountID =" + cafeSandwichBarAccountId, connection14))
                                                                                    {
                                                                                        using (MySqlDataReader reader14 = command14.ExecuteReader())
                                                                                        {
                                                                                            while (reader14.Read())
                                                                                            {
                                                                                                data = reader14.GetValue(0);
                                                                                                cafeSandwichBarTransactionId = data;
                                                                                                if (cafeSandwichBarTransactionId.Equals(TransactionId))
                                                                                                {
                                                                                                    cafesandwichbarTransactionIdSaleItems = TransactionId;
                                                                                                    using (MySqlConnection connection7 = new MySqlConnection(cs7))
                                                                                                    {
                                                                                                        connection7.Open();
                                                                                                        using (MySqlCommand command7 = new MySqlCommand("SELECT SalesID FROM sales ORDER BY SalesID DESC LIMIT 1", connection7))
                                                                                                        {
                                                                                                            using (MySqlDataReader reader7 = command7.ExecuteReader())
                                                                                                            {
                                                                                                                while (reader7.Read())
                                                                                                                {
                                                                                                                    values = "";
                                                                                                                    value = reader7.GetValue(0);
                                                                                                                    values = '"' + Convert.ToString(value) + '"';
                                                                                                                    cafeSandwichBarSalesId = values;
                                                                                                                    var q1 = "INSERT INTO salescafesandwichbar(HotItemValue,HotItemPercentage,ColdItemValue,ColdItemPercentage,TotalAmount,TotalAmountPercentage,SalesID) Values(" + CafeHotAmount + "," + CafeHotPercentage + "," + CafeColdAmount + "," + CafeColdPercentage + "," + totalAmount + "," + totalPercentage + "," + cafeSandwichBarSalesId + ");";
                                                                                                                    RunQueryClientDatabase(q1);
                                                                                                                    var cafeSandwichBarSalesType = '"' + AppSettingsUtil.SALES_TYPE_SALESCAFEANDSANDWICHBAR + '"';
                                                                                                                    var q3 = "UPDATE sales set SalesType =  " + cafeSandwichBarSalesType + " Where SalesID = " + cafeSandwichBarSalesId + " ";
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
                                                                using (MySqlConnection connection8 = new MySqlConnection(cs1))
                                                                {
                                                                    connection8.Open();
                                                                    using (MySqlCommand command8 = new MySqlCommand("SELECT AccountID FROM account Where IndustryTypeID = 5", connection8))
                                                                    {
                                                                        using (MySqlDataReader reader8 = command8.ExecuteReader())
                                                                        {
                                                                            while (reader8.Read())
                                                                            {
                                                                                data = reader8.GetValue(0);
                                                                                pharmacyAccountId = data;
                                                                                using (MySqlConnection connection9 = new MySqlConnection(cs1))
                                                                                {
                                                                                    connection9.Open();
                                                                                    using (MySqlCommand command9 = new MySqlCommand("SELECT TransactionID FROM transaction Where AccountID =" + pharmacyAccountId, connection9))
                                                                                    {
                                                                                        using (MySqlDataReader reader9 = command9.ExecuteReader())
                                                                                        {
                                                                                            while (reader9.Read())
                                                                                            {
                                                                                                data = reader9.GetValue(0);
                                                                                                pharmacyTransactionId = data;
                                                                                                if (pharmacyTransactionId.Equals(TransactionId))
                                                                                                {
                                                                                                    pharmacyTransactionIdSaleItems = TransactionId;
                                                                                                    using (MySqlConnection connection10 = new MySqlConnection(cs8))
                                                                                                    {
                                                                                                        connection10.Open();
                                                                                                        using (MySqlCommand command10 = new MySqlCommand("SELECT SalesID FROM sales ORDER BY SalesID DESC LIMIT 1", connection10))
                                                                                                        {
                                                                                                            using (MySqlDataReader reader10 = command10.ExecuteReader())
                                                                                                            {
                                                                                                                while (reader10.Read())
                                                                                                                {
                                                                                                                    data = reader10.GetValue(0);
                                                                                                                    pharmacySalesId = '"' + Convert.ToString(data) + '"';
                                                                                                                    var q2 = "INSERT INTO salespharmacy(PracticePayment,TaxablePracticePayment,TaxableOtherIncome,NHSChequeReceived,VATonTaxablePracticePayment,PrivatePrescriptions,NHSPrescription,SalesID,Status) Values(" + PracticePayment + "," + TaxablePracticePayment + "," + TaxableOtherIncome + "," + NHSchequeReceived + "," + VATNonTaxablePracticePayment + "," + PrivatePrescription + "," + NHSPrescription + "," + pharmacySalesId + "," + 1 + ");";
                                                                                                                    RunQueryClientDatabase(q2);
                                                                                                                    object pharmacyTreatmentSaleTransactionId;
                                                                                                                    using (MySqlConnection connection19 = new MySqlConnection(cs1))
                                                                                                                    {
                                                                                                                        connection19.Open();
                                                                                                                        using (MySqlCommand command19 = new MySqlCommand("SELECT SaleTransactionID FROM saletransaction Where TransactionID =" + TransactionId, connection19))
                                                                                                                        {
                                                                                                                            using (MySqlDataReader reader19 = command19.ExecuteReader())
                                                                                                                            {
                                                                                                                                while (reader19.Read())
                                                                                                                                {
                                                                                                                                    pharmacyTreatmentSaleTransactionId = reader19.GetValue(0);
                                                                                                                                    using (MySqlConnection connection11 = new MySqlConnection(cs1))
                                                                                                                                    {
                                                                                                                                        connection11.Open();
                                                                                                                                        using (MySqlCommand command11 = new MySqlCommand("SELECT Treatment,Elements,Value FROM salepharmacytreatment Where SaleTransactionID =" + pharmacyTreatmentSaleTransactionId, connection11))
                                                                                                                                        {
                                                                                                                                            using (MySqlDataReader reader11 = command11.ExecuteReader())
                                                                                                                                            {
                                                                                                                                                while (reader11.Read())
                                                                                                                                                {
                                                                                                                                                    datas = "";
                                                                                                                                                    for (int i = 0; i < reader11.FieldCount; i++)
                                                                                                                                                    {
                                                                                                                                                        data = reader11.GetValue(i);
                                                                                                                                                        if (datas != "")
                                                                                                                                                            datas += ",";
                                                                                                                                                        datas += '"' + Convert.ToString(data) + '"';
                                                                                                                                                    }
                                                                                                                                                    var q11 = "INSERT INTO salespharmacytreatment(Treatment,Elements,Value,SalesID) Values(" + datas + "," + pharmacySalesId + ");";
                                                                                                                                                    RunQueryClientDatabase(q11);
                                                                                                                                                    var cafePharmacySalesType = '"' + AppSettingsUtil.SALES_TYPE_SALESPHARMACY + '"';
                                                                                                                                                    var q3 = "UPDATE sales set SalesType =  " + cafePharmacySalesType + " Where SalesID = " + pharmacySalesId + " ";
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
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                string cs5 = cs2 + MasterDBClientId;
                                                                object saleTransactionId;
                                                                using (MySqlConnection connection5 = new MySqlConnection(cs1))
                                                                {
                                                                    connection5.Open();
                                                                    using (MySqlCommand command15 = new MySqlCommand("SELECT SaleTransactionID FROM saletransaction Where TransactionID =" + TransactionId + " AND TransactionID != " + pharmacyTransactionIdSaleItems + " AND TransactionID != " + cafesandwichbarTransactionIdSaleItems, connection5))
                                                                    {
                                                                        using (MySqlDataReader reader15 = command15.ExecuteReader())
                                                                        {
                                                                            while (reader15.Read())
                                                                            {
                                                                                saleTransactionId = reader15.GetValue(0);
                                                                                SaleTransactionItemTableDataMigration(saleTransactionId, TransactionId, MasterDBClientId);
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                using (MySqlConnection connection4 = new MySqlConnection(cs5))
                                                                {
                                                                    connection4.Open();
                                                                    using (MySqlCommand command4 = new MySqlCommand("SELECT SalesID FROM sales ORDER BY SalesID DESC LIMIT 1", connection4))
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
                                                                                SalesId = datas;
                                                                                var encodedID = AppSettingsUtil.Encode(Convert.ToString(SalesId));
                                                                                var encodedIDValue = '"' + Convert.ToString(encodedID) + '"';
                                                                                var dailyGrossTakingSalesType = '"' + AppSettingsUtil.SALES_TYPE_SALESDAILYGROSSTAKING + '"';
                                                                                var q3 = "UPDATE sales set EncodedSalesID =  " + encodedIDValue + " Where SalesID = " + SalesId + " ";
                                                                                RunQueryClientDatabase(q3);
                                                                                var q4 = "UPDATE sales set SalesType =  " + dailyGrossTakingSalesType + " Where SalesID = " + SalesId + " AND SalesType IS NULL";
                                                                                RunQueryClientDatabase(q4);
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
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }

        }

        public static void SaleTransactionTableDataMigrationForNormalSales()
        {
            int index = 0;
            string Notes, SaleType, InvoiceNumber, Cash, Cheque, CreditNotes, CreditSales, OwnConsumption, DGTGross, Date, GrossAmount, VATReportingDate, ReferenceNo, PaymentDate, ChequeNumber, BankName, AcNumber, CCType, IsEC, IsPaid;
            object normalSaleTransactionId;

            try
            {
                GetMasterClientIdListForNormalSaleTransaction();

                using (MySqlConnection connection20 = new MySqlConnection(cs1))
                {
                    connection20.Open();
                    using (MySqlCommand command20 = new MySqlCommand("SELECT TransactionID FROM transaction Where Type = 'Sale' ORDER BY TransactionID ASC", connection20))
                    {
                        using (MySqlDataReader reader20 = command20.ExecuteReader())
                        {
                            while (reader20.Read())
                            {
                                normalSaleTransactionId = reader20.GetValue(0);
                                using (MySqlConnection connection = new MySqlConnection(cs1))
                                {
                                    connection.Open();
                                    using (MySqlCommand command = new MySqlCommand("SELECT TransactionID FROM saletransaction Where TransactionID =" + normalSaleTransactionId, connection))
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
                                                    using (MySqlCommand command1 = new MySqlCommand("SELECT saletransaction.Notes,saletransaction.SaleType,saletransaction.InvoiceNumber,saletransaction.Cash,saletransaction.Cheque,saletransaction.CreditNotes,saletransaction.CreditSales,saletransaction.OwnConsumption,saletransaction.DGTGross,transaction.Date,transaction.GrossAmount,transaction.VATReportingDate,transaction.ReferenceNo,transaction.PaymentDate,transaction.ChequeNumber,transaction.BankName,transaction.AcNumber,transaction.CCType,transaction.IsEC,transaction.IsPaid FROM saletransaction LEFT JOIN transaction ON saletransaction.TransactionID = transaction.TransactionID Where saletransaction.TransactionID =" + TransactionId, connection2))
                                                    {
                                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                                        {
                                                            while (reader1.Read())
                                                            {
                                                                Notes = "";
                                                                SaleType = "";
                                                                InvoiceNumber = "";
                                                                Cash = "";
                                                                Cheque = "";
                                                                CreditNotes = "";
                                                                CreditSales = "";
                                                                OwnConsumption = "";
                                                                DGTGross = "";
                                                                Date = "";
                                                                GrossAmount = "";
                                                                VATReportingDate = "";
                                                                ReferenceNo = "";
                                                                PaymentDate = "";
                                                                ChequeNumber = "";
                                                                BankName = "";
                                                                AcNumber = "";
                                                                CCType = "";
                                                                IsEC = "";
                                                                IsPaid = "";
                                                                for (int i = 0; i < reader1.FieldCount; i++)
                                                                {
                                                                    data = reader1.GetValue(i);
                                                                    if (i == 0)
                                                                        Notes += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 1)
                                                                        SaleType += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 2)
                                                                        InvoiceNumber += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 3)
                                                                        Cash += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 4)
                                                                        Cheque += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 5)
                                                                        CreditNotes += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 6)
                                                                        CreditSales += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 7)
                                                                        OwnConsumption += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 8)
                                                                        DGTGross += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 9)
                                                                    {
                                                                        // Changing the format of date
                                                                        var date = (DateTime)data;
                                                                        Date += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                                                    }
                                                                    if (i == 10)
                                                                        GrossAmount += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 11)
                                                                    {
                                                                        // Changing the format of date
                                                                        var date = (DateTime)data;
                                                                        VATReportingDate += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                                                    }
                                                                    if (i == 12)
                                                                        ReferenceNo += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 13)
                                                                    {
                                                                        // Changing the format of date
                                                                        var date = (DateTime)data;
                                                                        PaymentDate += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                                                    }
                                                                    if (i == 14)
                                                                        ChequeNumber += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 15)
                                                                        BankName += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 16)
                                                                        AcNumber += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 17)
                                                                        CCType += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 18)
                                                                        IsEC += '"' + Convert.ToString(data) + '"';
                                                                    if (i == 19)
                                                                        IsPaid += '"' + Convert.ToString(data) + '"';
                                                                }
                                                                string cs7 = cs2 + MasterDBClientId;
                                                                string cs8 = cs2 + MasterDBClientId;
                                                                string cs9 = cs2 + MasterDBClientId;
                                                                string cs5 = cs2 + MasterDBClientId;
                                                                string cs6 = cs2 + MasterDBClientId;
                                                                using (MySqlConnection connection3 = new MySqlConnection(cs1))
                                                                {
                                                                    connection3.Open();
                                                                    using (MySqlCommand command3 = new MySqlCommand("SELECT CustomerID FROM saletransaction Where TransactionID =" + TransactionId, connection3))
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
                                                                                SourceDBCustomerId = datas;
                                                                                using (MySqlConnection connection8 = new MySqlConnection(cs6))
                                                                                {
                                                                                    connection8.Open();
                                                                                    using (MySqlCommand command8 = new MySqlCommand("SELECT ClientCustomerID FROM temporarycustomeridassociation Where SourceCustomerID =" + SourceDBCustomerId, connection8))
                                                                                    {
                                                                                        using (MySqlDataReader reader8 = command8.ExecuteReader())
                                                                                        {
                                                                                            while (reader8.Read())
                                                                                            {
                                                                                                datas = "";
                                                                                                data = reader8.GetValue(0);
                                                                                                datas += '"' + Convert.ToString(data) + '"';
                                                                                                ClientDBCustomerId = datas;
                                                                                                var reportTypeId = (int)AppSettingsUtil.REPORT_TYPE.DATA_REPORT;
                                                                                                var salesType = '"' + AppSettingsUtil.SALES_TYPE_SALESNORMAL + '"';
                                                                                                var salesStatus = (int)AppSettingsUtil.SALES_STATUS.ACTIVE;
                                                                                                var q = "INSERT INTO sales(Notes,PaymentMethod,InvoiceNumber,Cash,Cheque,CreditCards,CreditSales,OwnConsumption,DGTValue,InvoiceDate,TotalGrossAmount,VATReportingDate,ReferenceNumber,PaymentDate,ChequeNumber,Bank,AccountNumber,CreditCardType,IsEC,IsPaid,AccountantID,ReportTypeID,CustomerID,SalesType,Status) Values(" + Notes + "," + SaleType + "," + InvoiceNumber + "," + Cash + "," + Cheque + "," + CreditNotes + "," + CreditSales + "," + OwnConsumption + "," + DGTGross + "," + Date + "," + GrossAmount + "," + VATReportingDate + "," + ReferenceNo + "," + PaymentDate + "," + ChequeNumber + "," + BankName + "," + AcNumber + "," + CCType + "," + IsEC + "," + IsPaid + "," + AccountantId + "," + reportTypeId + "," + ClientDBCustomerId + "," + salesType + "," + salesStatus + "); ";
                                                                                                RunQueryClientDatabase(q);
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                object saleTransactionId;
                                                                using (MySqlConnection connection5 = new MySqlConnection(cs1))
                                                                {
                                                                    connection5.Open();
                                                                    using (MySqlCommand command15 = new MySqlCommand("SELECT SaleTransactionID FROM saletransaction Where TransactionID =" + TransactionId, connection5))
                                                                    {
                                                                        using (MySqlDataReader reader15 = command15.ExecuteReader())
                                                                        {
                                                                            while (reader15.Read())
                                                                            {
                                                                                saleTransactionId = reader15.GetValue(0);
                                                                                SaleTransactionItemTableDataMigrationForNormalSales(saleTransactionId, TransactionId, MasterDBClientId);
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                using (MySqlConnection connection4 = new MySqlConnection(cs5))
                                                                {
                                                                    connection4.Open();
                                                                    using (MySqlCommand command4 = new MySqlCommand("SELECT SalesID FROM sales ORDER BY SalesID DESC LIMIT 1", connection4))
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
                                                                                SalesId = datas;
                                                                                var encodedID = AppSettingsUtil.Encode(Convert.ToString(SalesId));
                                                                                var encodedIDValue = '"' + Convert.ToString(encodedID) + '"';
                                                                                var q3 = "UPDATE sales set EncodedSalesID =  " + encodedIDValue + " Where SalesID = " + SalesId + " ";
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
                                    else if (data.ToString().Contains("SaleDailyTaking") || data.ToString().Contains("Sale"))
                                    {
                                        data = "Sales";
                                        datas += '"' + Convert.ToString(data) + '"';
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
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT SalesID FROM sales ORDER BY SalesID DESC LIMIT 1", connection1))
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
                                    else if (data.ToString().Contains("SaleDailyTaking") || data.ToString().Contains("Sale"))
                                    {
                                        data = "Sales";
                                        datas += '"' + Convert.ToString(data) + '"';
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
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT SalesID FROM sales ORDER BY SalesID DESC LIMIT 1", connection1))
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

        private static void SaleTransactionItemTableDataMigration(object saleTransactionId, object transactionId, object masterDBClientId)
        {
            string cs7 = cs2 + masterDBClientId;
            string cs8 = cs2 + masterDBClientId;
            string cs9 = cs2 + masterDBClientId;
            string cs10 = cs2 + masterDBClientId;
            object salesItemsSalesID;
            object saleTransactionItemId;

            try
            {
                using (MySqlConnection connection10 = new MySqlConnection(cs1))
                {
                    connection10.Open();
                    using (MySqlCommand command10 = new MySqlCommand("SELECT SaleTransactionItemID FROM saletransactionitem Where SaleTransactionID =" + saleTransactionId, connection10))
                    {
                        using (MySqlDataReader reader10 = command10.ExecuteReader())
                        {
                            while (reader10.Read())
                            {
                                saleTransactionItemId = reader10.GetValue(0);
                                using (MySqlConnection connection7 = new MySqlConnection(cs7))
                                {
                                    connection7.Open();
                                    using (MySqlCommand command7 = new MySqlCommand("SELECT SalesID FROM sales ORDER BY SalesID DESC LIMIT 1", connection7))
                                    {
                                        using (MySqlDataReader reader7 = command7.ExecuteReader())
                                        {
                                            while (reader7.Read())
                                            {
                                                salesItemsSalesID = reader7.GetValue(0);
                                                using (MySqlConnection connection = new MySqlConnection(cs1))
                                                {
                                                    connection.Open();
                                                    using (MySqlCommand command = new MySqlCommand("SELECT NettAmount,GrossAmount,ItemType,Commission FROM saletransactionitem where SaleTransactionID =" + saleTransactionId + " AND SaleTransactionItemID =" + saleTransactionItemId, connection))
                                                    {
                                                        using (MySqlDataReader reader = command.ExecuteReader())
                                                        {
                                                            datas = "";
                                                            while (reader.Read())
                                                            {
                                                                for (int i = 0; i < reader.FieldCount; i++)
                                                                {
                                                                    data = reader.GetValue(i);
                                                                    if (datas != "")
                                                                        datas += ",";
                                                                    datas += '"' + Convert.ToString(data) + '"';
                                                                }
                                                                using (MySqlConnection connection15 = new MySqlConnection(cs1))
                                                                {
                                                                    connection15.Open();
                                                                    object itemTypeValue = 0;
                                                                    object itemTypeIdValue = 0;
                                                                    object description;
                                                                    string itemNameValue;
                                                                    object value;
                                                                    string values;
                                                                    using (MySqlCommand command15 = new MySqlCommand("SELECT ItemType,ItemTypeID FROM saletransactionitem where SaleTransactionID =" + saleTransactionId, connection15))
                                                                    {
                                                                        using (MySqlDataReader reader15 = command15.ExecuteReader())
                                                                        {
                                                                            while (reader15.Read())
                                                                            {
                                                                                for (int i = 0; i < reader15.FieldCount; i++)
                                                                                {
                                                                                    itemTypeValue = reader15.GetValue(0);
                                                                                    itemTypeIdValue = reader15.GetValue(1);
                                                                                    if ((int)itemTypeValue == 1)
                                                                                    {
                                                                                        using (MySqlConnection connection16 = new MySqlConnection(cs1))
                                                                                        {
                                                                                            connection16.Open();
                                                                                            using (MySqlCommand command16 = new MySqlCommand("SELECT Description FROM exemptitems Where ExemptItemID =" + itemTypeIdValue, connection16))
                                                                                            {
                                                                                                using (MySqlDataReader reader16 = command16.ExecuteReader())
                                                                                                {
                                                                                                    while (reader16.Read())
                                                                                                    {
                                                                                                        itemNameValue = "";
                                                                                                        description = reader16.GetValue(0);
                                                                                                        itemNameValue = '"' + Convert.ToString(description) + '"';

                                                                                                        using (MySqlConnection connection17 = new MySqlConnection(cs8))
                                                                                                        {
                                                                                                            connection17.Open();
                                                                                                            using (MySqlCommand command17 = new MySqlCommand("SELECT ItemTypeDetailsID FROM ItemTypeDetails Where ItemName =" + itemNameValue + " AND ItemTypeID =" + itemTypeValue, connection17))
                                                                                                            {
                                                                                                                using (MySqlDataReader reader17 = command17.ExecuteReader())
                                                                                                                {
                                                                                                                    while (reader17.Read())
                                                                                                                    {
                                                                                                                        values = "";
                                                                                                                        value = reader17.GetValue(0);
                                                                                                                        values = '"' + Convert.ToString(value) + '"';
                                                                                                                        var q1 = "INSERT INTO salesitems(NettAmount,GrossAmount,ItemTypeID,Commission,SalesID,ItemTypeDetailsID) Values(" + datas + "," + salesItemsSalesID + "," + values + "); ";
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
                                                                                    if ((int)itemTypeValue == 2)
                                                                                    {
                                                                                        using (MySqlConnection connection16 = new MySqlConnection(cs1))
                                                                                        {
                                                                                            connection16.Open();
                                                                                            using (MySqlCommand command16 = new MySqlCommand("SELECT Description FROM zerorateditems Where ZeroRatedItemID =" + itemTypeIdValue, connection16))
                                                                                            {
                                                                                                using (MySqlDataReader reader16 = command16.ExecuteReader())
                                                                                                {
                                                                                                    while (reader16.Read())
                                                                                                    {
                                                                                                        itemNameValue = "";
                                                                                                        description = reader16.GetValue(0);
                                                                                                        itemNameValue = '"' + Convert.ToString(description) + '"';

                                                                                                        using (MySqlConnection connection17 = new MySqlConnection(cs8))
                                                                                                        {
                                                                                                            connection17.Open();
                                                                                                            using (MySqlCommand command17 = new MySqlCommand("SELECT ItemTypeDetailsID FROM ItemTypeDetails Where ItemName =" + itemNameValue + " AND ItemTypeID =" + itemTypeValue, connection17))
                                                                                                            {
                                                                                                                using (MySqlDataReader reader17 = command17.ExecuteReader())
                                                                                                                {
                                                                                                                    while (reader17.Read())
                                                                                                                    {
                                                                                                                        values = "";
                                                                                                                        value = reader17.GetValue(0);
                                                                                                                        values = '"' + Convert.ToString(value) + '"';
                                                                                                                        var q1 = "INSERT INTO salesitems(NettAmount,GrossAmount,ItemTypeID,Commission,SalesID,ItemTypeDetailsID) Values(" + datas + "," + salesItemsSalesID + "," + values + "); ";
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
                                                                                    if ((int)itemTypeValue == 3)
                                                                                    {
                                                                                        using (MySqlConnection connection16 = new MySqlConnection(cs1))
                                                                                        {
                                                                                            connection16.Open();
                                                                                            using (MySqlCommand command16 = new MySqlCommand("SELECT Description FROM exemptitemsnon Where ExemptItemNonID =" + itemTypeIdValue, connection16))
                                                                                            {
                                                                                                using (MySqlDataReader reader16 = command16.ExecuteReader())
                                                                                                {
                                                                                                    while (reader16.Read())
                                                                                                    {
                                                                                                        itemNameValue = "";
                                                                                                        description = reader16.GetValue(0);
                                                                                                        itemNameValue = '"' + Convert.ToString(description) + '"';

                                                                                                        using (MySqlConnection connection17 = new MySqlConnection(cs8))
                                                                                                        {
                                                                                                            connection17.Open();
                                                                                                            using (MySqlCommand command17 = new MySqlCommand("SELECT ItemTypeDetailsID FROM ItemTypeDetails Where ItemName =" + itemNameValue + " AND ItemTypeID =" + itemTypeValue, connection17))
                                                                                                            {
                                                                                                                using (MySqlDataReader reader17 = command17.ExecuteReader())
                                                                                                                {
                                                                                                                    while (reader17.Read())
                                                                                                                    {
                                                                                                                        values = "";
                                                                                                                        value = reader17.GetValue(0);
                                                                                                                        values = '"' + Convert.ToString(value) + '"';
                                                                                                                        var q1 = "INSERT INTO salesitems(NettAmount,GrossAmount,ItemTypeID,Commission,SalesID,ItemTypeDetailsID) Values(" + datas + "," + salesItemsSalesID + "," + values + "); ";
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

        private static void SaleTransactionItemTableDataMigrationForNormalSales(object saleTransactionId, object transactionId, object masterDBClientId)
        {
            string cs7 = cs2 + masterDBClientId;
            object salesItemsSalesID;

            try
            {
                using (MySqlConnection connection7 = new MySqlConnection(cs7))
                {
                    connection7.Open();
                    using (MySqlCommand command7 = new MySqlCommand("SELECT SalesID FROM sales ORDER BY SalesID DESC LIMIT 1", connection7))
                    {
                        using (MySqlDataReader reader7 = command7.ExecuteReader())
                        {
                            while (reader7.Read())
                            {
                                salesItemsSalesID = reader7.GetValue(0);
                                using (MySqlConnection connection = new MySqlConnection(cs1))
                                {
                                    connection.Open();
                                    using (MySqlCommand command = new MySqlCommand("SELECT Description,Quantity,UnitCost,RateType,NettAmount,GrossAmount FROM saletransactionitem where SaleTransactionID =" + saleTransactionId, connection))
                                    {
                                        using (MySqlDataReader reader = command.ExecuteReader())
                                        {
                                            datas = "";
                                            while (reader.Read())
                                            {
                                                for (int i = 0; i < reader.FieldCount; i++)
                                                {
                                                    data = reader.GetValue(i);
                                                    if (datas != "")
                                                        datas += ",";
                                                    datas += '"' + Convert.ToString(data) + '"';
                                                }
                                                var q1 = "INSERT INTO salesnormal(ItemDescription,Quantity,UnitCost,VATRate,NettAmount,GrossAmount,SalesID) Values(" + datas + "," + salesItemsSalesID + "); ";
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

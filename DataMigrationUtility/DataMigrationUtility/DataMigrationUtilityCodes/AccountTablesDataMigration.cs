
using DataMigrationUtility.Utility;
using ImageMagick;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Security;
using WebAccounting.Lib.Utility;
using System.Web.WebPages;

namespace DataMigrationUtility.DataMigrationUtilityCodes
{
    class AccountTablesDataMigration
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
        static List<object> clientIdListMasterDatabase = new List<object>();

        public static void GetMasterClientIdListForAccountFuelChargeDetails()
        {
            object data;
            string datas = "";
            try
            {
                using (MySqlConnection connection6 = new MySqlConnection(cs1))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT AccountID FROM accountfuelchargedetails ORDER BY AccountID ASC", connection6))
                    {
                        using (MySqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                data = reader.GetValue(0);
                                datas += '"' + Convert.ToString(data) + '"';
                                AccountId = datas;
                                using (MySqlConnection connection = new MySqlConnection(cs))
                                {
                                    connection.Open();
                                    using (MySqlCommand command = new MySqlCommand("SELECT ClientID FROM temporaryoldnewclientidsassociation Where AccountID = " + AccountId + "ORDER BY ClientID ASC", connection))
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

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }

        }

        public static void GetMasterClientIdListForAccountDocument()
        {
            object data;
            string datas = "";

            try
            {
                using (MySqlConnection connection6 = new MySqlConnection(cs1))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT AccountID FROM accountdocument ORDER BY AccountID ASC", connection6))
                    {
                        using (MySqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                data = reader.GetValue(0);
                                datas += '"' + Convert.ToString(data) + '"';
                                AccountId = datas;
                                using (MySqlConnection connection = new MySqlConnection(cs))
                                {
                                    connection.Open();
                                    using (MySqlCommand command = new MySqlCommand("SELECT ClientID FROM temporaryoldnewclientidsassociation Where AccountID = " + AccountId + "ORDER BY ClientID ASC", connection))
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

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }

        }

        public static void GetMasterClientIdListForAccountOpeningClosingStock()
        {
            object data;
            string datas = "";

            try
            {
                using (MySqlConnection connection6 = new MySqlConnection(cs1))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT AccountID FROM accountopeningclosingstock ORDER BY AccountID ASC", connection6))
                    {
                        using (MySqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                data = reader.GetValue(0);
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

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }
        }

        public static void AccountDocumentTableDataMigration()
        {
            int index = 0;
            string Name;
            string FileGUID; 
            string CreateDate; 

            try
            {
                GetMasterClientIdListForAccountDocument();
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM accountdocument ORDER BY AccountID ASC", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);
                                MasterDBClientId = clientIdListMasterDatabase.ElementAt(index++);
                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT Name,FileGUID,CreateDate FROM accountdocument Where AccountID =" + ClientId + " AND Type = 2", connection2))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                Name = "";
                                                FileGUID = "";
                                                CreateDate = "";

                                                for (int i = 0; i < reader1.FieldCount; i++)
                                                {
                                                    data = reader1.GetValue(i);
                                                    if (i == 0)
                                                        Name += '"' + Convert.ToString(data) + '"';
                                                    if (i == 1)
                                                        FileGUID += Convert.ToString(data);
                                                    if(i == 2)
                                                    {
                                                        var date = (DateTime)data;
                                                        CreateDate += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                                    }
                                                        
                                                }
                                                var count = UploadUncategorizedImageInAWS(MasterDBClientId, ClientId, Name, FileGUID, CreateDate);
                                                if (count == 0)
                                                {
                                                    var transactionTypeforScannedInvoice = '"' + AppSettingsUtil.UNCATEGORIZED_INVOICE + '"';
                                                    var invoiceStatus = (int)AppSettingsUtil.SCANNEDINVOICE_STATUS.Pending;
                                                    var fileGuid = '"' + FileGUID + '"';
                                                    var q = "INSERT INTO scannedinvoice(GUID,FileGuid,ScannedDate,TransactionType,IsUploadedFromApp,Status) Values(" + Name + "," + fileGuid + "," + CreateDate + "," + transactionTypeforScannedInvoice + "," + "false" + "," + invoiceStatus + "); ";
                                                    RunQueryClientDatabase(q);
                                                    string message = "This image is not present in the folder containing images for vataccountant --- " + Name;
                                                    Program.LoggingForImagesNotPresentInFolder(message);
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

        public static void AccountDocumentTableDataMigrationForRecordTable()
        {
            int index = 0;
            string Name;
            string FileGUID;
            string CreateDate;

            try
            {
                GetMasterClientIdListForAccountDocument();
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM accountdocument ORDER BY AccountID ASC", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);
                                MasterDBClientId = clientIdListMasterDatabase.ElementAt(index++);
                                string transferYear = "";
                                string transferMonth = "";
                                string Month = "";
                                string Year = "";
                                string Day = "";
                                int count;

                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT Name,FileGUID,CreateDate FROM accountdocument Where AccountID =" + ClientId + " AND Type = 0 ", connection2))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                count = 0;
                                                Name = "";
                                                FileGUID = "";
                                                CreateDate = "";

                                                for (int i = 0; i < reader1.FieldCount; i++)
                                                {
                                                    data = reader1.GetValue(i);
                                                    if (i == 0)
                                                        Name += '"' + Convert.ToString(data) + '"';
                                                    if (i == 1)
                                                        FileGUID += Convert.ToString(data);
                                                    if (i == 2)
                                                    {
                                                        // Changing the format of date
                                                        var date = (DateTime)data;
                                                        CreateDate += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                                        var sDate = date.ToString("yyyy-MM-dd");
                                                        string[] Words = sDate.Split(new char[] { '-' });
                                                        foreach (string Word in Words)
                                                        {
                                                            count += 1;
                                                            if (count == 1)
                                                            {
                                                                Year = Word;
                                                                transferYear = '"' + Year + '"';
                                                            }
                                                            if (count == 2)
                                                            {
                                                                Month = Word;
                                                                if (Month.Contains("1"))
                                                                    Month = "Jan";
                                                                if (Month.Contains("2"))
                                                                    Month = "Feb";
                                                                if (Month.Contains("3"))
                                                                    Month = "Mar";
                                                                if (Month.Contains("4"))
                                                                    Month = "Apr";
                                                                if (Month.Contains("5"))
                                                                    Month = "May";
                                                                if (Month.Contains("6"))
                                                                    Month = "Jun";
                                                                if (Month.Contains("7"))
                                                                    Month = "Jul";
                                                                if (Month.Contains("8"))
                                                                    Month = "Aug";
                                                                if (Month.Contains("9"))
                                                                    Month = "Sep";
                                                                if (Month.Contains("10"))
                                                                    Month = "Oct";
                                                                if (Month.Contains("11"))
                                                                    Month = "Nov";
                                                                if (Month.Contains("12"))
                                                                    Month = "Dec";
                                                                transferMonth = '"' + Month + '"';
                                                            }
                                                            if (count == 3) { Day = Word; }
                                                        }
                                                    }
                                                }
                                                var c = UploadRecordImageInAWS(MasterDBClientId, ClientId, Name, FileGUID, CreateDate, transferYear, transferMonth);
                                                if (c == 0)
                                                {
                                                    var transactionType = '"' + AppSettingsUtil.RECORD_TRANSACTION_TYPE_RECORD + '"';
                                                    var invoiceStatus = (int)AppSettingsUtil.SCANNEDINVOICE_STATUS.Pending;
                                                    var fileGuid = '"' + FileGUID + '"';
                                                    var q = "INSERT INTO record(GUID,FileGuid,TransfreDate,TransactionType,TransferYear,TransferMonth,Status) Values(" + Name + "," + fileGuid + "," + CreateDate + "," + transactionType + "," + transferYear + "," + transferMonth + "," + invoiceStatus + "); ";
                                                    RunQueryClientDatabase(q);
                                                    string message = "This image is not present in the folder containing images for vataccountant --- " + Name;
                                                    Program.LoggingForImagesNotPresentInFolder(message);
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

        public static void AccountDocumentTableBankStatementDataMigrationForRecordTable()
        {
            int index = 0;

            string Name;
            string FileGUID;
            string CreateDate;

            try
            {
                GetMasterClientIdListForAccountDocument();
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM accountdocument ORDER BY AccountID ASC", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientId = reader.GetValue(0);
                                MasterDBClientId = clientIdListMasterDatabase.ElementAt(index++);
                                string transferYear = "";
                                string transferMonth = "";
                                string Month = "";
                                string Year = "";
                                string Day = "";
                                int count;

                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT Name,FileGUID,CreateDate FROM accountdocument Where AccountID =" + ClientId + " AND Type = 1 ", connection2))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                count = 0;
                                                Name = "";
                                                FileGUID = "";
                                                CreateDate = "";

                                                for (int i = 0; i < reader1.FieldCount; i++)
                                                {
                                                    data = reader1.GetValue(i);
                                                    if (i == 0)
                                                        Name += '"' + Convert.ToString(data) + '"';
                                                    if (i == 1)
                                                        FileGUID += Convert.ToString(data);
                                                    if (i == 2)
                                                    {
                                                        // Changing the format of date
                                                        var date = (DateTime)data;
                                                        CreateDate += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                                        var sDate = date.ToString("yyyy-MM-dd");
                                                        string[] Words = sDate.Split(new char[] { '-' });
                                                        foreach (string Word in Words)
                                                        {
                                                            count += 1;
                                                            if (count == 1)
                                                            {
                                                                Year = Word;
                                                                transferYear = '"' + Year + '"';
                                                            }
                                                            if (count == 2)
                                                            {
                                                                Month = Word;
                                                                if (Month.Contains("1"))
                                                                    Month = "Jan";
                                                                if (Month.Contains("2"))
                                                                    Month = "Feb";
                                                                if (Month.Contains("3"))
                                                                    Month = "Mar";
                                                                if (Month.Contains("4"))
                                                                    Month = "Apr";
                                                                if (Month.Contains("5"))
                                                                    Month = "May";
                                                                if (Month.Contains("6"))
                                                                    Month = "Jun";
                                                                if (Month.Contains("7"))
                                                                    Month = "Jul";
                                                                if (Month.Contains("8"))
                                                                    Month = "Aug";
                                                                if (Month.Contains("9"))
                                                                    Month = "Sep";
                                                                if (Month.Contains("10"))
                                                                    Month = "Oct";
                                                                if (Month.Contains("11"))
                                                                    Month = "Nov";
                                                                if (Month.Contains("12"))
                                                                    Month = "Dec";
                                                                transferMonth = '"' + Month + '"';
                                                            }
                                                            if (count == 3) { Day = Word; }
                                                        }
                                                    }
                                                }
                                                var c = UploadBankStatementImageInAWS(MasterDBClientId, ClientId, Name, FileGUID, CreateDate, transferYear, transferMonth);
                                                if (c == 0)
                                                {
                                                    var transactionType = '"' + AppSettingsUtil.RECORD_TRANSACTION_TYPE_BANKSTATEMENT + '"';
                                                    var invoiceStatus = (int)AppSettingsUtil.SCANNEDINVOICE_STATUS.Pending;
                                                    var fileGuid = '"' + FileGUID + '"';
                                                    var q = "INSERT INTO record(GUID,FileGuid,TransfreDate,TransactionType,TransferYear,TransferMonth,Status) Values(" + Name + "," + fileGuid + "," + CreateDate + "," + transactionType + "," + transferYear + "," + transferMonth + "," + invoiceStatus + "); ";
                                                    RunQueryClientDatabase(q);
                                                    string message = "This image is not present in the folder containing images for vataccountant --- " + Name;
                                                    Program.LoggingForImagesNotPresentInFolder(message);
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

        public static void AccountFuelChargeDetails()
        {
            int index = 0;

            try
            {
                GetMasterClientIdListForAccountFuelChargeDetails();
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM accountfuelchargedetails ORDER BY AccountID ASC", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);
                                MasterDBClientId = clientIdListMasterDatabase.ElementAt(index++);
                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT Make,RegistrationNumber,PurchaseDate,CO2EmissionBand,Owned_HP FROM accountfuelchargedetails Where AccountID =" + ClientId, connection2))
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
                                                var q = "INSERT INTO clientfuelchargedetails(Make,RegistrationNumber,PurchaseDate,CO2EmissionBand,OwnedHP) Values(" + datas + "); ";
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

        public static void AccountOpeningClosingStockTableDataMigration()
        {
            int index = 0;

            try
            {
                GetMasterClientIdListForAccountOpeningClosingStock();
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM accountopeningclosingstock ORDER BY AccountID ASC", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);
                                MasterDBClientId = clientIdListMasterDatabase.ElementAt(index++);
                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT OpeningStock,ClosingStock,CreateDate,ProfitMargin FROM accountopeningclosingstock Where AccountID =" + ClientId, connection2))
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
                                                var q = "INSERT INTO openingclosingstock(OpeningStock,ClosingStock,CreateDate,ProfitMargin) Values(" + datas + "); ";
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

        public static int UploadUncategorizedImageInAWS(object clientID, object AccountId, string Name, string FileGUID, string CreateDate)
        {
            AmazonS3Util amazonS3 = new AmazonS3Util();
            int clientId;
            string key = "";
            string transactionType = "";
            clientId = (int)clientID;
            object VatNumber;
            int UploadedImageCount = 0;
            int notUploadedImageCount = 0;
            object AccountIdForImageUpload = AccountId;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT VATNumber FROM account Where AccountId = " + AccountIdForImageUpload, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VatNumber = reader.GetValue(0);
                                try
                                {
                                    List<String> Files = new List<String>();
                                    foreach (string file in Directory.GetFiles(@"D:\VATScanImages\VATScan\DocStorage\" + VatNumber + "\\ScannedInvoice"))
                                    {
                                        Files.Add(file);
                                    }

                                    for (int i = 0; i < Files.Count; i++)
                                    {
                                        string fileName;
                                        string nameWithoutExtension = Name.Replace(".tif", "");
                                        fileName = Path.GetFileName(Files[i]);
                                        string fileNameWithoutExtension = '"' + Path.GetFileNameWithoutExtension(Files[i]) + '"';

                                        if (fileNameWithoutExtension.Equals(nameWithoutExtension))
                                        {

                                            //Get the file Extension
                                            string fileExtenSion = Path.GetExtension(fileName);

                                            FileStream fileStream = new FileStream(Files[i], FileMode.Open, FileAccess.Read);

                                            if (fileExtenSion == ".jpeg" || fileExtenSion == ".jpg" || fileExtenSion == ".tif" || fileExtenSion == ".tiff")
                                            {
                                                byte[] buffer = new byte[fileStream.Length];
                                                //Get the complete folder path and store the file inside it.  

                                                if (fileExtenSion == ".tif" || fileExtenSion == ".tiff")
                                                {
                                                    fileName = Path.ChangeExtension(fileName, ".jpeg");
                                                }

                                                fileStream.Read(buffer, 0, buffer.Length);

                                                MemoryStream ms = new MemoryStream(buffer, true);

                                                Image newImage = Image.FromStream(ms);
                                                var width = newImage.Width;
                                                var height = newImage.Height;

                                                System.IO.Stream stream = new System.IO.MemoryStream();

                                                using (MagickImage magickImage = new MagickImage(buffer))
                                                {
                                                    magickImage.Quality = 10;
                                                    magickImage.Resize(width, height);
                                                    magickImage.Format = MagickFormat.Jpeg;
                                                    magickImage.Write(stream);
                                                }

                                                key = FileGUID.ToString() + fileName;
                                                transactionType = AppSettingsUtil.UNCATEGORIZED_INVOICE;

                                                string imageName = fileName;
                                                string sourceObjectKey = fileName;
                                                FileGUID = fileName;
                                                Name = key;

                                                // Upload Image to Cloud
                                                amazonS3.UploadImagesToS3ByTransferUtil(transactionType, clientId, imageName, sourceObjectKey, key, stream);
                                                var transactionTypeforScannedInvoice = '"' + AppSettingsUtil.UNCATEGORIZED_INVOICE + '"';
                                                var invoiceStatus = (int)AppSettingsUtil.SCANNEDINVOICE_STATUS.Pending;
                                                var fileGuid = '"' + FileGUID + '"';
                                                var guidName = '"' + Name + '"';
                                                var q = "INSERT INTO scannedinvoice(GUID,FileGuid,ScannedDate,TransactionType,IsUploadedFromApp,Status) Values(" + guidName + "," + fileGuid + "," + CreateDate + "," + transactionTypeforScannedInvoice + "," + "false" + "," + invoiceStatus + "); ";
                                                RunQueryClientDatabase(q);
                                                UploadedImageCount++;
                                            }
                                        }
                                        else
                                            notUploadedImageCount++;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Program.ErrorLogging(ex);
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

            if (UploadedImageCount >= 1)
                return 1;
            else
                return 0;
        }

        public static int UploadRecordImageInAWS(object clientID, object AccountId, string Name, string FileGUID, string CreateDate, string transferYear, string transferMonth)
        {
            AmazonS3Util amazonS3 = new AmazonS3Util();
            int clientId;
            string key = "";
            string transactionType = "";
            int UploadedImageCount = 0;
            int notUploadedFileCount = 0;
            clientId = (int)clientID;
            object VatNumber;
            object AccountIdForImageUpload = AccountId;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT VATNumber FROM account Where AccountId = " + AccountIdForImageUpload, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VatNumber = reader.GetValue(0);
                                try
                                {
                                    List<String> Files = new List<String>();
                                    foreach (string file in Directory.GetFiles(@"D:\VATScanImages\VATScan\DocStorage\" + VatNumber + "\\Records"))
                                    {
                                        Files.Add(file);
                                    }

                                    for (int i = 0; i < Files.Count; i++)
                                    {
                                        string fileName;
                                        string nameWithoutExtension = Name.Replace(".tif", "");
                                        fileName = Path.GetFileName(Files[i]);
                                        string fileNameWithoutExtension = '"' + Path.GetFileNameWithoutExtension(Files[i]) + '"';

                                        if (fileNameWithoutExtension.Equals(nameWithoutExtension))
                                        {

                                            //Get the file Extension
                                            string fileExtenSion = Path.GetExtension(fileName);

                                            FileStream fileStream = new FileStream(Files[i], FileMode.Open, FileAccess.Read);

                                            if (fileExtenSion == ".jpeg" || fileExtenSion == ".jpg" || fileExtenSion == ".tif" || fileExtenSion == ".tiff")
                                            {
                                                byte[] buffer = new byte[fileStream.Length];
                                                //Get the complete folder path and store the file inside it.  

                                                if (fileExtenSion == ".tif" || fileExtenSion == ".tiff")
                                                {
                                                    fileName = Path.ChangeExtension(fileName, ".jpeg");
                                                }

                                                fileStream.Read(buffer, 0, buffer.Length);

                                                MemoryStream ms = new MemoryStream(buffer, true);

                                                Image newImage = Image.FromStream(ms);
                                                var width = newImage.Width;
                                                var height = newImage.Height;

                                                System.IO.Stream stream = new System.IO.MemoryStream();

                                                using (MagickImage magickImage = new MagickImage(buffer))
                                                {
                                                    magickImage.Quality = 10;
                                                    magickImage.Resize(width, height);
                                                    magickImage.Format = MagickFormat.Jpeg;
                                                    magickImage.Write(stream);
                                                }

                                                key = FileGUID.ToString() + fileName;
                                                transactionType = AppSettingsUtil.RECORD_TRANSACTION_TYPE_RECORD;

                                                string imageName = fileName;
                                                string sourceObjectKey = fileName;
                                                FileGUID = fileName;
                                                Name = key;

                                                // Upload Image to Cloud
                                                amazonS3.UploadRecordAndBankStatementImagesToS3ByTransferUtil(transactionType, clientId, imageName, sourceObjectKey, key, stream, transferYear, transferMonth);
                                                var transactionTypeforRecord = '"' + AppSettingsUtil.RECORD_TRANSACTION_TYPE_RECORD + '"';
                                                var invoiceStatus = (int)AppSettingsUtil.SCANNEDINVOICE_STATUS.Pending;
                                                var fileGuid = '"' + FileGUID + '"';
                                                var guidName = '"' + Name + '"';
                                                var q = "INSERT INTO record(GUID,FileGuid,TransfreDate,TransactionType,TransferYear,TransferMonth,Status) Values(" + guidName + "," + fileGuid + "," + CreateDate + "," + transactionTypeforRecord + "," + transferYear + "," + transferMonth + "," + invoiceStatus + "); ";
                                                RunQueryClientDatabase(q);
                                                UploadedImageCount++;
                                            }
                                        }
                                        else
                                            notUploadedFileCount++;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Program.ErrorLogging(ex);
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

            if (UploadedImageCount >= 1)
                return 1;
            else
                return 0;
        }

        public static int UploadBankStatementImageInAWS(object clientID, object AccountId, string Name, string FileGUID, string CreateDate, string transferYear, string transferMonth)
        {
            AmazonS3Util amazonS3 = new AmazonS3Util();
            int clientId;
            string key = "";
            string transactionType = "";
            int UploadedImageCount = 0;
            int notUploadedFileCount = 0;
            clientId = (int)clientID;
            object VatNumber;
            object AccountIdForImageUpload = AccountId;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT VATNumber FROM account Where AccountId = " + AccountIdForImageUpload, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VatNumber = reader.GetValue(0);
                                try
                                {
                                    List<String> Files = new List<String>();
                                    foreach (string file in Directory.GetFiles(@"D:\VATScanImages\VATScan\DocStorage\" + VatNumber + "\\BankStatement"))
                                    {
                                        Files.Add(file);
                                    }

                                    for (int i = 0; i < Files.Count; i++)
                                    {
                                        string fileName;
                                        string nameWithoutExtension = Name.Replace(".tif", "");
                                        fileName = Path.GetFileName(Files[i]);
                                        string fileNameWithoutExtension = '"' + Path.GetFileNameWithoutExtension(Files[i]) + '"';

                                        if (fileNameWithoutExtension.Equals(nameWithoutExtension))
                                        {

                                            //Get the file Extension
                                            string fileExtenSion = Path.GetExtension(fileName);

                                            FileStream fileStream = new FileStream(Files[i], FileMode.Open, FileAccess.Read);

                                            if (fileExtenSion == ".jpeg" || fileExtenSion == ".jpg" || fileExtenSion == ".tif" || fileExtenSion == ".tiff")
                                            {
                                                byte[] buffer = new byte[fileStream.Length];
                                                //Get the complete folder path and store the file inside it.  

                                                if (fileExtenSion == ".tif" || fileExtenSion == ".tiff")
                                                {
                                                    fileName = Path.ChangeExtension(fileName, ".jpeg");
                                                }

                                                fileStream.Read(buffer, 0, buffer.Length);

                                                MemoryStream ms = new MemoryStream(buffer, true);

                                                Image newImage = Image.FromStream(ms);
                                                var width = newImage.Width;
                                                var height = newImage.Height;

                                                System.IO.Stream stream = new System.IO.MemoryStream();

                                                using (MagickImage magickImage = new MagickImage(buffer))
                                                {
                                                    magickImage.Quality = 10;
                                                    magickImage.Resize(width, height);
                                                    magickImage.Format = MagickFormat.Jpeg;
                                                    magickImage.Write(stream);
                                                }

                                                key = FileGUID.ToString() + fileName;
                                                transactionType = AppSettingsUtil.RECORD_TRANSACTION_TYPE_BANKSTATEMENT;

                                                string imageName = fileName;
                                                string sourceObjectKey = fileName;
                                                FileGUID = fileName;
                                                Name = key;

                                                // Upload Image to Cloud
                                                amazonS3.UploadRecordAndBankStatementImagesToS3ByTransferUtil(transactionType, clientId, imageName, sourceObjectKey, key, stream, transferYear, transferMonth);
                                                var transactionTypeforBankStatement = '"' + AppSettingsUtil.RECORD_TRANSACTION_TYPE_BANKSTATEMENT + '"';
                                                var invoiceStatus = (int)AppSettingsUtil.SCANNEDINVOICE_STATUS.Pending;
                                                var fileGuid = '"' + FileGUID + '"';
                                                var guidName = '"' + Name + '"';
                                                var q = "INSERT INTO record(GUID,FileGuid,TransfreDate,TransactionType,TransferYear,TransferMonth,Status) Values(" + guidName + "," + fileGuid + "," + CreateDate + "," + transactionTypeforBankStatement + "," + transferYear + "," + transferMonth + "," + invoiceStatus + "); ";
                                                RunQueryClientDatabase(q);
                                                UploadedImageCount++;
                                            }
                                        }
                                        else
                                            notUploadedFileCount++;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Program.ErrorLogging(ex);
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

            if (UploadedImageCount >= 1)
                return 1;
            else
                return 0;
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
                Program.ErrorLoggingForQueries(ex, query);
            }
        }
    }
}

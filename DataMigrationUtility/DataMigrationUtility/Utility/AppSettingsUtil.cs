using DataMigrationUtility;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Security.Cryptography;

namespace WebAccounting.Lib.Utility
{
    public static class AppSettingsUtil
    {
        #region "Variable(s)"
        public static string ConnectionStringMasterDB = @"server=localhost;userid=root;
        password=Promact2017;database=master_client";

        public static string ConnectionStringSourceDB = @"server=server12;userid=vatuser;
        password=Promact2016;database=vataccountant";

        public static string ConnectionStringClientDB = @"server=localhost;userid=root;
        password=Promact2017;database=clientedmx_";
        #endregion

        #region "Constant (s)"
        private const string TAMPER_PROOF_KEY = "astkvsnanvpi";
        public const string SALES_TYPE_SALESNORMAL = "SalesNormal";
        public const string SALES_TYPE_SALESCAFEANDSANDWICHBAR = "SalesCafeAndSandwichBar";
        public const string SALES_TYPE_SALESDAILYGROSSTAKING = "SalesDailyGrossTaking";
        public const string SALES_TYPE_SALESPHARMACY = "SalesPharmacy";
        public const string TRANSACTION_TYPE_SALES = "Sales";
        public const string RECORD_TRANSACTION_TYPE_BANKSTATEMENT = "Bank Statement";
        public const string RECORD_TRANSACTION_TYPE_RECORD = "Record";
        public const string UNCATEGORIZED_INVOICE = "uncategorized";
        public const string KeyPath = "Images/Client_";
        public const string PURCHASE_INVOICE = "purchaseinvoice";
        public const string SALES_INVOICE = "salesinvoice";
        public const string EXPENSE_INVOICE = "expenseinvoice";
        public const string BANK_INVOICE = "bankinvoice";
        public const string UploadImagesFileNamePrefix = "Scan_";
        public const string CREDIT_NOTE_SALES = "creditnotesales";
        public const string CREDIT_NOTE_PURCHASE = "creditnotepurchase";
        public const string CREDIT_NOTE_EXPENSE = "creditnoteexpense";
        #endregion

        #region "Key(s)"
        public static string CONNECTIONSTRING
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["CONNECTIONSTRING"].ToString();
            }
        }

        public static string DBNAME
        {
            get
            {
                return ConfigurationManager.AppSettings["DBNAME"];
            }
        }
        #endregion

        #region "Enum(s)"
        public enum ACCOUNTANTCLIENT_STATUS
        {
            INACTIVE = 0,
            ACTIVE = 1
        }

        public enum ROLE
        {
            ADMINISTRATOR = 1,
            ACCOUNTANT = 2,
            DATA_ENTRY_OPERATOR = 3,
            CLIENT = 4,
            SCANNER = 5
        }

        public enum TRANSACTION_PERSON
        {
            Client = 0,
            Accountant = 1,
        }

        public enum REPORT_TYPE
        {
            DATA_REPORT = 1,
            CREDITNOTE_REPORT = 2,
            BOTH = 3
        }

        public enum EXPENSETYPE_STATUS
        {
            TRUE = 1,
            FALSE = 0,
            DELETE = 2

        }

        public enum SALES_STATUS
        {
            INACTIVE = 0,
            ACTIVE = 1,
            HOLD = 2,
            DELETE = 3
        }

        public enum SCANNEDINVOICE_STATUS
        {
            Pending = 0,
            Completed = 1
        }
        #endregion

        #region "Public Method(s)"
        public static string Encode(string value)
        {
            return TamperProofStringEncode(value, TAMPER_PROOF_KEY);
        }

        /// <summary>
        ///Function to encode the string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string TamperProofStringEncode(string value, string key)
        {
            using (MACTripleDES mac3des = new MACTripleDES())
            {
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    mac3des.Key = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(key));
                    return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value)) + System.Convert.ToChar("-") + System.Convert.ToBase64String(mac3des.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value)));
                }
            }
        }

        /// <summary>
        /// return path for the keyname 
        /// </summary>
        /// <param name="transactionType"></param>
        /// <param name="currentClientId"></param>
        /// <returns></returns>
        public static string GetPathForKeyNameBucket(string transactionType, long currentClientId)
        {
            string imagePath = "";
            try
            {
                if (transactionType.Equals(AppSettingsUtil.PURCHASE_INVOICE))
                    imagePath = KeyPath + currentClientId.ToString() + "/" + AppSettingsUtil.PURCHASE_INVOICE;
                else if (transactionType.Equals(AppSettingsUtil.SALES_INVOICE))
                    imagePath = KeyPath + currentClientId.ToString() + "/" + AppSettingsUtil.PURCHASE_INVOICE;
                else if (transactionType.Equals(AppSettingsUtil.EXPENSE_INVOICE))
                    imagePath = KeyPath + currentClientId.ToString() + "/" + AppSettingsUtil.EXPENSE_INVOICE;
                else if (transactionType.Equals(AppSettingsUtil.UNCATEGORIZED_INVOICE))
                    imagePath = KeyPath + currentClientId.ToString() + "/" + AppSettingsUtil.UNCATEGORIZED_INVOICE;
                return imagePath;
            }
            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
                return ex.Message.ToString();
            }

        }

        public static string GetPathForKeyNameBucketForRecordAndBankStatementTransaction(string transactionType, long currentClientId, string transferYear, string transferMonth)
        {
            string imagePath = "";
            try
            {
                if (transactionType.Equals(AppSettingsUtil.RECORD_TRANSACTION_TYPE_RECORD))
                    imagePath = KeyPath + currentClientId.ToString() + "/" + AppSettingsUtil.RECORD_TRANSACTION_TYPE_RECORD + "/" + transferYear + "/" + transferMonth;
                else if (transactionType.Equals(AppSettingsUtil.RECORD_TRANSACTION_TYPE_BANKSTATEMENT))
                    imagePath = KeyPath + currentClientId.ToString() + "/" + AppSettingsUtil.RECORD_TRANSACTION_TYPE_BANKSTATEMENT + "/" + transferYear + "/" + transferMonth;
                return imagePath;
            }
            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
                return ex.Message.ToString();
            }
        }
        #endregion
    }
}

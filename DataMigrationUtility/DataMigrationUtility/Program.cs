using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using WebAccounting.Lib.Utility;

namespace DataMigrationUtility
{
    class Program
    {
        static string cs = AppSettingsUtil.ConnectionStringMasterDB;

        static void Main(string[] args)
        {
            //var createTableQuery = "CREATE TABLE IF NOT EXISTS `master_client`.`temporaryoldnewclientidsassociation` (`idtemporaryoldnewclientidsassociation` INT NOT NULL AUTO_INCREMENT,`AccountID` INT NULL,`ClientID` INT NULL,PRIMARY KEY(`idtemporaryoldnewclientidsassociation`));";
            //RunQuery(createTableQuery);
            //var createTemporaryTableQuery = "CREATE TABLE IF NOT EXISTS `master_client`.`temporaryfuelscalechargeprofileidassociation` (`idtemporaryfuelscalechargeprofileidassociation` INT NOT NULL AUTO_INCREMENT,`SourceFuelProfileID` INT NULL,`MasterFuelProfileID` INT NULL,PRIMARY KEY(`idtemporaryfuelscalechargeprofileidassociation`));";
            //RunQuery(createTemporaryTableQuery);
            //DataMigrationUtilityCodes.ClientDatabaseCreation.AccountTableDataMigration();
            //DataMigrationUtilityCodes.TemporaryTableDataInsertion.InsertDataTemporaryTable();

            //DataMigrationUtilityCodes.AccountTablesDataMigration.AccountFuelChargeDetails();
            //DataMigrationUtilityCodes.AccountTablesDataMigration.AccountOpeningClosingStockTableDataMigration();

            //DataMigrationUtilityCodes.SeedDataMigration.VATRateTableDataMigration();
            //DataMigrationUtilityCodes.SeedDataMigration.ExemptItemsDataMigration();
            //DataMigrationUtilityCodes.SeedDataMigration.ZeroRatedItemsDataMigration();
            //DataMigrationUtilityCodes.SeedDataMigration.ExemptItemsNonDataMigration();
            //DataMigrationUtilityCodes.SeedDataMigration.ExpenseSourceDataMigration();
            //DataMigrationUtilityCodes.SeedDataMigration.ExpenseTypeDataMigration();

            //DataMigrationUtilityCodes.SupplierTableDataMigration.SupplierTableMigration();
            //DataMigrationUtilityCodes.CustomerTableDataMigration.CustomerTableMigration();
            //DataMigrationUtilityCodes.BankingTablesDataMigration.BankingTableDataMigration();
            //DataMigrationUtilityCodes.TemporaryCustomerSupplierTableCreationAndInsertion.CreateTemporaryCustomerSupplierTables();
            //DataMigrationUtilityCodes.TemporaryCustomerSupplierTableCreationAndInsertion.InsertDataTemporaryCustomerTable();
            //DataMigrationUtilityCodes.TemporaryCustomerSupplierTableCreationAndInsertion.InsertDataTemporarySupplierTable();

            //DataMigrationUtilityCodes.CreditNotesTransactionTableDataMigration.CreditNoteTransactionTableDataMigration();
            //DataMigrationUtilityCodes.PurchaseTransactionTablesDataMigration.PurchaseTransactionTableDataMigration();
            //DataMigrationUtilityCodes.ExpenseTransactionTablesDataMigration.ExpenseTransactionTableDataMigration();
            //DataMigrationUtilityCodes.SaleTransactionTablesDataMigration.SaleTransactionTableDataMigration();
            //DataMigrationUtilityCodes.SaleTransactionTablesDataMigration.SaleTransactionTableDataMigrationForNormalSales();

            //DataMigrationUtilityCodes.FuelScaleChargeTablesDataMigration.FuelScaleChargeProfileDataMigration();
            //DataMigrationUtilityCodes.TemporaryFuelScaleChargeProfileIdAssociation.InsertDataTemporaryTable();
            //DataMigrationUtilityCodes.FuelScaleChargeTablesDataMigration.FuelScaleChargeDetailsDataMigration();

            // DataMigrationUtilityCodes.AccountTablesDataMigration.AccountDocumentTableDataMigration();
             //DataMigrationUtilityCodes.AccountTablesDataMigration.AccountDocumentTableDataMigrationForRecordTable();
            //DataMigrationUtilityCodes.AccountTablesDataMigration.AccountDocumentTableBankStatementDataMigrationForRecordTable();

            //DataMigrationUtilityCodes.DropTemporaryCustomerSupplierTables.DropTemporaryCustomerAndSupplierClientTables();

            //var dropTableQuery = "DROP TABLE IF EXISTS `master_client`.`temporaryfuelscalechargeprofileidassociation`";
            //RunQuery(dropTableQuery);
            //var dropTemporaryTableQuery = "DROP TABLE IF EXISTS `master_client`.`temporaryoldnewclientidsassociation`";
            //RunQuery(dropTemporaryTableQuery);
           
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
                ErrorLoggingForQueries(ex, query);
            }
        }

        public static void ErrorLogging(Exception ex)
        {
            string strPath = @"D:\Madhurima\Exception\ExceptionLog.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);
                sw.WriteLine();
                sw.WriteLine();
            }
        }

        public static void ErrorLoggingForQueries(Exception ex, string query)
        {
            string strPath = @"D:\Madhurima\Exception\QueryLog.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("Query throwing Exception: " + query);
                sw.WriteLine("===========End============= " + DateTime.Now);
                sw.WriteLine();
                sw.WriteLine();
            }
        }

        public static void LoggingForImagesNotPresentInFolder(string message)
        {
            string strPath = @"D:\Madhurima\Exception\ImageLog.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("============= Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + message);
                sw.WriteLine("===========End============= " + DateTime.Now);
                sw.WriteLine();
                sw.WriteLine();
            }
        }
    }
}

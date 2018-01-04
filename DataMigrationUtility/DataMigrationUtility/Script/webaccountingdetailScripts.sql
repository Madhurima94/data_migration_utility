SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';


-- -----------------------------------------------------
-- Table `bank`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `bank` (
  `BankID` INT(11) NOT NULL AUTO_INCREMENT ,
  `BankName` VARCHAR(100) NULL DEFAULT NULL ,
  `AccountNumber` VARCHAR(20) NULL DEFAULT NULL ,
  PRIMARY KEY (`BankID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;

-- -----------------------------------------------------
-- Table `LockDate`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lockdates` (
  `ID` int(20) NOT NULL AUTO_INCREMENT,
  `ToDate` datetime NOT NULL,
  `FromDate` datetime NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- -----------------------------------------------------
-- Table `record`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `record` (
  `RecordId` bigint(20) NOT NULL AUTO_INCREMENT,
  `TransfreDate` datetime DEFAULT NULL,
  `TransactionType` varchar(50) DEFAULT NULL,
  `FileGuid` varchar(150) DEFAULT NULL,
  `GUID` varchar(500) DEFAULT NULL,
  `Status` varchar(20) DEFAULT NULL,
  `TransferYear` int(6) DEFAULT NULL,
  `TransferMonth` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`RecordId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;


-- -----------------------------------------------------
-- Table `banking`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `banking` (
  `BankingID` INT(11) NOT NULL AUTO_INCREMENT ,
  `Date` DATE NULL DEFAULT NULL ,
  `Type` VARCHAR(45) NULL DEFAULT NULL ,
  `BankID` INT(11) NULL DEFAULT NULL ,
  `Credit` DECIMAL(10,2) NULL DEFAULT NULL ,
  `Debit` DECIMAL(10,2) NULL DEFAULT NULL ,
  `ChequeNumber` INT(8) NULL DEFAULT NULL,
  `Status` INT(1) NULL DEFAULT NULL ,
  PRIMARY KEY (`BankingID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `bankstatement`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `bankstatement` (
  `BankStatementID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `GUID` VARCHAR(50) NULL DEFAULT NULL ,
  `BankStatementDate` DATETIME NULL DEFAULT NULL ,
  `FileGUID` VARCHAR(100) NULL DEFAULT NULL ,
  `FilePath` VARCHAR(100) NULL DEFAULT NULL ,
  `Notes` VARCHAR(500) NULL DEFAULT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`BankStatementID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `bankstatementdetails`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `bankstatementdetails` (
  `BankStatementID` INT(11) NOT NULL AUTO_INCREMENT ,
  `BankID` INT(11) NULL DEFAULT NULL ,
  `BalanceBroughtForward` DECIMAL(10,2) NULL DEFAULT NULL ,
  `Date` DATETIME NULL DEFAULT NULL ,
  `Particulars` VARCHAR(100) NULL DEFAULT NULL ,
  `ChequeORRefNo` VARCHAR(45) NULL DEFAULT NULL ,
  `AmountType` VARCHAR(45) NULL DEFAULT NULL ,
  `Amount` DECIMAL(10,2) NULL DEFAULT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`BankStatementID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;

-- -----------------------------------------------------
-- Table `cashbook`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `cashbook` (
  `CashBookID` INT(11) NOT NULL AUTO_INCREMENT ,
  `Type` VARCHAR(45) NULL DEFAULT NULL ,
  `CashDate` DATETIME NULL DEFAULT NULL ,
  `CloseDate` DATETIME NULL DEFAULT NULL ,
  `CashDescription` VARCHAR(200) NULL DEFAULT NULL ,
  `Amount` DECIMAL(10,2) NULL DEFAULT NULL ,
  `AmountTotal` DECIMAL(10,2) NULL DEFAULT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  `Supplier` VARCHAR(100) NULL DEFAULT NULL ,
  `CloseAmountTotal` DECIMAL(10,2) NULL DEFAULT NULL ,
  `SupportID` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`CashBookID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `clientfuelchargedetails`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `clientfuelchargedetails` (
  `ClientFuelChargeDetailsID` INT(11) NOT NULL AUTO_INCREMENT ,
  `Make` VARCHAR(100) NULL DEFAULT NULL ,
  `RegistrationNumber` VARCHAR(100) NULL DEFAULT NULL ,
  `PurchaseDate` DATETIME NULL DEFAULT NULL ,
  `CO2EmissionBand` VARCHAR(100) NULL DEFAULT NULL ,
  `VehicleSoldDate` datetime DEFAULT NULL,
  `OwnedHP` VARCHAR(100) NULL DEFAULT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`ClientFuelChargeDetailsID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `clientfuelchargedetailsnew`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `clientfuelchargedetailsnew` (
  `ClientFuelChargeDetailsnewID` INT(11) NOT NULL AUTO_INCREMENT ,
  `Make` VARCHAR(100) NULL DEFAULT NULL ,
  `RegistrationNumber` VARCHAR(100) NULL DEFAULT NULL ,
  `PurchaseDate` DATETIME NULL DEFAULT NULL ,
  `CO2EmissionBand` VARCHAR(100) NULL DEFAULT NULL ,
  `Quantity` INT(11) NULL DEFAULT NULL ,
  `OwnedHP` VARCHAR(100) NULL DEFAULT NULL ,
  PRIMARY KEY (`ClientFuelChargeDetailsnewID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `fuelscalecharges`
-- -----------------------------------------------------
CREATE TABLE  IF NOT EXISTS `fuelscalecharges` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `SelectedMonth` VARCHAR(45) NULL,
  `FuelScalCharges` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`));




-- -----------------------------------------------------
-- Table `reporttype`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `reporttype` (
  `ReportTypeID` INT(11) NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`ReportTypeID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `creditnote`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `creditnote` (
  `CreditNoteID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `ReferenceNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `CreditNoteNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `CreditNoteDate` DATETIME NULL DEFAULT NULL ,
  `Notes` VARCHAR(500) NULL DEFAULT NULL ,
  `TransactionType` VARCHAR(10) NULL DEFAULT NULL ,
  `CustomerID` INT(11) NULL DEFAULT NULL ,
  `SupplierID` INT(11) NULL DEFAULT NULL ,
  `ExpenseTypeID` INT(11) NULL DEFAULT NULL ,
  `IsPaid` INT(1) NULL DEFAULT NULL ,
  `PaymentDate` DATETIME NULL DEFAULT NULL ,
  `PaymentMethod` VARCHAR(20) NULL DEFAULT NULL ,
  `PaymentAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `ChequeNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `Bank` VARCHAR(100) NULL DEFAULT NULL ,
  `AccountNumber` VARCHAR(20) NULL DEFAULT NULL ,
  `CreditCardType` VARCHAR(50) NULL DEFAULT NULL ,
  `AccountantID` INT(11) NOT NULL ,
  `TotalGrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `TotalVATAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `TotalNettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `ScannedInvoiceID` BIGINT(20) NULL DEFAULT NULL ,
  `IsEC` INT(1) NULL DEFAULT NULL ,
  `VATReportingDate` DATETIME NULL DEFAULT NULL ,
  `VATNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  `ReportTypeID` INT(11) NULL DEFAULT NULL ,
  `EncodedID` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`CreditNoteID`) ,
  INDEX `ReportTypeID_creditnote` (`ReportTypeID` ASC) ,
  CONSTRAINT `ReportTypeID_creditnote`
    FOREIGN KEY (`ReportTypeID` )
    REFERENCES `reporttype` (`ReportTypeID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `creditnotevatdetails`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `creditnotevatdetails` (
  `CreditNoteVATDetailsID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `CreditNoteID` BIGINT(20) NOT NULL ,
  `VATRateType` VARCHAR(20) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `VATAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `GrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  PRIMARY KEY (`CreditNoteVATDetailsID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `customer`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `customer` (
  `CustomerID` INT(11) NOT NULL AUTO_INCREMENT ,
  `CompanyName` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyAddress` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyCity` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyState` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyCounty` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyCountry` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyPostCode` VARCHAR(50) NULL DEFAULT NULL ,
  `CompanyEmail` VARCHAR(50) NULL DEFAULT NULL ,
  `CompanyPhone` VARCHAR(30) NULL DEFAULT NULL ,
  `CompanyWebSite` VARCHAR(100) NULL DEFAULT NULL ,
  `VATNumber` VARCHAR(30) NULL DEFAULT NULL ,
  `ContactName` VARCHAR(100) NULL DEFAULT NULL ,
  `ContactPhone` VARCHAR(30) NULL DEFAULT NULL ,
  `ContactEmail` VARCHAR(50) NULL DEFAULT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  `IsRevAllow` INT(10) NULL DEFAULT NULL ,
  PRIMARY KEY (`CustomerID`) )
ENGINE = InnoDB
AUTO_INCREMENT = 48
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `exemptitems`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `exemptitems` (
  `ExemptItemsID` INT(11) NOT NULL AUTO_INCREMENT ,
  `ItemName` VARCHAR(50) NOT NULL ,
  PRIMARY KEY (`ExemptItemsID`) )
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `exemptitemsnon`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `exemptitemsnon` (
  `ExemptItemsNonID` INT(11) NOT NULL AUTO_INCREMENT ,
  `ItemName` VARCHAR(50) NOT NULL ,
  PRIMARY KEY (`ExemptItemsNonID`) )
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `supplier`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `supplier` (
  `SupplierID` INT(11) NOT NULL AUTO_INCREMENT ,
  `CompanyName` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyAddress` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyCity` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyState` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyCounty` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyCountry` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyPostCode` VARCHAR(100) NULL DEFAULT NULL ,
  `CompanyEmail` VARCHAR(50) NULL DEFAULT NULL ,
  `CompanyPhone` VARCHAR(30) NULL DEFAULT NULL ,
  `CompanyWebSite` VARCHAR(100) NULL DEFAULT NULL ,
  `VATNumber` VARCHAR(30) NULL DEFAULT NULL ,
  `ContactName` VARCHAR(100) NULL DEFAULT NULL ,
  `ContactPhone` VARCHAR(30) NULL DEFAULT NULL ,
  `ContactEmail` VARCHAR(50) NULL DEFAULT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  `IsRevAllow` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`SupplierID`) )
ENGINE = InnoDB
AUTO_INCREMENT = 10
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `expense`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `expense` (
  `ExpenseID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SupplierID` INT(11) NOT NULL ,
  `ReferenceNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `InvoiceNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `InvoiceDate` DATETIME NULL DEFAULT NULL ,
  `ExpenseTypeID` INT(11) NULL DEFAULT NULL ,
  `TotalGrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `TotalVATAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `TotalNettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `IsEC` INT(11) NULL DEFAULT NULL ,
  `VATReportingDate` DATETIME NULL DEFAULT NULL ,
  `VATNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `IsImport` INT(11) NULL DEFAULT NULL ,
  `ImportDuty` DECIMAL(18,2) NULL DEFAULT NULL ,
  `ClearingCharges` DECIMAL(18,2) NULL DEFAULT NULL ,
  `OtherCharges` DECIMAL(18,2) NULL DEFAULT NULL ,
  `TotalImport` DECIMAL(18,2) NULL DEFAULT NULL ,
  `IsPaid` INT(11) NULL DEFAULT NULL ,
  `PaymentAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `PaymentMethod` VARCHAR(20) NULL DEFAULT NULL ,
  `PaymentDate` DATETIME NULL DEFAULT NULL ,
  `ChequeNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `Bank` VARCHAR(100) NULL DEFAULT NULL ,
  `AccountNumber` VARCHAR(20) NULL DEFAULT NULL ,
  `CreditCardType` VARCHAR(50) NULL DEFAULT NULL ,
  `AccountantID` INT(11) NOT NULL ,
  `Notes` VARCHAR(500) NULL DEFAULT NULL ,
  `ScannedInvoiceID` BIGINT(20) NULL DEFAULT NULL ,
  `IsCapitalExpenditure` INT(11) NULL DEFAULT NULL ,
  `PurchaseID` BIGINT(20) NULL DEFAULT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  `NonVATAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `ReportTypeID` INT(11) NULL DEFAULT NULL ,
  `VATValue` DECIMAL(18,2) NULL DEFAULT NULL ,
  `VAT` DECIMAL(18,2) NULL DEFAULT NULL ,
  `IsLowerRate` BIT(1) NULL DEFAULT NULL ,
  `EncodedExpenseID` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`ExpenseID`) ,
  INDEX `SupplierID_Expense` (`SupplierID` ASC) ,
  INDEX `ReportTypeId_Expense` (`ReportTypeID` ASC) ,
  CONSTRAINT `ReportTypeID_Expense`
    FOREIGN KEY (`ReportTypeID` )
    REFERENCES `reporttype` (`ReportTypeID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `SupplierID_Expense`
    FOREIGN KEY (`SupplierID` )
    REFERENCES `supplier` (`SupplierID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `expenseitem`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `expenseitem` (
  `ExpenseItemID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `ExpenseID` BIGINT(20) NOT NULL ,
  `ItemDescription` VARCHAR(100) NULL DEFAULT NULL ,
  `GrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `VATRate` DECIMAL(18,2) NULL DEFAULT NULL ,
  `VATAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `ExpenseSourceID` INT(11) NULL DEFAULT NULL ,
  `InvoiceDate` DATETIME NULL DEFAULT NULL ,
  `Remarks` VARCHAR(500) NULL DEFAULT NULL ,
  PRIMARY KEY (`ExpenseItemID`) ,
  INDEX `ExpenseID_ExpenseItem` (`ExpenseID` ASC) ,
  CONSTRAINT `ExpenseID_ExpenseItem`
    FOREIGN KEY (`ExpenseID` )
    REFERENCES `expense` (`ExpenseID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `expenseitemmemory`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `expenseitemmemory` (
  `ExpenseItemMemoryID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `ExpenseItemID` BIGINT(20) NULL DEFAULT NULL ,
  `SourceName` VARCHAR(100) NULL DEFAULT NULL ,
  `GrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `VATRate` VARCHAR(20) NULL DEFAULT NULL ,
  `VATAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `ExpenseID` BIGINT(20) NULL DEFAULT NULL ,
  `AccountantID` INT(11) NULL DEFAULT NULL ,
  `InvoiceDate` DATETIME NULL DEFAULT NULL ,
  `Remarks` VARCHAR(500) NULL DEFAULT NULL ,
  PRIMARY KEY (`ExpenseItemMemoryID`) )
ENGINE = MEMORY
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `expensesource`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `expensesource` (
  `ExpenseSourceID` INT(11) NOT NULL AUTO_INCREMENT ,
  `SourceName` VARCHAR(100) NULL DEFAULT NULL ,
  `Status` INT(10) NULL DEFAULT NULL ,
  PRIMARY KEY (`ExpenseSourceID`) )
ENGINE = InnoDB
AUTO_INCREMENT = 11
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `expensetype`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `expensetype` (
  `ExpenseTypeID` INT(11) NOT NULL AUTO_INCREMENT ,
  `ExpenseTypeName` VARCHAR(100) NULL DEFAULT NULL ,
  `ExpenditureCatagory` varchar(45) DEFAULT NULL,
  `Status` int(10) DEFAULT NULL,
  PRIMARY KEY (`ExpenseTypeID`) )
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `itemtype`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `itemtype` (
  `ItemTypeID` INT(11) NOT NULL AUTO_INCREMENT ,
  `ItemTypeName` VARCHAR(50) NOT NULL ,
  PRIMARY KEY (`ItemTypeID`) )
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `itemtypedetails`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `itemtypedetails` (
  `ItemTypeDetailsID` INT(11) NOT NULL AUTO_INCREMENT ,
  `ItemName` VARCHAR(100) NOT NULL ,
  `ItemTypeID` INT(11) NOT NULL ,
  PRIMARY KEY (`ItemTypeDetailsID`) ,
  INDEX `ItemTypeId` (`ItemTypeID` ASC) ,
  CONSTRAINT `ItemTypeId_itemtypedetails`
    FOREIGN KEY (`ItemTypeID` )
    REFERENCES `itemtype` (`ItemTypeID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 10
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `openingclosingstock`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `openingclosingstock` (
  `OpeningClosingStockID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ,
  `OpeningStock` DECIMAL(10,2) NOT NULL ,
  `ClosingStock` DECIMAL(10,2) NULL DEFAULT NULL ,
  `CreateDate` DATETIME NOT NULL ,
  `ProfitMargin` DECIMAL(10,2) NOT NULL ,
  PRIMARY KEY (`OpeningClosingStockID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `purchase`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `purchase` (
  `PurchaseID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SupplierID` INT(11) NOT NULL ,
  `ReferenceNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `InvoiceNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `InvoiceDate` DATETIME NULL DEFAULT NULL ,
  `TotalGrossAmount` DECIMAL(11,2) NULL DEFAULT NULL ,
  `TotalVATAmount` DECIMAL(11,2) NULL DEFAULT NULL ,
  `TotalNettAmount` DECIMAL(11,2) NULL DEFAULT NULL ,
  `IsEC` INT(10) NULL DEFAULT NULL ,
  `VATReportingDate` DATETIME NULL DEFAULT NULL ,
  `VATNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `IsImport` INT(11) NULL DEFAULT NULL ,
  `ImportDuty` DECIMAL(10,2) NULL DEFAULT NULL ,
  `ClearingCharges` DECIMAL(10,2) NULL DEFAULT NULL ,
  `OtherCharges` DECIMAL(10,2) NULL DEFAULT NULL ,
  `TotalImport` DECIMAL(11,2) NULL DEFAULT NULL ,
  `IsPaid` INT(11) NULL DEFAULT NULL ,
  `PaymentAmount` DECIMAL(10,2) NULL DEFAULT NULL ,
  `PaymentMethod` VARCHAR(20) NULL DEFAULT NULL ,
  `PaymentDate` DATETIME NULL DEFAULT NULL ,
  `ChequeNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `Bank` VARCHAR(100) NULL DEFAULT NULL ,
  `AccountNumber` VARCHAR(20) NULL DEFAULT NULL ,
  `CreditCardType` VARCHAR(50) NULL DEFAULT NULL ,
  `AccountantID` INT(11) NOT NULL ,
  `Notes` VARCHAR(500) NULL DEFAULT NULL ,
  `ScannedInvoiceID` BIGINT(20) NULL DEFAULT NULL ,
  `IsCapitalExpenditure` INT(11) NULL DEFAULT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  `ReportTypeID` INT(11) NULL DEFAULT NULL ,
  `VATValue` DECIMAL(10,2) NULL DEFAULT NULL ,
  `VAT` DECIMAL(10,2) NULL DEFAULT NULL ,
  `IsLowerRate` BIT(1) NULL DEFAULT NULL ,
  `EncodedPurchaseID` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`PurchaseID`) ,
  INDEX `SupplierID_Purchase` (`SupplierID` ASC) ,
  INDEX `ReportTypeId_Purchase` (`ReportTypeID` ASC) ,
  CONSTRAINT `ReportTypeID_Purchase`
    FOREIGN KEY (`ReportTypeID` )
    REFERENCES `reporttype` (`ReportTypeID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `SupplierID_PurchaseID`
    FOREIGN KEY (`SupplierID` )
    REFERENCES `supplier` (`SupplierID` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `purchaseitem`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `purchaseitem` (
 `PurchaseItemID` bigint(20) NOT NULL AUTO_INCREMENT,
 `PurchaseID` bigint(20) NOT NULL,
 `ItemDescription` varchar(100) DEFAULT NULL,
 `VATAmount` decimal(10,2) DEFAULT NULL,
 `NettAmount` decimal(11,2) DEFAULT NULL,
 `InvoiceNumber` varchar(50) DEFAULT NULL,
 `InvoiceDate` datetime DEFAULT NULL,
 `Remarks` varchar(500) DEFAULT NULL,
 `StandardGrossAmount` decimal(10,2) DEFAULT NULL,
 `LowerGrossAmount` decimal(10,2) DEFAULT NULL,
 `ZeroGrossAmount` decimal(10,2) DEFAULT NULL,
 `InsertFrom` int(11) DEFAULT NULL,
 `StandardRatedVat` decimal(10,2) DEFAULT NULL,
 `LowerRatedVat` decimal(10,2) DEFAULT NULL,
 PRIMARY KEY (`PurchaseItemID`),
 KEY `PurchaseID_PurchaseItem` (`PurchaseID`),
 CONSTRAINT `PurchaseID_PurchaseItem` FOREIGN KEY (`PurchaseID`) REFERENCES `purchase` (`PurchaseID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;


-- -----------------------------------------------------
-- Table `purchaseitemmemory`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `purchaseitemmemory` (
  `PurchaseItemMemoryID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `PurchaseItemID` BIGINT(20) NULL DEFAULT NULL ,
  `ItemDescription` VARCHAR(100) NULL DEFAULT NULL ,
  `VATAmount` DECIMAL(10,2) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(11,2) NULL DEFAULT NULL ,
  `PurchaseID` BIGINT(20) NULL DEFAULT NULL ,
  `AccountantID` INT(11) NULL DEFAULT NULL ,
  `InvoiceNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `InvoiceDate` DATETIME NULL DEFAULT NULL ,
  `Remarks` VARCHAR(500) NULL DEFAULT NULL ,
  `StandardGrossAmount` DECIMAL(10,2) NULL DEFAULT NULL ,
  `LowerGrossAmount` DECIMAL(10,2) NULL DEFAULT NULL ,
  `ZeroGrossAmount` DECIMAL(10,2) NULL DEFAULT NULL ,
  PRIMARY KEY (`PurchaseItemMemoryID`) )
ENGINE = MEMORY
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `sales`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sales` (
  `SalesID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SalesType` VARCHAR(30) NULL DEFAULT NULL ,
  `ReferenceNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `InvoiceNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `InvoiceDate` DATETIME NULL DEFAULT NULL ,
  `Cash` DECIMAL(18,2) NULL DEFAULT NULL ,
  `Cheque` DECIMAL(18,2) NULL DEFAULT NULL ,
  `CreditCards` DECIMAL(18,2) NULL DEFAULT NULL ,
  `CreditSales` DECIMAL(18,2) NULL DEFAULT NULL ,
  `OwnConsumption` DECIMAL(18,2) NULL DEFAULT NULL ,
  `DGTValue` DECIMAL(18,2) NULL DEFAULT NULL ,
  `TotalGrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `TotalVATAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `TotalNettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `CustomerID` INT(11) NULL DEFAULT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  `Notes` VARCHAR(500) NULL DEFAULT NULL ,
  `ScannedInvoiceID` BIGINT(20) NULL DEFAULT NULL ,
  `AccountantID` INT(11) NOT NULL ,
  `ReportTypeID` INT(11) NULL DEFAULT NULL ,
  `IsEC` INT(11) NULL DEFAULT NULL ,
  `VATReportingDate` DATETIME NULL DEFAULT NULL ,
  `VATNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `IsPaid` INT(11) NULL DEFAULT NULL ,
  `PaymentAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `PaymentMethod` VARCHAR(20) NULL DEFAULT NULL ,
  `PaymentDate` DATETIME NULL DEFAULT NULL ,
  `ChequeNumber` VARCHAR(50) NULL DEFAULT NULL ,
  `Bank` VARCHAR(100) NULL DEFAULT NULL ,
  `AccountNumber` VARCHAR(20) NULL DEFAULT NULL ,
  `CreditCardType` VARCHAR(50) NULL DEFAULT NULL ,
  `IsLowerRate` BIT(1) NULL DEFAULT NULL ,
  `EncodedSalesID` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`SalesID`) ,
  INDEX `CustomerID_Sales` (`CustomerID` ASC) ,
  INDEX `ReportTypeId_Sales` (`ReportTypeID` ASC) ,
  CONSTRAINT `CustomerID_Sales`
    FOREIGN KEY (`CustomerID` )
    REFERENCES `customer` (`CustomerID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `ReportTypeID_Sales`
    FOREIGN KEY (`ReportTypeID` )
    REFERENCES `reporttype` (`ReportTypeID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `salescafesandwichbar`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `salescafesandwichbar` (
  `SalesCafeSandwichBarID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SalesID` BIGINT(20) NOT NULL ,
  `HotItemValue` DECIMAL(18,2) NULL DEFAULT NULL ,
  `HotItemPercentage` DECIMAL(5,2) NULL DEFAULT NULL ,
  `ColdItemValue` DECIMAL(18,2) NULL DEFAULT NULL ,
  `ColdItemPercentage` DECIMAL(5,2) NULL DEFAULT NULL ,
  `TotalAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `TotalAmountPercentage` DECIMAL(5,2) NULL DEFAULT NULL ,
  PRIMARY KEY (`SalesCafeSandwichBarID`) ,
  INDEX `SalesID_SalesCafeSandwichBar` (`SalesID` ASC) ,
  CONSTRAINT `SalesID_SalesCafeSandwichBar`
    FOREIGN KEY (`SalesID` )
    REFERENCES `sales` (`SalesID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `salesexemptitemsmemory`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `salesexemptitemsmemory` (
  `SalesExemptItemsMemoryID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SalesItemsID` BIGINT(20) NULL DEFAULT NULL ,
  `ItemTypeExempt` VARCHAR(50) NULL DEFAULT NULL ,
  `ItemTypeDetailsID` INT(11) NULL DEFAULT NULL ,
  `GrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `Commission` DECIMAL(18,2) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  PRIMARY KEY (`SalesExemptItemsMemoryID`) )
ENGINE = MEMORY
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `salesitems`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `salesitems` (
  `SalesItemsID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SalesID` BIGINT(20) NOT NULL ,
  `ItemTypeID` INT(11) NULL DEFAULT NULL ,
  `ItemTypeDetailsID` INT(11) NULL DEFAULT NULL ,
  `GrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `Commission` DECIMAL(18,2) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  PRIMARY KEY (`SalesItemsID`) ,
  INDEX `SalesID_SalesItems` (`SalesID` ASC) ,
  INDEX `ItemTypeID_SalesItems` (`ItemTypeID` ASC) ,
  INDEX `ItemTypeDetailsID_SalesItems` (`ItemTypeDetailsID` ASC) ,
  CONSTRAINT `ItemTypeDetailsID_SalesItems`
    FOREIGN KEY (`ItemTypeDetailsID` )
    REFERENCES `itemtypedetails` (`ItemTypeDetailsID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `ItemTypeID_SalesItems`
    FOREIGN KEY (`ItemTypeID` )
    REFERENCES `itemtype` (`ItemTypeID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `SalesID_SalesItems`
    FOREIGN KEY (`SalesID` )
    REFERENCES `sales` (`SalesID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `salesitemsmemory`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `salesitemsmemory` (
  `SalesItemsMemoryID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SalesItemsID` BIGINT(20) NULL DEFAULT NULL ,
  `ItemTypeID` INT(11) NULL DEFAULT NULL ,
  `ItemTypeDetailsID` INT(11) NULL DEFAULT NULL ,
  `GrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `Commission` DECIMAL(18,2) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  PRIMARY KEY (`SalesItemsMemoryID`) )
ENGINE = MEMORY
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `salesnonexemptitemsmemory`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `salesnonexemptitemsmemory` (
  `SalesNonExemptItemsMemoryID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SalesItemsID` BIGINT(20) NULL DEFAULT NULL ,
  `ItemTypeNonExempt` VARCHAR(50) NULL DEFAULT NULL ,
  `ItemTypeDetailsID` INT(11) NULL DEFAULT NULL ,
  `GrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `Commission` DECIMAL(18,2) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  PRIMARY KEY (`SalesNonExemptItemsMemoryID`) )
ENGINE = MEMORY
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `salesnormal`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `salesnormal` (
  `SalesNormalID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SalesID` BIGINT(20) NOT NULL ,
  `ItemDescription` VARCHAR(200) NULL DEFAULT NULL ,
  `UnitCost` DECIMAL(18,2) NULL DEFAULT NULL ,
  `Quantity` INT(11) NULL DEFAULT NULL ,
  `GrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `VATRate` DECIMAL(18,2) NULL DEFAULT NULL ,
  `VATAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `InsertFrom` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`SalesNormalID`) ,
  INDEX `SalesID_SalesNormal` (`SalesID` ASC) ,
  CONSTRAINT `SalesID_SalesNormal`
    FOREIGN KEY (`SalesID` )
    REFERENCES `sales` (`SalesID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `salesnormalmemory`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `salesnormalmemory` (
  `SalesNormalMemoryID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SalesNormalID` BIGINT(20) NULL DEFAULT NULL ,
  `ItemDescription` VARCHAR(200) NULL DEFAULT NULL ,
  `UnitCost` DECIMAL(18,2) NULL DEFAULT NULL ,
  `Quantity` INT(11) NULL DEFAULT NULL ,
  `GrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `VATRate` VARCHAR(20) NULL DEFAULT NULL ,
  `VATAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `IsEC` BIT(1) NULL DEFAULT NULL ,
  PRIMARY KEY (`SalesNormalMemoryID`) )
ENGINE = MEMORY
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `salespharmacy`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `salespharmacy` (
  `SalesPharmacyID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SalesID` BIGINT(20) NOT NULL ,
  `PracticePayment` DECIMAL(18,2) NULL DEFAULT NULL ,
  `TaxablePracticePayment` DECIMAL(18,2) NULL DEFAULT NULL ,
  `TaxableOtherIncome` DECIMAL(18,2) NULL DEFAULT NULL ,
  `NHSChequeReceived` DECIMAL(18,2) NULL DEFAULT NULL ,
  `VATonTaxablePracticePayment` DECIMAL(18,2) NULL DEFAULT NULL ,
  `PrivatePrescriptions` DECIMAL(18,2) NULL DEFAULT NULL ,
  `NHSPrescription` DECIMAL(18,2) NULL DEFAULT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`SalesPharmacyID`) ,
  INDEX `SalesID_SalesPharmacy` (`SalesID` ASC) ,
  CONSTRAINT `SalesID_SalesPharmacy`
    FOREIGN KEY (`SalesID` )
    REFERENCES `sales` (`SalesID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `salespharmacytreatment`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `salespharmacytreatment` (
  `SalesPharmacyTreatmentID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SalesID` BIGINT(20) NOT NULL ,
  `Treatment` VARCHAR(50) NULL DEFAULT NULL ,
  `Elements` VARCHAR(100) NULL DEFAULT NULL ,
  `Value` DECIMAL(18,2) NULL DEFAULT NULL ,
  PRIMARY KEY (`SalesPharmacyTreatmentID`) ,
  INDEX `SalesID_SalePharmacyTreatment` (`SalesID` ASC) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `saleszerorateditemsmemory`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `saleszerorateditemsmemory` (
  `SalesZeroRatedItemsMemoryID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `SalesItemsID` BIGINT(20) NULL DEFAULT NULL ,
  `ItemTypeZeroRated` VARCHAR(50) NULL DEFAULT NULL ,
  `ItemTypeDetailsID` INT(11) NULL DEFAULT NULL ,
  `GrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `Commission` DECIMAL(18,2) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  PRIMARY KEY (`SalesZeroRatedItemsMemoryID`) )
ENGINE = MEMORY
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `scannedinvoice`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `scannedinvoice` (
  `ScannedInvoiceID` bigint(20) NOT NULL AUTO_INCREMENT,
  `GUID` varchar(500) DEFAULT NULL,
  `TransactionType` varchar(15) DEFAULT NULL,
  `ScannedDate` datetime DEFAULT NULL,
  `FileGuid` varchar(150) DEFAULT NULL,
  `Notes` varchar(500) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `UploadedByUserId` int(11) DEFAULT NULL,
  `IsUploadedFromApp` bit(1) NOT NULL,
  `Details` varchar(60) DEFAULT NULL,
  `UploadedByUser` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ScannedInvoiceID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- -----------------------------------------------------
-- Table `testtablefortrigger`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `testtablefortrigger` (
  `testtablefortriggerID` INT(11) NOT NULL AUTO_INCREMENT ,
  `CurrentTime` DATETIME NULL DEFAULT NULL ,
  PRIMARY KEY (`testtablefortriggerID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `transaction`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `transaction` (
  `TransactionID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `GUID` VARCHAR(50) NOT NULL ,
  `TransactionDate` DATETIME NOT NULL ,
  `AccountantID` INT(11) NULL DEFAULT NULL ,
  `TransactionType` VARCHAR(25) NOT NULL ,
  `TransactionTypeID` BIGINT(20) NOT NULL ,
  `TransactionPerson` BIT(1) NOT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`TransactionID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `transactionhistory`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `transactionhistory` (
  `TransactionHistoryID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `TransactionID` BIGINT(20) NOT NULL ,
  `GUID` VARCHAR(50) NOT NULL ,
  `TransactionDate` DATETIME NOT NULL ,
  `AccountantID` INT(11) NULL DEFAULT NULL ,
  `TransactionType` VARCHAR(25) NOT NULL ,
  `TransactionTypeID` BIGINT(20) NOT NULL ,
  `TransactionPerson` BIT(1) NOT NULL ,
  `Status` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`TransactionHistoryID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `transactionvat`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `transactionvat` (
  `TransactionVATID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `TransactionID` BIGINT(20) NOT NULL ,
  `VATRate` VARCHAR(20) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `VATAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `GrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  PRIMARY KEY (`TransactionVATID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `transactionvathistory`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `transactionvathistory` (
  `TransactionVATHistoryID` BIGINT(20) NOT NULL AUTO_INCREMENT ,
  `TransactionHistoryID` BIGINT(20) NOT NULL ,
  `TransactionID` BIGINT(20) NOT NULL ,
  `VATRate` VARCHAR(20) NULL DEFAULT NULL ,
  `NettAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `VATAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  `GrossAmount` DECIMAL(18,2) NULL DEFAULT NULL ,
  PRIMARY KEY (`TransactionVATHistoryID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `zerorateditems`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `zerorateditems` (
  `ZeroRatedItemsID` INT(11) NOT NULL AUTO_INCREMENT ,
  `ItemName` VARCHAR(50) NOT NULL ,
  PRIMARY KEY (`ZeroRatedItemsID`) )
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = latin1;

-- -----------------------------------------------------
-- Insert Default data into Table `reporttype`
-- -----------------------------------------------------
INSERT INTO `reporttype` (`ReportTypeID`,`Name`) VALUES (1,'Data Report');
INSERT INTO `reporttype` (`ReportTypeID`,`Name`) VALUES (2,'Credit Note Report');
INSERT INTO `reporttype` (`ReportTypeID`,`Name`) VALUES (3,'Both');

-- -----------------------------------------------------
-- Insert Default data into Table `itemtype`
-- -----------------------------------------------------
INSERT INTO `itemtype` (`ItemTypeID`,`ItemTypeName`) VALUES (1,'EXEMPT ITEMS');
INSERT INTO `itemtype` (`ItemTypeID`,`ItemTypeName`) VALUES (2,'ZERO RATED ITEMS');
INSERT INTO `itemtype` (`ItemTypeID`,`ItemTypeName`) VALUES (3,'ITEMS_SUBJECT_TO_VAT');


-- -----------------------------------------------------
-- procedure AccountGetAccountOpeningClosingStock
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `AccountGetAccountOpeningClosingStock`(IN _endDate datetime)
BEGIN
Select * From openingclosingstock Where CreateDate <= _endDate order by CreateDate asc;
END$$

$$
DELIMITER ;


DELIMITER ;
-- -----------------------------------------------------
-- function CalculateFuelScaleCharge
-- -----------------------------------------------------

-- -----------------------------------------------------
-- procedure GetBankStatemnetDetailsDashboardTransactions
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `GetBankStatemnetDetailsDashboardTransactions`()
BEGIN
SET @concatedQuery = concat("SELECT bankstatementdetails.BankStatementID,bankstatementdetails.BankID,bankstatementdetails.Date,bankstatementdetails.Particulars,bankstatementdetails.ChequeORRefNo,bankstatementdetails.AmountType,bankstatementdetails.Amount,bank.BankName,bank.AccountNumber,bankstatementdetails.Status 
                            from bankstatementdetails INNER JOIN bank on bankstatementdetails.BankID = bank.BankID");
PREPARE stmt from @concatedQuery;
EXECUTE stmt;
END$$

$$
DELIMITER ;


DELIMITER ;
-- -----------------------------------------------------
-- procedure GetBankingTransactions
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `GetBankingTransactions`()
BEGIN
SET @concatedQuery = concat("SELECT banking.BankingID,banking.Date,banking.BankID,banking.Type,bank.BankName,bank.AccountNumber,banking.Credit,banking.Debit,banking.ChequeNumber,banking.Status
                            from banking INNER JOIN bank on banking.BankID = bank.BankID");
PREPARE stmt from @concatedQuery;
EXECUTE stmt;

END$$

$$
DELIMITER ;


DELIMITER ;
-- -----------------------------------------------------
-- procedure GetCreditNoteExpenseTransactions
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `GetCreditNoteExpenseTransactions`(IN whereClause varchar(21845))
BEGIN

SET @concatedQuery = concat("SELECT creditnote.CreditNoteID,creditnote.ReferenceNumber,creditnote.CreditNoteNumber,creditnote.CreditNoteDate,creditnote.Notes,creditnote.TransactionType,creditnote.SupplierID,supplier.CompanyName,creditnote.ExpenseTypeID,expensetype.ExpenseTypeName,creditnote.IsPaid,creditnote.PaymentDate,creditnote.PaymentMethod,creditnote.PaymentAmount,creditnote.ChequeNumber,creditnote.Bank,creditnote.AccountNumber,creditnote.CreditCardType,creditnote.TotalGrossAmount,creditnote.TotalVATAmount,creditnote.TotalNettAmount,creditnote.IsEC,creditnote.VATReportingDate,creditnote.VATNumber,creditnote.EncodedID 

                            from creditnote INNER JOIN supplier on creditnote.SupplierID = supplier.SupplierID

                            INNER JOIN expensetype on creditnote.ExpenseTypeID = expensetype.ExpenseTypeID",whereClause);

PREPARE stmt from @concatedQuery;

EXECUTE stmt;

END$$

$$
DELIMITER ;


DELIMITER ;
-- -----------------------------------------------------
-- procedure GetCreditNotePurchaseTransactions
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `GetCreditNotePurchaseTransactions`(IN whereClause varchar(21845))
BEGIN

SET @concatedQuery = concat("SELECT creditnote.CreditNoteID,creditnote.ReferenceNumber,creditnote.CreditNoteNumber,creditnote.CreditNoteDate,creditnote.Notes,creditnote.TransactionType,creditnote.SupplierID,supplier.CompanyName,creditnote.IsPaid,creditnote.PaymentDate,creditnote.PaymentMethod,creditnote.PaymentAmount,creditnote.ChequeNumber,creditnote.Bank,creditnote.AccountNumber,creditnote.CreditCardType,creditnote.TotalGrossAmount,creditnote.TotalVATAmount,creditnote.TotalNettAmount,creditnote.IsEC,creditnote.VATReportingDate,creditnote.VATNumber,creditnote.EncodedID 

                            from creditnote INNER JOIN supplier on creditnote.SupplierID = supplier.SupplierID",whereClause);

PREPARE stmt from @concatedQuery;

EXECUTE stmt;

END$$

$$
DELIMITER ;


DELIMITER ;
-- -----------------------------------------------------
-- procedure GetCreditNoteSalesTransactions
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `GetCreditNoteSalesTransactions`(IN whereClause varchar(21845))
BEGIN

SET @concatedQuery = concat("SELECT creditnote.CreditNoteID,creditnote.ReferenceNumber,creditnote.CreditNoteNumber,creditnote.CreditNoteDate,creditnote.Notes,creditnote.TransactionType,creditnote.CustomerID,customer.CompanyName,creditnote.IsPaid,creditnote.PaymentDate,creditnote.PaymentMethod,creditnote.PaymentAmount,creditnote.ChequeNumber,creditnote.Bank,creditnote.AccountNumber,creditnote.CreditCardType,creditnote.TotalGrossAmount,creditnote.TotalVATAmount,creditnote.TotalNettAmount,creditnote.IsEC,creditnote.VATReportingDate,creditnote.VATNumber,creditnote.EncodedID 

                            from creditnote INNER JOIN customer on creditnote.CustomerID = customer.CustomerID",whereClause);

PREPARE stmt from @concatedQuery;

EXECUTE stmt;

END$$

$$
DELIMITER ;


DELIMITER ;
-- -----------------------------------------------------
-- procedure GetExpenseTransactions
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `GetExpenseTransactions`(IN whereClause varchar(21845))
BEGIN

SET @concatedQuery = concat("select expense.ExpenseID,expense.ReferenceNumber, supplier.CompanyName,expensetype.ExpenseTypeName,expense.InvoiceNumber,expense.InvoiceDate, 
(select sum(expenseitem.NettAmount) from expenseitem  where expenseitem.VATRate = 20.00 and expenseitem.ExpenseID = expense.ExpenseID) as StandardNettAmt, 
(select sum(expenseitem.NettAmount) from expenseitem  where expenseitem.VATRate = 5.00 and expenseitem.ExpenseID = expense.ExpenseID) as LowerNettAmt , 
(select sum(expenseitem.NettAmount) from expenseitem  where expenseitem.VATRate = 0.00 and expenseitem.ExpenseID = expense.ExpenseID) as ZeroRatedAmt ,
expense.NonVATAmount,expense.TotalNettAmount ,expense.TotalVATAmount,expense.TotalGrossAmount ,expense.PaymentMethod,expense.IsEC,expense.Notes,expense.EncodedExpenseID from expense inner join supplier on expense.SupplierID = supplier.SupplierID  INNER JOIN
    expensetype ON expense.ExpenseTypeID = expensetype.ExpenseTypeID",whereClause);

PREPARE stmt from  @concatedQuery;
EXECUTE stmt;

END$$

$$
DELIMITER ;


DELIMITER ;
-- -----------------------------------------------------
-- procedure GetPurchaseTransactions
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `GetPurchaseTransactions`(IN whereClause varchar(21845))
BEGIN

SET @concatedQuery = concat("select purchase.PurchaseID,purchase.ReferenceNumber, supplier.CompanyName,purchase.InvoiceNumber,purchase.InvoiceDate, 
(select sum(purchaseitem. StandardGrossAmount) from purchaseitem  where  purchaseitem.PurchaseID = purchase.PurchaseID) as StandardNettAmt, 
(select sum(purchaseitem. LowerGrossAmount) from purchaseitem  where  purchaseitem.PurchaseID = purchase.PurchaseID) as LowerNettAmt , 
(select sum(purchaseitem. ZeroGrossAmount) from purchaseitem  where  purchaseitem.PurchaseID = purchase.PurchaseID) as ZeroRatedAmt ,
purchase.TotalNettAmount ,purchase.TotalVATAmount,purchase.TotalGrossAmount ,purchase.PaymentMethod,purchase.IsEC,purchase.Notes,purchase.EncodedPurchaseID from purchase inner join supplier on purchase.SupplierID = supplier.SupplierID
",whereClause);

PREPARE stmt from @concatedQuery;
EXECUTE stmt;

END$$

$$
DELIMITER ;


DELIMITER ;
-- -----------------------------------------------------
-- procedure GetSalesDGTTransactions
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `GetSalesDGTTransactions`(IN whereClause varchar(21845))
BEGIN

SET @concatedQuery = concat("select sales.SalesID,sales.SalesType,sales.ReferenceNumber, sales.InvoiceNumber,sales.InvoiceDate, 
(select sum(salesnormal.NettAmount) from salesnormal  where salesnormal.VATRate = 20.00 and salesnormal.SalesID = sales.SalesID) as StandardNettAmt, 
(select sum(salesnormal.NettAmount) from salesnormal  where salesnormal.VATRate = 5.00 and salesnormal.SalesID = sales.SalesID) as LowerNettAmt , 
(select sum(salesnormal.NettAmount) from salesnormal  where salesnormal.VATRate = 0.00 and salesnormal.SalesID = sales.SalesID) as ZeroRatedAmt ,
sales.TotalNettAmount ,sales.TotalVATAmount,sales.TotalGrossAmount ,sales.PaymentMethod,sales.IsEC,sales.Notes,sales.EncodedSalesID from sales",
whereClause);

PREPARE stmt from @concatedQuery;
EXECUTE stmt;

END$$

$$
DELIMITER ;


DELIMITER ;
-- -----------------------------------------------------
-- procedure GetSalesDataTransactions
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `GetSalesDataTransactions`(IN whereClause varchar(21845))
BEGIN
SET @concatedQuery = concat("select sales.SalesID,sales.ReferenceNumber,sales.InvoiceNumber,sales.InvoiceDate,sales.Cash,sales.Cheque,sales.CreditCards,sales.CreditSales, sales.TotalNettAmount ,sales.TotalGrossAmount, sales.PaymentMethod ,sales.Notes,sales.SalesType,sales.EncodedSalesID from sales",whereClause);
PREPARE stmt from @concatedQuery;
EXECUTE stmt;
END$$

$$
DELIMITER ;


DELIMITER ;
-- -----------------------------------------------------
-- procedure GetSalesTransactions
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `GetSalesTransactions`(IN whereClause varchar(21845))
BEGIN

SET @concatedQuery = concat("select sales.SalesID,sales.ReferenceNumber, customer.CompanyName,sales.InvoiceNumber,sales.InvoiceDate, 
(select sum(salesnormal.NettAmount) from salesnormal  where salesnormal.VATRate = 20.00 and salesnormal.SalesID = sales.SalesID) as StandardNettAmt, 
(select sum(salesnormal.NettAmount) from salesnormal  where salesnormal.VATRate = 5.00 and salesnormal.SalesID = sales.SalesID) as LowerNettAmt , 
(select sum(salesnormal.NettAmount) from salesnormal  where salesnormal.VATRate = 0.00 and salesnormal.SalesID = sales.SalesID) as ZeroRatedAmt ,
sales.TotalNettAmount ,sales.TotalVATAmount,sales.TotalGrossAmount ,sales.PaymentMethod,sales.IsEC,sales.Notes,sales.EncodedSalesID,sales.IsPaid from sales inner join customer on sales.CustomerID = customer.CustomerID
",whereClause);

PREPARE stmt from @concatedQuery;
EXECUTE stmt;

END$$

$$
DELIMITER ;


DELIMITER ;
-- -----------------------------------------------------
-- procedure GettVatReturnRawValues
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `GettVatReturnRawValues`(IN _ClientId int,IN _startDate datetime, IN _endDate datetime)
BEGIN

-- 32)43) 41) 100) 103) 6) 3)   8) 1)  
	
declare TotalGrossSaleDGT decimal(18,2);
declare TotalGrossSale decimal(18,2);
declare TotalECSale decimal(18,2);
declare TotalGrossSaleCreditNote decimal(18,2);
declare TotalGrossECSaleCreditNote decimal(18,2);
declare TotalNettSaleCreditNote decimal (18,2);
declare TotalVATSaleCreditNote decimal(18,2);
declare TotalNettECSaleCreditNote decimal (18,2);
declare TotalVATECSaleCreditNote decimal(18,2);
declare TotalGrossSaleAtStandardRate decimal(18,2);
declare TotalGrossSaleCreditnoteAtStandardRate decimal(18,2);
declare TotalVATSaleAtStandardRate decimal(18,2);
declare TotalVATSaleCreditnoteAtStandardRate decimal(18,2);
declare TotalNettSaleAtStandardRate decimal(18,2);
declare TotalNettSaleCreditnoteAtStandardRate decimal(18,2);
declare TotalGrossSaleAtLowerRate decimal(18,2);
declare TotalGrossSaleCreditnoteATLowerRate decimal(18,2);
declare TotalVATSaleAtLowerRate decimal(18,2);
declare TotalVATSaleCreditnoteAtLowerRate decimal(18,2);
declare TotalNettSaleAtLowerRate decimal(18,2);
declare TotalNettSaleCreditnoteAtLowerRate decimal(18,2);
declare TotalGrossSaleAtZeroRate decimal(18,2);
declare TotalGrossSaleCreditnoteAtZeroRate decimal(18,2);
declare TotalVATSaleAtZeroRate decimal(18,2);
declare TotalVATSaleCreditnoteAtZeroRate decimal(18,2);
declare TotalNettSaleAtZeroRate decimal(18,2);
declare TotalNettSaleCreditnoteAtZeroRate decimal(18,2);
declare TotalGrossPurchases decimal(18,2);
declare TotalGrossPurchasesAtStandardRate decimal(18,2);
declare TotalGrossPurchasesAtLowerRate decimal(18,2);
declare TotalGrossPurchasesAtZeroRate decimal(18,2);
declare TotalNettPurchases decimal(18,2);
declare TotalNettPurchasesAtStandardRate decimal(18,2);
declare TotalNettPurchasesAtLowerRate decimal(18,2);
declare TotalNettPurchasesAtZeroRate decimal(18,2);
declare TotalVATPurchases decimal(18,2);
declare TotalVATPurchasesAtStandardRate decimal(18,2);
declare TotalVATPurchasesAtLowerRate decimal(18,2);
declare TotalVATPurchasesAtZeroRate decimal(18,2);
declare TotalGrossECPurchases decimal(18,2);
declare TotalNettECPurchases decimal(18,2);
declare TotalVATECPurchases decimal(18,2);
declare TotalGrossCreditNotesPurchases decimal(18,2);
declare TotalNettCreditNotesPurchases decimal(18,2);
declare TotalVATCreditNotesPurchases decimal(18,2);
declare TotalGrossCreditNotesPurchasesAtStandardRate decimal(18,2);
declare TotalGrossCreditNotesPurchasesAtLowerRate decimal(18,2);
declare TotalGrossCreditNotesPurchasesAtZeroRate decimal(18,2);
declare TotalNettCreditNotesPurchasesAtStandardRate decimal(18,2);
declare TotalNettCreditNotesPurchasesAtLowerRate decimal(18,2);
declare TotalNettCreditNotesPurchasesAtZeroRate decimal(18,2);
declare TotalVATCreditNotesPurchasesAtStandardRate decimal(18,2);
declare TotalVATCreditNotesPurchasesAtLowerRate decimal(18,2);
declare TotalVATCreditNotesPurchasesAtZeroRate decimal(18,2);
declare TotalVATCreditNotesECPurchasesAtZeroRate decimal(18,2);
declare TotalVATCreditNotesECPurchasesAtLowerRate decimal(18,2);
declare TotalVATCreditNotesECPurchasesAtStandardRate decimal(18,2);
declare TotalNettCreditNotesECPurchasesAtZeroRate decimal(18,2);
declare TotalNettCreditNotesECPurchasesAtLowerRate decimal(18,2);
declare TotalNettCreditNotesECPurchasesAtStandardRate decimal(18,2);
declare TotalGrossCreditNotesECPurchasesAtZeroRate decimal(18,2);
declare TotalGrossCreditNotesECPurchasesAtLowerRate decimal(18,2);
declare TotalGrossCreditNotesECPurchasesAtStandardRate decimal(18,2);
declare TotalGrossCreditNotesExpensesAtStandardRate decimal(18,2);
declare TotalGrossCreditNotesExpensesAtLowerRate decimal(18,2);
declare TotalGrossCreditNotesExpensesAtZeroRate decimal(18,2);
declare TotalNettCreditNotesExpensesAtStandardRate decimal(18,2);
declare TotalNettCreditNotesExpensesAtLowerRate decimal(18,2);
declare TotalNettCreditNotesExpensesAtZeroRate decimal(18,2);
declare TotalVATCreditNotesExpensesAtStandardRate decimal(18,2);
declare TotalVATCreditNotesExpensesAtLowerRate decimal(18,2);
declare TotalVATCreditNotesExpensesAtZeroRate decimal(18,2);
declare TotalVATCreditNotesECExpensesAtZeroRate decimal(18,2);
declare TotalVATCreditNotesECExpensesAtLowerRate decimal(18,2);
declare TotalVATCreditNotesECExpensesAtStandardRate decimal(18,2);
declare TotalNettCreditNotesECExpensesAtZeroRate decimal(18,2);
declare TotalNettCreditNotesECExpensesAtLowerRate decimal(18,2);
declare TotalNettCreditNotesECExpensesAtStandardRate decimal(18,2);
declare TotalGrossCreditNotesECExpensesAtZeroRate decimal(18,2);
declare TotalGrossCreditNotesECExpensesAtLowerRate decimal(18,2);
declare TotalGrossCreditNotesECExpensesAtStandardRate decimal(18,2);
declare TotalGrossCreditNotesSalesAtStandardRate decimal(18,2);
declare TotalGrossCreditNotesSalesAtLowerRate decimal(18,2);
declare TotalGrossCreditNotesSalesAtZeroRate decimal(18,2);
declare TotalNettCreditNotesSalesAtStandardRate decimal(18,2);
declare TotalNettCreditNotesSalesAtLowerRate decimal(18,2);
declare TotalNettCreditNotesSalesAtZeroRate decimal(18,2);
declare TotalVATCreditNotesSalesAtStandardRate decimal(18,2);
declare TotalVATCreditNotesSalesAtLowerRate decimal(18,2);
declare TotalVATCreditNotesSalesAtZeroRate decimal(18,2);
declare TotalVATCreditNotesECSalesAtZeroRate decimal(18,2);
declare TotalVATCreditNotesECSalesAtLowerRate decimal(18,2);
declare TotalVATCreditNotesECSalesAtStandardRate decimal(18,2);
declare TotalNettCreditNotesECSalesAtZeroRate decimal(18,2);
declare TotalNettCreditNotesECSalesAtLowerRate decimal(18,2);
declare TotalNettCreditNotesECSalesAtStandardRate decimal(18,2);
declare TotalGrossCreditNotesECSalesAtZeroRate decimal(18,2);
declare TotalGrossCreditNotesECSalesAtLowerRate decimal(18,2);
declare TotalGrossCreditNotesECSalesAtStandardRate decimal(18,2);
declare TotalGrossCreditNotesECPurchases decimal(18,2);
declare TotalNettCreditNotesEcPurchases decimal(18,2);
declare TotalVATCreditNotesECPurchases decimal(18,2);
declare TotalGrossImportPurchases decimal(18,2);
declare TotalNettImportsPurchases decimal(18,2);
declare TotalVATImportsPurchases decimal(18,2);
declare TotalGrossExpenses decimal(18,2);
declare TotalGrossExpensesAtStandardRate decimal(18,2);
declare TotalGrossExpensesAtLowerRate decimal(18,2);
declare TotalGrossExpensesAtZeroRate decimal(18,2);
declare TotalNettExpenses decimal(18,2);
declare TotalNettExpensesAtStandardRate decimal(18,2);
declare TotalNettExpensesAtLowerRate decimal(18,2);
declare TotalNettExpensesAtZeroRate decimal(18,2);
declare TotalVATExpenses decimal(18,2);
declare TotalVATExpensesAtStandardRate decimal(18,2);
declare TotalVATExpensesAtLowerRate decimal(18,2);
declare TotalVATExpensesAtZeroRate decimal(18,2);
declare TotalGrossECExpenses decimal(18,2);
declare TotalNettECExpenses decimal(18,2);
declare TotalVATECExpenses decimal(18,2);
declare TotalGrossCreditNotesExpenses decimal(18,2);
declare TotalNettCreditNotesExpenses decimal(18,2);
declare TotalVATCreditNotesExpenses decimal(18,2);
declare TotalGrossCreditNotesECExpenses decimal(18,2);
declare TotalNettCreditNotesEcExpenses decimal(18,2);
declare TotalVATCreditNotesECExpenses decimal(18,2);
declare TotalGrossImportExpenses decimal(18,2);
declare TotalNettImportsExpenses decimal(18,2);
declare TotalVATImportsExpenses decimal(18,2);
declare TotalGrossECPurchasesAtStandardRate decimal(18,2);
declare TotalGrossECPurchasesAtLowerRate decimal(18,2);
declare TotalGrossECPurchasesAtZeroRate decimal(18,2);
declare TotalNettECPurchasesAtStandardRate decimal(18,2);
declare TotalNettECPurchasesAtLowerRate decimal(18,2);
declare TotalNettECPurchasesAtZeroRate decimal(18,2);
declare TotalVATECPurchasesAtStandardRate decimal(18,2);
declare TotalVATECPurchasesAtLowerRate decimal(18,2);
declare TotalVATECPurchasesAtZeroRate decimal(18,2);
declare TotalGrossECExpensesAtStandardRate decimal(18,2);
declare TotalGrossECExpensesAtLowerRate decimal(18,2);
declare TotalGrossECExpensesAtZeroRate decimal(18,2);
declare TotalNettECExpensesAtStandardRate decimal(18,2);
declare TotalNettECExpensesAtLowerRate decimal(18,2);
declare TotalNettECExpensesAtZeroRate decimal(18,2);
declare TotalVATECExpensesAtStandardRate decimal(18,2);
declare TotalVATECExpensesAtLowerRate decimal(18,2);
declare TotalVATECExpensesAtZeroRate decimal(18,2);
declare TotalGrossECSalesAtStandardRate decimal(18,2);
declare TotalGrossECSalesAtLowerRate decimal(18,2);
declare TotalGrossECSalesAtZeroRate decimal(18,2);
declare TotalNettECSalesAtStandardRate decimal(18,2);
declare TotalNettECSalesAtLowerRate decimal(18,2);
declare TotalNettECSalesAtZeroRate decimal(18,2);
declare TotalVATECSalesAtStandardRate decimal(18,2);
declare TotalVATECSalesAtLowerRate decimal(18,2);
declare TotalVATECSalesAtZeroRate decimal(18,2);
declare TotalNHSPrescriptionAmount decimal(18,2);
declare TotalPrivatePrescriptionAmount decimal(18,2);
declare TotalPracticePaymentAmount decimal(18,2);
declare TotalNHSChequeReceivedAmount decimal(18,2);
declare TotalExemptZeroTreatmentAmount decimal(18,2);
declare TotalTaxablePracticePaymentAmount decimal(18,2);
declare TotalCafeHotAmount decimal(18,2);
declare TotalCafeColdAmount decimal(18,2);
declare TotalGrossSaleExemptItems decimal(18,2);
declare TotalTaxableOtherIncomeAmount decimal(18,2);
declare TotalNettValueExemptItems decimal(18,2);
declare TotalVATDueForFuelScaleCharges decimal(18,2);
declare TotalSaleDailyTakingCommissions decimal(18,2);
declare TotalNettSaleDailyTakings decimal(18,2);
declare TotalOwnConsumptions decimal(18,2);
declare TotalCommSaleExemptItems decimal(18,2);
declare TotalGrossSaleZeroItems decimal(18,2);
declare TotalNettValueZeroItems decimal(18,2);
declare TotalCommSaleZeroItems decimal(18,2);
declare TotalGrossSaleSubVATItems decimal(18,2);
declare TotalNettValueSubVATItems decimal(18,2);
declare TotalCommSaleSubVATItems decimal(18,2);
declare PharmacyRetailSalesForZeroRateValue decimal(18,2);
declare PharmacyRetailSalesForLowerRateValue decimal(18,2);
declare ESPForLowerRateValue decimal(18,2);
declare ESPForZeroRateValue decimal(18,2);
declare ESPForStandardRateValue decimal(18,2);
declare TotalVatNotApplicable decimal(18,2);
declare TotalNettSale decimal(18,2);
declare OpeningStock decimal(18,2);
declare TotalNettPurchasesForProfitAndLoss decimal(18,2);
declare period int;
declare end_Date int;
declare start_date int;
		 
    Select if (Sum(GrossAmount) is null,0, Sum(GrossAmount))
    From TransactionVat inner join Transaction on TransactionVat.TransactionID=Transaction.TransactionID
    inner join sales on sales.SalesID= Transaction.TransactionTypeID
    Where
    Sales.SalesType in ('SalesDailyGrossTaking') and
    Transaction.TransactionType in ('SALES') and
    Transaction.Status <> 0 and
    Sales.Status=1 and
    Sales.IsEC = 0 and
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossSaleDGT;



    Select if (Sum(sales.TotalGrossAmount) is null,0, Sum(sales.TotalGrossAmount))
    from sales
    inner join  Transaction on sales.SalesID=Transaction.TransactionTypeID
    Where
    Transaction.TransactionType in ('SALES') and
    Transaction.Status <> 0 and
    Transaction.TransactionDate between _startDate and _endDate into  TotalGrossSale;  



		Select if (Sum(GrossAmount) is null,0, Sum(GrossAmount))
    From TransactionVat inner join Transaction on TransactionVat.TransactionID=Transaction.TransactionID
    inner join sales on sales.SalesID=Transaction.TransactionTypeID
    Where
    Transaction.TransactionType in ('SALES') and
    Transaction.Status <> 0 and
    Sales.IsEC = 1 and
    Sales.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalECSale;




    Select if (Sum(creditnote.TotalGrossAmount) is null,0, Sum(creditnote.TotalGrossAmount))
     From creditnote 
     inner join Transaction on creditnote.creditnoteid=transaction.TransactionTypeID
    Where
    Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and
    creditnote.Status is null and
    Transaction.Status is null and
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossSaleCreditNote;



    Select if (Sum(GrossAmount) is null,0, Sum(GrossAmount))
    From TransactionVAT 
     inner join Transaction on transactionVAT.TransactionID = Transaction.TransactionID 
    inner join creditnote on creditnote.creditnoteid=transaction.TransactionTypeID
    Where
    Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and
    Creditnote.IsEC = 1 and
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossECSaleCreditNote;


   Select if (Sum(creditnote.TotalNettAmount) is null,0, Sum(creditnote.TotalNettAmount))
     From creditnote 
     inner join Transaction on creditnote.creditnoteid=transaction.TransactionTypeID
    Where
    Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and
    creditnote.Status is null and
    Transaction.Status is null and
    Creditnote.IsEC = 0 and
    Transaction.TransactionDate between _startDate and _endDate into TotalNettSaleCreditNote;



     Select if (Sum(VATAmount) is null,0,Sum(VATAmount))
     From transactionVAT inner join Transaction  on transactionVAT.TransactionID = Transaction.TransactionID
     inner join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
     Where
    Transaction.TransactionType in('CreditNote')and
    CreditNote.TransactionType in('Sales') and
    creditnote.Status=1 and
    Transaction.Status <> 0 and
    CreditNote.IsEC = 0 and
    Transaction.TransactionDate between _startDate and _endDate into TotalVATSaleCreditNote;



    Select if (Sum(NettAmount) is null,0, Sum(NettAmount))
    From transactionVAT inner join Transaction on transactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where
    Transaction.TransactionType in ('CreditNote') and
    CreditNote.TransactionType in('Sales') and
    CreditNote.IsEC = 1 and
    Transaction.TransactionDate between _startDate and _endDate into TotalNettECSaleCreditNote;
	


	Select if (Sum(VATAmount) is null,0,Sum(VATAmount))
     From transactionVAT inner join Transaction  on transactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where
    Transaction.TransactionType in('CreditNote')and
    CreditNote.TransactionType in('Sales') and
    creditnote.Status=1 and
    Transaction.Status <> 0 and
    CreditNote.IsEC = 1 and
    Transaction.TransactionDate between _startDate and _endDate into TotalVATECSaleCreditNote;



          Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Sales on Sales.SalesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('SALES') and
    TransactionVAT.VATRate IN ('Standard') AND
    Sales.IsEC = 0 and 
    Sales.Status=1 and
    Transaction.status = 1 and
    Transaction.TransactionDate between  _startDate and _endDate INTO TotalGrossSaleAtStandardRate;




	Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and
    creditnote.Status=1 and
    Transaction.Status <> 0 and CreditNote.IsEC = 0  and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossSaleCreditnoteAtStandardRate;



	
	 Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Sales on Sales.SalesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('SALES') and
    TransactionVAT.VATRate IN ('Standard') AND
    Sales.IsEC = 0 and 
    Transaction.status = 1 and
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATSaleAtStandardRate;



	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where  Transaction.TransactionType IN('CreditNote') and
    CreditNote.TransactionType in('Sales') and
    creditnote.Status=1 and
    Transaction.Status <> 0 and CreditNote.IsEC = 0  and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.TransactionDate between _startDate and _endDate into TotalVATSaleCreditnoteAtStandardRate;



    Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Sales on Sales.SalesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('SALES') and
    TransactionVAT.VATRate IN ('Standard') AND
    Sales.IsEC = 0 and 
    Transaction.status = 1 and
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettSaleAtStandardRate;



 	
	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID =Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.Transactiontype in ('Sales') and 
    CreditNote.Status=1 and 
    Transaction.Status <> 0 and  CreditNote.IsEC = 0 and  
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.TransactionDate between _startDate and _endDate into TotalNettSaleCreditnoteAtStandardRate;



	Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Sales on Sales.SalesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('SALES') and
    TransactionVAT.VATRate IN ('Lower') AND
    Sales.IsEC = 0 and 
    Sales.Status=1 and 
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossSaleAtLowerRate;



	Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.Transactiontype in ('Sales') and 
    CreditNote.Status=1 and 
    Transaction.status <> 0 and CreditNote.IsEC = 0 and 
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossSaleCreditnoteATLowerRate;



 	Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Sales on Sales.SalesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('SALES') and
    TransactionVAT.VATRate IN ('Lower') AND
    Sales.IsEC = 0 and 
    Sales.Status=1 and
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATSaleAtLowerRate;


	
	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where  Transaction.TransactionType in('CreditNote') and
    CreditNote.Transactiontype in ('Sales') and 
    CreditNote.Status=1 and 
    Transaction.Status <> 0 and  CreditNote.IsEC = 0 and 
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.TransactionDate between _startDate and _endDate into TotalVATSaleCreditnoteAtLowerRate;



	 Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Sales on Sales.SalesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('SALES') and
    TransactionVAT.VATRate IN ('Lower') AND
    Sales.IsEC = 0 and 
    Sales.Status=1 and 
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettSaleAtLowerRate;
    
    

	
	 Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where  Transaction.TransactionType in('CreditNote') and
    CreditNote.Transactiontype in ('Sales') and 
    CreditNote.Status=1 and 
    Transaction.Status <> 0 and  CreditNote.IsEC = 0 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.TransactionDate between _startDate and _endDate into TotalNettSaleCreditnoteAtLowerRate;



	  Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Sales on Sales.SalesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('SALES') and
    TransactionVAT.VATRate IN ('Zero') AND
    Sales.IsEC = 0 and 
    Sales.Status=1 and 
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossSaleAtZeroRate;



	Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.Transactiontype in ('Sales') and 
    CreditNote.Status=1 and 
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossSaleCreditnoteAtZeroRate;



 	Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Sales on Sales.SalesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('SALES') and
    TransactionVAT.VATRate IN ('Zero') AND
    Sales.IsEC = 0 and
    Sales.Status=1 and 
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATSaleAtZeroRate;

    


	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.Transactiontype in ('Sales') and 
    CreditNote.Status=1 and 
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.TransactionDate between _startDate and _endDate into TotalVATSaleCreditnoteAtZeroRate;



	 Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Sales on Sales.SalesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('SALES') and
    TransactionVAT.VATRate IN ('Zero') AND
    Sales.IsEC = 0 and
    Sales.Status=1 and 
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettSaleAtZeroRate;



	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where  Transaction.TransactionType in('CreditNote') and
    CreditNote.Transactiontype in ('Sales') and 
    CreditNote.Status=1 and 
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.TransactionDate between _startDate and _endDate into TotalNettSaleCreditnoteAtZeroRate;



	Select if (Sum(GrossAmount) is null, 0,Sum(GrossAmount))  From TransactionVat
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Transaction.status = 1 and
    Purchase.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossPurchases;

	


	Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    TransactionVAT.VATRate IN ('Standard') AND
    Purchase.IsEC = 0 and Purchase.IsImport = 0 and
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossPurchasesAtStandardRate;



	 Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    TransactionVAT.VATRate IN ('Lower') AND
    Purchase.IsEC = 0 and Purchase.IsImport = 0 and
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossPurchasesAtLowerRate;



	 Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TranSActionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    TransactionVAT.VATRate IN ('Zero') AND
    Purchase.IsEC = 0 and Purchase.IsImport = 0 and
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossPurchasesAtZeroRate;



 	Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('PURCHASE') and
    Purchase.IsEC = 0 and  Purchase.IsImport = 0 and 
    Transaction.status = 1 and
    Purchase.Status=1 and
    Transaction.TransactionDate between  _startDate and _endDate INTO TotalNettPurchases;



	 Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    TransactionVAT.VATRate IN ('Standard') AND
    Purchase.IsEC = 0 and Purchase.IsImport = 0 and
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettPurchasesAtStandardRate;
    


	 Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    TransactionVAT.VATRate IN ('Lower') AND
    Purchase.IsEC = 0 and Purchase.IsImport = 0 and
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between  _startDate and _endDate  INTO TotalNettPurchasesAtLowerRate;



	Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    TransactionVAT.VATRate IN ('Zero') AND
    Purchase.IsEC = 0 and Purchase.IsImport = 0 and
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettPurchasesAtZeroRate;



	Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 0 and Purchase.IsImport = 0 and
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATPurchases;



	Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    TransactionVAT.VATRate IN ('Standard') AND
    Purchase.IsEC = 0 and Purchase.IsImport = 0 and
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATPurchasesAtStandardRate; 




	Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    TransactionVAT.VATRate IN ('Lower') AND
    Purchase.IsEC = 0 and Purchase.IsImport = 0 and
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATPurchasesAtLowerRate;


	
	Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    TransactionVAT.VATRate IN ('Zero') AND
    Purchase.IsEC = 0 and Purchase.IsImport = 0 and
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between  _startDate and _endDate INTO TotalVATPurchasesAtZeroRate;



	 Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 1 and Purchase.IsImport = 0 and
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossECPurchases;

-- /////////////////////////
-- TotalNettECPurchases :-

			   Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('PURCHASE') and
    Purchase.IsEC = 1 and Purchase.IsImport = 0 and Transaction.status = 1 and
    Purchase.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate  INTO TotalNettECPurchases;


-- ///////////////////




	Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
     inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 1 and Purchase.IsImport = 0 and
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATECPurchases;



	Select if (Sum(GrossAmount) is null, 0,Sum(GrossAmount))  From TransactionVat 
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesPurchases;

 
	
		 
    Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  
    From TransactionVAT inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    inner join creditnote on creditnote.CreditNoteID=Transaction.TransactionTypeID
    where Transaction.TransactionType in ('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    creditnote.IsEC = 0 and
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesPurchases;
	


	
	 Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') AND CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesPurchases;


	
	Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    TransactionVAT.VATRate IN ('Standard') AND
    CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesPurchasesAtStandardRate;
		


	Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    TransactionVAT.VATRate IN ('Lower') AND
    CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesPurchasesAtLowerRate;



	Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and
    TransactionVAT.VATRate IN ('Zero') AND
    CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesPurchasesAtZeroRate;
    


	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where  Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and
CreditNote.Status=1 and 
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesPurchasesAtStandardRate;



	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and
CreditNote.Status=1 and 
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesPurchasesAtLowerRate;



	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType  in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and
CreditNote.Status=1 and 
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesPurchasesAtZeroRate;



	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
     Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType  in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesPurchasesAtStandardRate;	



	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesPurchasesAtLowerRate;



	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
   CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesPurchasesAtZeroRate;



	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesECPurchasesAtZeroRate;



	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC =1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesECPurchasesAtLowerRate;




	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesECPurchasesAtStandardRate;
	

	
	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesECPurchasesAtZeroRate;



	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesECPurchasesAtLowerRate;



	 Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC =1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesECPurchasesAtStandardRate;




		 Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    TransactionVAT.VATRate IN ('Zero') AND
    CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesECPurchasesAtZeroRate;



	Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    TransactionVAT.VATRate IN ('Lower') AND
    CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesECPurchasesAtLowerRate; 

 

	Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    TransactionVAT.VATRate IN ('Standard') AND
    CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesECPurchasesAtStandardRate;



	Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where  Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesExpensesAtStandardRate;

 

	Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesExpensesAtLowerRate;




	 Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesExpensesAtZeroRate;



	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesExpensesAtStandardRate;




	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType  in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesExpensesAtLowerRate;

-- 68) TotalNettCreditNotesExpensesAtZeroRate :-

	-- Not Given


 

	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    TransactionVAT.VATRate IN ('Standard') AND
    CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesExpensesAtStandardRate;

 
	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesExpensesAtLowerRate;



	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesExpensesAtZeroRate;



	 Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesECExpensesAtZeroRate;



	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC =1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesECExpensesAtLowerRate;



	 Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesECExpensesAtStandardRate;



	 Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    TransactionVAT.VATRate IN ('Zero') AND
    CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesECExpensesAtZeroRate;

 

	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesECExpensesAtLowerRate;



	 Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC =1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesECExpensesAtStandardRate;



	 Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesECExpensesAtZeroRate;


	 
	 Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesECExpensesAtLowerRate;



		Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesECExpensesAtStandardRate;



	Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesSalesAtStandardRate;


	
	 Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesSalesAtLowerRate;


    		
	Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesSalesAtZeroRate;



	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesSalesAtStandardRate;



	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesSalesAtLowerRate;



	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesSalesAtZeroRate;



	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesSalesAtStandardRate;




	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesSalesAtLowerRate;



	   Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesSalesAtZeroRate;



	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesECSalesAtZeroRate;



	Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesECSalesAtLowerRate;



		Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesECSalesAtStandardRate;

 
	
			Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesECSalesAtZeroRate;



	Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesECSalesAtLowerRate;


		
Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC =1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesECSalesAtStandardRate;



		Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesECSalesAtZeroRate;



		 Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.Status <> 0 and CreditNote.IsEC =1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesECSalesAtLowerRate;



		Select if (Sum(TransactionVAT.GrossAmount) is null, 0,Sum(TransactionVAT.GrossAmount))  From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Sales') and 
    CreditNote.Status=1 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesECSalesAtStandardRate;



  Select if (Sum(GrossAmount) is null, 0,Sum(GrossAmount))  From TransactionVAT 
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    CreditNote.Status=1 and
    Transaction.Status <> 0 and
    CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesECPurchases;



		 Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount)) 
    From TransactionVAT inner join Transaction  on  TransactionVAT.TransactionID =Transaction.TransactionID
    inner join creditnote on creditnote.CreditNoteID=Transaction.TransactionTypeID
    where Transaction.TransactionType in ('CreditNote') and 
    CreditNote.TransactionType in('Purchase') and
    creditnote.IsEC = 1 and
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesEcPurchases;



	 Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount)) From TransactionVAT 
    inner join Transaction  on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Purchase') and 
    CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesECPurchases;



	Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 0 and Purchase.IsImport = 1 and
    Purchase.status=1 and
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossImportPurchases;



		Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('PURCHASE') and
    Purchase.IsEC = 0 and Purchase.IsImport = 1  and Transaction.status = 1 and
    Purchase.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettImportsPurchases;
	


	 Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 0 and Purchase.IsImport = 1 and
    Purchase.status=1 and
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATImportsPurchases;
	


	Select if (Sum(GrossAmount) is null, 0,Sum(GrossAmount))  From TransactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 0 and Expense.IsImport = 0 and
    Expense.Status=1 and
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossExpenses;



		Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    TransactionVAT.VATRate IN ('Standard') AND
    Expense.IsEC = 0 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossExpensesAtStandardRate;


	
	Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    TransactionVAT.VATRate IN ('Lower') AND
    Expense.IsEC = 0 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossExpensesAtLowerRate;	



		Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    TransactionVAT.VATRate IN ('Zero') AND
    Expense.IsEC = 0 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossExpensesAtZeroRate;		



		Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 0 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettExpenses;



		 Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    TransactionVAT.VATRate IN ('Standard') AND
    Expense.IsEC = 0 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettExpensesAtStandardRate;



	Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    TransactionVAT.VATRate IN ('Lower') AND
    Expense.IsEC = 0 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettExpensesAtLowerRate;



		Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    TransactionVAT.VATRate IN ('Zero') AND
    Expense.IsEC = 0 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettExpensesAtZeroRate;



		Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 0 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATExpenses;



		
		 Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    TransactionVAT.VATRate IN ('Standard') AND
    Expense.IsEC = 0 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATExpensesAtStandardRate;	
	


		 Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    TransactionVAT.VATRate IN ('Lower') AND
    Expense.IsEC = 0 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATExpensesAtLowerRate;



		Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    TransactionVAT.VATRate IN ('Zero') AND
    Expense.IsEC = 0 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATExpensesAtZeroRate;



		Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 1 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossECExpenses;



		Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 1 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettECExpenses;



		Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 1 and Expense.IsImport = 0 and
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATECExpenses;


		 
    Select if (Sum(GrossAmount) is null, 0,Sum(GrossAmount)) From TransactionVAT
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    Transaction.Status <> 0 and CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesExpenses;		



		 Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))
    From TransactionVAT inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesExpenses;


		
			Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))
    From TransactionVAT inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') AND CreditNote.IsEC = 0 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesExpenses; 
    


		Select if (Sum(GrossAmount) is null, 0,Sum(GrossAmount)) From TransactionVAT 
    inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.Status=1 and
    Transaction.Status <> 0 and CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossCreditNotesECExpenses;


		Select if (Sum(TransactionVAT.NettAmount) is null, 0,Sum(TransactionVAT.NettAmount))
    From TransactionVAT inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.IsEC = 1 and
    Transaction.TransactionDate between _startDate and _endDate into TotalNettCreditNotesEcExpenses; 



		Select if (Sum(TransactionVAT.VATAmount) is null, 0,Sum(TransactionVAT.VATAmount))
    From TransactionVAT inner join Transaction on  TransactionVAT.TransactionID = Transaction.TransactionID
    Inner Join CreditNote on CreditNote.CreditNoteID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in('CreditNote') and
    CreditNote.TransactionType in('Expense') and 
    CreditNote.IsEC = 1 and 
    Transaction.TransactionDate between _startDate and _endDate into TotalVATCreditNotesECExpenses; 



	      Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))
    From transactionVAT Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 0 and Expense.IsImport = 1 and
    Expense.Status=1 and 
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossImportExpenses;




		 Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))
    From transactionVAT Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 0 and Expense.IsImport = 1 and
    Expense.Status=1 and 
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettImportsExpenses;



		Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))
    From transactionVAT Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 0 and Expense.IsImport = 1 and
    Expense.Status=1 and 
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATImportsExpenses;



		 Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 1 and Purchase.IsImport = 0 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossECPurchasesAtStandardRate;




		Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 1 and Purchase.IsImport = 0 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossECPurchasesAtLowerRate; 



		Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 1 and Purchase.IsImport = 0 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossECPurchasesAtZeroRate;



			Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 1 and Purchase.IsImport = 0 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettECPurchasesAtStandardRate;



			Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 1 and Purchase.IsImport = 0 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettECPurchasesAtLowerRate;



		 Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 1 and Purchase.IsImport = 0 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettECPurchasesAtZeroRate;


		
			Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 1 and Purchase.IsImport = 0 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATECPurchasesAtStandardRate;
		   

		
			Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 1 and Purchase.IsImport = 0 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATECPurchasesAtLowerRate;



		Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    inner join Purchase on Purchase.PurchaseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Purchase') and
    Purchase.IsEC = 1 and Purchase.IsImport = 0 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.status = 1 and
    Purchase.status=1 and
    Transaction.TransactionDate between _startDate and _endDate  INTO TotalVATECPurchasesAtZeroRate;


		
			Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 1 and Expense.IsImport = 0 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossECExpensesAtStandardRate;



		Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 1 and Expense.IsImport = 0 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossECExpensesAtLowerRate;

 
		Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 1 and Expense.IsImport = 0 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossECExpensesAtZeroRate;

 

		Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 1 and Expense.IsImport = 0 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettECExpensesAtStandardRate;

 
		
			 Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 1 and Expense.IsImport = 0 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettECExpensesAtLowerRate;



		Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 1 and Expense.IsImport = 0 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettECExpensesAtZeroRate;

 

		 Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 1 and Expense.IsImport = 0 and
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.status = 1 and
    Expense.Status=1 and 
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATECExpensesAtStandardRate;



			 Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 1 and Expense.IsImport = 0 and
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.status = 1 and
    Expense.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATECExpensesAtLowerRate;



			Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Expense on Expense.ExpenseID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Expense') and
    Expense.IsEC = 1 and Expense.IsImport = 0 and
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.status = 1 and
    Expense.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATECExpensesAtZeroRate;




		Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Sales on Sales.salesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Sales') and
    Sales.IsEC = 1 and 
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.status = 1 and
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossECSalesAtStandardRate;



		 Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Sales on Sales.salesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Sales') and
    Sales.IsEC = 1 and 
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.status = 1 and
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossECSalesAtLowerRate;

 

		Select if (Sum(transactionVAT.GrossAmount) is null, 0,Sum(transactionVAT.GrossAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Sales on Sales.salesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Sales') and
    Sales.IsEC = 1 and 
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.status = 1 and
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalGrossECSalesAtZeroRate;



		Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Sales on Sales.salesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Sales') and
    Sales.IsEC = 1 and 
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.status = 1 and
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettECSalesAtStandardRate;

 

		Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Sales on Sales.salesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Sales') and
    Sales.IsEC = 1 and 
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.status = 1 and
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettECSalesAtLowerRate;


			
			 Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Sales on Sales.salesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Sales') and
    Sales.IsEC = 1 and 
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.status = 1 and
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettECSalesAtZeroRate;

 

		 Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Sales on Sales.salesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Sales') and
    Sales.IsEC = 1 and 
    TransactionVAT.VATRate IN ('Standard') AND
    Transaction.status = 1 and
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATECSalesAtStandardRate;



				Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Sales on Sales.salesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Sales') and
    Sales.IsEC = 1 and 
    TransactionVAT.VATRate IN ('Lower') AND
    Transaction.status = 1 and
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATECSalesAtLowerRate;
		


			Select if (Sum(transactionVAT.VATAmount) is null, 0,Sum(transactionVAT.VATAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Sales on Sales.salesID=Transaction.TransactionTypeID
    Where Transaction.TransactionType in ('Sales') and
    Sales.IsEC = 1 and 
    TransactionVAT.VATRate IN ('Zero') AND
    Transaction.status = 1 and
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalVATECSalesAtZeroRate;
		


	select if (sum(NHSPrescription) is null, 0,sum(NHSPrescription)) from Salespharmacy
    inner join Sales on Sales.SalesID=Salespharmacy.SalesID
    inner join Transaction on Transaction.TransactionTypeID = Sales.SalesID
    where Sales.SalesType='SalesPharmacy' and
    Transaction.Status=1 and
    Transaction.TransactionType='Sales' and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNHSPrescriptionAmount;



		select if (SUM(PrivatePrescriptions) is null, 0,SUM(PrivatePrescriptions)) from Salespharmacy
    inner join Sales on Sales.SalesID=Salespharmacy.SalesID
    inner join Transaction on Transaction.TransactionTypeID = Sales.SalesID
    where Sales.SalesType='SalesPharmacy' and
    Transaction.Status=1 and
    Transaction.TransactionType='Sales' and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalPrivatePrescriptionAmount;
		  	 
    


		select if (SUM(PracticePayment) is null, 0,SUM(PracticePayment)) from Salespharmacy
    inner join Sales on Sales.SalesID=Salespharmacy.SalesID
    inner join Transaction on Transaction.TransactionTypeID = Sales.SalesID
    where Sales.SalesType='SalesPharmacy' and
    Transaction.Status=1 and
    Transaction.TransactionType='Sales' and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalPracticePaymentAmount;



	 select if (SUM(NHSChequeReceived) is null, 0,SUM(NHSChequeReceived)) from Salespharmacy
    inner join Sales on Sales.SalesID=Salespharmacy.SalesID
    inner join Transaction on Transaction.TransactionTypeID = Sales.SalesID
    where Sales.SalesType='SalesPharmacy' and
    Transaction.Status=1 and
    Transaction.TransactionType='Sales' and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNHSChequeReceivedAmount;



	select if (sum(PracticePayment*(value/100)) is null, 0,sum(PracticePayment*(value/100))) from salespharmacytreatment
    inner join Sales on Sales.SalesID=salespharmacytreatment.SalesID
    inner join Transaction on Transaction.TransactionTypeID = Sales.SalesID
    inner join salespharmacy on salespharmacy.salesid=Sales.SalesID
    where salespharmacytreatment.SalesID in (select SalesID from Sales where SalesType in('SalesPharmacy')) and
    treatment in ('Exempt','Zero Rated') and Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate into TotalExemptZeroTreatmentAmount;  




	select if (SUM(TaxablePracticePayment) is null, 0,SUM(TaxablePracticePayment)) from Salespharmacy
    inner join Sales on Sales.SalesID=Salespharmacy.SalesID
    inner join Transaction on Transaction.TransactionTypeID = Sales.SalesID
    where Sales.SalesType='SalesPharmacy' and
    Transaction.Status=1 and
    Transaction.TransactionType='Sales' and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalTaxablePracticePaymentAmount; 




	select if(sum(HotItemValue) is null, 0,sum(HotItemValue)) from salescafesandwichbar
    inner join Sales on Sales.SalesID=salescafesandwichbar.SalesID
    inner join Transaction on Transaction.TransactionTypeID=Sales.SalesID
    Where Sales.SalesType='SalesCafeAndSandwichBar' and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalCafeHotAmount;



		select if(sum(ColdItemValue) is null, 0,sum(ColdItemValue)) from salescafesandwichbar
    inner join Sales on Sales.SalesID=salescafesandwichbar.SalesID
    inner join Transaction on Transaction.TransactionTypeID=Sales.SalesID
    Where Sales.SalesType='SalesCafeAndSandwichBar' and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalCafeColdAmount;
			
	Select if (Sum(GrossAmount) is null,0, Sum(GrossAmount)) From Sales
    Inner join Transaction on Transaction.TransactionTypeID=Sales.SalesID 
    Inner join salesitems on Salesitems.SalesID=Sales.SalesID
    where Transaction.TransactionType='Sales' and
    Sales.Salestype='SalesDailyGrossTaking' and
    salesitems.Itemtypeid IN(Select ItemTypeID from itemtype WHERE ItemTypeName like 'EXEMPT ITEMS') and 
    transaction.status<>0 and 
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossSaleExemptItems;

		
		
 	select if (SUM(TaxableOtherIncome) is null, 0,SUM(TaxableOtherIncome)) from Salespharmacy
    inner join Sales on Sales.SalesID=Salespharmacy.SalesID
    inner join Transaction on Transaction.TransactionTypeID = Sales.SalesID
    where Sales.SalesType='SalesPharmacy' and
    Transaction.Status=1 and
    Sales.Status=1 and
    Transaction.TransactionType='Sales' and
    Transaction.TransactionDate between _startDate and _endDate  INTO TotalTaxableOtherIncomeAmount;



		
				 Select if (Sum(NettAmount) is null,0, Sum(NettAmount)) From Sales
    Inner join Transaction on Transaction.TransactionTypeID=Sales.SalesID 
    Inner join salesitems on Salesitems.SalesID=Sales.SalesID
    where Transaction.TransactionType='Sales' and
    Sales.Salestype='SalesDailyGrossTaking' and
    salesitems.Itemtypeid IN(Select ItemTypeID from itemtype WHERE ItemTypeName like 'EXEMPT ITEMS') and 
    transaction.status<>0 and 
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate into TotalNettValueExemptItems;



  -- Not in webaccounting.
  
	-- Select Extract(Year_Month From _startDate) into start_date ;
  --  Select Extract(Year_Month From _endDate) into end_date;
  --  Select Period_Diff(end_date,start_date) into period;
  --  Set TotalVATDueForFuelScaleCharges  = (Select CalculateFuelScaleCharge(period));

  SELECT if (FuelScalCharges is null,0,FuelScalCharges) FROM FuelScaleCharges into TotalVATDueForFuelScaleCharges;




	select if (Sum(Commission) is null,0, Sum(Commission))  from salesitems
      inner join Sales on Sales.SalesID=salesitems.SalesID
      inner join transaction on transaction.transactiontypeid=sales.SalesID
      where Sales.Salestype='SalesDailyGrossTaking' and
	  transaction.TransactionType='Sales' and
      Sales.Status=1 and
      Transaction.Status<>0 and
      Transaction.TransactionDate between _startDate and _endDate into TotalSaleDailyTakingCommissions;



		select TotalGrossSaleDGT into TotalNettSaleDailyTakings;



      select if (sum(OwnConsumption) is null,0, sum(OwnConsumption)) from Sales
      inner join transaction on transaction.transactiontypeid=sales.SalesID
      where Sales.Salestype='SalesDailyGrossTaking' and
      Transaction.TransactionType='Sales'and
      Sales.Status=1 and
      Transaction.Status<>0 and
      Transaction.TransactionDate between _startDate and _endDate into TotalOwnConsumptions;





  Select if (Sum(Commission) is null,0, Sum(Commission)) from Salesitems 
    inner join Sales on Sales.SalesID=Salesitems.SalesId
    inner join transaction on transaction.transactiontypeid=sales.SalesID
    where Transaction.TransactionType='Sales' and
    Sales.Salestype='SalesDailyGrossTaking' and
    Sales.Status=1 and
    Transaction.Status <> 0 and
    salesitems.Itemtypeid IN(Select ItemTypeID from itemtype WHERE ItemTypeName like 'EXEMPT ITEMS') and
    Transaction.TransactionDate between _startDate and _endDate into TotalCommSaleExemptItems;



		Select if (Sum(salesitems.GrossAmount) is null,0, Sum(salesitems.GrossAmount)) from salesitems
  inner join Sales on Sales.SalesID=Salesitems.SalesId
    inner join transaction on transaction.transactiontypeid=sales.SalesID
    where Transaction.TransactionType='Sales' and
    Sales.Salestype='SalesDailyGrossTaking' and
    Sales.Status=1 and
    Transaction.Status <> 0 and
    salesitems.Itemtypeid IN(Select ItemTypeID from itemtype WHERE ItemTypeName like 'ZERO RATED ITEMS') and
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossSaleZeroItems;



	
		Select if (Sum(NettAmount) is null,0, Sum(NettAmount)) from salesitems
  inner join Sales on Sales.SalesID=Salesitems.SalesId
    inner join transaction on transaction.transactiontypeid=sales.SalesID
    where Transaction.TransactionType='Sales' and
    Sales.Salestype='SalesDailyGrossTaking' and
    Sales.Status=1 and
    Transaction.Status <> 0 and
    salesitems.Itemtypeid IN(Select ItemTypeID from itemtype WHERE ItemTypeName like 'ZERO RATED ITEMS') and
    Transaction.TransactionDate between '2012-02-01' and '2012-02-29' into TotalNettValueZeroItems;



			Select if (Sum(Commission) is null,0, Sum(Commission)) from Salesitems 
    inner join Sales on Sales.SalesID=Salesitems.SalesId
    inner join transaction on transaction.transactiontypeid=sales.SalesID
    where Transaction.TransactionType='Sales' and
    Sales.Salestype='SalesDailyGrossTaking' and
    Sales.Status=1 and
    Transaction.Status <> 0 and
    salesitems.Itemtypeid IN(Select ItemTypeID from itemtype WHERE ItemTypeName like 'ZERO RATED ITEMS') and
    Transaction.TransactionDate between _startDate and _endDate into TotalCommSaleZeroItems;

		


	Select if (Sum(GrossAmount) is null,0, Sum(GrossAmount)) From Sales
    Inner join Transaction on Transaction.TransactionTypeID=Sales.SalesID 
    Inner join salesitems on Salesitems.SalesID=Sales.SalesID
    where Transaction.TransactionType='Sales' and
    Sales.Salestype='SalesDailyGrossTaking' and
    salesitems.Itemtypeid IN(Select ItemTypeID from itemtype WHERE ItemTypeName like 'ITEMS_SUBJECT_TO_VAT') and 
    transaction.status<>0 and 
    Sales.Status=1 and
    Transaction.TransactionDate between _startDate and _endDate into TotalGrossSaleSubVATItems;



		 Select if (Sum(SalesItems.NettAmount) is null,0, Sum(SalesItems.NettAmount))  From SalesItems
    inner join Sales on Sales.SalesID=Salesitems.SalesId
    inner join transaction on transaction.transactiontypeid=sales.SalesID
    inner join transactionvat on transactionvat.transactionid=transaction.transactionID
    where Transaction.TransactionType='Sales' and
    Sales.Salestype='SalesDailyGrossTaking' and
    Sales.Status=1 and
    Transaction.Status <> 0 and
    salesitems.Itemtypeid IN(Select ItemTypeID from itemtype WHERE ItemTypeName like 'ITEMS_SUBJECT_TO_VAT') and
    transactionvat.VATRate IN('Standard') and 
    Transaction.TransactionDate between _startDate and _endDate into TotalNettValueSubVATItems;

	SELECT 
	if (Sum(salesitems.NettAmount) is null, 0,Sum(salesitems.NettAmount))
	from salesitems
	inner join Sales on salesitems.SalesID = Sales.SalesID
	inner join transaction on transaction.transactiontypeid = Sales.SalesID
	where 
	Transaction.TransactionType = 'Sales' 
	and Sales.Salestype='SalesDailyGrossTaking' 
	and Sales.Status = 1 
	and Transaction.Status <> 0 
	and salesitems.Itemtypeid = 3
	and transaction.TransactionDate between _startDate and _endDate into TotalCommSaleSubVATItems;
 





		select PharmacyRetailSalesForZeroRate from master.clientdetails where ClientID=_ClientId  into PharmacyRetailSalesForZeroRateValue;




		    select PharmacyRetailSalesForLowerRate from master.clientdetails where ClientID=_ClientId  into PharmacyRetailSalesForLowerRateValue;




	    select ESPForLowerRate from master.clientdetails where ClientID=_ClientId  into ESPForLowerRateValue;



	select ESPForZeroRate from master.clientdetails where ClientID=_ClientId  into ESPForZeroRateValue;

 

	select ESPForStandardRate from master.clientdetails where ClientID=_ClientId  into ESPForStandardRateValue;


 

	 Select if (Sum(NonVATAmount) is null, 0,Sum(NonVATAmount))  From Expense
    Where Expense.IsEC = 0 and Expense.IsImport = 0 and
    Expense.status = 1 and
    Expense.InvoiceDate between _startDate and _endDate INTO TotalVatNotApplicable;



		Select if (Sum(transactionVAT.NettAmount) is null,0, Sum(transactionVAT.NettAmount))
    from transactionVAT
    inner join  Transaction on transactionVAT.TransactionID = Transaction.TransactionID
    inner join Sales on Sales.SalesID=Transaction.TransactionTypeID
    Where
    Transaction.TransactionType in ('SALES') and
    Sales.Status=1 and
    Transaction.Status <> 0 and
    Sales.IsEC = 0 and
    Transaction.TransactionDate between _startDate and _endDate into  TotalNettSale;
		


		 
     select if (sum(OpeningStock) is null,0,OpeningStock) from openingclosingstock
 where  CreateDate = _startDate into OpeningStock; 



		Select if (Sum(transactionVAT.NettAmount) is null, 0,Sum(transactionVAT.NettAmount))  From transactionVAT
    Inner join Transaction on TransactionVAT.TransactionID = Transaction.TransactionID
    Inner join Purchase on Purchase.PurchaseID = Transaction.TransactionTypeID
    Where Transaction.Transactiontype in ('Purchase') AND
    Purchase.IsEC = 0 and Purchase.IsImport = 0 and
    Purchase.IsCapitalExpenditure = 2  and
    Purchase.Status=1 and 
    Transaction.status = 1 and
    Transaction.TransactionDate between _startDate and _endDate INTO TotalNettPurchasesForProfitAndLoss;


			
	Select Period_Diff(end_date,start_date) into period;



	Select Extract(Year_Month From _endDate) into end_date;

 
		
	Select Extract(Year_Month From _startDate) into start_date;



select TotalGrossSaleDGT ,
 TotalGrossSale ,
 TotalECSale ,
 TotalGrossSaleCreditNote ,
 TotalGrossECSaleCreditNote,
 TotalNettSaleCreditNote ,
 TotalVATSaleCreditNote ,
 TotalGrossSaleExemptItems ,
 TotalNettValueExemptItems ,
 TotalCommSaleExemptItems,
 TotalGrossSaleZeroItems,
 TotalNettValueZeroItems,
 TotalCommSaleZeroItems,
 TotalGrossSaleSubVATItems,
 TotalNettValueSubVATItems,
 TotalCommSaleSubVATItems,
 if (TotalVATDueForFuelScaleCharges is null, 0,TotalVATDueForFuelScaleCharges) as 'TotalVATDueForFuelScaleCharges' ,
 TotalSaleDailyTakingCommissions ,
 TotalNettSaleDailyTakings,
 TotalOwnConsumptions ,
 TotalGrossPurchases ,
 TotalGrossPurchasesAtStandardRate ,
 TotalGrossPurchasesAtLowerRate ,
 TotalGrossPurchasesAtZeroRate ,
 TotalNettPurchases ,
 TotalNettPurchasesAtStandardRate ,
 TotalNettPurchasesAtLowerRate ,
 TotalNettPurchasesAtZeroRate ,
 TotalVATPurchases ,
 TotalVATPurchasesAtStandardRate ,
 TotalVATPurchasesAtLowerRate ,
 TotalVATPurchasesAtZeroRate ,
 TotalGrossECPurchases ,
 TotalNettECPurchases ,
 TotalVATECPurchases ,
 TotalGrossCreditNotesPurchases ,
 TotalNettCreditNotesPurchases ,
 TotalVATCreditNotesPurchases ,
 TotalGrossCreditNotesECPurchases ,
 TotalNettCreditNotesEcPurchases ,
 TotalVATCreditNotesECPurchases ,
 TotalGrossImportPurchases ,
 TotalNettImportsPurchases ,
 TotalVATImportsPurchases ,
 TotalGrossExpenses ,
 TotalGrossExpensesAtStandardRate ,
 TotalGrossExpensesAtLowerRate ,
 TotalGrossExpensesAtZeroRate ,
 TotalNettExpenses ,
 TotalNettExpensesAtStandardRate ,
 TotalNettExpensesAtLowerRate ,
 TotalNettExpensesAtZeroRate ,
 TotalVATExpenses ,
 TotalVATExpensesAtStandardRate ,
 TotalVATExpensesAtLowerRate ,
 TotalVATExpensesAtZeroRate ,
 TotalGrossECExpenses ,
 TotalNettECExpenses ,
 TotalVATECExpenses ,
 TotalGrossCreditNotesExpenses ,
 TotalNettCreditNotesExpenses ,
 TotalVATCreditNotesExpenses ,
 TotalGrossCreditNotesECExpenses ,
 TotalNettCreditNotesEcExpenses ,
 TotalVATCreditNotesECExpenses ,
 TotalGrossImportExpenses ,
 TotalNettImportsExpenses ,
 TotalVATImportsExpenses ,
 TotalNHSPrescriptionAmount ,
 TotalPrivatePrescriptionAmount ,
 TotalPracticePaymentAmount ,
 TotalNHSChequeReceivedAmount ,
 TotalExemptZeroTreatmentAmount ,
 TotalTaxablePracticePaymentAmount ,
 TotalTaxableOtherIncomeAmount ,
 TotalCafeHotAmount ,
 TotalCafeColdAmount ,
 TotalGrossSaleExemptItems ,
 TotalNettValueExemptItems ,
 if (TotalVATDueForFuelScaleCharges is null, 0,TotalVATDueForFuelScaleCharges) as 'TotalVATDueForFuelScaleCharges' ,
 TotalSaleDailyTakingCommissions ,
 TotalNettSaleDailyTakings ,
 TotalOwnConsumptions,
 PharmacyRetailSalesForZeroRateValue,
 PharmacyRetailSalesForLowerRateValue,
 ESPForLowerRateValue,
 ESPForZeroRateValue,
 ESPForStandardRateValue,
TotalVatNotApplicable,
TotalNettECSaleCreditNote,
TotalVATECSaleCreditNote,
TotalNettSale,OpeningStock,
TotalGrossSaleAtStandardRate,
TotalGrossSaleCreditnoteAtStandardRate,
TotalVATSaleAtStandardRate,
TotalVATSaleCreditnoteAtStandardRate,
TotalNettSaleAtStandardRate,
TotalNettSaleCreditnoteAtStandardRate,
TotalGrossSaleAtLowerRate,
TotalGrossSaleCreditnoteATLowerRate,
TotalVATSaleAtLowerRate,
TotalVATSaleCreditnoteAtLowerRate,
TotalNettSaleAtLowerRate,
TotalNettSaleCreditnoteAtLowerRate,
TotalGrossSaleAtZeroRate,
TotalGrossSaleCreditnoteAtZeroRate,
TotalVATSaleAtZeroRate,
TotalVATSaleCreditnoteAtZeroRate,
TotalNettSaleAtZeroRate,
TotalNettSaleCreditnoteAtZeroRate,
TotalGrossCreditNotesPurchasesAtStandardRate,
TotalGrossCreditNotesPurchasesAtLowerRate,
TotalGrossCreditNotesPurchasesAtZeroRate,
TotalNettCreditNotesPurchasesAtStandardRate,
TotalNettCreditNotesPurchasesAtLowerRate,
TotalNettCreditNotesPurchasesAtZeroRate,
TotalVATCreditNotesPurchasesAtStandardRate,
TotalVATCreditNotesPurchasesAtLowerRate,
TotalVATCreditNotesPurchasesAtZeroRate,
TotalVATCreditNotesECPurchasesAtZeroRate,
TotalVATCreditNotesECPurchasesAtLowerRate,
TotalVATCreditNotesECPurchasesAtStandardRate,
TotalNettCreditNotesECPurchasesAtZeroRate,
TotalNettCreditNotesECPurchasesAtLowerRate,
TotalNettCreditNotesECPurchasesAtStandardRate,
TotalGrossCreditNotesECPurchasesAtZeroRate,
TotalGrossCreditNotesECPurchasesAtLowerRate,
TotalGrossCreditNotesECPurchasesAtStandardRate,
TotalGrossECPurchasesAtStandardRate,
TotalGrossECPurchasesAtLowerRate,
TotalGrossECPurchasesAtZeroRate,
TotalNettECPurchasesAtStandardRate,
TotalNettECPurchasesAtLowerRate,
TotalNettECPurchasesAtZeroRate,
TotalVATECPurchasesAtStandardRate,
TotalVATECPurchasesAtLowerRate,
TotalVATECPurchasesAtZeroRate,
TotalNettPurchasesForProfitAndLoss,
TotalGrossCreditNotesExpensesAtStandardRate,
TotalGrossCreditNotesExpensesAtLowerRate,
TotalGrossCreditNotesExpensesAtZeroRate,
TotalNettCreditNotesExpensesAtStandardRate,
TotalNettCreditNotesExpensesAtLowerRate,
TotalNettCreditNotesExpensesAtZeroRate,
TotalVATCreditNotesExpensesAtStandardRate,
TotalVATCreditNotesExpensesAtLowerRate,
TotalVATCreditNotesExpensesAtZeroRate,
TotalVATCreditNotesECExpensesAtZeroRate,
TotalVATCreditNotesECExpensesAtLowerRate,
TotalVATCreditNotesECExpensesAtStandardRate,
TotalNettCreditNotesECExpensesAtZeroRate,
TotalNettCreditNotesECExpensesAtLowerRate,
TotalNettCreditNotesECExpensesAtStandardRate,
TotalGrossCreditNotesECExpensesAtZeroRate,
TotalGrossCreditNotesECExpensesAtLowerRate,
TotalGrossCreditNotesECExpensesAtStandardRate,
TotalGrossECExpensesAtStandardRate,
TotalGrossECExpensesAtLowerRate,
TotalGrossECExpensesAtZeroRate,
TotalNettECExpensesAtStandardRate,
TotalNettECExpensesAtLowerRate,
TotalNettECExpensesAtZeroRate,
TotalVATECExpensesAtStandardRate,
TotalVATECExpensesAtLowerRate,
TotalVATECExpensesAtZeroRate,
TotalGrossCreditNotesSalesAtStandardRate,
TotalGrossCreditNotesSalesAtLowerRate,
TotalGrossCreditNotesSalesAtZeroRate,
TotalNettCreditNotesSalesAtStandardRate,
TotalNettCreditNotesSalesAtLowerRate,
TotalNettCreditNotesSalesAtZeroRate,
TotalVATCreditNotesSalesAtStandardRate,
TotalVATCreditNotesSalesAtLowerRate,
TotalVATCreditNotesSalesAtZeroRate,
TotalVATCreditNotesECSalesAtZeroRate,
TotalVATCreditNotesECSalesAtLowerRate,
TotalVATCreditNotesECSalesAtStandardRate,
TotalNettCreditNotesECSalesAtZeroRate,
TotalNettCreditNotesECSalesAtLowerRate,
TotalNettCreditNotesECSalesAtStandardRate,
TotalGrossCreditNotesECSalesAtZeroRate,
TotalGrossCreditNotesECSalesAtLowerRate,
TotalGrossCreditNotesECSalesAtStandardRate,
TotalGrossECSalesAtStandardRate,
TotalGrossECSalesAtLowerRate,
TotalGrossECSalesAtZeroRate,
TotalNettECSalesAtStandardRate,
TotalNettECSalesAtLowerRate,
TotalNettECSalesAtZeroRate,
TotalVATECSalesAtStandardRate,
TotalVATECSalesAtLowerRate,
TotalVATECSalesAtZeroRate;
END$$

$$
DELIMITER ;


DELIMITER ;
-- -----------------------------------------------------
-- procedure ReportProfitAndLossDetails
-- -----------------------------------------------------
DELIMITER $$

DELIMITER $$
CREATE PROCEDURE `ReportProfitAndLossDetails`(IN _startDate datetime , IN _endDate datetime)
BEGIN
Select ExpenseType , (ExpenseAmount - CreditAmt) as ExpenseAmount, ISCAPITALEXPENDITURE, ExpenseHead,
CreditAMt, OrigionalExpenseAmount from(
select  ET.ExpenseTypeName as ExpenseType,(E.TotalNettAmount)
 as ExpenseAmount, (E.TotalNettAmount) as OrigionalExpenseAmount,
(
Select IFNULL(Sum(TV.NettAmount),0) from transactionvat TV 
inner join transaction T on TV.transactionid= T.transactionid
inner join creditnote C on T.transactiontypeid= C.Creditnoteid
inner join expensetype ET on C.expensetypeid= ET.Expensetypeid
where T.transactiontype in ('creditnote') and
C.transactiontype in ('expense') AND T.status=1 and C.status=1
and T.transactiondate between _startDate and _endDate
)
  as CreditAmt,
   ISCAPITALEXPENDITURE,'' as ExpenseHead from ExpenseType ET
   inner join Expense E on E.expensetypeid=ET.expensetypeid
   inner join transaction T on T.transactiontypeid=E.ExpenseId
   inner join transactionVAT TV on TV.transactionid= T.Transactionid
   Where E.iscapitalexpenditure !=1 and T.transactiondate between _startDate and _endDate and
   T.status=1 and E.status=1 group by ET.ExpenseTypeID,E.ISCAPITALEXPENDITURE
) as st;
END$$

$$
DELIMITER ;


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mashup.Api.Quality.Entities
{
    public class CQTSAdHocTransEntity
    {
        // New version matching the Praveen Trans report.

        public string INVOICE_NBR { get; set; }
        public string GLUS_CODE { get; set; }
        public Decimal UNIT_PRODUCT_WEIGHT { get; set; }
        public Decimal CUST_CLAIMED_DOLLARS { get; set; }
        public Decimal S140_TOTAL_CREDIT_DOLLARS { get; set; }
        public DateTime CREATE_TIMESTAMP { get; set; }
        public string CREDIT_PAID_FLAG { get; set; }
        public DateTime SENTTO_INVCE_DT { get; set; }
        public DateTime CRED_INV_PROCESS_DATE { get; set; }
        public DateTime TRANS_SHIP_DATE { get; set; }
        public DateTime UNLOAD_DATE { get; set; }
        public string ORG_NAME { get; set; }
        public string TRANS_SHIPTO_NAME { get; set; }
        public string TRANS_SHIPTO_NBR { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string CITY { get; set; }
        public string STATE_CD { get; set; }
        public string ZIP_CD { get; set; }
        public string CNTRY_ABBR { get; set; }
        public string VEHICLE_NBR { get; set; }
        public string TRANS_MODE { get; set; }
        public string MODE_DESC { get; set; }
        public string SHIPPING_FAC { get; set; }
        public string DISPOSITION_CD { get; set; }
        public string DISPOSITION { get; set; }
        public string CALL_TYPE_CODE { get; set; }
        public string CALL_REPORT_TYPE { get; set; }
        public string MANUFACTURING_FAC { get; set; }
        public string CLAIM_STATUS { get; set; }
        public DateTime FILE_DATE { get; set; }
        public DateTime CLOSE_DATE { get; set; }
        public Decimal ORIGINAL_CLAIM_AMT { get; set; }
        public Decimal CARRIER_PAYMENT { get; set; }
        public Decimal SALVAGE_PAYMENT { get; set; }
        public Decimal INS_PAYMENT { get; set; }
        public Decimal CARRIER_AMND { get; set; }
        public string COMPLAINT_NUMBER { get; set; }
        public Decimal COMP_ID_ITEM_SEQ_NBR { get; set; }
        public string COMP_SUPPL { get; set; }
        public Decimal DISPOSITION_SEQ_NBR { get; set; }
        public Decimal BILL_SEQ_NBR { get; set; }
        public string BILL_OF_LADING_MEMO { get; set; }
        public string ORD_REF_NBR { get; set; }
        public string FILING_CARRIER_SCAC { get; set; }
        public string CARRIER_NAME { get; set; }
        public string BUSINESS { get; set; }
        public string CUST_NBR { get; set; }
        public string CALL_REPORT_SUMMARY { get; set; }
        public string TECH_SERV_DEFECT_CODE { get; set; }
        public string STD_DESC { get; set; }
        public Decimal CUST_CLAIMED_NBR_UNITS { get; set; }





        // The old version of the query.

        //public DateTime Create_Date { get; set; }
        //public DateTime Credit_Approval_Date { get; set; }
        //public string Complaint_Number { get; set; }
        //public string Transit_Damage_Desc { get; set; }
        //public string Load { get; set; }
        //public string Order_Number { get; set; }
        //public string Transit_Damage { get; set; }
        //public string Carrier { get; set; }
        //public decimal No_of_Units { get; set; }
        //public decimal Weight { get; set; }
        //public decimal Credit_Dollar { get; set; }
        //public string Customer { get; set; }
        //public string Consignee { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string Mode { get; set; }
        //public string Vehicle { get; set; }
        //public string Trans_Ship_To_Name { get; set; }
        //public string Invoice { get; set; }
        //public string Producing_Mill { get; set; }
        //public string Claim_Status { get; set; }
        //public DateTime File_Date { get; set; }
        //public DateTime Closed_Date { get; set; }
        //public Decimal Customer_Claim_Dollars { get; set; }
        //public string Activity_Type { get; set; }
        //public string Entry_Type { get; set; }
        //public Decimal Entry_Dollars { get; set; }

    }
}

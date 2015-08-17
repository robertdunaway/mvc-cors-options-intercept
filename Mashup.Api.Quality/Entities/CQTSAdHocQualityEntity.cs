using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mashup.Api.Quality.Entities
{
    public class CQTSAdHocQualityEntity
    {
        public DateTime Create_Date  { get; set; }
        public DateTime Credit_Approval_Date { get; set; }
        public string Complaint_Number { get; set; }
        public string Complaint_Supplement { get; set; }
        public string Order_Ref_Nbr	{ get; set; }
        public string Grade_Name { get; set; }
        public string PO { get; set; }
        public decimal Basis_Wgt { get; set; }
        public string Defect { get; set; }
        public decimal No_of_Units { get; set; }
        public decimal Weight { get; set; }
        public decimal Credit_Dollar { get; set; }
        public string Customer{ get; set; }
        public string Consignee { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Facility { get; set; }
        public string Machine { get; set; }
        public DateTime MFG_Date { get; set; }

    }
}

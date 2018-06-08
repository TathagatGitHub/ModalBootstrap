using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ModalBootstrap.Models
{
    public class FinancialSummary
    {
        [Display(Name="Payer Type")]
        public string PayerType {get;set;}

        [Display(Name = "FICO Score")]
        public string FICOScore { get; set; }

        public int? ChartNo { get; set; }

        public virtual eChart eChart { get; set; }
            
            
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ModalBootstrap.Models
{
    public class Treatment
    {
        [Key]
        public int TreatmentNo { get; set; }

        [Required, Display(Name="Status")]
        public string TreatmentStatus { get; set; }

        [Display(Name = "1st Visit")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime InitialVisit { get; set; }

        [Display(Name = "Last Visit")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastVisit { get; set; }

        [Display(Name = "Next Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NextVisit { get; set; }

        public int ChartNo { get; set; }

        public virtual eChart eChart { get; set; }
            
            
    }
}
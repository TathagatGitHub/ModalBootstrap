using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ModalBootstrap.Models
{
    public class TreatmentItems
    {
        [Key]
        public int TreatmentItemsNo { get; set; }
        public int TreatmentNo { get; set; }
        public virtual Treatment Treatment { get; set; }
        [Required]
        public int LOC { get; set; }
        [Required]
        public string SURF { get; set; }
        [Required]
        public string PROC { get; set; }
        [Required, Display(Name = "Procedure Description")]
        public string ProcedureDescription { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOS { get; set; }
        public int DDS { get; set; }
        public Boolean COMP { get; set; }

    }
}
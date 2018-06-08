using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ModalBootstrap.Models
{
    public class eChart
    {
        [Key]
        [Display(Name="Chart No.")]
        public int ChartNo { get; set; }
        
        [Required, StringLength(25), Display(Name="First Name")]
        public string PatientFirstName { get; set; }

        [Required, StringLength(25), Display(Name = "Last Name")]
        public string PatientLastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string PatientEmail { get; set; }

        [Required(ErrorMessage = "Mobile is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string PatientPhoneNo { get; set; }

        public string Sex{ get; set; }

        [Required(ErrorMessage = "Date of birth is required"), Display(Name = "Birth Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PatientBirthDate { get; set; }

        [Required(ErrorMessage = "Appointment date is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Appointment")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Address is required"), StringLength(200), Display(Name = "Address")]
        public string PatientAddress { get; set; }

        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}
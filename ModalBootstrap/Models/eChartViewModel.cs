using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModalBootstrap.Models
{
    public class eChartViewModel
    {
       public eChart chart{ get; set; }
       public List<Treatment> treatments { get; set; }
       public List<TreatmentItems> treatmentItems { get; set; }
    }
}
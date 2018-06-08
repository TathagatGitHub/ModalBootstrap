using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ModalBootstrap.Models
{
    public class eChartContext: DbContext
    {

        public eChartContext(): base("eChart") // "DefaultConnection" is from web.config file.
	        {
                Database.SetInitializer<eChartContext>(new DropCreateDatabaseIfModelChanges<eChartContext>()); 
	            // Above line is important otherwise when you make any change in the model, it will not work.
	
	        }

        public System.Data.Entity.DbSet<ModalBootstrap.Models.eChart> eCharts { get; set; }

        public System.Data.Entity.DbSet<ModalBootstrap.Models.Treatment> Treatments { get; set; }

        public System.Data.Entity.DbSet<ModalBootstrap.Models.TreatmentItems> TreatmentItems { get; set; }

    }
}
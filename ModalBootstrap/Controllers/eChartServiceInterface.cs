using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModalBootstrap.Models;

namespace ModalBootstrap.Controllers
{
    public interface eChartServiceInterface
    {
         IEnumerable<eChart> Index();
        
    }
}

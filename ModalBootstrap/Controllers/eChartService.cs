using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModalBootstrap.Models;
namespace ModalBootstrap.Controllers
{
    public class eChartService : eChartServiceInterface
    {
        private eChartRepository _eChartRepository = new eChartRepository();
        public IEnumerable<eChart> Index()
        {
           return ( _eChartRepository.GetAll());
        }
    }
}
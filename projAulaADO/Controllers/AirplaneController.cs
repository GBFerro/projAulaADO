using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projAulaADO.Model;
using projAulaADO.Services;

namespace projAulaADO.Controllers
{
    public class AirplaneController
    {
        public bool Insert(Airplane airplane)
        {
            return new AirplaneService().Insert(airplane);
        }

        public List<Airplane> FindAll() 
        {
            return new AirplaneService().FindAll();
        }
    }
}

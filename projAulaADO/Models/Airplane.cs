using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projAulaADO.Models;

namespace projAulaADO.Model
{
    public class Airplane
    {
        #region Properties

        public int Id { get; set; }
        public string? Name { get; set; }
        public int NumberOfPassengers { get; set; }
        public string? Description { get; set; }
        public Engine Engine { get; set; }

        #endregion

        public override string ToString()
        {
            return $"Nome: {this.Name}\nDescrição: {this.Description}\nNúmero de passageiros: {this.NumberOfPassengers}\n" +
                $"Descrição do motor: {this.Engine}\n\n";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Web.Models
{
    public class ExpositionModel
    {
        public int Id { get; set; }
        public string ExpositionName { get; set; }
        public string Theme { get; set; }
        public int TargetAudience { get; set; }
        public string Plane { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return ExpositionName+" | Theme : "+Theme+" | Target audience : "+TargetAudience+" | Price : "+Price.ToString()
                + "\n-----------------Plan-----------------\n"+Plane+"\n--------------------------------------\n";
        }
    }
}

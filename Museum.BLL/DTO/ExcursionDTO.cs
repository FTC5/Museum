using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.DTO
{
    public class ExcursionDTO
    {
        public int Id { get; set; }
        public virtual TimeSpan StartTime { get; set; }
        public int Time { get; set; }
        public string GuideName { get; set; }
        public override string ToString()
        {
            return Id.ToString() + " | Start time : " + StartTime.ToString() + " | Time : " + Time.ToString() + " | Guide : " + GuideName + "\n";
        }
    }
}

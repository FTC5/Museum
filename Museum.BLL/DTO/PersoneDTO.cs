using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.DTO
{
    public class PersoneDTO
    {
        public  int Id { get; set; }
        public  int Age { get; set; }
        public  string Name { get; set; }

        public override string ToString()
        {
            return Name +" | Age : "+Age+"\n";
        }
    }
}

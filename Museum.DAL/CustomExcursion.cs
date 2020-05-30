using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.DAL
{
    [Table("CustomExcursions")]
    public class CustomExcursion
    {
        [Key]
        public int Id { get; set; }
        public virtual Guide Guide { get; set; }
        [Column("StartTime", TypeName = "time")]
        public TimeSpan StartTime { get; set; }
        public int Time { get; set; }
        public virtual ExcursionsSchedule ExcursionsSchedule { get; set; }
        private ICollection<Customer> customers;
        public virtual ICollection<Customer> Customers
        {
            get { return customers ?? (customers = new List<Customer>()); }
            set { customers = value; }
        }
    }
}

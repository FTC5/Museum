using Museum.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.Infrastructure
{
    public class SmallAgeCustomerException : Exception
    {
        List<CustomerDTO> list;
        public SmallAgeCustomerException()
        {
        }
        public SmallAgeCustomerException(string message) : base(message)
        {
        }
        public SmallAgeCustomerException(string message,List<CustomerDTO> list) : base(message)
        {
        }

        public SmallAgeCustomerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SmallAgeCustomerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString()
        {
            string text = Message + "\n";
            foreach (var item in list)
            {
                text += item.ToString()+"\n";
            }
            return text;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.Infrastructure
{
    public class ExcursionNotFoundException : Exception
    {
        public ExcursionNotFoundException()
        {
        }

        public ExcursionNotFoundException(string message) : base(message)
        {
        }

        public ExcursionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExcursionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

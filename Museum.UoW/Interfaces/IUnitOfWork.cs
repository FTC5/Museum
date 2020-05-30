using Museum.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.UoW.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Customer{ get;}
        IRepository<CustomExcursion> CustomExcursion { get; }
        IRepository<ExcursionsSchedule> ExcursionsSchedule { get; }
        IRepository<Exposition> Exposition { get; }
        IRepository<Grafik> Grafik { get; }
        IRepository<Excursion> Excursion { get; }
        IRepository<Guide> Guide { get; }
        void Save(); 
    }
}

using Museum.DAL;
using Museum.DAL.Context;
using Museum.UoW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.UoW.EFCodeFirst
{
    class UnitOfWork : IUnitOfWork
    {
        private MuseumContext db = null;
        private bool disposed = false;
        private IRepository<Customer> customer;
        private IRepository<CustomExcursion> customExcursion;
        private IRepository<ExcursionsSchedule> excursionsSchedule;
        private IRepository<Exposition> exposition;
        private IRepository<Grafik> grafik;
        private IRepository<Excursion> excursion;
        private IRepository<Guide> guide;

        public IRepository<Customer> Customer
        {
            get
            {
                if (customer == null)
                {
                    customer = new Repository<Customer>(db);
                }
                return customer;
            }
        }
        public IRepository<CustomExcursion> CustomExcursion
        {
            get {
                if (customExcursion == null)
                {
                    customExcursion = new Repository<CustomExcursion>(db);
                } return customExcursion;
            }
        }
        public IRepository<ExcursionsSchedule> ExcursionsSchedule
        {
            get
            { if (excursionsSchedule == null)
                {
                    excursionsSchedule = new Repository<ExcursionsSchedule>(db);
                } return excursionsSchedule;
            }
        }
        public IRepository<Exposition> Exposition
        {
            get
            {
                if (exposition == null)
                {
                    exposition = new Repository<Exposition>(db);
                }
                return exposition;
            }
        }
        public IRepository<Grafik> Grafik
        {
            get
            {
                if (grafik == null)
                {
                    grafik = new Repository<Grafik>(db);
                }
                return grafik;
            }
        }
        public IRepository<Excursion> Excursion
        {
            get
            {
                if (excursion == null)
                {
                    excursion = new Repository<Excursion>(db);
                }
                return excursion;
            }
        }
        public IRepository<Guide> Guide
        {
            get
            {
                if (guide == null)
                {
                    guide = new Repository<Guide>(db);
                } return guide;
            }
        }
        internal virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}

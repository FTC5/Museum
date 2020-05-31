using Museum.BLL.DTO;
using Museum.BLL.Interfaces;
using Museum.DAL.Context;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Museum.DAL;
using AutoMapper;
using Museum.UoW.Interfaces;

namespace Museum.BLL.Services
{
    public class GrafikService : Service,IGrafikService
    {
        public GrafikService(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public IEnumerable<GrafikDTO> GetGrafiks()
        {
            var grafiks = db.Grafik.GetAll();
            return mapper.Map<IEnumerable<GrafikDTO>>(grafiks);
        }
        public IEnumerable<GrafikDTO> FindByName(string name)
        {
            var grafiks = db.Grafik.Find(g =>
            {
                if (g.Exposition.ExpositionName.Contains(name))
                {
                    return true;
                }
                return false;
            });
            return mapper.Map<IEnumerable<GrafikDTO>>(grafiks);
        }
    }
}

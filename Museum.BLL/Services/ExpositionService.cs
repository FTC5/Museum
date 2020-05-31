using Museum.BLL.DTO;
using Museum.BLL.Interfaces;
using Museum.DAL.Context;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Museum.DAL;
using AutoMapper;
using Museum.UoW.Interfaces;

namespace Museum.BLL.Services
{
    public class ExpositionService : Service,IExpositionService
    {
        public ExpositionService(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public ExpositionDTO GetExpositionInfo(int id)
        {
            var exposition = db.Exposition.Get(id);
            return mapper.Map<ExpositionDTO>(exposition);
        }
        public void DeleteExposition(int id)
        {
            db.Exposition.Delete(id);
            db.Save();
        }
        public void UpdateExposition(ExpositionDTO exposition)
        {
            var old=db.Exposition.Get(exposition.Id);
            if (old == null)
            {
                return;
            }
            db.Exposition.Update(mapper.Map(exposition,old));
            db.Save();
        }
        public void AddExposition(ExpositionDTO exposition)
        {
            db.Exposition.Create(mapper.Map<Exposition>(exposition));
            db.Save();
        }
    }
}

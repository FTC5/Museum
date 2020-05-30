using Museum.BLL.DTO;
using Museum.BLL.Interfaces;
using Museum.DAL.Context;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Museum.DAL;

namespace Museum.BLL.Services
{
    public class ExpositionService : Service,IExpositionService
    {
        public ExpositionService()
        {
        }
        public ExpositionDTO GetExpositionInfo(int id)
        {
            var exposition = db.Exposition.Get(id);
            return mapper.Map<ExpositionDTO>(exposition);
        }
    }
}

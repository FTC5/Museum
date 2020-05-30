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
    public class ExpositionService : IExpositionService
    {
        IRebuilderService rebuilder;
        public ExpositionService()
        {
            rebuilder = new RebuilderService();
        }
        public ExpositionDTO GetExpositionInfo(int id)
        {
            using (var context = new MuseumContext())
            {
                var exposition = context.Exposition.Find(id);
                if (exposition == null)
                {
                    return null;
                }
                return rebuilder.ExpositionToExpositionDTO(exposition);
            }
        }
    }
}

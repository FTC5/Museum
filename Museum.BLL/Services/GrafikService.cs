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

namespace Museum.BLL.Services
{
    public class GrafikService : IGrafikService
    {
        IRebuilderService rebuilderService;
        public GrafikService()
        {
            rebuilderService = new RebuilderService();
        }

        public IEnumerable<GrafikDTO> GetGrafiks()
        {
            using (var context = new MuseumContext())
            {
                var grafiks = context.Grafik.Include(g => g.Exposition);
                return rebuilderService.GrafikToGrafikDTO(grafiks.ToList());
            }
        }
        public IEnumerable<GrafikDTO> FindByName(string name)
        {
            
            using (var context = new MuseumContext())
            {
                var grafiks = context.Grafik.Where(g => g.Exposition.ExpositionName.Contains(name));
                return rebuilderService.GrafikToGrafikDTO(grafiks.ToArray());
            }
        }
    }
}

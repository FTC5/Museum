using Museum.BLL.Interfaces;
using Museum.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.Services
{
    public class InitService : IInitService
    {
        public InitService()
        {
            
        }
        public void InitDropCreateDBOnModelChanged()
        {
            (new DropCreateDBOnModelChanged()).InitializeDatabase(new MuseumContext());
        }
    }
}

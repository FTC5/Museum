using AutoMapper;
using Museum.BLL.Infrastructure;
using Museum.UoW.EFCodeFirst;
using Museum.UoW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.Services
{
    public class Service
    {
        protected IUnitOfWork db;
        protected readonly IMapper mapper;

        public Service()
        {
            this.db = new UnitOfWork("MuseumContext");
            this.mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapping>()).CreateMapper();
        }
    }
}

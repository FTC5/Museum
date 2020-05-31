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
        protected readonly IUnitOfWork db;
        protected readonly IMapper mapper;

        public Service(IMapper mapper, IUnitOfWork db)
        {
            this.db = db;
            this.mapper = mapper;
        }
    }
}

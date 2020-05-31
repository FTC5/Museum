using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Museum.BLL.DTO;
using Museum.BLL.Infrastructure;
using Museum.BLL.Interfaces;
using Museum.BLL.Services;
using Museum.DAL;
using Museum.UoW.Interfaces;
using Ninject;
using Ninject.MockingKernel.NSubstitute;
using NSubstitute;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Museum.BLL.Tests
{
    [TestFixture]
    class ExpositionServiceTests
    {
        private readonly IFixture _fixture = new Fixture();
        private IUnitOfWork _unitOfWork;
        private IExpositionService _expositionService;
        [SetUp]
        public void SetUp()
        {
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapping>()).CreateMapper(); ;
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _expositionService = new ExpositionService(mapper, _unitOfWork);
        }
        [Test]
        public void GetExpositionInfo_return_null_when_Exposition_not_found()
        {
            int id = 0;

            var result = _expositionService.GetExpositionInfo(id);

            Assert.IsNull(result);
        }
        [Test]
        public void FindByName_return_Exposition_when_Exposition_found()
        {
            var exposition = _fixture.Create<Exposition>();
            _unitOfWork.Exposition.Get(default).ReturnsForAnyArgs(exposition);

            var result = _expositionService.GetExpositionInfo(default);

            Assert.IsNotNull(result);
        }
    }
}

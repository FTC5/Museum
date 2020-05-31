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
    class GrafikServiceTests
    {
        private IGrafikService _grafikService;
        private readonly IFixture _fixture = new Fixture();
        private IUnitOfWork _unitOfWork;
        [SetUp]
        public void SetUp()
        {
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapping>()).CreateMapper(); ;
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _grafikService = new GrafikService(mapper, _unitOfWork);
        }
        [Test]
        public void FindByName_return_null_when_Exposition_with_name_not_found()
        {
            string name="";

            var result = _grafikService.FindByName(name);

            Assert.IsEmpty(result);
        }
        [Test]
        public void FindByName_return_IEnumerable_of_GrafikDTO_when_Expositions_with_name_found()
        {
            //var grafiks = _fixture.CreateMany<Grafik>();
            var grafiks = new List<Grafik>();
            grafiks.Add(_fixture.Create<Grafik>());
            _unitOfWork.Grafik.Find(default).ReturnsForAnyArgs(grafiks.AsQueryable());

            var result = _grafikService.FindByName(default);

            Assert.IsNotEmpty(result);
        }
    }
}

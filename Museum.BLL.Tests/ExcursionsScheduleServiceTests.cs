using System;
using System.Collections.Generic;
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
    public class ExcursionsScheduleServiceTests
    {
        private IExcursionsScheduleService _excursionsScheduleService;
        private IExpositionService _expositionService;
        private readonly IFixture _fixture = new Fixture();
        private IUnitOfWork _unitOfWork;
        [SetUp]
        public void SetUp()
        {
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapping>()).CreateMapper(); ;
            using (var kernel = new NSubstituteMockingKernel())
            {
                _expositionService = kernel.Get<IExpositionService>();
            }
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _excursionsScheduleService = new ExcursionsScheduleService(_expositionService, mapper, _unitOfWork);
        }
        [Test]
        public void SignUpToCustomExcursion_throw_ExcursionNotFoundException_if_CustomExcursion_not_fount()
        {
            var customer = _fixture.Create<CustomerDTO>();

            var ex = Assert.Throws<ExcursionNotFoundException>(() 
                => _excursionsScheduleService.SignUpToCustomExcursion(default, customer));

            Assert.That(ex.Message, Is.EqualTo("Excursion with id not found"));
        }
        [Test]
        public void SignUpToCustomExcursion_throw_SmallAgeCustomerException_if_Customer_age_to_small()
        {
            var customer = _fixture.Create<CustomerDTO>();
            var excursion = _fixture.Create<CustomExcursion>();
            customer.Age = -1000;
            _unitOfWork.CustomExcursion.Get(default).ReturnsForAnyArgs(excursion);

            var ex = Assert.Throws<SmallAgeCustomerException>(()
                => _excursionsScheduleService.SignUpToCustomExcursion(default, customer));

            Assert.That(ex.Message, Is.EqualTo("Small age customer found"));
        }
        [Test]
        public void SignUpToCustomExcursion_return_true_if_all_is_ok()
        {
            var customer = _fixture.Create<CustomerDTO>();
            var excursion = _fixture.Create<CustomExcursion>();
            customer.Age = excursion.ExcursionsSchedule.Grafik.Exposition.TargetAudience+1;
            _unitOfWork.CustomExcursion.Get(default).ReturnsForAnyArgs(excursion);

            var result = _excursionsScheduleService.SignUpToCustomExcursion(default, customer);

            Assert.IsTrue(result);
        }
        [Test]
        public void SignUpToCustomExcursion__throw_ExcursionNotFoundException_if_CustomExcursion_not_fount()
        {
            var customers = _fixture.CreateMany<CustomerDTO>();

            var ex = Assert.Throws<ExcursionNotFoundException>(()
                => _excursionsScheduleService.SignUpToCustomExcursion(default, customers));

            Assert.That(ex.Message, Is.EqualTo("Excursion with id not found"));
        }
        [Test]
        public void SignUpToCustomExcursion_throw_SmallAgeCustomerException_if_one_of_the_Customers_age_to_small()
        {
            var customers = new List<CustomerDTO>();
            var customer = _fixture.Build<CustomerDTO>().With(c=>c.Age,-1000).Create();
            var excursion = _fixture.Create<CustomExcursion>();
            customers.Add(customer);
            _unitOfWork.CustomExcursion.Get(default).ReturnsForAnyArgs(excursion);

            var ex = Assert.Throws<SmallAgeCustomerException>(()
                => _excursionsScheduleService.SignUpToCustomExcursion(default, customers));

            Assert.That(ex.Message, Is.EqualTo("Small age customers found"));
        }
        [Test]
        public void SignUpToCustomExcursion_cause_Save_if_all_is_ok()
        {
            var customers = new List<CustomerDTO>();
            var customer = _fixture.Create<CustomerDTO>();
            var excursion = _fixture.Create<CustomExcursion>();
            customer.Age = excursion.ExcursionsSchedule.Grafik.Exposition.TargetAudience + 1;
            customers.Add(customer);
            _unitOfWork.CustomExcursion.Get(default).ReturnsForAnyArgs(excursion);

            _excursionsScheduleService.SignUpToCustomExcursion(default, customers);

            _unitOfWork.Received().Save();
        }
        [Test]
        public void GetCustomExcursions_return_null_when_ExcursionsSchedule_not_found()
        {
            int id = 0;

            var result = _excursionsScheduleService.GetCustomExcursions(id);

            Assert.IsNull(result);
        }
        [Test]
        public void GetCustomExcursions_return_list_of_CustomExcursionDTO_when_ExcursionsSchedule_found()
        {
            var excursionShedule = _fixture.Create<ExcursionsSchedule>();
            _unitOfWork.ExcursionsSchedule.Get(default).ReturnsForAnyArgs(excursionShedule);

            var result = _excursionsScheduleService.GetCustomExcursions(default);

            Assert.IsNotNull(result);
        }
        [Test]
        public void GetScheduledExcursionsInfo_return_null_when_Excursion_not_found()
        {
            int id = 0;

            var result = _excursionsScheduleService.GetScheduledExcursionsInfo(id);

            Assert.IsNull(result);
        }
        [Test]
        public void GetScheduledExcursionsInfo_return_Excursion_when_Excursion_found()
        {
            var excursion = _fixture.Create<Excursion>();
            _unitOfWork.Excursion.Get(default).ReturnsForAnyArgs(excursion);

            var result = _excursionsScheduleService.GetScheduledExcursionsInfo(default);

            Assert.IsNotNull(result);
        }
    }
}

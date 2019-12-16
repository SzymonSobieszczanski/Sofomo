using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Sofomo.Data;
using Sofomo.Data.IRepositories;
using Sofomo.DTO;
using Sofomo.Extension;
using Sofomo.IpStack;
using Sofomo.Logic;
using Sofomo.Models;

namespace Tests
{
    [TestFixture]
    public class LogicTest
    { 
        private IRepository _repository;
        private List<IpInfo> _objects;
        
       static MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.CreateMap<IpInfo, IpInfoDTO>();
            cfg.CreateMap<IpInfoDTO, IpInfo>();
        });
        IMapper mapper = config.CreateMapper();

        [Test]
        public void TestAdd()
        {

            var mockedRepository = new Mock<IRepository>();
            mockedRepository.Setup(m => m.Add(fakeInfo)).Returns(0);
            ILogic logic = new Logic(mockedRepository.Object, mapper);
            var result = logic.Add(fakeInfoDto);
            Assert.AreEqual(0,result);
        }
        [Test]
        public void TestGet()
        {
            var mockedRepository = new Mock<IRepository>();
            mockedRepository.Setup(m => m.Get("123.123.132.123")).Returns(fakeInfo);
            ILogic logic = new Logic(mockedRepository.Object,mapper);
            var result = logic.Get("123.123.132.123");
            Assert.AreEqual(fakeInfo.City,result.City);
            Assert.AreEqual(fakeInfo.Ip, result.Ip);
            Assert.AreEqual(fakeInfo.ContinentCode, result.ContinentCode);
        }
        [Test]
        public void TestDelete()
        {
            var mockedRepository = new Mock<IRepository>();
            mockedRepository.Setup(m => m.Remove("123.123.132.123")).Returns(HttpStatusCode.OK);
            ILogic logic = new Logic(mockedRepository.Object, mapper);
            var result = logic.Delete("123.123.132.123");
            Assert.AreEqual(HttpStatusCode.OK, result);
        }

        private IpInfo fakeInfo = new IpInfo
        {
            City = "Warsaw",
            ContinentCode = "Eu",
            Ip = "123.123.132.123",
            ContinentName = "Europe",
            SearchAddress = "https://google.pl"
        };

        private IpInfoDTO fakeInfoDto = new IpInfoDTO()
        {
            City = "Warsaw",
            ContinentCode = "Eu",
            Ip = "123.123.132.123",
            ContinentName = "Europe",
            SearchAddress = "https://google.pl"
        };
    }

}
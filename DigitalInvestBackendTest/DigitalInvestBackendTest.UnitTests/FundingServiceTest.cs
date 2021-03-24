using AutoMapper;
using DigitalInvestBackendTest.Data.Entities;
using DigitalInvestBackendTest.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace DigitalInvestBackendTest.UnitTests
{
    public class FundingServiceTest
    {

        //private Mock<IFundingRepository> _fundingRepository;

        //private IFundingService _fundingService;

        ///// <summary>
        ///// Constructor, initializes an instance of <see cref="FundingServiceTest"/>
        ///// </summary>
        //public FundingServiceTest()
        //{
        //    _fundingRepository = new Mock<IFundingRepository>();

        //    _fundingService = new FundingService( _fundingRepository.Object);
        //}

        [Fact]
        public async void GetAllFundingsTest()
        {
            //var id = Guid.NewGuid();

            //var fundingsList = new List<Funding>();
            ////{
            ////    new Funding()
            ////    {
            ////        Id = id,
            ////        ProjectId = 1234,
            ////        Address = "AddressTest",
            ////        ResidentailType = "ResidentailTypeTest"
            ////    }
            ////};

            //_fundingRepository.Setup(x => x.GetAllFundings()).ReturnsAsync(fundingsList);

            //var fundingsListResult = await _fundingService.GetAllFundings();

            //Assert.Single(fundingsListResult);
            //Assert.Equal(id, fundingsListResult.First().Id);
            //Assert.Equal(1234, fundingsListResult.First().ProjectId);
            //Assert.Equal("AddressTest", fundingsListResult.First().Address);
            //Assert.Equal("ResidentailTypeTest", fundingsListResult.First().ResidentailType);
        }
    }
}

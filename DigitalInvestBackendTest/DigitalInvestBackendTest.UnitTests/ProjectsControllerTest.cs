using DigitalInvestBackendTest.Api.Controllers;
using DigitalInvestBackendTest.Api.Models;
using DigitalInvestBackendTest.Services;
using DigitalInvestBackendTest.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DigitalInvestBackendTest.UnitTests
{
    public class ProjectsControllerTest
    {
        private Mock<IProjectService> _projectService;

        private ProjectsController _projectsController;

        public ProjectsControllerTest()
        {
            _projectService = new Mock<IProjectService>();
            _projectsController = new ProjectsController(_projectService.Object);
        }

        [Fact]
        public async void GetAllProjectsTest()
        {
            var id = Guid.NewGuid();

            var projectsList = new List<Project>()
            {
                new Project()
                {
                    Id = id,
                    Name = "NameTest",
                    AssetClass = "AssetClassTest",
                    TotalVolum = 1000,
                    AlreadyInvested = 10,
                    Description = "DescriptionTest"
                }
            };

            _projectService.Setup(x => x.GetAllProjects()).ReturnsAsync(projectsList);

            var projectsListResult = await _projectsController.GetAllProjects();
            Assert.IsType<OkObjectResult>(projectsListResult);

            var okObjectResult = (OkObjectResult)projectsListResult;

            projectsList =  (List<Project>) okObjectResult.Value;

            Assert.Equal(id, projectsList.First().Id);
            Assert.Equal("NameTest", projectsList.First().Name);
            Assert.Equal("AssetClassTest", projectsList.First().AssetClass);
            Assert.Equal(1000, projectsList.First().TotalVolum);
            Assert.Equal(10, projectsList.First().AlreadyInvested);
            Assert.Equal("DescriptionTest", projectsList.First().Description);
        }

        [Fact]
        public async void GetAllProjectsTestNoContent()
        {
            var id = Guid.NewGuid();

            var projectsList = new List<Project>();

            _projectService.Setup(x => x.GetAllProjects()).ReturnsAsync(projectsList);

            var projectsListResult = await _projectsController.GetAllProjects();
            Assert.IsType<NoContentResult>(projectsListResult);
        }


        [Fact]
        public async void SubmitInvestmentInvalidInvestmentAmount()
        {
            var createFundingModel = new CreateFundingModel()
            {
                ProjectId = Guid.NewGuid(),
                InvestorId = Guid.NewGuid(),
                InvestmentAmount = 10
            };

            var submitInvestmentResult = await _projectsController.SubmitInvestment(createFundingModel);
            Assert.IsType<BadRequestObjectResult>(submitInvestmentResult);
        }


        [Fact]
        public async void SubmitInvestmentInvalidInvestmentExist()
        {
            var createFundingModel = new CreateFundingModel()
            {
                ProjectId = Guid.NewGuid(),
                InvestorId = Guid.NewGuid(),
                InvestmentAmount = 1000
            };

            var funding = new Funding()
            {
                ProjectId = createFundingModel.ProjectId,
                InvestorId = createFundingModel.InvestorId,
                InvestmentAmount = createFundingModel.InvestmentAmount
            };

            _projectService.Setup(x => x.CheckIfTheInvestmentExist(It.IsAny<Funding>())).ReturnsAsync(true);

            var submitInvestmentResult = await _projectsController.SubmitInvestment(createFundingModel);
            Assert.IsType<ConflictObjectResult>(submitInvestmentResult);
        }

        [Fact]
        public async void SubmitInvestmentTest()
        {
            var createFundingModel = new CreateFundingModel()
            {
                ProjectId = Guid.NewGuid(),
                InvestorId = Guid.NewGuid(),
                InvestmentAmount = 1000
            };

            var funding = new Funding()
            {
                ProjectId = createFundingModel.ProjectId,
                InvestorId = createFundingModel.InvestorId,
                InvestmentAmount = createFundingModel.InvestmentAmount
            };

            _projectService.Setup(x => x.CheckIfTheInvestmentExist(It.IsAny<Funding>())).ReturnsAsync(false);

            var submitInvestmentResult = await _projectsController.SubmitInvestment(createFundingModel);
            Assert.IsType<OkObjectResult>(submitInvestmentResult);
        }

    }
}

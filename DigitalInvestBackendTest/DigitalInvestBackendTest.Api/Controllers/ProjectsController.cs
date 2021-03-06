using DigitalInvestBackendTest.Api.Models;
using DigitalInvestBackendTest.Services;
using DigitalInvestBackendTest.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalInvestBackendTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private IProjectService _projectService;

        /// <summary>
        /// Constructor, initializes an instance of <see cref="ProjectsController"/>
        /// </summary>
        /// <param name="projectService">An instance of <see cref="IProjectService"/></param>
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projectsList = await _projectService.GetAllProjects();

            if (projectsList.Count() == 0)
            {
                return NoContent();
            }

            return Ok(projectsList);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitInvestment(CreateFundingModel createFundingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }


            if (createFundingModel.InvestmentAmount < 100 || createFundingModel.InvestmentAmount > 10000)
            {
                return BadRequest("The investment amount should be between 100 and 10.000");
            }

            var funding = new Funding()
            {
                ProjectId = createFundingModel.ProjectId,
                InvestorId = createFundingModel.InvestorId,
                InvestmentAmount = createFundingModel.InvestmentAmount
            };

            // Check if there is only one investment amount for the project
            if (await _projectService.CheckIfTheInvestmentExist(funding))
            {
                return Conflict("You can only submit an amount once per funding");
            }

            try
            {
                await _projectService.SubmitInvestment(funding);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}

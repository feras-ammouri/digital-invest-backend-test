using DigitalInvestBackendTest.Api.Models;
using DigitalInvestBackendTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalInvestBackendTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private IFundingService _fundingService;

        /// <summary>
        /// Constructor, initializes an instance of <see cref="ProjectsController"/>
        /// </summary>
        /// <param name="fundingService">An instance of <see cref="IFundingService"/></param>
        public ProjectsController(IFundingService fundingService)
        {
            _fundingService = fundingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projectsList = await _fundingService.GetAllProjects();

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
                return BadRequest("Invalid data.");

            if (createFundingModel.InvestmentAmount < 100 || createFundingModel.InvestmentAmount > 10000)
            {
                return BadRequest("The investment amount should be between 100 and 10.000");
            }


            return Ok();
        }


 
        public IActionResult Index()
        {
            return View();
        }
    }
}

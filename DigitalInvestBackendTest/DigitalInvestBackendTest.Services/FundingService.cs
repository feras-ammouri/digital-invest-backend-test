using AutoMapper;
using DigitalInvestBackendTest.Data;
using DigitalInvestBackendTest.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalInvestBackendTest.Services
{
    public class FundingService : IFundingService
    {
        private DigitalInvestDbContext _digitalInvestDbContext;

        /// <summary>
        /// Constructor, initializes an instance of <see cref="FundingService"/>
        /// </summary>
        /// <param name="digitalInvestDbContext"> An instance of <see cref="DigitalInvestDbContext"/></param>
        public FundingService(DigitalInvestDbContext digitalInvestDbContext)
        {
            _digitalInvestDbContext = digitalInvestDbContext;
        }

        /// <summary>
        /// Returns all fundings
        /// </summary>
        /// <returns>List of <see cref="Project"/></returns>
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            // retrieve all fundings from the database
            var dbProjectsList = await (from project in _digitalInvestDbContext.Projects
                                          join funding in _digitalInvestDbContext.Fundings
                                              on project.Id equals funding.ProjectId
                                          group new { project, funding } by new {funding.ProjectId} into g
                                          select new 
                                          {
                                              Id = g.First().project.Id,
                                              Name = g.First().project.Name,
                                              AssetClass = g.First().project.AssetClass,
                                              TotalVolum = g.First().project.TotalVolum,
                                              AlreadyInvested = g.Sum(x=>x.funding.InvestmentAmount),
                                              Description = g.First().project.Description
                                          }).ToListAsync();

            var projectsList = new List<Project>();
            foreach (var dbProject in dbProjectsList)
            {
                var project = new Project()
                {
                    Id = dbProject.Id,
                    Name = dbProject.Name,
                    AssetClass = dbProject.AssetClass,
                    TotalVolum = dbProject.TotalVolum,
                    Description = dbProject.Description,
                    AlreadyInvested = dbProject.AlreadyInvested
                };

                projectsList.Add(project);
            }

            return projectsList;
        }
    }
}

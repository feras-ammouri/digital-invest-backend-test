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
                                              Id = g.Key.ProjectId,
                                              AlreadyInvested = g.Sum(x=>x.funding.InvestmentAmount)
                                          }).ToListAsync();

            var projectsList = new List<Project>();
            foreach (var dbProject in dbProjectsList)
            {
                var projectEntity = _digitalInvestDbContext.Projects.Where(x => x.Id == dbProject.Id).FirstOrDefault();

                var project = new Project()
                {
                    Id = dbProject.Id,
                    Name = projectEntity.Name,
                    AssetClass = projectEntity.AssetClass,
                    TotalVolum = projectEntity.TotalVolum,
                    Description = projectEntity.Description,
                    AlreadyInvested = dbProject.AlreadyInvested
                };

                projectsList.Add(project);
            }

            return projectsList;
        }

        public async Task<bool> CheckIfTheInvestmentExist(Funding funding)
        {
            var dbFunding = await (_digitalInvestDbContext.Fundings.Where(f => f.ProjectId == funding.ProjectId && f.InvestorId == funding.InvestorId)).FirstOrDefaultAsync();

            if (dbFunding == null)
            {
                return false;
            }

            return true;
        }

        public async Task SubmitInvestment(Funding funding)
        {
            var dbFunding = new Data.Entities.Funding()
            {
                Id = Guid.NewGuid(),
                ProjectId = funding.ProjectId,
                InvestorId = funding.InvestorId,
                InvestmentAmount = funding.InvestmentAmount,
                InvestmentDate = DateTime.Now
            };

            await _digitalInvestDbContext.AddAsync(dbFunding);
            await _digitalInvestDbContext.SaveChangesAsync();
        }
    }
}

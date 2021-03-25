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
    public class ProjectService : IProjectService
    {
        private DigitalInvestDbContext _digitalInvestDbContext;

        /// <summary>
        /// Constructor, initializes an instance of <see cref="ProjectService"/>
        /// </summary>
        /// <param name="digitalInvestDbContext"> An instance of <see cref="DigitalInvestDbContext"/></param>
        public ProjectService(DigitalInvestDbContext digitalInvestDbContext)
        {
            _digitalInvestDbContext = digitalInvestDbContext;
        }

        /// <summary>
        /// Returns all fundings
        /// </summary>
        /// <returns>List of <see cref="Project"/></returns>
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            // retrieve all projects from the database
            var projectEntitiesList = await _digitalInvestDbContext.Projects.ToListAsync();

            var projectsList = new List<Project>();
            foreach (var projectEntity in projectEntitiesList)
            {
                var project = new Project()
                {
                    Id = projectEntity.Id,
                    Name = projectEntity.Name,
                    AssetClass = projectEntity.AssetClass,
                    TotalVolum = projectEntity.TotalVolum,
                    Description = projectEntity.Description,
                    AlreadyInvested = (_digitalInvestDbContext.Fundings.Where(x=>x.ProjectId.Equals(projectEntity.Id)).Sum(x=>x.InvestmentAmount))
                };

                projectsList.Add(project);
            }

            return projectsList;
        }

        /// <summary>
        /// Checks if the funcding exists
        /// </summary>
        /// <param name="funding">An instance of <see cref="Funding"/></param>
        /// <returns></returns>
        public async Task<bool> CheckIfTheInvestmentExist(Funding funding)
        {
            // check if the funding exists in the db
            var dbFunding = await (_digitalInvestDbContext.Fundings.Where(f => f.ProjectId == funding.ProjectId && f.InvestorId == funding.InvestorId)).FirstOrDefaultAsync();

            if (dbFunding == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Submits a funding 
        /// </summary>
        /// <param name="funding">An instance of <see cref="Funding"/></param>
        /// <returns></returns>
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

            // save the funding in the db
            await _digitalInvestDbContext.AddAsync(dbFunding);
            await _digitalInvestDbContext.SaveChangesAsync();
        }
    }
}

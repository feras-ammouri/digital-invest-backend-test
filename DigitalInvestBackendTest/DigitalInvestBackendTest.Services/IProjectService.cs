using DigitalInvestBackendTest.Data;
using DigitalInvestBackendTest.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalInvestBackendTest.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjects();

        Task<bool> CheckIfTheInvestmentExist(Funding funding);

        Task SubmitInvestment(Funding funding);
    }
}

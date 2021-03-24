using DigitalInvestBackendTest.Data;
using DigitalInvestBackendTest.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalInvestBackendTest.Services
{
    public interface IFundingService
    {
        Task<IEnumerable<Project>> GetAllProjects();
    }
}

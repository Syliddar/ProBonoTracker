using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Models.CaseViewModels;

namespace MemigrationProBonoTracker.Services
{
    public interface IContextService
    {
        Task<CaseListViewModel> GetCaseListViewModel(bool? openCases);

        Task<Case> GetCaseDetails(int id);

        void AddCase(Case @case);
        void UpdateCase(Case @case);
        void DeleteCase(int id);
    }
}

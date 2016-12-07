using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBonoTracker.Services.Interfaces
{
    public interface IContextService
    {
        int GetNumberOfAssignedCases(int attorneyId);
    }
}

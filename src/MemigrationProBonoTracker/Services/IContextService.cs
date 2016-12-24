﻿using System;
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
        CaseListViewModel GetCaseListViewModel(bool? openCases);

        Case GetCaseDetails(int id);

        int AddCase(Case @case);
        int UpdateCase(Case @case);
        int DeleteCase(int id);
        List<Person> GetPeopleList();
        Person GetPerson(int id);
        int AddPerson(Person @person);
        int UpdatePerson(Person @person);
        int DeletePerson(int id);
    }
}
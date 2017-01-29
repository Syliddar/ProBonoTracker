using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemigrationProBonoTracker.Models.PersonViewModel
{
    public class PersonDetailsViewModel
    {
        public Person Person { get; set; }
        public List<Case> Cases { get; set; }

    }
}

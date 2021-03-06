using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Custom user properties
        [PersonalData]
        public string FullName { get; set; }
        [PersonalData]
        public string NetId { get; set; }
        [PersonalData]
        public DateTime CreationDateTime { get; set; }
    }
}

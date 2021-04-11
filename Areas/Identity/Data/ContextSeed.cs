using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Areas.Identity.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Seeding the default roles
            await roleManager.CreateAsync(new IdentityRole("Researcher"));
            await roleManager.CreateAsync(new IdentityRole("Administrator"));
        }
    }
}

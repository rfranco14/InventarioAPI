using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Context
{
    public class InventarioIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public InventarioIdentityContext(DbContextOptions<InventarioIdentityContext> options)
       : base(options)
        {

        }
    }
}

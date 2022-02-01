using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FristProjectIti.Models
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context>options):base (options)
        { 
        }
        public DbSet<Patient>patients { get; set; }
    }
}

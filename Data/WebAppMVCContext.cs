using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Models;

namespace WebAppMVC.Data
{
    public class WebAppMVCContext : DbContext
    {
        public WebAppMVCContext (DbContextOptions<WebAppMVCContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppMVC.Models.Movie> Movie { get; set; } = default!;
        public DbSet<WebAppMVC.Models.Category> Category { get; set; } = default!;
        public DbSet<WebAppMVC.Models.Product> Product { get; set; } = default!;
    }
}

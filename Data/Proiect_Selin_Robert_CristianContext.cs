using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Selin_Robert_Cristian.Models;

namespace Proiect_Selin_Robert_Cristian.Data
{
    public class Proiect_Selin_Robert_CristianContext : DbContext
    {
        public Proiect_Selin_Robert_CristianContext (DbContextOptions<Proiect_Selin_Robert_CristianContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Selin_Robert_Cristian.Models.SportsField> SportsField { get; set; } = default!;

        public DbSet<Proiect_Selin_Robert_Cristian.Models.SportsFacility> SportsFacility { get; set; }

        public DbSet<Proiect_Selin_Robert_Cristian.Models.Category> Category { get; set; }

        public DbSet<Proiect_Selin_Robert_Cristian.Models.City> City { get; set; }

        public DbSet<Proiect_Selin_Robert_Cristian.Models.Member> Member { get; set; }

        public DbSet<Proiect_Selin_Robert_Cristian.Models.Booking> Booking { get; set; }

    }
}

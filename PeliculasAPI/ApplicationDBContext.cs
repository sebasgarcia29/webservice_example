using System;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Entities;

namespace PeliculasAPI
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Gender> Genders { get; set; }

    }
}


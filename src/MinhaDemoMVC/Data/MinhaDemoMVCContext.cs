using System;
using Microsoft.EntityFrameworkCore;
using MinhaDemoMVC.Models;

namespace MinhaDemoMVC.Data
{
    public class MinhaDemoMVCContext : DbContext
    {
        public MinhaDemoMVCContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MinhaDemoMVC.Models.Filme> Filme { get; set; }
    }
}


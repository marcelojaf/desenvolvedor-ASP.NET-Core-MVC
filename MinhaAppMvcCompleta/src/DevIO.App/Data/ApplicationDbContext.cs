using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DevIO.App.ViewModel;

namespace DevIO.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DevIO.App.ViewModel.EnderecoViewModel> EnderecoViewModel { get; set; }
    }
}
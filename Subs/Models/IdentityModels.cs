using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;
using Subs.Models.Entity;

namespace Subs.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //[Required]  // Ekki nullable
        public string sEmail { get; set; }
        public int iRanking { get; set; }
        public int iTheme { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime dSignupDate { get; set; }

        // Adkomulykill
        //[ForeignKey("ID")]
        //public virtual Client Client { get; set; }
        //public virtual Request Request { get; set; }
        //public virtual SubFile SubFile { get; set; }

        //public virtual ICollection<Request> Request { get; set; }
        // (one-to-many) - listi af skram
        //public virtual ICollection<SubFile> SubFile { get; set; }
        // (one-to-many) - listi af umsognum
        public virtual ICollection<Comment> Comment { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")//, throwIfV1Schema: false
        {
        }

        // Gagnagrunnstoflur
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<SubFile> SubFiles { get; set; }




        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Request>()
        //    //    .HasOptional(quote => quote.SubFile
        //    //        .WithRequired(order => order.Request);
        //}
    }
}
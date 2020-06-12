using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth2Fb.Models
{
    public class FacebookConnectContext : DbContext
    {
        public DbSet<Email> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=email.db");
    }
        
    public class Email
    {
        [Key]
        public int Email_Id { get; set; }
        public string Email_Address { get; set; }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OAuth2Fb.Data;
using OAuth2Fb.Models;
using Microsoft.AspNetCore.Identity;

namespace OAuth2Fb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            using (var db = new FacebookConnectContext())
            {
                //Create
                //Console.WriteLine("Adding an emailaddress");
                //db.Add(new Email {Email_Address = User.Identiy.Name});
                //db.SaveChanges();

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

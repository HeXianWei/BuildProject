using Microsoft.EntityFrameworkCore;
using Mimikko.WebApi.Framework.User.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphWeb
{
    public class MimikkoCloudTestDbContext : DbContext
    {

        public MimikkoCloudTestDbContext(DbContextOptions<MimikkoCloudTestDbContext> context)
            : base(context)
        {
        }

        public DbSet<UserTitle> UserTitles { get; set; }

        public DbSet<Title> Titles { get; set; }

        public DbSet<UserInformation> UserInformations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            base.OnModelCreating(modelBuilder);

        }

    }
}

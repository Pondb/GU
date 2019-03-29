using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GU.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using GU.Controllers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GU.Data
{
    public class GU_DB : DbContext
    {
        public GU_DB(DbContextOptions<GU_DB> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<ToDo_Task> ToDo_Task { get; set; }
        public DbSet<Trees> Trees { get; set; }
        //public DbSet<UserMapping> UserMapping { get; set; }
        public DbSet<Tree_Type> Tree_Type { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<ToDo_Task>().ToTable("ToDo_Task");
            modelBuilder.Entity<Trees>().ToTable("Trees");
            modelBuilder.Entity<Tree_Type>().ToTable("Tree_Type");
            //modelBuilder.Entity<UserMapping>().ToTable("UserMapping").HasKey(c => new { c.User_ID, c.Tree_ID });





           

        }

    }
}

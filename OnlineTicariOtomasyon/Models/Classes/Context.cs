﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillNote> BillNotes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesMovement> SalesMovements { get; set; }
        public DbSet<Stuff> Stuffs { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoTracking> CargoTrackings { get; set; }


    }
}
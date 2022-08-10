using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiBank_0.Models.Entities;
using WebApiBank_0.Models.Init;

namespace WebApiBank_0.Models.Context
{
    public class MyContext:DbContext
    {
        public MyContext():base("MyConnection")
        {
            Database.SetInitializer(new MyInit());


        }

        public DbSet<CardInfo> Cards { get; set; }



    }
}
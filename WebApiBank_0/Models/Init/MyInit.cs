using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiBank_0.Models.Context;
using WebApiBank_0.Models.Entities;

namespace WebApiBank_0.Models.Init
{
    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            CardInfo ci = new CardInfo();
            ci.CardUserName = "Ali Tarakci";
            ci.CardNumber = "1111 1111 1111 1111";
            ci.CardExpiryYear = 2024;
            ci.CardExpiryMonth = 12;
            ci.SecurityNumber = "666";
            ci.Limit = 50000;
            ci.Balance = 50000;
            context.Cards.Add(ci);
            context.SaveChanges();

        }



    }
}
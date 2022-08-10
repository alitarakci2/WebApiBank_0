using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiBank_0.DesignPatterns.SingletonPattern;
using WebApiBank_0.DTOClasses;
using WebApiBank_0.Models.Context;
using WebApiBank_0.Models.Entities;

namespace WebApiBank_0.Controllers
{
    public class PaymentController : ApiController
    {

        MyContext _db;
        public PaymentController()
        {
            _db = DBTool.DBInstance;
        }


        //Asagidaki Action sadece development testi icindir.

        //[HttpGet]
        //public List<PaymentDTO> GetAll()
        //{

        //    return _db.Cards.Select(x => new PaymentDTO
        //    {

        //        CardExpiryMonth = x.CardExpiryMonth,
        //        CardUserName = x.CardUserName,
        //        CardNumber = x.CardNumber
        //    }).ToList();


        //}

        [HttpPost]
        public IHttpActionResult RecievePayment(PaymentDTO item)
        {
            CardInfo ci = _db.Cards.FirstOrDefault(x => x.CardNumber == item.CardNumber && x.SecurityNumber == item.SecurityNumber && x.CardUserName == item.CardUserName && x.CardExpiryYear == item.CardExpiryYear && x.CardExpiryMonth == item.CardExpiryMonth);

            if (ci != null)
            {
                if (ci.CardExpiryYear < DateTime.Now.Year)
                {
                    return BadRequest("Expired Card");
                }
                else if (ci.CardExpiryYear == DateTime.Now.Year)
                {
                    if (ci.CardExpiryMonth < DateTime.Now.Month)
                    {
                        return BadRequest("Expired Card(Month)");
                    }

                    if (ci.Balance >= item.ShoppingPrice)
                    {

                        SetBalance(item,ci);

                        return Ok();
                    }
                    else
                    {
                        return BadRequest("Balance exceeded");
                    }

                }


                else if (ci.Balance >= item.ShoppingPrice)
                {
                    SetBalance(item, ci);
                    return Ok();


                }
                return BadRequest("Balance exceeded");
            }

            return BadRequest("Card Not Found");

        }


        private void SetBalance(PaymentDTO item, CardInfo ci)
        {
            ci.Balance -= item.ShoppingPrice;
            _db.SaveChanges();

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiBank_0.Models.Context;

namespace WebApiBank_0.DesignPatterns.SingletonPattern
{
    public class DBTool
    {


        public DBTool()
        {

        }


        static MyContext _dbInstance;

        public static MyContext DBInstance
        {

            get
            {
                if (_dbInstance == null) _dbInstance = new MyContext();
                return _dbInstance;
            }



        }
    }
}
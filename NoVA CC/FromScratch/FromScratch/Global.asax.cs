﻿
using FromScratch.StartMyStuff;
using System;
using System.Web.Http;

namespace FromScratch
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(INeedSomeCoffee.SetMeUp);
        }

    }
}
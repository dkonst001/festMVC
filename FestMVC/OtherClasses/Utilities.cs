using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestMVC.OtherClasses
{
    public class Utilities
    {
        public static string GetServerRoot(HttpServerUtilityBase server)
        {
            return server.MapPath(@"\");

        }
    }
}
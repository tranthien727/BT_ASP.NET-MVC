using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap1_61133181.Models
{
    public class ModelController : Controller
    {
        // GET: Model
        public class CalModels
        {
            public double a { get; set; }
            public double b { get; set; }
            public string pt { get; set; }
        }
    }
}
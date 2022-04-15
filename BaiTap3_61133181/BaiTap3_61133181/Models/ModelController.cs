﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap3_61133181.Models
{
    public class ModelController : Controller
    {
        // GET: Model
        public class EmpModel
        {
            public string EmpID { get; set; }
            public string Name { get; set; }
            public DateTime BirthOfDate { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Department { get; set; }
            public string Avatar { get; set; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Areas.Admin.Models;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected AppRepository app = new AppRepository();
    }
}
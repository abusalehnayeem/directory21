﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using directory21.Core.Data;
using directory21.Core.Domain;
using directory21.Data;

namespace directory21.Controllers
{
    public class HomeController : Controller
    {
        //private IRepository<Resources> _repository;

        //public HomeController(IRepository<Resources> repository)
        //{
        //    _repository = repository;
        //}

        private readonly SimpleContext _context = new SimpleContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View(_context.Resources.ToList());
        }


    }
}

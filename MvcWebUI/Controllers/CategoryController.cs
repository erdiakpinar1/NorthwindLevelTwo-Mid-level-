﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        //Alttakine ihtiyaç kalmadı onun yerine partial viewe benzer bir yapı kurduk ve oraya eklemeleri yaptık. => CategoryListViewComponent.cs <=
        //public IActionResult Index()
        //{
        //    var model = new CategoryListViewModel
        //    {
        //        Categories = _categoryService.GetAll()
        //    };
        //    return View(model);
        //}
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.MVC.ViewModel;

namespace ProjectX.MVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IEntityService<Specialization> _specializationService;
        private readonly IEntityService<Course> _courseService;
        private readonly IMapper _mapper;
        private readonly ILogger<CoursesController> _logger;
        public CoursesController(IEntityService<Course> courseService, 
            IEntityService<Specialization> specializationService, 
            IMapper mapper, ILogger<CoursesController> logger)
        {
            _specializationService = specializationService;
            _courseService = courseService;
            _mapper = mapper;
            _logger = logger;
        }
        public IActionResult Index(int id)
        {
            try
            {
                ViewBag.SpecializationTitle = _specializationService.GetEntityById(id).Title;
                var courses = _courseService.GetAll().Where(_ => _.SpecializationId == id);
                return View(_mapper.Map<IEnumerable<CourseViewModel>>(courses).ToList());
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}

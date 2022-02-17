using AutoMapper;
using ContactManager.Data;
using ContactManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ContactManager.Controllers
{
    public class AppController : Controller
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;

        public AppController(IContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get(bool includeAddresses = true)
        {
            try
            {
                var results = _repository.GetAllClients(includeAddresses);
                return Ok(_mapper.Map<IEnumerable<ClientViewModel>>(results));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
		public IActionResult Create()
		{
			return View();
		}
	}
}

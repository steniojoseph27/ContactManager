using AutoMapper;
using ContactManager.Data;
using ContactManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    [Route("api/[Controller]")]
    public class ClientsController : Controller
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;

        public ClientsController(IContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
    }
}

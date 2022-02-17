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
    public class AddressesController : Controller
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;

        public AddressesController(IContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int clientId)
        {
            var client = _repository.GetClientById(clientId);
            if (client != null) return Ok(_mapper.Map<IEnumerable<AddressViewModel>>(client.Addresses));
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int clientId, int id)
        {
            var client = _repository.GetClientById(clientId);
            if (client != null)
            {
                var address = client.Addresses.Where(c => c.Id == id).FirstOrDefault();

                if (address != null)
                {
                    return Ok(_mapper.Map<AddressViewModel>(address));
                }
            }
            return NotFound();
        }
    }
}

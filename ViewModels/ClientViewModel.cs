using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ViewModels
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public ICollection<AddressViewModel> Addresses { get; set; }
    }
}

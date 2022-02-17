using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public string FullAddress { get; set; }
        public string AddressType { get; set; }
        public Client Client { get; set; }
    }
}

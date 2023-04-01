using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string TypeDocument { get; set; }

        public string NumberDocument { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FirstLastName { get; set; }

        public string LastLastName { get; set; }

        public DateTime BirthDate { get; set; } 

        public string CelephoneNumber { get; set; }

        public string Email { get; set; }   

        public string Address { get; set; }
      
    }
}

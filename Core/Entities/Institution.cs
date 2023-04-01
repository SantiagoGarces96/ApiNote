using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Institution
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public string Email { get; set; } = default;
        public string Location { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Porcentage { get; set; } = default;

        public string DateNote { get; set; } = default;

        public string Observation { get; set; } = default;

        public string ValueNote { get; set; } = default;
    }
}

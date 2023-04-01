using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AcademicProgram

    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default;

        public string Code { get; set; } = default;

        public string AcademicDirector { get; set; }

        public bool State { get; set; }

        public string Schedule { get; set; }

        public string Modality { get; set; }
    }
}

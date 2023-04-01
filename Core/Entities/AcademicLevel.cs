﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class AcademicLevel
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }    

        public string Code { get; set; }

        public string NumberSemesters { get; set; }
    }
}

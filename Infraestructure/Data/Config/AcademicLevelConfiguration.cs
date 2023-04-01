using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Config
{
    public class AcademicLevelConfiguration : IEntityTypeConfiguration<AcademicLevel>
    {
        public void Configure(EntityTypeBuilder<AcademicLevel> builder)
        {
            builder.Property(l => l.Id).IsRequired();
            builder.Property(l => l.Name).IsRequired();
            builder.Property(l => l.Code).IsRequired();
            builder.Property(l => l.NumberSemesters).IsRequired();



        }
    }
}

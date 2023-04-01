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
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Property(n => n.Id).IsRequired();
            builder.Property(n => n.Porcentage).IsRequired();
            builder.Property(n => n.DateNote).IsRequired();
            builder.Property(n => n.Observation).IsRequired();
            builder.Property(n => n.ValueNote).IsRequired();
        }
    }
}

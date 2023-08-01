using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Domain.Entities;

namespace TodoApp.Infrastructure.Persistence.Configuration
{
    public class TodoEntityConfiguration : IEntityTypeConfiguration<TodoEntity>
    {
        public void Configure(EntityTypeBuilder<TodoEntity> builder)
        {
            builder.ToTable("Todos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.IsCompleted)
                   .IsRequired();
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegrationTestsDemo.Api.Models;

public class Customer
{
    public int Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }
}

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(20)
            .IsRequired();
    }
}

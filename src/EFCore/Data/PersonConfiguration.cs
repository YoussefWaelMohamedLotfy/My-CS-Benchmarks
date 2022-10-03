using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    static int count = 1;
    Faker<Person> personFaker = new Faker<Person>()
            .RuleFor(p => p.ID, _ => count++)
            .RuleFor(p => p.FullName, f => f.Name.FullName())
            .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(p => p.Address, f => f.Address.StreetAddress());

    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(x => x.ID).IsRequired();

        builder.HasData(personFaker.GenerateBetween(5, 10));
    }
}

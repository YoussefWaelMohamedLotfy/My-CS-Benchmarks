namespace EFCore.Data;

public sealed class Person
{
    public int ID { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }
}

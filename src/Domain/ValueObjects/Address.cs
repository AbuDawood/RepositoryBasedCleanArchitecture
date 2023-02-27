namespace CleanArchitecture.Domain.ValueObjects;

public class Address : ValueObject
{

    public string Line01 { get; private set; }

    public int ZipCode { get; private set; }


    protected Address() { }

    public Address(string line01, int zipCode)
    {
        Line01 = line01;
        ZipCode = zipCode;
    }


    protected override IEnumerable<object> GetEqualityComponents()
    {
        return new List<object>() { Line01, ZipCode };
    }
}

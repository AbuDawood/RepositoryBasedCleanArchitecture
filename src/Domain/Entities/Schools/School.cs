using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Schools;
public class School : BaseEntity<Guid>
{
    public string Code { get; protected set; }

    public string Name { get; protected set; }

    public Address Address { get; protected set; }

    public ICollection<SchoolClassroom> Classrooms { get; protected set; }

    protected School() { }

    internal protected School(Guid id, string name, string code, Address address) : base(id)
    {
        Name = name;
        Code = code;
        Address = address;
    }

}

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

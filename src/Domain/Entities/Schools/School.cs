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

    protected School() { }

    internal protected School(Guid id, string name, string code, Address address) : base(id)
    {
        Name = name;
        Code = code;
        Address = address;
    }

}

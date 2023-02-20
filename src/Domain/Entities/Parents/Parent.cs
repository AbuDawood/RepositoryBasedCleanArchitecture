using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Parents.Exceptions;

namespace CleanArchitecture.Domain.Entities.Parents;
public class Parent : BaseEntity<Guid>
{
    protected Parent() { }

    public Parent(Guid id, string firstname, string lastname) : base(id)
    {
        Firstname = firstname;
        Lastname = lastname;
    }

    public string Firstname { get; protected set; }

    public string Lastname { get; protected set; }

    public ICollection<Child> Children { get; protected set; }

    public void AddChild(string firstname, int age)
    {
        if (age < 6 || age > 10)
        {
            throw new AgeOutOfRangeException(age);
        }

        if (Children.Any(e => e.Firstname == firstname))
        {
            throw new FirstnameNotAvailableException(firstname);
        }

        Children.Add(new Child(Guid.NewGuid(), firstname, Lastname, age));
    }
}

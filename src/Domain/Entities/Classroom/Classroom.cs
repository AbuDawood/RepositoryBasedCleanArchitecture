using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Classroom;

public class Classroom : BaseEntity<Guid>
{
    public int MaxNumber { get; set; }


}

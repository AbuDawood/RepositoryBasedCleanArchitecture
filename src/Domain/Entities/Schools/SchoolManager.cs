using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Schools.Exceptions;

namespace CleanArchitecture.Domain.Entities.Schools;


public class SchoolManager : ISchoolManager
{
    private readonly ISchoolRepository _schoolRepository;

    public SchoolManager(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }


    public async Task<School> CreateSchoolAsync(string name, string code, Address address)
    {
        var exist = _schoolRepository.FindAsync(e => e.Code == code);

        if (exist != null)
        {
            throw new SchoolCodeNotAvailableException(code);
        }

        return new School(Guid.NewGuid(), name, code, address);
    }

}

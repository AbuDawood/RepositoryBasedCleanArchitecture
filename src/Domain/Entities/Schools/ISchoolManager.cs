namespace CleanArchitecture.Domain.Entities.Schools;

public interface ISchoolManager
{
    Task<School> CreateSchoolAsync(string name, string code, Address address);
}
using FluentNHibernate.Mapping;

namespace MvvmDemo.Mappings
{
    public class EmployeeMapping : ClassMap<Models.Employee>
    {
        public EmployeeMapping()
        {
            Id(x => x.Id);
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Table("Employee");
        }
    }
}

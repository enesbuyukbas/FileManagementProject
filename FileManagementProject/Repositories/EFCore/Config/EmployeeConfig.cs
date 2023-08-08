using FileManagementProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileManagementProject.Repositories.EFCore.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    EmployeeId = 1,
                    EmployeeFirstName = "Enes",
                    EmployeeLastName = "Büyükbaş",
                    EmployeeEmail = "enes_bykbss@hotmail.com",
                    EmployeePassword = "1234",
                    DepartmentId = 0,
                    EmployeeManagerId = 0
                },
                new Employee
                {
                    EmployeeId = 2,
                    EmployeeFirstName = "Beyza",
                    EmployeeLastName = "Yüksel",
                    EmployeeEmail = "beyzayuksel0111@gmail.com",
                    EmployeePassword = "12345",
                    DepartmentId = 2
                },
                new Employee
                {
                    EmployeeId = 3,
                    EmployeeFirstName = "erhan",
                    EmployeeLastName = "yılmaz",
                    EmployeeEmail = "erhanyılmaz@gmail.com",
                    EmployeePassword = "123456789",
                    DepartmentId = 3
                },
                new Employee
                {
                    EmployeeId = 4,
                    EmployeeFirstName = "Emre",
                    EmployeeLastName = "Büyükbaş",
                    EmployeeEmail = "enes_bykbss@hotmail.com",
                    EmployeePassword = "123564",
                    DepartmentId = 5
                },
                new Employee
                {
                    EmployeeId = 5,
                    EmployeeFirstName = "hasan",
                    EmployeeLastName = "yılmaz",
                    EmployeeEmail = "hasanyılmaz@hotmail.com",
                    EmployeePassword = "1268345",
                    DepartmentId = 6
                },
                new Employee
                {
                    EmployeeId = 6,
                    EmployeeFirstName = "merve",
                    EmployeeLastName = "Yüksel",
                    EmployeeEmail = "merveyuksel0111@gmail.com",
                    EmployeePassword = "1235456789",
                    DepartmentId = 8
                },
                new Employee
                {
                    EmployeeId = 7,
                    EmployeeFirstName = "halil",
                    EmployeeLastName = "atakan",
                    EmployeeEmail = "halilatakan@hotmail.com",
                    EmployeePassword = "123487",
                    DepartmentId = 9
                }
                );
        }
    }
}

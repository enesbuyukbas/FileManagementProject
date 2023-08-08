using FileManagementProject.Entities.Models;
using FileManagementProject.Services;

namespace FileManagementProject.Entities.Dtos
{
    public record EmployeeDtoForCreate
    {
        public int EmployeeId { get; init; }
        public String EmployeeFirstName { get; init; }
        public String EmployeeLastName { get; init; }
        public String? EmployeeEmail { get; init; }
        public String? EmployeePassword { get; init; }
        public int DepartmentId { get; init; }
        public int? EmployeeManagerId { get; init; }
    }
}
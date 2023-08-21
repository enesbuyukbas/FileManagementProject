using FileManagementProject.Entities.Models;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace FileManagementProject.Repositories.EFCore
{
    public static class EmployeeRepositoryExtensions
    {
        public static IQueryable<Employee> FilterEmployee(this IQueryable<Employee> employees,
            int? requestDepartmentId) =>
            employees.Where(employee => employee.DepartmentId == requestDepartmentId);


        //public static IQueryable<Employee> Sort(this IQueryable<Employee> employees,
        //    string orderByQueryString)
        //{
        //    if (string.IsNullOrWhiteSpace(orderByQueryString))
        //        return employees.OrderBy(e => e.EmployeeId);

        //    var orderParams = orderByQueryString.Trim().Split(','); //query string ifadesini aldık

        //    var propertyInfos = typeof(Employee)
        //        .GetProperties(BindingFlags.Public | BindingFlags.Instance); //nesnler üzerinde propotylerin bilgilerini aldık

        //    var orderQueryBuilder = new StringBuilder();

        //    foreach (var param in orderParams)
        //    {
        //        if (string.IsNullOrWhiteSpace(param))
        //            continue;

        //        var propertyFromQueryName = param.Split(' ')[0];

        //        var objectProperty = propertyInfos
        //            .FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName,
        //            StringComparison.InvariantCultureIgnoreCase));

        //        if (objectProperty is null)
        //            continue;

        //        var direction = param.EndsWith("desc") ? "descending" : "ascending";

        //        orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
        //    }

        //    var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

        //    if (orderQuery is null)
        //        return employees.OrderBy(e => e.EmployeeId);

        //    return employees.OrderBy(orderQuery);
        //}
    }
}

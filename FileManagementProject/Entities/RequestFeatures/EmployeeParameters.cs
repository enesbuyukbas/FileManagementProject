namespace FileManagementProject.Entities.RequestFeatures
{
    public class EmployeeParameters : RequestParameters
	{
        public int requestDepartmentId { get; set; }
        public bool ValidDepartmentId => requestDepartmentId != null;

        //public EmployeeParameters()
        //{
        //    OrderBy = "id";
        //}
    }
}

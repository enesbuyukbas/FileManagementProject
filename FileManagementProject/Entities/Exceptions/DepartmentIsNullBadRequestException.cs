namespace FileManagementProject.Entities.Exceptions
{
  
        public class DepartmentIsNullBadRequestException : BadRequestException
        {
            public DepartmentIsNullBadRequestException() : base("Department should be exist ")
            {
                
            }
        }
    
}

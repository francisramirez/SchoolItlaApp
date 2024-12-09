

namespace SchoolItlaApp.Data.Exceptions
{
    public class DepartmentDaoException : Exception
    {
        public DepartmentDaoException(string message) :base(message) 
        {
            // Persistir el error o enviar notificacion.
        }
    }
}

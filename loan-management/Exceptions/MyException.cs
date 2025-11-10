namespace LoanManagement.Exceptions
{
    public class MyException: ApplicationException
    {
        public MyException()
        {

        }
        public MyException(string msg) : base(msg)
        {

        }
    }
}

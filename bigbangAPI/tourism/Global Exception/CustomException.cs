namespace tourismBigBang.Global_Exception
{
    public class CustomException
    {
        public static Dictionary<string, string> ExceptionMessages { get; } = new Dictionary<string, string>
        {
            {"Empty","This Entry can not be null" },
            {"NoId","There is no data for the entered Id" }
        };
    }
}

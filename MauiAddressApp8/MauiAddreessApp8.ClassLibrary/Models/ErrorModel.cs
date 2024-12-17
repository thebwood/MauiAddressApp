namespace MauiAddreessApp8.ClassLibrary.Models
{
    public class ErrorModel
    {
        private string _code;
        private string _name;
        public ErrorModel(string code, string name)

        {
            _code = code;
            _name = name;
        }
        public static ErrorModel None = new(string.Empty, string.Empty);

        public static ErrorModel NullValue = new("Error.NullValue", "Null value was provided");

    }
}

using System.Net;

namespace MauiAddreessApp8.ClassLibrary.Models
{
    public class Result
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Error> Errors { get; set; }
        public Result()
        {
            Errors = new List<Error>();
        }
    }

    public class Result<TValue> : Result
    {
        public TValue? Value { get; set; }

        public Result()
        {
            Errors = new List<Error>();
        }
    }
}

using System.Net;

namespace SchoolProject.Core.Bases;

public class ExtraResponseOutput<T>
{
    public ExtraResponseOutput()
    { }
    public ExtraResponseOutput(T data, string message = null)
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }
    public ExtraResponseOutput(string message)
    {
        Succeeded = false;
        Message = message;
    }
    public ExtraResponseOutput(string message, bool succeeded)
    {
        Succeeded = succeeded;
        Message = message;
    }

    public HttpStatusCode StatusCode { get; set; }
    public object Meta { get; set; }

    public bool Succeeded { get; set; }
    public string Message { get; set; }
    //public Dictionary<string, List<string>> ErrorsBag { get; set; }
    public T Data { get; set; }
}
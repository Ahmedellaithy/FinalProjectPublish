namespace SchoolProject.Core.Bases;

public class ExtraResponseHandler
{
       
    public ExtraResponseHandler()
    { }
    
    public ExtraResponseOutput<T> Deleted<T>()
    {
        return new ExtraResponseOutput<T>() {
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            //Message = "Deleted Successfully"
        };
    }
    public ExtraResponseOutput<T> Success<T>(T entity, object Meta = null)
    {
        return new ExtraResponseOutput<T>() {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            //Message = message == null ? "Success" : message,
            Meta = Meta
        };
    }
    public ExtraResponseOutput<T> Unauthorized<T>()
    {
        return new ExtraResponseOutput<T>() {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            Succeeded = true,
            //Message = "UnAuthorized"
        };
    }
    public ExtraResponseOutput<T> BadRequest<T>(string Message = null)
    {
        return new ExtraResponseOutput<T>() {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Succeeded = false,
            //Message = Message == null ? "Bad Request" : Message
        };
    }
    
    public ExtraResponseOutput<T>UnprocessableEntity<T>(string Message = null)
    {
        return new ExtraResponseOutput<T>() {
            StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
            Succeeded = false,
           // Message = Message == null ? "Unprocessable Entity" : Message
        };
    }
    
    public ExtraResponseOutput<T>Conflict<T>(string Message = null)
    {
        return new ExtraResponseOutput<T>() {
            StatusCode = System.Net.HttpStatusCode.Conflict,
            Succeeded = false,
            // Message = Message == null ? "Unprocessable Entity" : Message
        };
    }

    
    public ExtraResponseOutput<T> NotFound<T>(string message = null)
    {
        return new ExtraResponseOutput<T>() {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            Succeeded = false,
            Message = message == null ? "Not Found" : message
        };
    }
        
    public ExtraResponseOutput<T> Created<T>(T entity, object Meta = null)
    {
        return new ExtraResponseOutput<T>() {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.Created,
            Succeeded = true,
           // Message = "Created",
            Meta = Meta
        };
    }
}
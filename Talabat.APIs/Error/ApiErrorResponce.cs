
namespace Talabat.APIs.Error
{
    public class ApiErrorResponce
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public ApiErrorResponce(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request – The server could not understand the request.",
                401 => "Unauthorized – Authentication is required.",
                403 => "Forbidden – You do not have permission to access this resource.",
                404 => "Not Found – The requested resource was not found.",
                405 => "Method Not Allowed – This HTTP method is not supported for this endpoint.",
                408 => "Request Timeout – The server timed out waiting for the request.",
                409 => "Conflict – There was a conflict with the current state of the resource.",
                415 => "Unsupported Media Type – The request format is not supported.",
                422 => "Unprocessable Entity – The request was well-formed but contains semantic errors.",
                429 => "Too Many Requests – You have sent too many requests in a given amount of time.",
                500 => "Internal Server Error – An unexpected error occurred on the server.",
                502 => "Bad Gateway – Invalid response from the upstream server.",
                503 => "Service Unavailable – The server is currently unable to handle the request.",
                504 => "Gateway Timeout – The server did not receive a timely response from the upstream server.",
                _ => null,
            };
        }

    }
}

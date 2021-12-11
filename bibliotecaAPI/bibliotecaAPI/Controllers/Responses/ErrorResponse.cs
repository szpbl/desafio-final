namespace bibliotecaAPI.Controllers.Responses
{
    public class ErrorResponse
    {
        #region Properties

        public string Status { get; private set; }
        public int StatusCode { get; private set; }
        public string Message { get; private set; }

        #endregion

        #region Constructor

        public ErrorResponse(int statusCode, string message)
        {
            Status = "Error";
            StatusCode = statusCode;
            Message = message;
        }

        #endregion
    }
}

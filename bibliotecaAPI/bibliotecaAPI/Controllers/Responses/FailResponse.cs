namespace bibliotecaAPI.Controllers.Responses
{
    public class FailResponse
    {

        #region Properties

        public string Status { get; private set; }
        public int StatusCode { get; private set; }
        public object Result { get; private set; }

        #endregion

        #region Constructor

        public FailResponse(int statusCode, object result)
        {
            Status = "Fail";
            StatusCode = statusCode;
            Result = result;
        }

        #endregion
    }
}

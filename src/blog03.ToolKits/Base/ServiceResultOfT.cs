namespace blog03.ToolKits.Base
{
    public class ServiceResult<T> : ServiceResult where T : class
    {
        public T Result { get; set; }

        public void IsSuccess(T result = null, string message = "")
        {
            Message = message;
            Code = Enum.ServiceResultCode.Succeed;
            Result = result;
        }
    }
}

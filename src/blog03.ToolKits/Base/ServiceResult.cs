using blog03.ToolKits.Base.Enum;

namespace blog03.ToolKits.Base
{
    public class ServiceResult
    {
        public ServiceResultCode Code { get; set; }
        public string Message { get; set; }
        public bool Success => Code == ServiceResultCode.Succeed;
        public long Timestamp { get; } = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;

        public void IsSuccess(string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Succeed;
        }

        public void IsFailed(string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Failed;
        }

        public void IsFailed(Exception ex)
        {
            Message = ex.InnerException?.StackTrace;
            Code = ServiceResultCode.Failed;
        }
    }
}

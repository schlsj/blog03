namespace blog03
{
    public class blog03Consts
    {
        public const string DbTablePrefix = "blog03_";
    }

    public static class Grouping
    {
        public const string GroupName_v1 = "v1";
        public const string GroupName_v2 = "v2";
        public const string GroupName_v3 = "v3";
        public const string GroupName_v4 = "v4";
    }

    public static class CacheStrategy
    {
        public const int ONE_DAY = 1440;
        public const int HALF_DAY = 720;
        public const int EIGHT_HOURS = 480;
        public const int FIVE_HOURS = 300;
        public const int THREE_HOURS = 180;
        public const int TWO_HOURS = 120;
        public const int ONE_HOURS = 60;
        public const int HALF_HOURS = 30;
        public const int FIVE_MINUTES = 5;
        public const int ONE_MINUTE = 1;
        public const int NEVER = -1;
    }

    public static class ResponseText
    {
        /// <summary>
        /// 新增成功
        /// </summary>
        public const string INSERT_SUCCESS = "新增成功";

        /// <summary>
        /// 更新成功
        /// </summary>
        public const string UPDATE_SUCCESS = "更新成功";

        /// <summary>
        /// 删除成功
        /// </summary>
        public const string DELETE_SUCCESS = "删除成功";

        /// <summary>
        /// 什么不存在
        /// </summary>
        public const string WHAT_NOT_EXIST = "{0}:{1} 不存在";

        /// <summary>
        /// 数据为空
        /// </summary>
        public const string DATA_IS_NONE = "数据为空";

        /// <summary>
        /// IP地址格式错误
        /// </summary>
        public const string IP_IS_WRONG = "IP地址格式错误";

        /// <summary>
        /// 图片错误
        /// </summary>
        public const string IMG_IS_WRONG = "图片错误";

        /// <summary>
        /// 密码错误
        /// </summary>
        public const string PASSWORD_WRONG = "密码错误";

        /// <summary>
        /// 参数错误
        /// </summary>
        public const string PARAMETER_ERROR = "参数错误";
    }
}

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
}

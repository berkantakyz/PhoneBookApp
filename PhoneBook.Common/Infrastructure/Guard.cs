namespace PhoneBook.Common.Infrastructure
{
    public static class Guard
    {
        public static void IsNull(object arg, Exception exception)
        {
            if (arg == null)
            {
                throw exception;
            }
        }

        public static void IsFalse(bool arg, Exception exception)
        {
            if (!arg)
            {
                throw exception;
            }
        }

        public static void IsNullOrEmpty<T>(List<T> arg, Exception exception)
        {
            if (arg == null || arg.Count == 0)
            {
                throw exception;
            }
        }

        public static void IsNullOrEmptyStr(string arg, Exception exception)
        {
            if (string.IsNullOrEmpty(arg))
            {
                throw exception;
            }
        }

        public static void IsLessThan(int arg, int value, Exception exception)
        {
            if (arg < value)
            {
                throw exception;
            }
        }

        public static void IsGreaterThan(int arg, int value, Exception exception)
        {
            if (arg > value)
            {
                throw exception;
            }
        }
    }
}
using System;

namespace Comun
{
    public static class Utilidades
    {
        public static object NullCheck(this string self)
        {
            return (string.IsNullOrEmpty(self)) ? (object)DBNull.Value : self;
        }

        public static object NullCheck(this double self)
        {
            return self == 0 ? (object)DBNull.Value : self;
        }

        public static object NullCheck(this int self)
        {
            return self == 0 ? (object)DBNull.Value : self;
        }
        public static object NullCheck(this DateTime self)
        {
            return self==DateTime.MinValue ? (object)DBNull.Value : self;
        }
        public static object NullCheck(this Decimal self)
        {
            return self == 0 ? (object)DBNull.Value : self;
        }
    }
}

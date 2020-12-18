using System;
using System.Globalization;

namespace api.Helpers
{
    public class AppException : Exception
    {
        public int Status { get; set; } = 500;
        public object Value { get; set; }

        public AppException() : base() { }
        public AppException(string message) : base(message) { }
        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }

    }
}
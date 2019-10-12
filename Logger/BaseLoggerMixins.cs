using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        static void CheckArgument(Object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
        }

        public static void Error(this BaseLogger This, string message)
        {
            CheckArgument(This);

            This.Log(LogLevel.Error, message);
        }

        public static void Debug(this BaseLogger This, string message)
        {
            CheckArgument(This);

            This.Log(LogLevel.Debug, message);
        }
        public static void Information(this BaseLogger This, string message)
        {
            CheckArgument(This);

            This.Log(LogLevel.Information, message);
        }
        public static void Warning(this BaseLogger This, string message)
        {
            CheckArgument(This);

            This.Log(LogLevel.Warning, message);
        }
    }
}

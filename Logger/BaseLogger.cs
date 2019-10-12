using System;

namespace Logger
{
    public abstract class BaseLogger
    {
        public string ClassName { get; set; }
        public abstract void Log(LogLevel logLevel, string message);

        protected string FormatMsg(LogLevel logLevel, string message)
        {
            /*
 The current date/time
The name of the class that created the logger
The log level
The message
The format may vary, but an example might look like this "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message" 
*/
            return $"{DateTime.Now} {ClassName} {logLevel} {message}\n";
        }

    }
}

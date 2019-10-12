using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string FileName { get; private set; }
        public FileLogger(String fileName)
        {
            this.FileName = fileName;
        }
        public override void Log(LogLevel logLevel, string message)
        {


            File.AppendAllText(FileName, FormatMsg(logLevel, message));
            
        }
    }
}

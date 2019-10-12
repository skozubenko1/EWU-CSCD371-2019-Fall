namespace Logger
{
    public class LogFactory
    {
        private string FileName;

        public BaseLogger CreateLogger(string className)
        {
            if (FileName == null)
                return null;

            return new FileLogger(FileName) { ClassName = className };
        }

        public void ConfigureFileLogger(string FileName)
        {
            this.FileName = FileName;
        }
    }
}

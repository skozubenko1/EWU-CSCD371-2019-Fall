using System;

namespace SampleApp
{
    class Program
    {
        static string[] HardCodedNames = new string[] { "one", "two", "three", "four"};
        public static void Main()
        {
            CreateEnviroment();
            Print();
        }

        public static FileConfig CreateEnviroment()
        {
            FileConfig Fconfig = new FileConfig();

            for(int i = 0; i < HardCodedNames.Length; i++)
            {
                Fconfig.SetConfigValue(HardCodedNames[i], i.ToString());

            }

            Fconfig.Save();

            return Fconfig;
        }

        public static void Print()
        {
            for (int i = 0; i < HardCodedNames.Length; i++)
            {
                Console.WriteLine($"{HardCodedNames[i]} = {Environment.GetEnvironmentVariable(HardCodedNames[i])}");                     
            }
        }
    }
}

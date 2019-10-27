using System;
using System.IO;
using System.Text;

public class FileConfig : EnvironmentConfig
{
    const string FileName = "config.settings";


    public FileConfig(bool trancate = false) 
	{
        //if trancating we ignore FileConfig Content
        if (trancate)
            return;

        //config.settings 
        if (File.Exists(FileName))
        {
            var lines = File.ReadAllLines(FileName);

            foreach(var line in lines)
            {
                var parts = line.Split("=", 2);

                if (parts.Length != 2)
                    continue;

                Config.Add(new Setting { name = parts[0], value = parts[1] });
                Environment.SetEnvironmentVariable(parts[0], parts[1], EnvironmentVariableTarget.Process);
            }
        }
    }

    public override void Save()
    {
        var sb = new StringBuilder();

        foreach(var setting in Config)
        {
            sb.AppendLine($"{setting.name}={setting.value}");
        }

        File.WriteAllText(FileName, sb.ToString());
    }

}

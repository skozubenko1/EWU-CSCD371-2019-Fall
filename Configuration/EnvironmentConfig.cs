using Configuration;
using System;
using System.Collections.Generic;

public class EnvironmentConfig : IConfig
{
    protected List<Setting> Config { get; } = new List<Setting>();
	public EnvironmentConfig()
	{
	}
    public bool GetConfigValue(string name, out string? value)
    {
        value = null;
        //Environment.SetEnvironment();
        var setting = GetSetting(name);

        if (setting is null)
            return false;

        if(value != null)
            setting.value = value;

        return true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool SetConfigValue(string name, string? value)
    {
        //do not alow null "", a space, or "=" in the name

        if (name is null || name is "")
            throw new ArgumentException("Name cannot be null or empty");

        if (name.Contains("=") || name.Contains(" "))
            throw new ArgumentException("Name cannot contain spaces or '='");

        //returns key value pair if given name alrady exists in the config or null 
        var setting = GetSetting(name);

        if(value is null)
        {
            if(setting != null)
            {
                Config.Remove(setting);
                //flushes config to file. the virtual save will call on the child save and flush it to the file
                this.Save();
            }
            Environment.SetEnvironmentVariable(name, null, EnvironmentVariableTarget.Process);
            return true;
        }

        //we already know value is not null
        //var val = value is null ? "" : value;

        if (setting is null)
        {
            Config.Add(new Setting { name = name, value = value});
        }
        else
        {
            setting.value = value;
        }

        Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.Process);

        return true;
    }
    /// <summary>
    /// this method checks if config contains an item with the given name
    /// if it finds it, it returns it. if it doesnt find it, it returns null
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private Setting? GetSetting(string name)
    {
        foreach (var item in Config)
        {
            if (item.name == name)
            {
                return item;
            }
        }
        return null;
    }

    public virtual void Save()
    {
        //nothing to save in this implementation. Derived classes can override this method
    }
}


public class Setting
{
    public string? name { get; set; }
    public string? value { get; set; }

}
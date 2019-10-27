using Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestSampleApp()
        {
            FileConfig config = new FileConfig();
            //Do not allow null, empty string, or names with spaces or '='. 
            //Feel free to document other assumptions using unit tests.
            config.SetConfigValue("sveta", "girl");
            
            //checks that it throws an Exception for space and the name 
            Assert.ThrowsException<ArgumentException>(()=> {

                config.SetConfigValue("sv eta", "girl");
            });

            Assert.ThrowsException<ArgumentException>(() => {

                config.SetConfigValue("sve=ta", "girl");
            });

            Assert.ThrowsException<ArgumentException>(() => {

                config.SetConfigValue("", "girl");
            });

            Assert.ThrowsException<ArgumentException>(() => {

                config.SetConfigValue(null, "girl");
            });
        }


    }
}

public class MockConfig : EnvironmentConfig
{

}

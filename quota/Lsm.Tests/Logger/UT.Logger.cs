using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoE.Lsm.Logger.Context;
using DoE.Lsm.Logger;
using DoE.Lsm.Logger.Api;

namespace Logger.Tests
{
    [TestClass]
    public class FileAppender_Tests
    {
        [TestMethod]
        public void FileAppender_LogFormat_ShouldLogError()
        {
           var moqError =  new Error
                            {
                                LogTime = DateTime.Now,
                                Entity  = "",
                                AttemptedAction = "Log an Info Error",
                                StackTrace = "Exception.UnitTest",
                                Code = 1050
                            };

            var fileAppender = new FileAppenderHub(this);
                fileAppender.Log(moqError.ToString());

            Assert.IsInstanceOfType(moqError, typeof(Error));
        }
    }
}
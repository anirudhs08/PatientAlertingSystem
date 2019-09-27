using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_JsonInputProcessor
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_JsonInputProcessor_InvalidInputString()
        {
            string _inputString = "{ \"hello\" , \"t\" : true , \"f\" : false, \"n\": null, \"i\":123, \"pi\": 3.141}";
            JsonInputProcessor.JsonInputProcessor jsonInputProcessor = new JsonInputProcessor.JsonInputProcessor();
            try
            {
                jsonInputProcessor.ProcessJsonInput(_inputString);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Invalid Input String");
                return;
            }
            Assert.Fail("Exception Not Thrown");
        }
        [TestMethod]
        public void Test_JsonInputProcessor_ValidInputString()
        {
            string _inputString = "{ \"patientID\" : \"WE1234\", \"spo2\" : 96 , \"pulserate\" : 110, \"temperature\": 97}";
            JsonInputProcessor.JsonInputProcessor jsonInputProcessor = new JsonInputProcessor.JsonInputProcessor();
            int retVal = jsonInputProcessor.ProcessJsonInput(_inputString);
            Assert.AreNotEqual(retVal, -1);
        }
    }
}

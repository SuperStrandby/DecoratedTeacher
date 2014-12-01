using System;
using DecoratedTeacher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecoratedTeacherTest
{
    [TestClass]
    public class ThreadsafeTeacherTests
    {
        [TestMethod]
        public void TestAll()
        {
            ITeacher normalTeacher = new Teacher
            {
                Name = "Per",
                Salary = 48000
            };
            ITeacher safeTeacher = new ThreadsafeTeacher(normalTeacher);
            Assert.AreEqual("Per", safeTeacher.Name);
            Assert.AreEqual(48000, safeTeacher.Salary);
            safeTeacher.Name = "John";
            Assert.AreEqual("John", safeTeacher.Name);
            Assert.AreEqual("John", normalTeacher.Name);

            Assert.AreEqual(48000, safeTeacher.Salary);
            safeTeacher.Salary = 36000;
            Assert.AreEqual(36000, safeTeacher.Salary);
            Assert.AreEqual(36000, normalTeacher.Salary);

            try
            {
                new ThreadsafeTeacher(null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {

                /* empty */
            }
        }
    }
}

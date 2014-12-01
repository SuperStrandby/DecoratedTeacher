using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratedTeacher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecoratedTeacherTest
{
    [TestClass]
    public class UnmodifiableTeacherTests
    {
        [TestMethod]
        public void UnmodifiableTeacherTest()
        {
            try
            {
                new UnmodifiableTeacher(null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                
                /*empty */
            }
        }

        [TestMethod]
        public void TeacherTest()
        {
            ITeacher normalTeacher = new Teacher
            {
                Name = "John",
                Salary = 25000
            };

            ITeacher unmodifiableTeacher = new UnmodifiableTeacher(normalTeacher);
            Assert.AreEqual("John", unmodifiableTeacher.Name);
            Assert.AreEqual(25000, unmodifiableTeacher.Salary);
            try
            {
                unmodifiableTeacher.Name = "Peter";
                Assert.Fail();
            }
            catch (NotSupportedException)
            {

                /* empty */
            }

            try
            {
                unmodifiableTeacher.Salary = 26000;
                Assert.Fail();
            }
            catch (NotSupportedException)
            {
                /* empty */
                
            }
        }

        [TestMethod]
        public void EqualsHashcodeTest()
        {
            ITeacher normalTeacher2 = new Teacher
            {
                Name = "John",
                Salary = 25000
            };
            ITeacher unmodifiableTeacher = new UnmodifiableTeacher(normalTeacher2);
            Assert.IsTrue(normalTeacher2.Equals(unmodifiableTeacher));
            Assert.IsTrue(unmodifiableTeacher.Equals(normalTeacher2));
            Assert.AreEqual(normalTeacher2.GetHashCode(), unmodifiableTeacher.GetHashCode());
            Assert.AreEqual(unmodifiableTeacher.GetHashCode(), normalTeacher2.GetHashCode());
        }
    }
}

using DomainLayer.Models;
using FluentAssertions;

namespace UnitTests
{
    public class StudentTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var Student1 = new Student();
            Student1.Should().NotBeNull();
        }

        [Test]
        public void Test2()
        {
            var Student2 = new Student();
            Student2.studentId = 123;
            Student2.studentId.Should().BeOfType(typeof(int));
            Student2.studentId.Should().Be(123);
        }

        [Test]
        public void Test3()
        {
            var Student3 = new Student();
            Student3.firstName = "John";
            Student3.firstName.Should().BeOfType<string>();
            Student3.firstName.Should().Be("John");
        }

        [Test]
        public void Test4()
        {
            var Student4 = new Student();
            Student4.lastName = "Smith";
            Student4.lastName.Should().BeOfType<string>();
            Student4.lastName.Should().Be("Smith");
        }

        [Test]
        public void Test5()
        {
            var Student5 = new Student();
            Student5.emailAddress = "johnsmith123@gmail.com";
            Student5.emailAddress.Should().BeOfType<string>();
            Student5.emailAddress.Should().Be("johnsmith123@gmail.com");
        }

        [Test]
        public void Test6()
        {
            var Student6 = new Student();
            var Student7 = new Student();
            Student6.Should().NotBe(Student7);
        }
    }
}
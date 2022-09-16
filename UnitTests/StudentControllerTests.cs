using School.Controllers;
using DomainLayer.Models;
using ServiceLayer.ICustomServices;
using FluentAssertions;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class StudentControllerTests
    {
        private ICustomServices<Student> service;
        private Student student1;
        private Student student2;

        [SetUp]
        public void Setup()
        {
            service = Substitute.For<ICustomServices<Student>>();
            student1 = new Student();
            student1.firstName = "John";
            student1.lastName = "Smith";
            student2 = new Student();
            student2.firstName = "Mary";
            student2.lastName = "Simpson";
            service.Get(1).Returns(student1);
            service.Get(2).Returns(student2);
            service.GetAll().Returns(new Student[] { student1, student2 });
        }

        [Test]
        public void TestGoodGetStudentById()
        {
            var controller = new StudentController(service);
            var getResult = controller.GetStudentByID(1);

            var okObjectResult = getResult as OkObjectResult;
            okObjectResult.Should().NotBeNull();

            var studentResult = okObjectResult.Value as Student;
            studentResult.Should().NotBeNull();

            studentResult.Should().Be(student1);
        }

        [Test]
        public void TestBadGetStudentById()
        {
            var controller = new StudentController(service);
            var getResult = controller.GetStudentByID(99);

            getResult.Should().BeOfType<NotFoundResult>();
        }

        [Test]
        public void TestGetAllStudents()
        {
            var controller = new StudentController(service);
            var getResult = controller.GetAllStudents();

            var okObjectResult = getResult as OkObjectResult;
            okObjectResult.Should().NotBeNull();

            var studentsResult = okObjectResult.Value as Student[];
            studentsResult.Should().NotBeNull();

            studentsResult.Should().BeEquivalentTo(new Student[] { student1, student2 });
        }

        [Test]
        public void TestGoodCreateStudent()
        {
            var controller = new StudentController(service);
            var createResult = controller.CreateStudent(student1);

            var okObjectResult = createResult as OkObjectResult;
            okObjectResult.Should().NotBeNull();

            var stringResult = okObjectResult.Value as String;
            stringResult.Should().NotBeNull();

            stringResult.Should().Be("Created Successfully");
        }

        [Test]
        public void TestBadCreateStudent()
        {
            var controller = new StudentController(service);
            var createResult = controller.CreateStudent(null);

            var badRequestObjectResult = createResult as BadRequestObjectResult;
            badRequestObjectResult.Should().NotBeNull();

            var stringResult = badRequestObjectResult.Value as String;
            stringResult.Should().NotBeNull();

            stringResult.Should().Be("Failed to Create");
        }

        [Test]
        public void TestGoodUpdateStudent()
        {
            var controller = new StudentController(service);
            var updateResult = controller.UpdateStudent(student1);

            var okObjectResult = updateResult as OkObjectResult;
            okObjectResult.Should().NotBeNull();

            var stringResult = okObjectResult.Value as String;
            stringResult.Should().NotBeNull();

            stringResult.Should().Be("Updated Successfully");
        }

        [Test]
        public void TestBadUpdateStudent()
        {
            var controller = new StudentController(service);
            var updateResult = controller.UpdateStudent(null);

            var badRequestObjectResult = updateResult as BadRequestObjectResult;
            badRequestObjectResult.Should().NotBeNull();

            var stringResult = badRequestObjectResult.Value as String;
            stringResult.Should().NotBeNull();

            stringResult.Should().Be("Failed to Update");
        }

        [Test]
        public void TestGoodDeleteStudent()
        {
            var controller = new StudentController(service);
            var deleteResult = controller.DeleteStudent(student1);

            var okObjectResult = deleteResult as OkObjectResult;
            okObjectResult.Should().NotBeNull();

            var stringResult = okObjectResult.Value as String;
            stringResult.Should().NotBeNull();

            stringResult.Should().Be("Deleted Successfully");
        }

        [Test]
        public void TestBadDeleteStudent()
        {
            var controller = new StudentController(service);
            var deleteResult = controller.DeleteStudent(null);

            var badRequestObjectResult = deleteResult as BadRequestObjectResult;
            badRequestObjectResult.Should().NotBeNull();

            var stringResult = badRequestObjectResult.Value as String;
            stringResult.Should().NotBeNull();

            stringResult.Should().Be("Failed to Delete");
        }
    }
}

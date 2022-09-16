using RepositoryLayer.IRepository;
using DomainLayer.Models;
using ServiceLayer.CustomServices;
using FluentAssertions;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTests
{

    public class StudentServiceTests
    {
        private IRepository<Student> repository;
        private Student student1;
        private Student student2;

        [SetUp]
        public void Setup()
        {
            repository = Substitute.For<IRepository<Student>>();
            student1 = new Student();
            student1.firstName = "John";
            student1.lastName = "Smith";
            student2 = new Student();
            student2.firstName = "Mary";
            student2.lastName = "Simpson";
            repository.Get(1).Returns(student1);
            repository.GetAll().Returns(new Student[] { student1, student2 });
        }

        [Test]
        public void TestGoodGet()
        {
            var service = new StudentService(repository);
            var studentResult = service.Get(1);
            studentResult.Should().NotBeNull();
            studentResult.Should().Be(student1);
        }

        [Test]
        public void TestBadGet()
        {
            var service = new StudentService(repository);
            var studentResult = service.Get(99);
            studentResult.Should().BeNull();
        }

        [Test]
        public void TestGetAll()
        {
            var service = new StudentService(repository);
            var studentResult = service.GetAll();
            studentResult.Should().NotBeNull();
            studentResult.Should().BeEquivalentTo(new Student[] { student1, student2 });
        }
    }
}

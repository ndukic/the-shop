using AutoFixture;
using AutoFixture.AutoMoq;
using NUnit.Framework;
using System;
using TheShop.Dal.InMemory;
using TheShop.Domain.Model;

namespace TheShop.Dal.Tests
{
    public class InMemoryEntityRepositoryTests
    {
        private IFixture _fixture;
        private InMemoryEntityRepository<DummyClass> _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            _sut = _fixture.Create<InMemoryEntityRepository<DummyClass>>();
        }

        [Test]
        public void Saved_Object_Can_Be_Fetched_By_Id()
        {
            var dummy = CreateRandomDummy();

            _sut.Save(dummy);
            var actual = _sut.GetById(dummy.Id);

            AssertPropertiesAreEqual(dummy, actual);
        }

        [Test]
        public void Get_Object_That_Not_Exist_Should_Return_Null()
        {
            var actual = _sut.GetById(767676);
            Assert.IsNull(actual);
        }

        private DummyClass CreateRandomDummy()
        {
            var rand = new Random();
            var id = rand.Next(1, 1000);
            var price = (rand.NextDouble() + 1) * 100;
            return new DummyClass()
            {
                Id = id,
                Ref = Guid.NewGuid(),
                Name = $"Awesome dummy {id}",
                Price = price
            };
        }

        private void AssertPropertiesAreEqual(DummyClass expected, DummyClass actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Ref, actual.Ref);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Price, actual.Price);
        }
    }

    public class DummyClass : Entity
    {
        public Guid Ref { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class NotAnEntity
    {

    }
}

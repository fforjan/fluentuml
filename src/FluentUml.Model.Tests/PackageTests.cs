using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using System.Collections.Generic;

namespace FluentUml.Model.Tests;

[TestClass]
public class PackageTests
{
    [TestMethod]
    public void ConstructorTest()
    {
        // act
        var package = new Package(nameof(ConstructorTest));

        // assert
        package.Name.Should().Be(nameof(ConstructorTest));
        package.Components.Should().BeEmpty();
        package.Interfaces.Should().BeNull();
    }

    [TestMethod]
    public void AddPackageTest() 
    {
        // arrange
        var component = new Mock<IAggregateComponent>();

        var list = new List<IComponent>();
        component.Setup(_ => _.Components).Returns(list);

        // act
        component.Object.AddPackage(nameof(AddPackageTest));

        // assert
        list.Should().HaveCount(1);
        list[0].Should().BeOfType<Package>()
                    .Which.Name.Should().Be(nameof(AddPackageTest));
                    
    }
}
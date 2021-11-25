
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentUml.SelfDescribe;
using System.IO;
using ApprovalTests;
using ApprovalTests.Reporters;

[assembly: UseReporter(typeof(DiffReporter))]

namespace FluentUml.PlantUmlGenerator.Tests;
[TestClass]
public class GeneratorTests
{
    [TestMethod]
    public void ComponentDiagramTest()
    {
        // Arrange
        var generator = new Generator();
        var diagram = new ComponentDiagram();
        diagram.Describe();

        using var textStream = new StringWriter();
        
        // Act
        generator.GeneratePlantUmlDocument(diagram, textStream);

        // Assert
        Approvals.Verify(textStream.GetStringBuilder().ToString());
    }

    [TestMethod]
    public void MEFDiagramTest()
    {
        // Arrange
        var generator = new Generator();
        var diagram = new MEFDiagram();
        diagram.Describe();
        
        using var textStream = new StringWriter();
        
        // Act
        generator.GeneratePlantUmlDocument(diagram, textStream);

        // Assert
        Approvals.Verify(textStream.GetStringBuilder().ToString());
    }
}
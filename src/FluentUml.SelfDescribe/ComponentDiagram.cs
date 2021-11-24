namespace FluentUml.SelfDescribe;

using System.ComponentModel.Composition;
using FluentUml.Model;

[Export(typeof(DiagramBase))]
public class ComponentDiagram : DiagramBase
{
    public ComponentDiagram() : base("ComponentDiagram"){}

    override public void Describe() 
    {
        this.AddPackage("Core")
            .WhichContains(typeof(FluentUml.Generator.GeneratorApp).Assembly)
            .WhichContains(typeof(FluentUml.Model.DiagramBase).Assembly);
        this.AddPackage("Plugins")
            .WhichContains(typeof(FluentUml.ExcelGenerator.Generator).Assembly)
            .WhichContains(typeof(FluentUml.PlantUmlGenerator.Generator).Assembly);        
    }

}

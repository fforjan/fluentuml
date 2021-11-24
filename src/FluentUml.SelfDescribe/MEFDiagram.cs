namespace FluentUml.SelfDescribe;

using System.ComponentModel.Composition;
using System.Reflection;
using FluentUml.Model;

[Export(typeof(DiagramBase))]
public class MEFDiagram : DiagramBase
{
    public MEFDiagram() : base("MEF"){}

    override public void Describe() 
    {
        this.AddExportFrom(this.GetType().Assembly);
        this.AddExportFrom(typeof(FluentUml.Generator.GeneratorApp).Assembly);
        this.AddExportFrom(typeof(FluentUml.Model.DiagramBase).Assembly);
        this.AddExportFrom(typeof(FluentUml.ExcelGenerator.Generator).Assembly);
        this.AddExportFrom(typeof(FluentUml.PlantUmlGenerator.Generator).Assembly);        
    }
}

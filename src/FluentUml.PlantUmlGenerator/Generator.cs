namespace FluentUml.PlantUmlGenerator;

using System.ComponentModel.Composition;
using System.IO;
using FluentUml.Model;

[Export(typeof(IGenerator))]
public class Generator : IGenerator
{
    public void Generate(DiagramBase diagram) {
            using var sw = new StreamWriter($"{diagram.Name}.plantuml");
            GeneratePlantUmlDocument(diagram, sw);
    }

    private void GeneratePlantUmlDocument(DiagramBase db, TextWriter sw) {
        sw.WriteLine("@startuml");
        foreach(var pack in db.Components.OfType<Package>()) {
            GeneratePlantUmlDocument(pack, sw);
        }

        sw.WriteLine("@enduml");
    }

    private void GeneratePlantUmlDocument(Package package, TextWriter sw) {
         sw.WriteLine($"package {package.Name} {{");
        foreach(var component in package.Components) {
            GeneratePlantUmlDocument(component, sw);
        }        
        sw.WriteLine("}");
    }

    private void GeneratePlantUmlDocument(IComponent component, TextWriter sw)
    {
        sw.WriteLine($"[{component.Name}]");
    }
}


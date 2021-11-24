namespace FluentUml.SelfDescribe;

using System.ComponentModel.Composition;
using System.Reflection;
using FluentUml.Model;

public class MEFTypeComponent : IComponent {

    private Type type;
    public MEFTypeComponent(Type type)
    {
        this.type = type;
    }

    public string Name => this.type.Name;

    public static IEnumerable<Type> ExportedTypes(Assembly a) {
        foreach(var type in a.GetTypes()) {
            if(type.GetCustomAttributes<ExportAttribute>(true).Any()) {
                yield return type;
            }
        }
    }
}

public static class Extensions {
     public static void AddExportFrom(this DiagramBase diagram, Assembly assembly) {
        var package = diagram.AddPackage(assembly.GetName().Name ?? "Unknown");
        package.Components.AddRange(
            MEFTypeComponent.ExportedTypes(assembly).Select( _ => new MEFTypeComponent(_))
        );
    }
}

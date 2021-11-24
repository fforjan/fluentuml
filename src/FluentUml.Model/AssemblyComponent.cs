using System.Reflection;

namespace FluentUml.Model;

public class AssemblyComponent : IComponent
{
    private readonly Assembly assembly;

    public AssemblyComponent(Assembly assembly)
    {
        this.assembly = assembly;
    }

    public string Name { get { return this.assembly.GetName().Name ?? "Unknown"; } }

    public IEnumerable<string>? Interfaces => null;
}

public static class AssemblyComponentExtensions
{
    public static Package WhichContains(this Package package, Assembly assembly) {
        package.Components.Add(new AssemblyComponent(assembly));
        return package;
    }
}
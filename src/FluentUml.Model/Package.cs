namespace FluentUml.Model;

public class Package : IAggregateComponent
{

    public Package(string name)
    {
        this.Components = new List<IComponent>();
        this.Name = name;
    }

    public string Name { get; }

    public List<IComponent> Components { get; }
}

public static class PackageExtensions 
{
    public static Package AddPackage(this IAggregateComponent component, string name){
        var package = new Package(name);
        component.Components.Add(package);
        return package;
    }
}

namespace FluentUml.Model;

public abstract class DiagramBase : IAggregateComponent
{
    public DiagramBase(string name)
    {
        this.Name = name;
        this.Components = new List<IComponent>();
    }

    public List<IComponent> Components { get;}

    public IEnumerable<string>? Interfaces => null;

    public string Name {get;}

    public abstract void Describe();
}

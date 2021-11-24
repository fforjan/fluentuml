namespace FluentUml.Model;

public interface IAggregateComponent : IComponent {
    List<IComponent> Components { get; }
}

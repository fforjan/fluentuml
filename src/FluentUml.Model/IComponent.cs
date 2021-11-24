namespace FluentUml.Model;

public interface IComponent
{
    string Name { get; }    

    IEnumerable<string>? Interfaces {get;}

}

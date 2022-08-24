Base a = Base.Create(3 , new ());
Derived d = new(4,new());

Console.WriteLine($"base class state is {a.State} and calculate state is {a.Calculated}");
Console.WriteLine($"derived class state is {d.State} and calculate state is {d.Calculated}");


class Base
{
    public int State { get; }
    public int Calculated { get; }
    
    public object Dependency { get; }

    public static Base Create(int state, object dependency) => new(dependency, state, state * 2);

    protected Base(object dependency, int state, int calculated) =>
        (Dependency, State, Calculated) = (dependency, state, calculated);
}

class Derived : Base
{
    public Derived(int state, object dependency) 
        : base(dependency,state, dependency.GetHashCode() % state * 2) { }

}
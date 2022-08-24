Base a = new Base(3 , new ());
Derived d = new(4,new());

Console.WriteLine($"base class state is {a.State} and calculate state is {a.Calculated}");
Console.WriteLine($"derived class state is {d.State} and calculate state is {d.Calculated}");


class Base
{
    public int State { get; }
    public int Calculated { get; }
    
    public object Dependency { get; }

    public Base(int state, object dependency)
    {
        this.State = state;
        Dependency = dependency;
        this.Calculated = this.Calculate(); // temporary fix. Wont be possible always. 
    }

    protected virtual int Calculate() => 7;
}

class Derived : Base
{
    public Derived(int state, object dependency) : base(state,dependency)
    {
        
    }
    //Below will fail because Dependency is still null as the value used is before initialization
    protected override int Calculate() => this.Dependency.GetHashCode() % base.State * 2;
    

}
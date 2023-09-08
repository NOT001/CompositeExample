public abstract class Animal
{
    protected string Name;
    protected Animal(string name)
    {
        Name = name;
    }
    public virtual void Add(Animal animal)
    {
        throw new NotImplementedException();
    }
    public virtual void PrintTree(int indent)
    {
        throw new NotImplementedException();
    }
}

public class Species : Animal
{
    public Species(string name) : base(name) { }

    public override void PrintTree(int indent)
    {
        Console.WriteLine(new String('-', indent) + " " + Name);
    }
}

public class SpeciesComposite : Animal
{
    private readonly List<Animal> _animals = new List<Animal>();

    public SpeciesComposite(string name) : base(name) { }

    public override void Add(Animal animal)
    {
        _animals.Add(animal);
    }

    public override void PrintTree(int indent)
    {
        Console.WriteLine(new String('-', indent) + "+ " + Name);

        foreach (var animal in _animals)
        {
            animal.PrintTree(indent + 2);
        }
    }
}

public static class CompositeExample
{
    public static void Main()
    {
        var mammal = new SpeciesComposite("Mammal");

        var carnivore = new SpeciesComposite("Carnivore");

        var nonCarnivore = new SpeciesComposite("Non-Carnivore");

        var tiger = new Species("Tiger");

        var leopard = new Species("Leopard");

        var sheep = new Species("Sheep");

        var cow = new Species("Cow");

        carnivore.Add(tiger);

        carnivore.Add(leopard);

        nonCarnivore.Add(sheep);

        nonCarnivore.Add(cow);

        mammal.Add(carnivore);

        mammal.Add(nonCarnivore);

        mammal.PrintTree(1);
    }
}

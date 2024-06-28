
/*
The Factory Design Pattern is a creational pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created. This pattern is useful when the exact type of object to be created isn't known until runtime.

Here's a simple example in C# to illustrate the Factory Design Pattern:

Step-by-Step Implementation
Define the Product Interface: This will be the common interface for all types of products that the factory can create.
Implement Concrete Products: These are the classes that implement the Product interface.
Create the Factory Class: This class will have a method to create and return instances of the products.
Use the Factory: The client code uses the factory to create objects without needing to know the exact class being instantiated.
Example
Let's create an example where we have different types of Animal classes that the factory can create.

1. Define the Product Interface
*/

public interface IAnimal
{
    void Speak();
}

public class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Meow!");
    }
}


public static class AnimalFactory
{
    public static IAnimal CreateAnimal(string animalType)
    {
        switch (animalType.ToLower())
        {
            case "dog":
                return new Dog();
            case "cat":
                return new Cat();
            default:
                throw new ArgumentException("Invalid animal type");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create a Dog using the factory
        IAnimal dog = AnimalFactory.CreateAnimal("dog");
        dog.Speak(); // Output: Woof!

        // Create a Cat using the factory
        IAnimal cat = AnimalFactory.CreateAnimal("cat");
        cat.Speak(); // Output: Meow!

        // Try to create an unknown animal type
        try
        {
            IAnimal unknown = AnimalFactory.CreateAnimal("elephant");
            unknown.Speak();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message); // Output: Invalid animal type
        }
    }
}



/*
Explanation
Product Interface (IAnimal): This interface declares a method Speak that all concrete products must implement.

Concrete Products (Dog and Cat): These classes implement the IAnimal interface and provide their specific implementation of the Speak method.

Factory Class (AnimalFactory): This static class contains a CreateAnimal method that takes a string parameter and returns an instance of the 
appropriate class based on the input.

Client Code (Program): The Main method demonstrates how to use the factory to create instances of Dog and Cat without directly instantiating them.

This example illustrates the Factory Design Pattern in C#, showing how to decouple the client code from the concrete classes it needs to instantiate,
providing flexibility and ease of maintenance.
*/
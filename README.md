# IocDemo
A simple example of an IOC framework built with two requirements:
1. It should operate without explicit registration, using reflection to find all classes that it can create,
and automatically resolving all constructor dependencies
2. It should allow the user to override the automatic resolution of dependencies by passing in existing objects

## Example Usage
The container should be initialized by calling `RegisterAllTypes()` before you call `Get<T>()`.
Here's a very basic example using a singleton.

Create a static class which calls `RegisterAllTypes()` the first time the container is used.
```
public static class IocContainer
{
    private static IocDemo.IocContainer _container;

    public static T Get<T>(params object[] existingArguments)
    {
        if (_container == null)
        {
            _container = new IocDemo.IocContainer();
            _container.RegisterAllTypes(Assembly.GetExecutingAssembly());
        }

        return _container.Get<T>(existingArguments);
    }
}
```
Then use the static class like this:
```
var instance = IocContainer.Get<AnyClass>();
```
What if the class takes a value object (e.g. a string) as a constructor parameter?
The IOC container can't create that, so you can pass it in:
```
var instance = IocContainer.Get<AnyClass>("A string value");
```
What about polymorphism, where a constructor parameter's interface has multiple implementations?
The IOC container wouldn't know which implementation to create, so you can pass it in:
```
var existingObject = new SomeDependency();
var instance = IocContainer.Get<AnyClass>(existingObject);
```

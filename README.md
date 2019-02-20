# IocDemo
Example of a basic IOC framework

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
            _container.RegisterAllTypes();
        }

        return _container.Get<T>(existingArguments);
    }
}
```
Then use the static class like this:
```
var instance = IocContainer.Get<AnyClass>();
```

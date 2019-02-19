namespace IocDemo.Test.TestClasses
{
    public interface IDependency3
    {
        string PrintName3();
    }

    public class Dependency3 : IDependency3
    {
        public string PrintName3()
        {
            return GetType().Name;
        }
    }

    public class OtherDependency3 : IDependency3
    {
        public string PrintName3()
        {
            return GetType().Name;
        }
    }
}

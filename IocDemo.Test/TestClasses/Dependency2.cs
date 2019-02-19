namespace IocDemo.Test.TestClasses
{
    public interface IDependency2
    {
        string CustomMessage2 { get; set; }
        string PrintName2();
    }

    public class Dependency2 : IDependency2
    {
        public string CustomMessage2 { get; set; }

        public string PrintName2()
        {
            return CustomMessage2 ?? GetType().Name;
        }
    }
}

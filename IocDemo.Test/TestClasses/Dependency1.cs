namespace IocDemo.Test.TestClasses
{
    public interface IDependency1
    {
        string CustomMessage1 { get; set; }
        string PrintName1();
    }

    public class Dependency1 : IDependency1
    {
        public string CustomMessage1 { get; set; }

        public string PrintName1()
        {
            return CustomMessage1 ?? GetType().Name;
        }
    }
}

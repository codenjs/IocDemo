namespace IocDemo.Test.TestClasses
{
    public interface IClassWithNestedDependenciesLevel1
    {
        string RunTest();
    }

    public class ClassWithNestedDependenciesLevel1 : IClassWithNestedDependenciesLevel1
    {
        private IClassWithTwoDependencies _dependency;

        public ClassWithNestedDependenciesLevel1(IClassWithTwoDependencies dependency)
        {
            _dependency = dependency;
        }

        public string RunTest()
        {
            return $"I use a nested dependency. It says: {_dependency.RunTest()}";
        }
    }
}

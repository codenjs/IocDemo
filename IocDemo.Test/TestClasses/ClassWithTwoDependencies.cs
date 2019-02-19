namespace IocDemo.Test.TestClasses
{
    public interface IClassWithTwoDependencies
    {
        string RunTest();
    }

    public class ClassWithTwoDependencies : IClassWithTwoDependencies
    {
        private IDependency1 _dependency1;
        private IDependency2 _dependency2;

        public ClassWithTwoDependencies(IDependency1 dependency1, IDependency2 dependency2)
        {
            _dependency1 = dependency1;
            _dependency2 = dependency2;
        }

        public string RunTest()
        {
            return $"I use 2 dependencies: {_dependency1.PrintName1()}, {_dependency2.PrintName2()}";
        }
    }
}

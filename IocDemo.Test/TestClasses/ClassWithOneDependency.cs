namespace IocDemo.Test.TestClasses
{
    public class ClassWithOneDependency
    {
        private IDependency1 _dependency1;

        public ClassWithOneDependency(IDependency1 dependency1)
        {
            _dependency1 = dependency1;
        }

        public string RunTest()
        {
            return $"I use 1 dependency: {_dependency1.PrintName1()}";
        }
    }
}

namespace IocDemo.Test.TestClasses
{
    public class ClassWithMultipleMatchingDependencies
    {
        private IDependency3 _dependency;

        public ClassWithMultipleMatchingDependencies(IDependency3 dependency)
        {
            _dependency = dependency;
        }

        public string RunTest()
        {
            return $"I currently use this dependency: {_dependency.PrintName3()}";
        }
    }
}

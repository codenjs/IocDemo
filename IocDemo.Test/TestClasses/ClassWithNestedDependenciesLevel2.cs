namespace IocDemo.Test.TestClasses
{
    public class ClassWithNestedDependenciesLevel2
    {
        private IClassWithNestedDependenciesLevel1 _dependency;

        public ClassWithNestedDependenciesLevel2(IClassWithNestedDependenciesLevel1 dependency)
        {
            _dependency = dependency;
        }

        public string RunTest()
        {
            return $"I use a nested dependency. It says: {_dependency.RunTest()}";
        }
    }
}

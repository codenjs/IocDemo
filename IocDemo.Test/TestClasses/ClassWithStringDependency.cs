namespace IocDemo.Test.TestClasses
{
    public class ClassWithStringDependency
    {
        private string _dependency;

        public ClassWithStringDependency(string dependency)
        {
            _dependency = dependency;
        }

        public string RunTest()
        {
            return $"I have a message: {_dependency}";
        }
    }
}

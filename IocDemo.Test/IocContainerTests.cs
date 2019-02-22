using System.Reflection;
using IocDemo.Test.TestClasses;
using NUnit.Framework;

namespace IocDemo.Test
{
    [TestFixture]
    public class IocContainerTests
    {
        private T Get<T>(params object[] existingArguments)
        {
            var container = new IocContainer();
            container.RegisterAllTypes(Assembly.GetExecutingAssembly());
            return container.Get<T>(existingArguments);
        }

        [Test]
        public void Get_Class_With_No_Dependencies()
        {
            var testClass = Get<ClassWithNoDependencies>();
            var result = testClass.RunTest();
            Assert.AreEqual("I use no dependencies", result);
        }

        [Test]
        public void Get_Class_With_One_Dependency()
        {
            var testClass = Get<ClassWithOneDependency>();
            var result = testClass.RunTest();
            Assert.AreEqual("I use 1 dependency: Dependency1", result);
        }

        [Test]
        public void Get_Class_With_Multiple_Dependencies()
        {
            var testClass = Get<ClassWithTwoDependencies>();
            var result = testClass.RunTest();
            Assert.AreEqual("I use 2 dependencies: Dependency1, Dependency2", result);
        }

        [Test]
        public void Get_Class_With_One_Level_Of_Nested_Dependencies()
        {
            var testClass = Get<ClassWithNestedDependenciesLevel1>();
            var result = testClass.RunTest();
            Assert.AreEqual("I use a nested dependency. It says: I use 2 dependencies: Dependency1, Dependency2", result);
        }

        [Test]
        public void Get_Class_With_Multiple_Levels_Of_Nested_Dependencies()
        {
            var testClass = Get<ClassWithNestedDependenciesLevel2>();
            var result = testClass.RunTest();
            Assert.AreEqual("I use a nested dependency. It says: I use a nested dependency. It says: I use 2 dependencies: Dependency1, Dependency2", result);
        }

        [Test]
        public void Get_Class_With_String_Dependency()
        {
            var customMessage = "Custom Message";

            var testClass = Get<ClassWithStringDependency>(customMessage);
            var result = testClass.RunTest();
            Assert.AreEqual("I have a message: Custom Message", result);
        }

        [Test]
        public void When_Existing_Object_Is_Provided_Then_Class_Is_Created_Using_Existing_Object_As_Dependency()
        {
            var existingObject = new Dependency1();
            existingObject.CustomMessage1 = "Custom Message";

            var testClass = Get<ClassWithOneDependency>(existingObject);
            var result = testClass.RunTest();
            Assert.AreEqual("I use 1 dependency: Custom Message", result);
        }

        [Test]
        public void When_Multiple_Existing_Objects_Are_Provided_Then_Class_Is_Created_Using_Existing_Objects_As_Dependencies()
        {
            var existingObject1 = new Dependency1();
            existingObject1.CustomMessage1 = "Custom Message1";

            var existingObject2 = new Dependency2();
            existingObject2.CustomMessage2 = "Custom Message2";

            var testClass = Get<ClassWithTwoDependencies>(existingObject1, existingObject2);
            var result = testClass.RunTest();
            Assert.AreEqual("I use 2 dependencies: Custom Message1, Custom Message2", result);
        }

        [Test]
        public void Get_Class_When_Multiple_Possible_Matches_Exist_For_Dependency()
        {
            var testClass = Get<ClassWithMultipleMatchingDependencies>(new Dependency3());
            var result = testClass.RunTest();
            Assert.AreEqual("I currently use this dependency: Dependency3", result);

            testClass = Get<ClassWithMultipleMatchingDependencies>(new OtherDependency3());
            result = testClass.RunTest();
            Assert.AreEqual("I currently use this dependency: OtherDependency3", result);
        }
    }
}

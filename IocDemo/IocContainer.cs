using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IocDemo
{
    public class IocContainer
    {
        private List<Type> _alltypes;
        private Dictionary<Type, object> _existingArgs;

        public void RegisterAllTypes()
        {
            _alltypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => !t.IsInterface)
                .ToList();
        }

        public T Get<T>(params object[] existingArguments)
        {
            LoadExistingArgs(existingArguments);
            return (T)CreateInstance(typeof(T));
        }

        private void LoadExistingArgs(object[] existingArguments)
        {
            _existingArgs = new Dictionary<Type, object>();
            foreach (var arg in existingArguments)
                _existingArgs.Add(arg.GetType(), arg);
        }

        private object CreateInstance(Type type)
        {
            var ctor = type.GetConstructors().First();
            var args = ctor.GetParameters().Select(GetNewOrExistingArg).ToArray();
            return Activator.CreateInstance(type, args);
        }

        private object GetNewOrExistingArg(ParameterInfo parameterInfo)
        {
            var argInterface = parameterInfo.ParameterType;

            foreach (var existingArg in _existingArgs)
            {
                if (argInterface.IsAssignableFrom(existingArg.Key))
                    return existingArg.Value;
            }

            var argType = _alltypes.Single(t => argInterface.IsAssignableFrom(t));
            return CreateInstance(argType);
        }
    }
}

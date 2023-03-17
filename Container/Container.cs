using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private Dictionary<Type, Type> Instances { get; set; } = new Dictionary<Type, Type>();
        public void Bind(Type interfaceType, Type implementationType)
        {
            // Assume container cannot have more than one instance of a given interfaceType and implementationType must be of interfaceType
            if (interfaceType == null || implementationType == null
                || Instances.ContainsKey(interfaceType) || !interfaceType.IsAssignableFrom(implementationType))
            {
                throw new InvalidOperationException();
            }
            Instances.Add(interfaceType, implementationType);
        }
        public T Get<T>()
        {
            if (!Instances.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException();
            }

            Instances.TryGetValue(typeof(T), out Type obj);
            return (T)Activator.CreateInstance(obj);
        }
    }
}
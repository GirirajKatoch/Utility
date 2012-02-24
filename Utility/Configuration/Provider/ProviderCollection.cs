using System;
using System.Configuration;
using System.Configuration.Provider;

namespace Utility.Configuration.Provider
{
    public class ProviderCollection<T> : ProviderCollection
        where T : System.Configuration.Provider.ProviderBase
    {
        public new T this[string name]
        {
            get
            {
                return (T)base[name];
            }
        }

        public T this[int index]
        {
            get
            {
                int counter = 0;

                foreach (T provider in this)
                {
                    if (counter == index)
                    {
                        return provider;
                    }
                    counter++;
                }

                return null;
            }
        }

        public override void Add(System.Configuration.Provider.ProviderBase provider)
        {
            if (!(provider is T))
            {
                throw new ArgumentException(
                    String.Format("The provider is not of type {0}.", typeof(T).ToString()));
            }

            base.Add((T)provider);
        }
    }
}
using System;
using System.Data;
using System.Configuration;

namespace Utility.Patterns
{
    /// <summary>
    /// Summary description for Singleton
    /// </summary>
    public class Singleton<T> where T : new()
    {
        public Singleton()
        {
        }

        private readonly static T objInstance = new T();

        public static T Instance
        {
            get
            {
                return objInstance;
            }
        }
    }
}
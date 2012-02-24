using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Utility.ComponentModel.Composition
{
    public static partial class Plugin
    {
        public static void Compose<T>(T instance)
        {
            Compose<T>(instance, String.Empty);
        }

        public static void Compose<T>(T instance, string folder) {
            string directory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder);

            DirectoryCatalog directoryCatalog = new DirectoryCatalog(directory);
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(typeof(T).Assembly);

            AggregateCatalog catalog = new AggregateCatalog(directoryCatalog, assemblyCatalog);

            CompositionContainer container = new CompositionContainer(catalog);

            container.ComposeParts(instance);
        }
    }
}

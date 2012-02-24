using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web.Configuration;

namespace Utility.Configuration.Provider
{
    public class ProviderManager<T> where T : System.Configuration.Provider.ProviderBase
    {
        private T defaultProvider;

        public ProviderCollection<T> Providers
        {
            get
            {
                return this.providers;
            }
        }

        protected ProviderCollection<T> providers = new ProviderCollection<T>();

        public ProviderManager(string sectionName)
        {
            ProvidersSection section = (ProvidersSection)ConfigurationManager.GetSection(sectionName);

            if (section == null)
                throw new ConfigurationErrorsException
                    ("SampleProvider configuration section is not set correctly.");

            foreach (ProviderSettings providerSettings in section.Providers)
            {
                providers.Add(ProvidersHelper.InstantiateProvider(providerSettings, typeof(T)));
            }

            defaultProvider = providers[section.DefaultProvider];

            if (defaultProvider == null)
                throw new Exception("defaultProvider");        
        }

        public T Provider
        {
            get
            {
                return defaultProvider;
            }
        }
    }
}
using System;
using System.Configuration;

namespace Utility.Configuration.Provider
{
    /// <summary>
    /// A configuration section for a collection of providers.
    /// </summary>
    public class ProvidersSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>The providers.</value>
        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get
            {
                return (ProviderSettingsCollection)base["providers"];
            }
        }

        /// <summary>
        /// Gets or sets the default provider.
        /// </summary>
        /// <value>The default provider.</value>
        [ConfigurationProperty("defaultProvider", IsRequired = false)]
        public string DefaultProvider
        {
            get
            {
                return (string)base["defaultProvider"];
            }
            set
            {
                base["defaultProvider"] = value;
            }
        }
    }
}
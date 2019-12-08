using System;
using System.Collections.Generic;
using System.Text;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;

namespace Analogy.LogViewer.Template
{
    public class DataProvidersFactory : IAnalogyDataProvidersFactory
    {
        public string Title { get; } = "Some Title";
        public IEnumerable<IAnalogyDataProvider> Items { get; }

        public DataProvidersFactory()
        {
            //get some data provider
            List<IAnalogyDataProvider> dataProviders = new List<IAnalogyDataProvider>();
            dataProviders.Add(new OfflineDataProvider());
            dataProviders.Add(new OnlineDataProvider());
        }
    }
}

using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Interfaces.Winforms;
using Analogy.Interfaces.Winforms.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analogy.LogViewer.Template
{
    public abstract class DataProvidersFactory : IAnalogyDataProvidersFactory
    {
        public abstract Guid FactoryId { get; set; }
        public abstract string Title { get; set; }
        public abstract IEnumerable<IAnalogyDataProvider> DataProviders { get; set; }
    }
    public abstract class DataProvidersFactoryWinforms : IAnalogyDataProvidersFactoryWinforms
    {
        public abstract Guid FactoryId { get; set; }
        public abstract string Title { get; set; }

        IEnumerable<IAnalogyDataProvider> IAnalogyDataProvidersFactory.DataProviders => DataProviders;
        public abstract IEnumerable<IAnalogyDataProviderWinforms> DataProviders { get; set; }
    }
}
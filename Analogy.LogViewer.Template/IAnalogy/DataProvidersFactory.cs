using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Template
{
    public abstract class DataProvidersFactory : IAnalogyDataProvidersFactory
    {
        public virtual Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public abstract string Title { get; set; }
        public abstract IEnumerable<IAnalogyDataProvider> DataProviders { get; set; }

    }
}

using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analogy.LogViewer.Template
{
    public abstract class DataProvidersFactory : IAnalogyDataProvidersFactory
    {
        public abstract Guid FactoryId { get; set; }
        public abstract string Title { get; set; }
        public virtual IEnumerable<IAnalogyDataProvider> DataProviders { get; set; } = [];
    }
}
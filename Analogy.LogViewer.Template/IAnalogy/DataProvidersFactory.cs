using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.Factories;
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
    public abstract class DataProvidersFactoryWinForms : IAnalogyDataProvidersFactoryWinForms
    {
        public abstract Guid FactoryId { get; set; }
        public abstract string Title { get; set; }

        IEnumerable<IAnalogyDataProvider> IAnalogyDataProvidersFactory.DataProviders => DataProviders;
        public abstract IEnumerable<IAnalogyDataProviderWinForms> DataProviders { get; set; }
    }
}
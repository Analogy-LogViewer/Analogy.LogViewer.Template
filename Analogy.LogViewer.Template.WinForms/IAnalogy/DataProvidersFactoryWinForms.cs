using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.Factories;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Template.WinForms
{
    public abstract class DataProvidersFactoryWinForms : DataProvidersFactory, IAnalogyDataProvidersFactoryWinForms
    {
        public abstract IEnumerable<IAnalogyDataProviderWinForms> DataProviders { get; }
    }
}
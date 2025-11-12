using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Template
{
    public abstract class CustomActionsFactory : IAnalogyCustomActionsFactory
    {
        public abstract Guid FactoryId { get; set; }
        public abstract string Title { get; set; }
        public virtual IEnumerable<IAnalogyCustomAction> Actions { get; } = [];
    }
}
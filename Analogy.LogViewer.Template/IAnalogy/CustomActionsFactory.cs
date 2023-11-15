using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Template
{
    public abstract class CustomActionsFactory : IAnalogyCustomActionsFactory
    {
        public abstract Guid FactoryId { get; set; }
        public virtual string Title { get; set; } = "Custom Action";
        public abstract IEnumerable<IAnalogyCustomAction> Actions { get; }
    }
}
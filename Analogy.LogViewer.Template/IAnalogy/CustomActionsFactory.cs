using System;
using System.Collections.Generic;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;

namespace Analogy.LogViewer.Template
{
    public abstract class CustomActionsFactory: IAnalogyCustomActionsFactory
    {
        public abstract Guid FactoryId { get; set; }
        public virtual string Title { get; set; } = "Custom Action";
        public abstract IEnumerable<IAnalogyCustomAction> Actions { get; }
    }
}

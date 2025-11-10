using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Interfaces.Winforms;
using Analogy.Interfaces.Winforms.Factories;
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
    public abstract class CustomActionsFactoryWinforms : IAnalogyCustomActionsFactoryWinforms
    {
        public abstract Guid FactoryId { get; set; }
        public virtual string Title { get; set; } = "Custom Action";
        IEnumerable<IAnalogyCustomAction> IAnalogyCustomActionsFactory.Actions => Actions;

        public abstract IEnumerable<IAnalogyCustomActionWinforms> Actions { get; }
    }
}
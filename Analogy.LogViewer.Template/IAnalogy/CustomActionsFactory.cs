using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.Factories;
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
    public abstract class CustomActionsFactoryWinForms : IAnalogyCustomActionsFactoryWinForms
    {
        public abstract Guid FactoryId { get; set; }
        public virtual string Title { get; set; } = "Custom Action";
        IEnumerable<IAnalogyCustomAction> IAnalogyCustomActionsFactory.Actions => Actions;

        public abstract IEnumerable<IAnalogyCustomActionWinForms> Actions { get; }
    }
}
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.Factories;
using System.Collections.Generic;

namespace Analogy.LogViewer.Template.WinForms
{
    public abstract class CustomActionsFactoryWinForms : CustomActionsFactory, IAnalogyCustomActionsFactoryWinForms
    {
        public abstract IEnumerable<IAnalogyCustomActionWinForms> Actions { get; }
    }
}
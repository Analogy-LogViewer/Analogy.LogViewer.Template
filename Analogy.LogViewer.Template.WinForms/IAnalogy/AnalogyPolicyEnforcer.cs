using Analogy.Interfaces;

namespace Analogy.LogViewer.Template.WinForms
{
    public class AnalogyPolicyEnforcer : IAnalogyPolicyEnforcer
    {
        public virtual bool DisableUpdates { get; set; }
    }
}
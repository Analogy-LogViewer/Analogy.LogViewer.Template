using Analogy.Interfaces;

namespace Analogy.LogViewer.Template
{
    public class AnalogyPolicyEnforcer : IAnalogyPolicyEnforcer
    {
        public virtual bool DisableUpdates { get; set; }
    }
}
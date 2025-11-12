using Analogy.LogViewer.Template.WinForms.Properties;
using System.Drawing;

namespace Analogy.LogViewer.Template.WinForms
{
    public abstract class PrimaryFactoryWinForms : PrimaryFactory
    {
        public virtual Image? SmallImage { get; set; } = Resources.Analogy16x16;
        public virtual Image? LargeImage { get; set; } = Resources.Analogy32x32;
    }
}
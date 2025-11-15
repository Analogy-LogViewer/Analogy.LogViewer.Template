using Analogy.Interfaces.WinForms.Factories;
using Analogy.LogViewer.Template.WinForms.Properties;
using System;
using System.Drawing;

namespace Analogy.LogViewer.Template.WinForms
{
    public abstract class PrimaryFactoryWinForms : PrimaryFactory, IAnalogyFactoryWinForms
    {
        public virtual Image? SmallImage { get; set; } = Resources.Analogy16x16;
        public virtual Image? LargeImage { get; set; } = Resources.Analogy32x32;
    }
}
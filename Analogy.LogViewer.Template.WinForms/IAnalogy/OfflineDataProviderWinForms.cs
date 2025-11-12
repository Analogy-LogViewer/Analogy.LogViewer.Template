using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.DataTypes;
using Analogy.LogViewer.Template.WinForms.Properties;
using System.Drawing;

namespace Analogy.LogViewer.Template.WinForms
{
    public abstract class OfflineDataProviderWinForms : OfflineDataProvider, IAnalogyOfflineDataProviderWinForms
    {
        public virtual Image? SmallImage { get; set; } = Resources.Analogy16x16;
        public virtual Image? LargeImage { get; set; } = Resources.Analogy32x32;
        AnalogyToolTip? IAnalogyDataProvider.ToolTip
        {
            get => ToolTip;
            set => ToolTip = value as AnalogyToolTipWinForms;
        }
        public new virtual AnalogyToolTipWinForms? ToolTip { get; set; } = new AnalogyToolTipWinForms("Offline Data Provider", "Read a static list of messages (in most cases the source is a log file)", "", null, null);
    }
}
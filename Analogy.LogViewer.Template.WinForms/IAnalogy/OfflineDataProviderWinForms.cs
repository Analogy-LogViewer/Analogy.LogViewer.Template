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
        public virtual Image? ToolTipSmallImage { get; set; } = Resources.Analogy16x16;
        public virtual Image? ToolTipLargeImage { get; set; } = Resources.Analogy32x32;
        public Image? GetDataProviderSmallImage() => SmallImage;
        public Image? GetDataProviderLargeImage() => LargeImage;

        public Image? GetDataProviderToolTipSmallImage() => ToolTipSmallImage;

        public Image? GetDataProviderToolTipLargeImage() => ToolTipLargeImage;
    }
}
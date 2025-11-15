using Analogy.Interfaces.WinForms;
using Analogy.LogViewer.Template.WinForms.Properties;
using System.Drawing;

namespace Analogy.LogViewer.Template.WinForms
{
    public abstract class AnalogyProviderSidePagingProviderWinForms : AnalogyProviderSidePagingProvider, IAnalogyProviderSidePagingProviderWinForms
    {
        public virtual Image? LargeImage { get; set; } = Resources.ServerMode_32x32;
        public virtual Image? SmallImage { get; set; } = Resources.ServerMode_16x16;
        public Image? GetDataProviderSmallImage() => SmallImage;

        public Image? GetDataProviderLargeImage() => LargeImage;

        public virtual Image? GetDataProviderToolTipSmallImage() => SmallImage;

        public virtual Image? GetDataProviderToolTipLargeImage() => LargeImage;
    }
}
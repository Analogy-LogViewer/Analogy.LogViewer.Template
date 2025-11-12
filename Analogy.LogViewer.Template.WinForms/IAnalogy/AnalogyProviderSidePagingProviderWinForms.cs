using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.DataTypes;
using Analogy.LogViewer.Template.WinForms.Properties;
using System.Drawing;

namespace Analogy.LogViewer.Template.WinForms
{
    public abstract class AnalogyProviderSidePagingProviderWinForms : AnalogyProviderSidePagingProvider, IAnalogyProviderSidePagingProviderWinForms
    {
        public virtual Image? LargeImage { get; set; } = Resources.ServerMode_32x32;
        public virtual Image? SmallImage { get; set; } = Resources.ServerMode_16x16;
        AnalogyToolTip? IAnalogyDataProvider.ToolTip
        {
            get => ToolTip;
            set => ToolTip = value is AnalogyToolTipWinForms WinForms ? WinForms : null;
        }
        public virtual AnalogyToolTipWinForms? ToolTip { get; set; } = new AnalogyToolTipWinForms("Server Side Provider", "Server Side data Fetcher", "", null, null);
    }
}
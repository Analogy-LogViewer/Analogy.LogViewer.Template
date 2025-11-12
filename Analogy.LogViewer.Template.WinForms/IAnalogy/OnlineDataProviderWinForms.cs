using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.DataTypes;
using Analogy.LogViewer.Template.WinForms.Properties;
using System.Drawing;

namespace Analogy.LogViewer.Template.WinForms
{
    public abstract class OnlineDataProviderWinForms : OnlineDataProvider, IAnalogyRealTimeDataProviderWinForms
    {
        IAnalogyOfflineDataProvider? IAnalogyRealTimeDataProvider.FileOperationsHandler => FileOperationsHandler;
        public new virtual IAnalogyOfflineDataProviderWinForms? FileOperationsHandler { get; set; }
        AnalogyToolTip? IAnalogyDataProvider.ToolTip
        {
            get => ToolTip;
            set => ToolTip = value as AnalogyToolTipWinForms;
        }
        public new virtual AnalogyToolTipWinForms? ToolTip { get; set; } = new AnalogyToolTipWinForms("Online Data Provider", "Supply a stream of messages", "", null, null);
        public virtual Image? ConnectedLargeImage { get; set; } = Resources.DatabaseOn32x32;
        public virtual Image? ConnectedSmallImage { get; set; } = Resources.DatabaseOn16x16;
        public virtual Image? DisconnectedLargeImage { get; set; } = Resources.DatabaseOff32x32;
        public virtual Image? DisconnectedSmallImage { get; set; } = Resources.DatabaseOff16x16;
    }
}
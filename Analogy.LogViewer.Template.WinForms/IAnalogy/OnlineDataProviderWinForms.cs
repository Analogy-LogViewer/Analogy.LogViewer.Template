using Analogy.Interfaces;
using Analogy.Interfaces.WinForms;
using Analogy.LogViewer.Template.WinForms.Properties;
using System.Drawing;

namespace Analogy.LogViewer.Template.WinForms
{
    public abstract class OnlineDataProviderWinForms : OnlineDataProvider, IAnalogyRealTimeDataProviderWinForms
    {
        public virtual Image? ConnectedLargeImage { get; set; } = Resources.DatabaseOn32x32;
        public virtual Image? ConnectedSmallImage { get; set; } = Resources.DatabaseOn16x16;
        public virtual Image? DisconnectedLargeImage { get; set; } = Resources.DatabaseOff32x32;
        public virtual Image? DisconnectedSmallImage { get; set; } = Resources.DatabaseOff16x16;
        public virtual Image GetStreamingConnectedLargeImage() => ConnectedLargeImage ?? Resources.DatabaseOn32x32;
        public virtual Image GetStreamingConnectedSmallImage() => ConnectedSmallImage ?? Resources.DatabaseOn16x16;
        public virtual Image GetStreamingDisconnectedLargeImage() => DisconnectedLargeImage ?? Resources.DatabaseOff32x32;
        public virtual Image GetStreamingDisconnectedSmallImage() => DisconnectedSmallImage ?? Resources.DatabaseOff16x16;
    }
}
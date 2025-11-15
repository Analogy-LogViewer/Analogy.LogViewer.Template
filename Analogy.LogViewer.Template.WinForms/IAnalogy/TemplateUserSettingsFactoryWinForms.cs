using Analogy.Interfaces.WinForms;
using Analogy.LogViewer.Template.WinForms.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace Analogy.LogViewer.Template.WinForms
{
    public abstract class TemplateUserSettingsFactoryWinForms : TemplateUserSettingsFactory, IAnalogyDataProviderSettingsWinForms
    {
        public abstract UserControl DataProviderSettings { get; set; }
        public virtual Image? SmallImage { get; set; } = Resources.Settings16x16;
        public virtual Image? LargeImage { get; set; } = Resources.Settings32x32;
        public virtual Image? ToolTipSmallImage { get; set; } = Resources.Analogy16x16;
        public virtual Image? ToolTipLargeImage { get; set; } = Resources.Analogy32x32;
        public virtual Image? GetDataProviderSettingsSmallImage() => SmallImage;

        public virtual Image? GetDataProviderSettingsLargeImage() => LargeImage;

        public virtual Image? GetDataProviderSettingsToolTipSmallImage() => ToolTipSmallImage;

        public virtual Image? GetDataProviderSettingsToolTipLargeImage() => ToolTipLargeImage;
    }
}
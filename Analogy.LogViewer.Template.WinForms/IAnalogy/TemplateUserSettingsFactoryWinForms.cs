using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.DataTypes;
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
        AnalogyToolTip? IAnalogyDataProviderSettings.ToolTip
        {
            get => ToolTip;
            set => ToolTip = value is AnalogyToolTipWinForms WinForms ? WinForms : null;
        }
        public virtual AnalogyToolTipWinForms? ToolTip { get; set; } = new AnalogyToolTipWinForms("User Setting", "Data Provider's User Setting", "", null, null);
    }
}
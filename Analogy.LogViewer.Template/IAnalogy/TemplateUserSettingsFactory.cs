using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.Winforms;
using Analogy.Interfaces.Winforms.DataTypes;
using Analogy.LogViewer.Template.Properties;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.Template
{
    public abstract class TemplateUserSettingsFactory : IAnalogyDataProviderSettings
    {
        public virtual string Title { get; set; } = "User Settings";
        public abstract UserControl DataProviderSettings { get; set; }
        public virtual Image? SmallImage { get; set; } = Resources.Settings16x16;
        public virtual Image? LargeImage { get; set; } = Resources.Settings32x32;
        public virtual AnalogyToolTip? ToolTip { get; set; } = new AnalogyToolTip("User Setting", "Data Provider's User Setting", "");
        public abstract Guid FactoryId { get; set; }
        public abstract Guid Id { get; set; }

        public abstract void CreateUserControl(ILogger logger);

        public abstract Task SaveSettingsAsync();
    }
    public abstract class TemplateUserSettingsFactoryWinforms : IAnalogyDataProviderSettingsWinforms
    {
        public virtual string Title { get; set; } = "User Settings";
        public abstract UserControl DataProviderSettings { get; set; }
        public virtual Image? SmallImage { get; set; } = Resources.Settings16x16;
        public virtual Image? LargeImage { get; set; } = Resources.Settings32x32;
        AnalogyToolTip? IAnalogyDataProviderSettings.ToolTip
        {
            get => ToolTip;
            set => ToolTip = value is AnalogyToolTipWinforms winforms ? winforms : null;
        }
        public virtual AnalogyToolTipWinforms? ToolTip { get; set; } = new AnalogyToolTipWinforms("User Setting", "Data Provider's User Setting", "", null, null);
        public abstract Guid FactoryId { get; set; }
        public abstract Guid Id { get; set; }

        public abstract void CreateUserControl(ILogger logger);

        public abstract Task SaveSettingsAsync();
    }
}
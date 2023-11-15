using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
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
        public virtual AnalogyToolTip? ToolTip { get; set; } = new AnalogyToolTip("User Setting", "Data Provider's User Setting", "", null, null);
        public abstract Guid FactoryId { get; set; }
        public abstract Guid Id { get; set; }

        public abstract void CreateUserControl(ILogger logger);

        public abstract Task SaveSettingsAsync();
    }
}
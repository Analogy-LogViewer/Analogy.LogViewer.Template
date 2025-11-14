using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Template
{
    public abstract class TemplateUserSettingsFactory : IAnalogyDataProviderSettings
    {
        public virtual string Title { get; set; } = "User Settings";
        public virtual AnalogyToolTip? ToolTip { get; set; } = new AnalogyToolTip("User Setting", "Data Provider's User Setting", "");
        public abstract Guid FactoryId { get; set; }
        public abstract Guid Id { get; set; }
        public abstract void CreateUserControl(ILogger logger);
        public abstract Task SaveSettingsAsync();
    }
}
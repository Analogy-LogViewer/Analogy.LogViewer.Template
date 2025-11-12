using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Template.WinForms
{
    public static class ChangeLogListWinForms
    {
        public static IEnumerable<AnalogyChangeLog> GetChangeLog()
        {
            return new List<AnalogyChangeLog>
            {
            new AnalogyChangeLog("Update template to use as based implementation", AnalogChangeLogType.None, "Lior Banai", new DateTime(2020, 09, 11), ""),
            new AnalogyChangeLog("Example (template)", AnalogChangeLogType.None, "Lior Banai", new DateTime(2019, 12, 08), ""),
            };
        }
    }
}
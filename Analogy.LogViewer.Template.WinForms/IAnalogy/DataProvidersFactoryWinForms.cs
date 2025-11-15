using Analogy.Interfaces.WinForms.Factories;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Analogy.LogViewer.Template.WinForms
{
    public abstract class DataProvidersFactoryWinForms : DataProvidersFactory, IAnalogyDataProvidersFactoryWinForms
    {
        public Dictionary<Guid, Image?> SmallImages { get; } = [];
        public Dictionary<Guid, Image?> LargeImages { get; } = [];
        public Image? GetDataFactorySmallImage(Guid componentId)
        {
            SmallImages.TryGetValue(componentId, out var img);
            return img;
        }

        public Image? GetDataFacoryLargeImage(Guid componentId)
        {
            LargeImages.TryGetValue(componentId, out var img);
            return img;
        }
    }
}
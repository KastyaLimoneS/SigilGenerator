using Avalonia.Controls;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigilGenerator.SigilGeneration.AltMode.Shapes
{
    public abstract class Shape
    {
        protected List<FreePlaceBuilder> _templates = new List<FreePlaceBuilder>();
        private int _current = -1;
        public abstract void DrawSelf(FreePlace place, SKCanvas canvas, SKPaint paint);
        public abstract void GenerateSelf(Random random);
        public List<FreePlace> GetPlaces(FreePlace place) => _templates.Select(x => x.Build(place.Position, place.Angle, place.Size)).ToList();
        public virtual bool IsCoolShape() => false;
        protected void DrawChildren(FreePlace place, SKCanvas canvas, SKPaint paint) {
            if (place.Children == null)
                return;
            place.Children.ForEach(x => x.DrawShape(canvas, paint));
        }
    }
}

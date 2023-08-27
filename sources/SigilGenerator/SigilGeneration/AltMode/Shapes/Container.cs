using SkiaSharp;
using System;

namespace SigilGenerator.SigilGeneration.AltMode.Shapes {
    internal class Container : Shape {
        public override void DrawSelf(FreePlace place, SKCanvas canvas, SKPaint paint) {
            DrawChildren(place, canvas, paint);
        }

        public override void GenerateSelf(Random random) {
            _templates.Add(new FreePlaceBuilder(0, 1, 0));
            _templates.Add(new FreePlaceBuilder(180, 1, 0));
        }
    }
}

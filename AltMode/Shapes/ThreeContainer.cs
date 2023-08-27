using SkiaSharp;
using System;

namespace SigilGenerator.SigilGeneration.AltMode.Shapes {
    internal class ThreeContainer : Shape {
        public override void DrawSelf(FreePlace place, SKCanvas canvas, SKPaint paint) {
            DrawChildren(place, canvas, paint);
        }

        public override void GenerateSelf(Random random) {
            _templates.Add(new FreePlaceBuilder(0, 1, 0));
            _templates.Add(new FreePlaceBuilder(120, 1, 0));
            _templates.Add(new FreePlaceBuilder(240, 1, 0));
        }
    }
}

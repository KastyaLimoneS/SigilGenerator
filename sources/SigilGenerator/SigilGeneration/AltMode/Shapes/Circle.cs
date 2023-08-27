using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigilGenerator.SigilGeneration.AltMode.Shapes {
    internal class Circle : Shape {
        public override void DrawSelf(FreePlace place, SKCanvas canvas, SKPaint paint) {
            canvas.DrawCircle(place.Position.X, place.Position.Y, place.Size, paint);
            DrawChildren(place, canvas, paint);
        }

        public override void GenerateSelf(Random random) {
            var angoffset = random.Next(2) * 45;
            var _vertecies = 4;
            var _innerAngle = (float) 360 / _vertecies;
            var sizeRatio = MathF.Cos((90 - _innerAngle / 2).Deg2Rads());
            //center is alway in the end.
            if (random.NextSingle() < 0.6)
                for (int i = 0; i < _vertecies; i++) {
                _templates.Add(new FreePlaceBuilder(_innerAngle * i + angoffset, sizeRatio));
                }
            _templates.Add(new FreePlaceBuilder(0, sizeRatio, 0));
        }
    }
}

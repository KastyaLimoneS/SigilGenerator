using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SigilGenerator.SigilGeneration.AltMode.Shapes {
    internal class Line : Shape {
        float _angle = 0;
        public override void DrawSelf(FreePlace place, SKCanvas canvas, SKPaint paint) {
            var offset = new Vector2(MathF.Cos(((place.Angle + _angle) % 360).Deg2Rads()), MathF.Sin(((place.Angle + _angle) % 360).Deg2Rads())) * place.Size;
            canvas.DrawLine((place.Position + offset).X, (place.Position + offset).Y, (place.Position - offset).X, (place.Position - offset).Y, paint);
        }

        public override void GenerateSelf(Random random) {
            _angle = 90 * random.Next(2);
        }
    }
}

using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigilGenerator.SigilGeneration.AltMode.Shapes {
    internal class Point : Shape {
        public override void DrawSelf(FreePlace place, SKCanvas canvas, SKPaint paint) {
            paint.Style = SKPaintStyle.Fill;
            canvas.DrawCircle(place.Position.X, place.Position.Y, 5 * (place.Size / DrawConfig.StartSize), paint);
            paint.Style = SKPaintStyle.Stroke;
        }

        public override void GenerateSelf(Random random) {
            
        }
    }
}

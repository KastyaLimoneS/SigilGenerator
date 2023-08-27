using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SigilGenerator.SigilGeneration.AltMode.Shapes {
    internal class Star : StuffWithVertecies {
        public override void DrawSelf(FreePlace place, SKCanvas canvas, SKPaint paint) {
            var startAngle = place.Angle + (_innerAngle * _floored) / 2;
            for (int i = 0; i < _vertecies; i++) {
                var pos_ = place.Position + new Vector2(MathF.Cos((startAngle + i * _innerAngle).Deg2Rads()), MathF.Sin((startAngle + i * _innerAngle).Deg2Rads())) * place.Size;
                canvas.DrawLine(place.Position.X, place.Position.Y, pos_.X, pos_.Y, paint);
            }

            DrawChildren(place, canvas, paint);
        }
    }
}

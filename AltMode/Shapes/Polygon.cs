using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SigilGenerator.SigilGeneration.AltMode.Shapes {
    internal class Polygon : StuffWithVertecies {
        public override void DrawSelf(FreePlace place, SKCanvas canvas, SKPaint paint) {
            var startAngle = place.Angle + (_innerAngle * _floored) / 2;
            List<Vector2> poses = new List<Vector2>();
            for (int i = 1; i < _vertecies; i++) {
                var prevIndex = i - 1;
                var pos_ = place.Position + new Vector2(MathF.Cos((startAngle + i * _innerAngle).Deg2Rads()), MathF.Sin((startAngle + i * _innerAngle).Deg2Rads())) * place.Size;
                var posPrev_ = place.Position + new Vector2(MathF.Cos((startAngle + (i-1) * _innerAngle).Deg2Rads()), MathF.Sin((startAngle + (i-1) * _innerAngle).Deg2Rads())) * place.Size;
                if (prevIndex == 0) {
                    poses.Add(posPrev_);
                }
                else {
                    poses.Add(pos_);
                }
                canvas.DrawLine(posPrev_.X, posPrev_.Y, pos_.X, pos_.Y, paint);
            }
            canvas.DrawLine(poses[0].X, poses[0].Y, poses[^1].X, poses[^1].Y, paint);

            DrawChildren(place, canvas, paint);
        }

        public override bool IsCoolShape() => true;
    }
}

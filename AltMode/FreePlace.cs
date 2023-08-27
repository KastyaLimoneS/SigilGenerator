using SigilGenerator.SigilGeneration.AltMode.Shapes;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SigilGenerator.SigilGeneration.AltMode
{
    public class FreePlace {
        public float Angle;
        public Vector2 Position;
        public float Size;
        public int HasOffset;

        public Shape? ShapeInside = null;
        public List<FreePlace>? Children = null;

        public FreePlace(Vector2 position, float angle, float size, int hasOffset=1) {
            Angle = angle;
            Position = position;
            Size = size;
            HasOffset = hasOffset;
        }

        public void DrawShape(SKCanvas canvas, SKPaint paint) {
            if (ShapeInside == null)
                return;
            ShapeInside.DrawSelf(this, canvas, paint);
        }

        public List<FreePlace>? CreateChildren() {
            if (ShapeInside == null)
                return null;
            Children = ShapeInside.GetPlaces(this); 
            return Children;
        }
    }

    public record FreePlaceBuilder(float AngleOffset, float SizeRatio, int HasOffset = 1) {
        public FreePlace Build(Vector2 position, float angle, float size) {
            var resultAngle = (angle + AngleOffset) % 360;
            var resultSize = size * SizeRatio;
            var resultPosition = position + new Vector2(MathF.Cos(resultAngle.Deg2Rads()), MathF.Sin(resultAngle.Deg2Rads()) ) * size * HasOffset;
            return new FreePlace(resultPosition, resultAngle, resultSize);
        }
    }
}

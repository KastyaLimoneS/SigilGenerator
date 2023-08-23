using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SkiaSharp;

namespace SigilGenerator.SigilGeneration.Shapes; 

public class Circle: AbstractShape {
    public override void DrawSelf(SKCanvas canvas, uint color) {
        var paint = DrawConfig.GetPaint(SKPaintStyle.Stroke, color);
        canvas.DrawCircle(Position.X, Position.Y, Size, paint);
        
        Children.ForEach(x => x.DrawSelf(canvas, color));
    }

    public override float GetSize(int child) => Size / 1.5f;

    public override Vector2 GetNormal(int child) => (child == 0) ? Normal : Normal.RotateDegrees(((child-1)%2)*180 + 90 * ( (int) ((child-1)/2) ));

    public override Vector2 GetPosition(int child) => (child == 0) ? Position : Position + Size * Normal.RotateDegrees(((child-1)%2)*180 + 90 * ( (int) ((child-1)/2) ));

    public override bool HasIndex(int index) => index < 5;

    public override int NaturalShift() => 1;
}
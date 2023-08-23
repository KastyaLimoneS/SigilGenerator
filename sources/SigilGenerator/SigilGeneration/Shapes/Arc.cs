using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SkiaSharp;

namespace SigilGenerator.SigilGeneration.Shapes; 

public class Arc: AbstractShape {
    public override void DrawSelf(SKCanvas canvas, uint color) {
        var paint = DrawConfig.GetPaint(SKPaintStyle.Stroke, color);
        var oval = new SKRect(Position.X - Size, Position.Y - Size, Position.X + Size, Position.Y + Size);
        canvas.DrawArc(oval,Normal.RotateDegrees(270).GetRadians() / MathF.PI * 180, 180, false, paint);
        
        Children.ForEach(x => x.DrawSelf(canvas, color));
    }

    public override float GetSize(int child) => Size / 1.5f;

    public override Vector2 GetNormal(int child) => Normal;

    public override Vector2 GetPosition(int child) => Position;

    public override bool HasIndex(int index) => index < 1;
}
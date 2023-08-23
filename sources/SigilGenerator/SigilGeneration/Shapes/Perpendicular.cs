using System.Numerics;
using SkiaSharp;

namespace SigilGenerator.SigilGeneration.Shapes; 

public class Perpendicular: AbstractShape {
    public override void DrawSelf(SKCanvas canvas, uint color) {
        var paint = DrawConfig.GetPaint(SKPaintStyle.Stroke, color);
        var p1 = Position + Normal.RotateDegrees(90) * Size;
        var p2 = Position - Normal.RotateDegrees(90) * Size;
        canvas.DrawLine(p1.X, p1.Y, p2.X, p2.Y, paint);
        Children.ForEach(x => x.DrawSelf(canvas, color));
    }

    public override float GetSize(int child) => Size / (1 + child * 0.5f);

    public override Vector2 GetNormal(int child) => Normal;

    public override Vector2 GetPosition(int child) => Position + Normal * child * Size / 1.5f;

    public override bool HasIndex(int index) => index < 2;
}
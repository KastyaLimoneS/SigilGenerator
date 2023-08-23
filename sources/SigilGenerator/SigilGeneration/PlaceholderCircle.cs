using System.Numerics;
using SkiaSharp;

namespace SigilGenerator.SigilGeneration; 

public class PlaceholderCircle: AbstractShape {
    public override void DrawSelf(SKCanvas canvas, uint color) {
        var paint = DrawConfig.GetPaint(SKPaintStyle.Fill, color);
        canvas.DrawCircle(new SKPoint(Position.X, Position.Y), Size, paint);
    }

    public override float GetSize(int child) => 0;

    public override Vector2 GetNormal(int child) => Vector2.Zero;
    public override Vector2 GetPosition(int child) => Vector2.Zero;

    protected override int SetChild(AbstractShape child) => -1;
    public override bool HasIndex(int index) => false;
}
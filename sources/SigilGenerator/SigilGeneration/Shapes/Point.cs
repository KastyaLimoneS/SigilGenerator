using System.Numerics;
using SkiaSharp;

namespace SigilGenerator.SigilGeneration.Shapes; 

public class Point: AbstractShape {
    public override void DrawSelf(SKCanvas canvas, uint color) {
        var paint = DrawConfig.GetPaint(SKPaintStyle.Fill, color);
        canvas.DrawCircle(Position.X, Position.Y, 2, paint);
    }

    public override float GetSize(int child) {
        throw new System.NotImplementedException();
    }

    public override Vector2 GetNormal(int child) {
        throw new System.NotImplementedException();
    }

    public override Vector2 GetPosition(int child) {
        throw new System.NotImplementedException();
    }

    public override bool HasIndex(int index) => false;
}
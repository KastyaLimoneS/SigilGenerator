using System.Numerics;
using SkiaSharp;

namespace SigilGenerator.SigilGeneration.Shapes; 

public class Plus: AbstractShape {
    public override void DrawSelf(SKCanvas canvas, uint color) {
        var paint = DrawConfig.GetPaint(SKPaintStyle.Stroke, color);
        var startNormal = Normal * Size * 1.5f;
        for (int i = 0; i < 4; i++)
            canvas.DrawLine(Position.X, Position.Y, (Position + startNormal.RotateDegrees(90 * i)).X, (Position + startNormal.RotateDegrees(90 * i)).Y, paint);
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
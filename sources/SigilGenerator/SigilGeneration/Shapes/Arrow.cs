using SkiaSharp;

namespace SigilGenerator.SigilGeneration.Shapes; 

public class Arrow: Parallel {
    public override void DrawSelf(SKCanvas canvas, uint color) {
        base.DrawSelf(canvas, color);
        var end = GetPosition(1);
        var paint = DrawConfig.GetPaint(SKPaintStyle.Stroke, color);
        var a1 = end + Normal.RotateDegrees(45) * Size/4;
        var a2 = end + Normal.RotateDegrees(-45) * Size/4;
        canvas.DrawLine(end.X, end.Y, a1.X, a1.Y, paint);
        canvas.DrawLine(end.X, end.Y, a2.X, a2.Y, paint);
    }
}
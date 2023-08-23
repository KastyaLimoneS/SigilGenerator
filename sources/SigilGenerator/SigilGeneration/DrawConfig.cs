using System.Numerics;
using SkiaSharp;

namespace SigilGenerator.SigilGeneration; 

public static class DrawConfig {

    public static readonly float StartSize = 50;
    public static readonly Vector2 StartNormal = -Vector2.UnitY;
    public static readonly Vector2 StartPosition = Vector2.One * 150;
    
    private static readonly float _strokeWidth = 4;
    private static SKPaint? _paint;
    
    public static SKPaint GetPaint(SKPaintStyle style, uint color) {
        if (_paint == null) {
            var paint = new SKPaint();
            paint.StrokeWidth = _strokeWidth;
            _paint = paint;
        }
        _paint.Style = style;
        _paint.Color = new SKColor(color);
        return _paint;
    }
}
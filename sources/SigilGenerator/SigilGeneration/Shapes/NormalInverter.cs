using System.Numerics;
using SkiaSharp;

namespace SigilGenerator.SigilGeneration.Shapes; 

public class NormalInverter: AbstractShape {
    public override void DrawSelf(SKCanvas canvas, uint color) {
        Children.ForEach(x => x.DrawSelf(canvas, color));
    }

    public override float GetSize(int child) => Size;

    public override Vector2 GetNormal(int child) => -Normal;

    public override Vector2 GetPosition(int child) => Position;

    public override bool HasIndex(int index) => index < 1;
}
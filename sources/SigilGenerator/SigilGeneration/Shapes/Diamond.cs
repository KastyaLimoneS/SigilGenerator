using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SkiaSharp;

namespace SigilGenerator.SigilGeneration.Shapes; 

public class Diamond: AbstractShape {
    public override void DrawSelf(SKCanvas canvas, uint color) {
        var paint = DrawConfig.GetPaint(SKPaintStyle.Stroke, color);
        var vertexes = new List<Vector2>();
        for (int i = 0; i < 4; i++) {
            vertexes.Add(Position + Normal.RotateDegrees(90*i) * Size);
        }
        
        vertexes.Add(vertexes.First());
        
        vertexes.Aggregate((v1, v2) => {
            canvas.DrawLine(v1.X, v1.Y, v2.X, v2.Y, paint);
            return v2;
        });
        
        vertexes.RemoveAt(vertexes.Count-1);
        
        Children.ForEach(x => x.DrawSelf(canvas, color));
    }

    public override float GetSize(int child) => Size / 1.5f;

    public override Vector2 GetNormal(int child) => (child == 0) ? Normal : Normal.RotateDegrees(((child-1)%2)*180 + 90 * ( (int) ((child-1)/2) ));

    public override Vector2 GetPosition(int child) => (child == 0) ? Position : Position + Size * Normal.RotateDegrees(((child-1)%2)*180 + 90 * ( (int) ((child-1)/2) ));

    public override bool HasIndex(int index) => index < 5;

    public override int NaturalShift() => 1;
}
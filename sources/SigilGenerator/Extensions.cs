using System;
using System.Numerics;
using Avalonia;

namespace SigilGenerator; 

public static class Extensions {
    public static AppBuilder DoStartStuff(this AppBuilder builder, Action stuff) {
        stuff();
        return builder;
    }

    public static Vector2 RotateDegrees(this Vector2 self, float angle) {
        var rads = MathF.PI * (angle / 180);
        var leng = self.Length();
        var ang = ( (MathF.Sign(self.Y) <= 0)? 0: MathF.PI) + MathF.Acos(self.X / leng);
        var resultAngle = ang + rads;
        var x = MathF.Round(MathF.Cos(resultAngle), 4);
        var y = MathF.Round(MathF.Sin(resultAngle), 4);
        return new Vector2(x * leng, y * leng);
    }

    public static float GetRadians(this Vector2 self) {
        var leng = self.Length();
        var ang = ( (MathF.Sign(self.Y) <= 0)? 0: MathF.PI) + MathF.Acos(self.X / leng);
        return ang;
    }

    public static int MyHash(this String self) {
        var result = 0;
        foreach (var c in self) {
            result *= 256;
            result += c;
        }

        return result;
    }
}
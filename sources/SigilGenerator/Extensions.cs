using System;
using System.Collections.Generic;
using System.Linq;
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

    public static float Deg2Rads(this float angle) {
        return (angle / 360) * MathF.PI * 2;
    }

    public static int MyHash(this String self) {
        var self_ = self.ToCharArray().Select(x => (int) x);
        var result = self_.Aggregate((x, y) => x ^ y);
        int i = 0;
        var result_ = BitConverter.GetBytes(result).Select(x => (byte)((i++ % 2 == 0) ? x ^ 0xFFFF : x)).ToArray();
        result = BitConverter.ToInt32(result_) ^ self.Length;

        return result;
    }

    public static T SortedRandom<T>(this IEnumerable<T> self, Random random) {
        var hl = self.Count() / 2;
        if (hl == 0)
            return self.First();
        var halfself = self.ToList();
        halfself.Reverse();
        return halfself.Skip(random.Next(1, hl)).SortedRandom(random);

    }
}
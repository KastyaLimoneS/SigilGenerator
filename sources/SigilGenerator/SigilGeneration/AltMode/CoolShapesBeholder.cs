using System;
using System.Linq;
using SigilGenerator.SigilGeneration.AltMode.Shapes;
using Circle = SigilGenerator.SigilGeneration.Shapes.Circle;

namespace SigilGenerator.SigilGeneration.AltMode; 

public static class CoolShapesBeholder {
    private static Type[] _coolTable = new Type[] {
        typeof(Circle),
        typeof(Polygon)
    };
    private static Type[] _containerTable = new Type[] {
        typeof(Container),
        typeof(ThreeContainer),
        typeof(Offsetter)
    };
    private static Type[] _poorTable = new Type[] {
        typeof(Point),
        typeof(Star),
        typeof(Line)
    };

    public static bool IsCool(Shape shape) => _coolTable.Contains(shape.GetType());
    public static bool IsCool(Type shape) => _coolTable.Contains(shape);
    public static bool IsPoor(Shape shape) => _poorTable.Contains(shape.GetType());
    public static bool IsContainer(Shape shape) => _containerTable.Contains(shape.GetType());
}
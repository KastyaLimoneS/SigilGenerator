using SigilGenerator.SigilGeneration.AltMode.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SigilGenerator.SigilGeneration.AltMode {
    public static class Generator {
        public static FreePlace? Root = null;
        private static readonly Func<Shape>[] _table = new Func<Shape>[] {
            () => new Polygon(),
            () => new Circle(),
            () => new Star(),
            () => new Line(),
            () => new Container(),
            () => new Offsetter(),
            () => new Point(),
            () => new ThreeContainer()
        }; 
        public static float Complexity = 0.7f;
        public static int RerollCount = 0;
        public static void Generate(String seed) {
            var random = new Random(seed.MyHash());
            for (int i = 0; i < RerollCount; i++)
                random = new Random(random.Next());
            var root = new FreePlace(DrawConfig.StartPosition, 270, DrawConfig.StartSize, 0);
            var placeList = new List<FreePlace>() { root };
            var minSymbols = (int) (Complexity * Complexity * 10);
            var table = new List<Func<Shape>>(_table);
            var containerCount = 1;
            while( ((random.NextSingle() < Complexity) || (minSymbols > 0)) && placeList.Count > 0) {
                var place = placeList.SortedRandom(random);
                var shape = table[random.Next(table.Count)]();
                var ip = CoolShapesBeholder.IsPoor(shape);
                int a = 1;
                while ((CoolShapesBeholder.IsPoor(shape) || (CoolShapesBeholder.IsContainer(shape) && containerCount <= 0)) && minSymbols > 0)
                    shape = table[random.Next(table.Count)]();
                if (CoolShapesBeholder.IsCool(shape))
                    table.Add(() => shape);
                shape.GenerateSelf(random);
                place.ShapeInside = shape;
                var children = place.CreateChildren();
                placeList.Remove(place);
                if (children == null)
                    continue;
                placeList.AddRange(children);
                minSymbols--;
                containerCount--;
            }
            Root = root;
        }
    }
}

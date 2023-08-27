using SigilGenerator.SigilGeneration.AltMode.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static float Complexity = 0.5f;
        public static void Generate(String seed) {
            var random = new Random(seed.MyHash());
            var root = new FreePlace(DrawConfig.StartPosition, 270, DrawConfig.StartSize, 0);
            var placeList = new List<FreePlace>() { root };
            var minSymbols = (int) (Complexity * 10);
            while( ((random.NextSingle() < Complexity) || (minSymbols > 0)) && placeList.Count > 0) {
                var place = placeList.SortedRandom(random);
                var shape = _table[random.Next(_table.Length / random.Next(1, 4))]();
                shape.GenerateSelf(random);
                place.ShapeInside = shape;
                var children = place.CreateChildren();
                placeList.Remove(place);
                if (children == null)
                    continue;
                placeList.AddRange(children);
                minSymbols--;
            }
            Root = root;
        }
    }
}

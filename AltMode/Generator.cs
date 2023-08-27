using SigilGenerator.SigilGeneration.AltMode.Shapes;
using System;
using System.Collections.Generic;
using Avalonia.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigilGenerator.SigilGeneration.AltMode {
    public static class Generator {
        public static FreePlace? Root = null;
        public static Slider? ComplexitySource;
        private static List<Func<Shape>> _table = new List<Func<Shape>> {
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
            Complexity = (ComplexitySource == null)? Complexity : (float)ComplexitySource.Value;
            var table = new List<Func<Shape>>(_table);
            var random = new Random(seed.MyHash());
            var root = new FreePlace(DrawConfig.StartPosition, 270, DrawConfig.StartSize, 0);
            var placeList = new List<FreePlace>() { root };
            var minSymbols = (int) (Complexity * Complexity * 10);
            while( ((random.NextSingle() < Complexity) || (minSymbols > 0)) && placeList.Count > 0) {
                var place = placeList.SortedRandom(random);
                var shape = table[random.Next(table.Count)]();
                while (!shape.IsCoolShape() && minSymbols > 0 || random.NextSingle() < 0.3)
                    shape = table[random.Next(table.Count)]();
                if (shape.IsCoolShape()) 
                    table.Add(() => shape);
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

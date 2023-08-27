using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using SigilGenerator.SigilGeneration.Shapes;
using SkiaSharp;

namespace SigilGenerator.SigilGeneration;

public static class Generator
{
    public static AbstractShape Root { get; private set; } = new PlaceholderCircle();
    public static TextBox Source;
    public static bool AltMode = false;
    private static Dictionary<char, Func<AbstractShape>> _table = new Dictionary<char, Func<AbstractShape>>() {
        {'a', () => new Point()},
        {'b', () => new Arrow()},
        {'c', () => new Diamond()},
        {'d', () => new Cross()},
        {'e', () => new Arc()},
        {'f', () => new MovedArc()},
        {'g', () => new Triangle()},
        {'h', () => new Diamond()},
        {'i', () => new Perpendicular()},
        {'k', () => new NormalInverter()},
        {'l', () => new Parallel()},
        {'m', () => new MovedArc()},
        {'n', () => new Triangle()},
        {'o', () => new Diamond()},
        {'p', () => new Plus()},
        {'q', () => new Arc()},
        {'r', () => new Circle()},
        {'s', () => new NormalInverter()},
        {'t', () => new Parallel()},
        {'u', () => new MovedArc()},
        {'v', () => new Point()},
        {'w', () => new Arrow()},
        {'x', () => new Diamond()},
        {'y', () => new Triangle()},
        {'z', () => new Diamond()},
    };

    public static void Generate(String replacer = "")
    {
        var prompt = Source.Text;
        if (prompt == null || prompt.Equals(String.Empty))
            return;
        if (AltMode) {
            SigilGeneration.AltMode.Generator.Generate(prompt);
            ColorsController.RecolorStuff();
            return;
        }
        prompt = prompt.Replace(" ", "").ToLower();
        if (replacer != "") prompt = replacer;
        try
        {
            var shapes = prompt.Where(x => _table.ContainsKey(x)).Select(x => _table[x]()).ToList();
            var poorShapes = shapes.TakeWhile(x => !x.HasIndex(0)).ToList();
            poorShapes.ForEach(x => shapes.Remove(x));
            shapes.AddRange(poorShapes);
            shapes.ForEach(x => x.RootSetUp());
            shapes.Aggregate((s1, s2) =>
            {
                s1.TrySetChild(s2);

                return s1;
            });

            var newRoot = shapes[0];
            shapes.Clear();
            shapes.Add(newRoot);

            if (shapes.Count == 1)
                Root = shapes[0];
            ColorsController.RecolorStuff();
        }
        catch (Exception)
        {
            Regenerate(prompt);
        }
    }


    public static void Regenerate(String prompt_)
    {
        var seed = prompt_.MyHash();
        var safeString = "ccccggggrrrrief";
        var random = new Random(seed);
        var newPrompt = "";
        while (random.NextSingle() > 0.6 || newPrompt.Length < 4)
        {
            newPrompt += safeString[(int)(random.NextSingle() * safeString.Length)];
        }
        Generate(newPrompt);
    }

    public static void DrawSigil(SKCanvas canvas, uint color)
    {
        if (AltMode && SigilGeneration.AltMode.Generator.Root != null) {
            SigilGeneration.AltMode.Generator.Root.DrawShape(canvas, DrawConfig.GetPaint(SKPaintStyle.Stroke, color));
            return;
        }
        Root.DrawSelf(canvas, color);

    }

    public static void SetUpRoot()
    {
        if (AltMode && SigilGeneration.AltMode.Generator.Root != null) {
            return;
        }
        Root.RootSetUp();
    }
}
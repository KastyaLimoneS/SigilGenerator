using System;
using System.IO;
using System.Net;
using SigilGenerator.SigilGeneration;
using SkiaSharp;
using SkiaSharp.Extended.Svg;

namespace SigilGenerator; 

public static class ImageCreator {
    public static String BufferImage = "bufferImage.png";
    public static SKData ActualImage;
    public static void DoStuff() {
        var image = new SKBitmap(300, 300);
        var bgcolor = ColorsController.GetColor(ColorsController.Target.Background);
        var fgcolor = ColorsController.GetColor(ColorsController.Target.Sigil);
        using (SKCanvas canvas = new SKCanvas(image)) {
            canvas.Clear(new SKColor(bgcolor));
            Generator.Root.DrawSelf(canvas, fgcolor);
        }
        /*
        var data = image.Encode(SKEncodedImageFormat.Png, 80);
        using (var stream = File.OpenWrite(BufferImage)) {
            data.SaveTo(stream);
        }*/
        ActualImage = image.Encode(SKEncodedImageFormat.Png, 80);

    }

    private static uint DeleteAlpha(uint color) => color & 0x00FFFFFF;
}
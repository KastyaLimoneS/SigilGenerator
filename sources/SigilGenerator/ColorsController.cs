using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace SigilGenerator; 

public static class ColorsController {
    //test implementation
    public static Image? Canvas;

    public static bool Initialized { get; private set; } = false;
    //end.
    public static readonly uint[] BackgroundPalette = new uint[] {
        0xFF34495E,
        0xFF392e4a,
        0xFF16453e,
        0xFF825e5c,
        
        0xFF043b5c,
        0xFF284387,
        0xFF342d71,
        0xFF6e304b,
        
        0xFF080e2c,
        0xFF1c474d,
        0xFF2e3131,
        0xFF24252a,
        
        0xFF22313f,
        0xFFf64747,
        0xFF34495e,
        0xFF674172
    };
    
    public static uint[] SigilPalette = new uint[] {
        0xFFc9f29b,
        0xFFecd9dd,
        0xFFe33d94,
        0xFFfffc7f,
        
        0xFF93faa5,
        0xFF2d55ff,
        0xFFe76d89,
        0xFF963694,
        
        0xFF67809f,
        0xFF03c9a9,
        0xFF2ecc71,
        0xFFd91e18,
        
        0xFFd8fa08,
        0xFFa537fd,
        0xFF848ccf,
        0xFFf1a9a0
    };
    
    private static Shape? _selectedSigilColor;
    private static Shape? _selectedBackgroundColor;

    public static void PickColor(Shape shape, Target target) {
        ref Shape? shp = ref _selectedSigilColor;
        if (target == Target.Background) 
            shp = ref _selectedBackgroundColor;
        if (shp != null)
            MakeDefault(shp);
        shp = shape;
        MakeSelected(shp);
        Initialized = (_selectedBackgroundColor != null) && (_selectedSigilColor != null);
        RecolorStuff();
    }

    public static uint GetColor(Target target) => (((target == Target.Sigil) ? _selectedSigilColor : _selectedBackgroundColor).Fill as SolidColorBrush).Color.ToUInt32();

    public static void RecolorStuff() {
        if (!Initialized)
            return;
        if (Canvas != null) {
            ImageCreator.DoStuff();
            Canvas.Source = new Bitmap(ImageCreator.ActualImage.AsStream());
        }
    }

    private static void MakeDefault(Shape shape) {
        shape.StrokeThickness = 0;
    }
    
    private static void MakeSelected(Shape shape) {
        shape.StrokeThickness = 4;
        shape.Stroke = new SolidColorBrush(0x00000000);
    }
    
    public enum Target {
        Sigil,
        Background
    }
}
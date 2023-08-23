using System;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using SigilGenerator.SigilGeneration;
using SkiaSharp;

namespace SigilGenerator;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }
    
    private void SigilColorPanel_OnInitialized(object? sender, EventArgs e) {
        var colors = (sender as Panel).Children;
        for (int i = 0; i < colors.Count; i++) {
            var control = colors[i];
            control.Tapped += (x, y) => ColorsController.PickColor(x as Shape, ColorsController.Target.Sigil);
            (control as Shape).Fill = new SolidColorBrush(ColorsController.SigilPalette[i]);
        }
        ColorsController.PickColor(colors[0] as Shape, ColorsController.Target.Sigil);
    }
    
    private void BackgroundColorPanel_OnInitialized(object? sender, EventArgs e) {
        var colors = (sender as Panel).Children;
        for (int i = 0; i < colors.Count; i++) {
            var control = colors[i];
            control.Tapped += (x, y) => ColorsController.PickColor(x as Shape, ColorsController.Target.Background);
            (control as Shape).Fill = new SolidColorBrush(ColorsController.BackgroundPalette[i]);
        }
        ColorsController.PickColor(colors[0] as Shape, ColorsController.Target.Background);
    }

    private void StyledElement_OnInitialized(object? sender, EventArgs e) {
        var image = sender as Image;
        ColorsController.Canvas = image;
    }

    private void SaveButton_OnClick(object? sender, RoutedEventArgs e) {
        Saver.Save();
    }

    private void GenerateButton_OnClick(object? sender, RoutedEventArgs e) {
        Generator.Generate();
    }

    private void TextBox__OnInitialized(object? sender, EventArgs e) {
        Generator.Source = sender as TextBox;
    }
}
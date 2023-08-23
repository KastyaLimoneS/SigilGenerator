using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using TinyDialogsNet;
namespace SigilGenerator; 

public static class Saver {
    private static bool _inited = false;
    private static String _defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
    public static void Save() {
        String path;
        var stuff = TinyDialogsNet.Dialogs.SaveFileDialog("Save Sigil", "", "*.png", "PNG Pictures");
        var result = stuff != null && stuff != "";
        if (!result)
            return;
        path = stuff;
        using (var stream = File.OpenWrite(path)) {
            ImageCreator.ActualImage.SaveTo(stream);
        }
    }

    private static void Init() {
        if (_inited)
            return;
        _inited = true;
    }
}
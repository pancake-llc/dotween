#if UNITY_EDITOR
using System.IO;
using UnityEditor;


public static class ImportPackage
{
#if !LANCE_DOTWEEN_SUPPORT
    private const string DOTWEEN_PACKAGE_PATH = "Assets/_Root/Packages/dotween-lastest.unitypackage";
    private const string PATH_INSTALL = "Assets/Plugins/Demigiant/DOTween";
    private const string PACKAGE_PATH = "Packages/com.snorlax.dotween/Packages/dotween-lastest.unitypackage";

    [MenuItem("Package/Import DOTween")]
    [InitializeOnLoadMethod]
    public static void ImportDoTween()
    {
        if (Directory.Exists(PATH_INSTALL)) return;
        string path = DOTWEEN_PACKAGE_PATH;
        if (!File.Exists(path)) path = !File.Exists(Path.GetFullPath(PACKAGE_PATH)) ? DOTWEEN_PACKAGE_PATH : PACKAGE_PATH;
        AssetDatabase.ImportPackage(path, true);
    }
#endif
}

#endif
#if UNITY_EDITOR
using System.IO;
using UnityEditor;

[InitializeOnLoad]
public class ImportPackage : AssetPostprocessor
{
    private const string DOTWEEN_PACKAGE_PATH = "Assets/_Root/Packages/dotween-lastest.unitypackage";
    private const string PATH_DOTWEEN_DLL = "Assets/Plugins/Demigiant/DOTween/DOTween.dll";
    private const string PACKAGE_PATH = "Packages/com.snorlax.dotween/Packages/dotween-lastest.unitypackage";

    static ImportPackage() { EditorApplication.update += AutoImported; }

    [MenuItem("Package/Import DOTween")]
    public static void ImportDoTween()
    {
        string path = DOTWEEN_PACKAGE_PATH;
        if (!File.Exists(path)) path = !File.Exists(Path.GetFullPath(PACKAGE_PATH)) ? DOTWEEN_PACKAGE_PATH : PACKAGE_PATH;
        AssetDatabase.ImportPackage(path, true);
    }

    public static void AutoImported()
    {
        EditorApplication.update -= AutoImported;
        
        if (!IsDotweenImported())
        {
            string path = DOTWEEN_PACKAGE_PATH;
            if (!File.Exists(path)) path = !File.Exists(Path.GetFullPath(PACKAGE_PATH)) ? DOTWEEN_PACKAGE_PATH : PACKAGE_PATH;
            AssetDatabase.ImportPackage(path, false);
        }
    }

    public static bool IsDotweenImported() { return File.Exists(PATH_DOTWEEN_DLL); }
}

#endif
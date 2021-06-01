using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ClearPlayerPrefs : EditorWindow
{
    [MenuItem("Tools/Reset Players Prefs")]
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}

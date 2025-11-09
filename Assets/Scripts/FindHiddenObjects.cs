#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class FindHiddenObjects
{
    [MenuItem("Tools/Find Hidden Objects")]
    static void FindHidden()
    {
        var objects = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (var obj in objects)
        {
            if (obj.hideFlags != HideFlags.None)
            {
                Debug.Log($"Hidden Object: {obj.name}, Flags: {obj.hideFlags}", obj);
                obj.hideFlags = HideFlags.None; // make visible
            }
        }

        EditorApplication.RepaintHierarchyWindow();
        Debug.Log("Search complete. Hidden objects (if any) are now visible in Hierarchy.");
    }
}
#endif


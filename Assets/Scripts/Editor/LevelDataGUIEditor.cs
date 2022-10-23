using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelData))]
public class LevelDataGUIEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelData script = (LevelData)target;
        if (GUILayout.Button("SelectTargetColor"))
        {
            script.SelectTargetColor();
            EditorUtility.SetDirty(script);
            
            AssetDatabase.SaveAssets();
        }
       
    }
}

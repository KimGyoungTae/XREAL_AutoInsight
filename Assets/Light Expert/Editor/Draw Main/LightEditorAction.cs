using UnityEditor;
using LightMaster;

[CustomEditor(typeof(LightAction))]
public class LightEditorAction : Editor {
    public override void OnInspectorGUI() {
        serializedObject.Update();
        // draws all varaibles, but only if certain conditions are true
        LightAction lightAction = (LightAction)target;
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Action"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ActionOn"));


        if(lightAction.ActionOn == LightAction.ActionsSelect.Tag)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Tag"));
        
        if(lightAction.ActionOn == LightAction.ActionsSelect.Random)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("RandomAmount"));

        if(lightAction.ActionOn == LightAction.ActionsSelect.Reference)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("LightReference"));
        /*
        if(lightAction.Action == LightAction.Actions.BlockLight) {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Block"));
            if(lightAction.Block == LightAction.BlockSpecs.Set)
                EditorGUILayout.PropertyField(serializedObject.FindProperty("SetValue"));
        }
        */

        if(lightAction.Action == LightAction.Actions.SetLight)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SetValue"));

        serializedObject.ApplyModifiedProperties();
    }
}

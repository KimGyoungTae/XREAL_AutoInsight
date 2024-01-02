using UnityEditor;
using LightMaster;

[CustomEditor(typeof(LightManager))]
public class LightEditorManager : Editor {
    public override void OnInspectorGUI() {
        serializedObject.Update();
        LightManager lightManager = (LightManager)target;
        //draw Containers
        EditorGUILayout.PropertyField(serializedObject.FindProperty("TagContainers"));
        //draw Console Design
        /// <see cref="LightConsoleVariablesEditor"/> for the actual Console Design Drawing
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ConsoleDesign"));
        serializedObject.ApplyModifiedProperties();
    }
}

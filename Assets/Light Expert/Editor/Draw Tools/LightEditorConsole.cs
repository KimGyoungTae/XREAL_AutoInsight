using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace LightMaster {
    [CustomPropertyDrawer(typeof(LightConsoleVariables))]
    public class LightConsoleVariablesEditor : PropertyDrawer {
        bool state = false; // saves if the variable window is shown
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if(GUILayout.Button("Console Variables")) {
                state = !state; // switch state
            }
            if(!state)
                return;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(property.FindPropertyRelative("textColor"));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(property.FindPropertyRelative("showPrefix"));
            if(property.FindPropertyRelative("showPrefix").boolValue) {
                EditorGUILayout.PropertyField(property.FindPropertyRelative("prefixColor"));
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.PropertyField(property.FindPropertyRelative("prefixText"));
            } else {
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.PropertyField(property.FindPropertyRelative("showLog"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("showWarning"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("showError"));

            //example output, send all possible messages
            if(GUILayout.Button("Example Output")) {
                LightMasterConsole.SendMessage("Example Normal Message");
                LightMasterConsole.SendWarning("Example Warning Message");
                LightMasterConsole.SendError("Example Error Message");
            }
        }
    }
}


using UnityEditor.UIElements;
using UnityEngine;
using UnityEditor;
using System;

namespace LightMaster {
    //Draws the Variables of the LC

    [CustomPropertyDrawer(typeof(SmoothTurnOnOff))]
    public class SmoothTurnOnOffDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(property.FindPropertyRelative("minIntensity"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("maxIntensity"));
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(property.FindPropertyRelative("goOnTimer"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("goOffTimer"));
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            //make sure min <= max
            if(property.FindPropertyRelative("maxIntensity").floatValue < property.FindPropertyRelative("minIntensity").floatValue) {
                property.FindPropertyRelative("maxIntensity").floatValue = property.FindPropertyRelative("minIntensity").floatValue;
            }
            EditorGUILayout.Space(5);
        }
    }

    [CustomPropertyDrawer(typeof(LightIntensity))] 
    public class LightIntensityDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(property.FindPropertyRelative("minIntensity"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("maxIntensity"));
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(property.FindPropertyRelative("ChangeSpeed"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("StartIncreasing"));
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            //make sure min <= max
            if(property.FindPropertyRelative("maxIntensity").floatValue < property.FindPropertyRelative("minIntensity").floatValue) {
                property.FindPropertyRelative("maxIntensity").floatValue = property.FindPropertyRelative("minIntensity").floatValue;
            }
            EditorGUILayout.Space(5);
        }
    }

    [CustomPropertyDrawer(typeof(ColorGradientVariables))] 
    public class ColorGradientDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUILayout.PropertyField(property.FindPropertyRelative("colorGradient"));
            GUILayout.FlexibleSpace();
            EditorGUILayout.PropertyField(property.FindPropertyRelative("colorGradientSpeed"));
            GUILayout.FlexibleSpace();
            EditorGUILayout.PropertyField(property.FindPropertyRelative("reverse"));
            
            EditorGUILayout.Space();
            EditorGUILayout.Space();
        }
    }

    [CustomPropertyDrawer(typeof(ColorSwitchVariables))] 
    public class ColorSwitchDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUILayout.PropertyField(property.FindPropertyRelative("colors"));
            GUILayout.FlexibleSpace();
            EditorGUILayout.PropertyField(property.FindPropertyRelative("ColorSwitchTimer"));
            GUILayout.FlexibleSpace();
            EditorGUILayout.Space(5);
        }
    }
    
}



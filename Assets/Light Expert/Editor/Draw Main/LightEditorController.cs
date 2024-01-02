using UnityEditor;
using LightMaster;
using UnityEngine;

[CustomEditor(typeof(LightController))] [CanEditMultipleObjects]
public class LightEditorController : Editor {
    class DataPack {
        public string text = "Show Variables";
        public bool isVisible = false;
    }

    DataPack smoothSwitchingUIData = new DataPack();
    DataPack smmothIntensityUIData = new DataPack();
    DataPack colorGradientUIData = new DataPack();
    DataPack colorSwitchUIData = new DataPack();

    LightController lightController;
    public override void OnInspectorGUI() {
        serializedObject.Update();

        lightController = (LightController)target;
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Tag"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("LightType"));

        GUILayout.Space(5f);

        ColorGradientVariablesUI();

        GUILayout.Space(5f);

        ColorSwitchVariablesUI();

        GUILayout.Space(5f);

        SmoothIntensityVariablesUI();

        GUILayout.Space(5f);

        SmoothSwitchingVariablesUI();

        GUILayout.Space(5f);
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("EnableEvents"));

        switch (lightController.LightType) {
            case LightControllTypes.Timer:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("timerLightVariables"));
                break;
        }

        if(lightController.EnableEvents)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("events"));

        if(Application.isPlaying) {
            GUILayout.Space(5f);
            GUI.enabled = false; // disable (=> Grey & not usable)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("isBlocked"));
            GUI.enabled = true; // enable all variables from now on again
        }

        serializedObject.ApplyModifiedProperties();
    } 

    private void ColorSwitchVariablesUI() {
        if(lightController.ColorSwitch)
            EditorGUILayout.BeginHorizontal();  // Button "Show" and Checkbox

        if(!lightController.ColorGradient) {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ColorSwitch"));
        } else {
            GUI.enabled = false; // disable (=> Grey & not usable)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ColorSwitch"));
            GUI.enabled = true; // enable all variables from now on again
        }
            
        if(lightController.ColorSwitch) {
            if(GUILayout.Button(colorSwitchUIData.text)) {  // Draw Button for Variables
                colorSwitchUIData.isVisible = !colorSwitchUIData.isVisible;
                colorSwitchUIData.text = colorSwitchUIData.isVisible ?
                    "Hide Color Switch Variables" :
                    "Show Color Switch Variables";
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();    // Button "Show" and Checkbox

            if(colorSwitchUIData.isVisible) {   //if button true
                EditorGUILayout.PropertyField(serializedObject.FindProperty("colorSwitchVariables"));
            }
        }
    }

    private void ColorGradientVariablesUI() {
        if(lightController.ColorGradient)
            EditorGUILayout.BeginHorizontal();  // Button "Show" and Checkbox

        if(!lightController.ColorSwitch) {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ColorGradient"));
        } else {
            GUI.enabled = false; // disable (=> Grey & not usable)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ColorGradient"));
            GUI.enabled = true; // enable all variables from now on again
        }
            
        if(lightController.ColorGradient) {
            if(GUILayout.Button(colorGradientUIData.text)) {  // Draw Button for Variables
                colorGradientUIData.isVisible = !colorGradientUIData.isVisible;
                colorGradientUIData.text = colorGradientUIData.isVisible ?
                    "Hide Color Gradient Variables" :
                    "Show Color Gradient Variables";
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();    // Button "Show" and Checkbox

            if(colorGradientUIData.isVisible) {   //if button true
                EditorGUILayout.PropertyField(serializedObject.FindProperty("colorGradientVariables"));
            }
        }
    }

    private void SmoothIntensityVariablesUI() {
        if(lightController.SmoothIntensity)
            EditorGUILayout.BeginHorizontal();  // Button "Show" and Checkbox
        EditorGUILayout.PropertyField(serializedObject.FindProperty("SmoothIntensity"));

        if(lightController.SmoothIntensity) {
            if(GUILayout.Button(smmothIntensityUIData.text)) {  // Draw Button for Variables
                smmothIntensityUIData.isVisible = !smmothIntensityUIData.isVisible;
                smmothIntensityUIData.text = smmothIntensityUIData.isVisible ?
                    "Hide Smooth Intensity Change Variables" :
                    "Show Smooth Intensity Change Variables";
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();    // Button "Show" and Checkbox

            if(smmothIntensityUIData.isVisible) {   //if button true
                EditorGUILayout.PropertyField(serializedObject.FindProperty("intensityVariables"));
            }
        }
    }
    private void SmoothSwitchingVariablesUI() {
        if(lightController.SmoothSwitching)
            EditorGUILayout.BeginHorizontal();  // Button "Show" and Checkbox

        EditorGUILayout.PropertyField(serializedObject.FindProperty("SmoothSwitching")); // Draw the CheckBox

        if(lightController.SmoothSwitching) {
            if(GUILayout.Button(smoothSwitchingUIData.text)) {  // Draw Button for Variables
                smoothSwitchingUIData.isVisible = !smoothSwitchingUIData.isVisible;
                smoothSwitchingUIData.text = smoothSwitchingUIData.isVisible ?
                    "Hide Smooth Switching Variables" :
                    "Show Smooth Switching Variables";
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();    // Button "Show" and Checkbox

            if(smoothSwitchingUIData.isVisible) {   //if button true
                EditorGUILayout.PropertyField(serializedObject.FindProperty("smoothOnOffVariables"));
                
                if(Application.isPlaying) {
                    EditorGUILayout.BeginHorizontal();
                    if(GUILayout.Button("Test Smooth On")) {
                        lightController.TurnOnSmooth();
                    }
                    if(GUILayout.Button("Test Smooth Off")) {
                        lightController.TurnOffSmooth();
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
        }
    }
}

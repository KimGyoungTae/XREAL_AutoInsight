using UnityEditor;
using LightMaster;
using UnityEngine;
using System.Collections.Generic;
[CustomEditor(typeof(LightTagsContainer))]
[CanEditMultipleObjects]
public class LightEditorTagContainerDrawer : Editor { // draws the SO of the Tag Containers
    bool wasDrawn = false;
    public override void OnInspectorGUI () {
        serializedObject.Update();

        LightTagsContainer ltc = (LightTagsContainer)target;

        base.OnInspectorGUI(); // draw normal UI

        if(GUILayout.Button("Save")) {
            FindObjectOfType<LightManager>().OnValidate(); //save all changes manuelly
        }

        if(GUILayout.Button("Get All Tagged Lights")) {
            wasDrawn = true;
        }

        if(wasDrawn) {
            //get a Dict. with all Tags and GameObjects with LC-Components with that tag
            Dictionary<string, List<GameObject>> tagNamePair
                = FindObjectOfType<LightManager>().GetAllTaggedLights(ltc);

            GUIStyle style = new GUIStyle() { // create style for readability
                fontStyle = FontStyle.Bold,
                fontSize = 12
            };

            //loop through all Objects and display those
            foreach(KeyValuePair<string, List<GameObject>> pair in tagNamePair) {
                GUILayout.Label("<color=grey> Tag: " + pair.Key + " </color>", style); // create Label of the Tag
                GUILayout.BeginVertical();
                foreach(GameObject tag in pair.Value) { // List all of the GameObjects with the tag vertically
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    //show name of the object (hierachy name)
                    GUILayout.Label(tag.name + " : ");
                    //create reference to the object
                    GameObject x = (GameObject)EditorGUILayout.ObjectField("", tag, typeof(GameObject), false);
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndVertical();
            }

        }

        serializedObject.ApplyModifiedProperties();
    }
}

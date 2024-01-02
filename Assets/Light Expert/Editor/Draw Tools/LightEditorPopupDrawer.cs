using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace LightMaster {
    [CustomPropertyDrawer(typeof(ListPopupAttribute))]
    public class ListPopupDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            ListPopupAttribute atb = attribute as ListPopupAttribute;
            List<string> stringList = null; // list of tags

            if(atb.MyType.GetField(atb.PropertyName) != null) {
                // get string list from LightManager Script
                stringList = atb.MyType.GetField(atb.PropertyName).GetValue(atb.MyType) as List<string>;
            }

            //if List exists, show Popup -> user can select which tag to choose
            if(stringList != null && stringList.Count != 0) {
                int selectedIndex = Mathf.Max(stringList.IndexOf(property.stringValue), 0);
                selectedIndex = EditorGUI.Popup(position, property.name, selectedIndex, stringList.ToArray());
                property.stringValue = stringList[selectedIndex];
            } else {
                //else just show a string field
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }
}

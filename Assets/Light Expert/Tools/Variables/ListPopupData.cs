using UnityEngine;
using System;
namespace LightMaster {
    public class ListPopupAttribute : PropertyAttribute {
        /// <summary> Type of the script with the List named "PropertyName" </summary>
        public Type MyType;
        /// <summary> The Property name of the List that should be used </summary>
        public string PropertyName;

        /// <summary>
        /// Creates a Popup (string) which shows all setted strings in the corresponding list
        /// </summary>
        /// <param name="myType">Type of the script with the List named "PropertyName"</param>
        /// <param name="propertyName">The Property name of the List that should be used</param>
        public ListPopupAttribute(Type myType, string propertyName) {
            MyType = myType;
            PropertyName = propertyName;
        }
    }


}

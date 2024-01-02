using System.Collections.Generic;
using UnityEngine;

namespace LightMaster {
    [CreateAssetMenu(fileName = "Light Tags", menuName = "Tools/Light Tags")]
    [System.Serializable]
    public class LightTagsContainer : ScriptableObject {
        public List<string> Tags = new List<string>();
        
        private void OnEnable() {
            #region No Tags
            //if no tags used, add "Default"
            if(Tags.Count == 0)
                Tags.Add("Default");
            #endregion
        }
        private void OnValidate() {
            #region "All" Tags
            //warn user if creating "ALL" tag
            for(int i = 0; i < Tags.Count; i++) {
                if(Tags[i] == "ALL") {
                    Tags[i] = "all";
                    LightMasterConsole.SendWarning("Tag \"ALL\" is unavaible");
                }
            }
            #endregion

            #region No Tags
            //if no tags used, add "Default"
            if(Tags.Count == 0)
                Tags.Add("Default");
            #endregion

            #region Empty Tags 
            //if a Tag is Empty, add "Default"
            for(int i = 0; i < Tags.Count; i++) {
                if(Tags[i] == "") {
                    Tags[i] = "Default";
                }
            }
            #endregion
            #region Double Tags
            //if there are duplicates, numerate them
            //example: Default -> Default1 
            int counter = 0;
            for(int i = 0; i < Tags.Count; i++) {
                for(int j = i; j < Tags.Count; j++) {
                    if(Tags[i] == Tags[j]) {
                        counter++;
                        if(counter >= 2) {
                            int lastIndex = Tags[j].Length - 1;
                            if(int.TryParse(Tags[j][lastIndex].ToString(), out int res)) {
                                Tags[j] += (res + 1);
                            } else {
                                Tags[j] = Tags[j] + counter;
                            }
                        }
                    }
                }
                counter = 0;
            }
            #endregion
        }
    }
}


using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace LightMaster {
    [DisallowMultipleComponent]
    [AddComponentMenu("Light /Light Manager")]
    public class LightManager : MonoBehaviour {
        public List<LightTagsContainer> TagContainers;
        public static List<string> Tags = new List<string>();

        private List<LightController> _lights = new List<LightController>();
        private Dictionary<string, List<LightController>> _taggedLights = new Dictionary<string, List<LightController>>();
        public LightConsoleVariables ConsoleDesign;
        
        #region Light Tag Setup
        public void OnValidate() { // gets called as soon as Data in the inspector changes, or the "Save" button on a Tag container gets pressed
            Tags = new List<string>();
            Tags.Add("ALL");
            if(TagContainers != null)
                if(TagContainers.Count > 0)
                    foreach(LightTagsContainer container in TagContainers)
                        if(container != null)
                            foreach(string s in container.Tags)
                                Tags.Add(s);
   
            ConsoleDesign.SetColorsToString();
            LightMasterConsole.SetupConsole(ConsoleDesign);
        }
        
        private void Awake() { 
            Tags = new List<string>();
            Tags.Add("ALL");
            if(TagContainers.Count > 0) {
                foreach(LightTagsContainer container in TagContainers)
                    if(container != null)
                        foreach(string s in container.Tags)
                            Tags.Add(s);
            } else {
                LightMasterConsole.SendWarning("No Tags Selected!");
            }
        }
        
        /// <summary> Get a Dictionary of all Tags with LightControllers GameObjects </summary>
        /// <param name="sender">Sender used for Inspector GUI</param>
        /// <returns>Tags and corresponding Game Objects</returns>
        public Dictionary<string, List<GameObject>> GetAllTaggedLights(LightTagsContainer sender) {
            OnValidate();
            Dictionary<string, List<GameObject>> TagNamePair 
                = new Dictionary<string, List<GameObject>>();  
            _lights = FindObjectsOfType<LightController>().ToList();

            foreach(string s in sender.Tags) {
                if(!TagNamePair.ContainsKey(s)) {
                    TagNamePair.Add(s, new List<GameObject>());
                }
            }
            foreach(LightController lc in _lights) {
                if(TagNamePair.ContainsKey(lc.Tag)) {
                    TagNamePair[lc.Tag].Add(lc.gameObject);
                }
            }
            return TagNamePair;
        }
        #endregion

        private void Start() => SetupLights();

        private void SetupLights() {
            _lights = FindObjectsOfType<LightController>().ToList();

            foreach(string s in Tags) {
                if(!_taggedLights.ContainsKey(s)) {
                    _taggedLights.Add(s, new List<LightController>());
                } else {
                    LightMasterConsole.SendWarning("Tag: " + s + " is located multiple times. Only one gets added.");
                }
            }
            
            for(int i = 0; i < _lights.Count; i++) {
                _taggedLights["ALL"].Add(_lights[i]);
            }
           // _taggedLights.Add("ALL", _lights); // add a List of all lights in the Scene

            foreach(LightController lc in _lights) {
                if(_taggedLights.ContainsKey(lc.Tag)) {
                    _taggedLights[lc.Tag].Add(lc);
                }
            }
        }

        #region Toggle Value
       
        /// <summary> Toggle all LightControlls with a specific Tag </summary>
        /// <param name="LightTag">Tag of the Light to toggle</param>
        public void ToggleValue(string LightTag) {
            if(_taggedLights.ContainsKey(LightTag)) {
                foreach(LightController lc in _taggedLights[LightTag].ToList()) {
                    lc.Toggle();
                }
            } else {
                LightMasterConsole.SendWarning("Sorry, Tag: " + LightTag + " doesn't exist!");
            }
            LightMasterConsole.SendMessage("Tag: " + LightTag + " toggled!");
        }
        
        /// <summary> Toggle light of a specific LightController </summary>
        /// <param name="lc">Light Controller to be set</param>
        public void ToggleValue(LightController lc) {
            lc.Toggle();
        }
        
        /// <summary> Toggles a Random amount of all Lights in the Scene </summary>
        /// <param name="amount">Amount of lights to be toggled</param>
        public void ToggleValue(int amount) {
            for(int i = 0; i < amount && i < _lights.Count; i++) {
                int index = Random.Range(0, _lights.Count);
                _lights[index].Toggle();
            }
        }
        #endregion

        #region Set Value
        /// <summary> Set the Value of all LightControlls with a specific Tag </summary>
        /// <param name="LightTag">Tag to be Set</param>
        /// <param name="Value">Value to be Set <br> True => Lights On, False => Lights Off</br></param>
        public void SetValue(string LightTag, bool Value) {
            if(_taggedLights.ContainsKey(LightTag)) {
                foreach(LightController lc in _taggedLights[LightTag].ToList()) {
                    lc.SetValue(Value);
                }
            } else {
                LightMasterConsole.SendWarning("Sorry, Tag: " + LightTag + " doesn't exist!");
            }
        }

        /// <summary> Set the Value to a Specific LightController in the Scene </summary>
        /// <param name="lc">LightController to be Set</param>
        /// <param name="Value">Value to be Set <br> True => Lights On, False => Lights Off</br></param>
        public void SetValue(LightController lc, bool Value) {
            lc.SetValue(Value);
        }

        /// <summary> Sets the value to Random LightControlls in the Scene. </summary>
        /// <param name="amount">Amount of LightControlls to be set</param>
        /// <param name="value">Set true or false. If you pass in NULL this value is randomized aswell</param>
        public void SetValue(int amount, bool? value) {
            if(value.HasValue) {
                for(int i = 0; i < amount && i < _lights.Count; i++) {
                    int index = Random.Range(0, _lights.Count);
                    _lights[index].SetValue((bool)value);
                }
            } else {
                for(int i = 0; i < amount && i < _lights.Count; i++) {
                    int index = Random.Range(0, _lights.Count);
                    bool rnd = Random.Range(0, 2) == 0; // creates 1 or 0, if 0 => light on else light off
                    _lights[index].SetValue(rnd);
                }
            }
        }
        #endregion

        #region Block Lights
        /// <summary> Toggle the Block of all Lights from "LightTag" </summary>
        /// <param name="LightTag">Tag of the Toggled lights</param>
        public void Block(string LightTag) {
            if(!_taggedLights.ContainsKey(LightTag)) {
                LightMasterConsole.SendWarning("Sorry, Tag: " + LightTag + " doesn't exist!");
                return;
            }
            foreach(LightController lc in _taggedLights[LightTag]) {
                lc.ToggleBlockValue();
            }
        }
        
        /// <summary> Set blocked values of all lights Tagged with "LightTag" to a specific value </summary>
        /// <param name="LightTag">Tag of the set lights</param>
        /// <param name="BlockValue">Value of the Block</param>
        public void Block(string LightTag, bool BlockValue) {
            if(!_taggedLights.ContainsKey(LightTag)) {
                LightMasterConsole.SendWarning("Sorry, Tag: " + LightTag + " doesn't exist!");
                return;
            }
            foreach(LightController lc in _taggedLights[LightTag]) {
                lc.SetBlockValue(BlockValue);
            }
        }
        
        /// <summary> Set block value of a specific Light Controller </summary>
        /// <param name="lc">Light Controller to be set</param>
        /// <param name="value">Value of the block value to be set</param>
        public void Block(LightController lc, bool value) {
            lc.SetBlockValue(value);
        }
       
        /// <summary> Toggle a specific Light Controller </summary>
        /// <param name="lc">Light Controller to toggle</param>
        public void Block(LightController lc) {
            lc.ToggleBlockValue();
        }
       
        /// <summary> Block random Light Controllers </summary>
        /// <param name="amount">Amount of random toggels</param>
        public void Block(int amount) {
            for(int i = 0; i < amount && i < _lights.Count; i++) {
                int index = Random.Range(0, _lights.Count);
                _lights[index].ToggleBlockValue();
            }
        }
        #endregion

        #region Destroy Lights
        /// <summary> Destroy all lights of a special Tag </summary>
        /// <param name="Tag">Tag of the lights that should be destroyed</param>
        public void Destroy(string Tag) {
            if(!_taggedLights.ContainsKey(Tag)) {
                LightMasterConsole.SendWarning("Sorry, Tag: " + Tag + " doesn't exist!");
                return;
            } 
            foreach(LightController lc in _taggedLights[Tag].ToList()) {
                Destroy(lc.gameObject);
                _taggedLights[Tag].Remove(lc);
                _lights.Remove(lc);
            }
        }
       
        /// <summary> Destroy a specific gameobject </summary>
        /// <param name="Light">GameObject of this will be destroyed</param>
        public void Destroy(LightController Light) {
            string tag = Light.Tag; // Light Tag
            _taggedLights[tag].Remove(Light);
            _lights.Remove(Light);
            Destroy(Light.gameObject);
        }
      
        /// <summary> Destroy a Random amount of Lights in the Scene </summary>
        /// <param name="amount">Amount of lights to be destroyed</param>
        public void Destroy(int amount) {
            for(int i = 0; i < amount && i < _lights.Count; i++) {
                int index = Random.Range(0, _lights.Count);

                LightController lc = _lights[index];
                _taggedLights[lc.Tag].Remove(lc);
                _lights.Remove(lc);
                Destroy(lc.gameObject);
            }
        }
        #endregion


    }
}
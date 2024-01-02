using UnityEngine;
namespace LightMaster {
    [AddComponentMenu("Light 2D/Extras/Light Action")]
    public class LightAction : MonoBehaviour {
        public enum Actions {
            ToggleLight,
            SetLight,
       //     BlockLight,
            DestroyLight
        }
        public enum ActionsSelect {
            Tag,
            Reference,
            Random
        }
        /* Furture update
        public enum BlockSpecs {
            Set,
            Toggle
        } 
        */

        public Actions Action; // Action to be performed
        public ActionsSelect ActionOn; // What kind of objects should be affected
    //    public BlockSpecs Block; // if Action == Block, what kind of block

        [ListPopup(typeof(LightManager), "Tags")] [Tooltip("Tag of the Lights")]
        public string Tag;
        [Tooltip("Reference to LC-Component")]
        public LightController LightReference; 

        [Tooltip("The Value that should be set")]
        public bool SetValue; // Gets shown if Action == SetLight
        [Tooltip("How many Lights should get randomly picked")]
        public int RandomAmount; // Gets shown if  ActionOn == Random

        /// <summary> Performs the Action thats been set in the inspector </summary>
        public void PerformAction() {
            LightManager manager = FindObjectOfType<LightManager>();
            switch(Action) {
                #region Toggle
                case Actions.ToggleLight:
                    switch(ActionOn) {
                        case ActionsSelect.Tag:
                            manager.ToggleValue(Tag);
                            break;
                        case ActionsSelect.Reference:
                            manager.ToggleValue(LightReference);
                            break;
                        case ActionsSelect.Random:
                            manager.ToggleValue(RandomAmount);
                            break;

                    }
                    break;
                #endregion

                #region Set
                case Actions.SetLight:
                    switch(ActionOn) {
                        case ActionsSelect.Tag:
                            manager.SetValue(Tag, SetValue);
                            break;
                        case ActionsSelect.Reference:
                            manager.SetValue(LightReference, SetValue);
                            break;
                        case ActionsSelect.Random:
                            manager.SetValue(RandomAmount, SetValue);
                            break;
                    }
                    break;
                #endregion
                /*
                #region Block
                case Actions.BlockLight:
                    switch(ActionOn) {
                        case ActionsSelect.Tag:
                            if(Block == BlockSpecs.Set) {
                                manager.Block(Tag, SetValue);
                            } else {
                                manager.Block(Tag);
                            }
                            break;
                        case ActionsSelect.Reference:
                            if(Block == BlockSpecs.Set) {
                                manager.Block(LightReference, SetValue);
                            } else {
                                manager.Block(LightReference);
                            }
                            break;
                        case ActionsSelect.Random:
                            manager.Block(RandomAmount);
                            break;
                    }
                    break;
                #endregion
                */

                #region Destroy
                case Actions.DestroyLight:
                    switch(ActionOn) {
                        case ActionsSelect.Tag:
                            manager.Destroy(Tag);
                            break;
                        case ActionsSelect.Reference:
                            manager.Destroy(LightReference);
                            break;
                        case ActionsSelect.Random:
                            manager.Destroy(RandomAmount);
                            break;
                    }
                    break;
                #endregion
            }
        }
    }
}


using UnityEngine;

namespace LightMaster {
    // Example Script how you can implement a Light Switch
    public class LightSwitchController : MonoBehaviour {
        enum AxisToRotate {
            x,
            y,
            z
        }
        [SerializeField] [Tooltip("The Axis that should be rotated around")]
        private AxisToRotate _axisToRotate = AxisToRotate.x;

        [SerializeField] [Tooltip("Transform of the object that should be rotated")]
        private Transform _objectToRotate;

        [Min(0)] [SerializeField] [Tooltip("Rotation if the switch is turned on")]
        private float _switchOnRotation;
        
        [Min(0)] [SerializeField] [Tooltip("Rotation if the switch is turned off. " +
            "\nCan't be < 0, therefore instead of e.g. -45, use 315")]
        private float _switchOffRotation;

        [SerializeField] [Tooltip("Which Action should be performed on toggle (On and Off!)")]
        private LightAction _switchAction;
        
        public void ToggleSwitch() {
            //rotate object around given axis & amount
            if(_objectToRotate != null) {
                switch(_axisToRotate) {
                    case AxisToRotate.x:
                        if(_objectToRotate.eulerAngles.x == _switchOffRotation)
                            _objectToRotate.rotation = 
                                Quaternion.Euler(_switchOnRotation, _objectToRotate.eulerAngles.y, _objectToRotate.eulerAngles.z);
                        else
                            _objectToRotate.rotation = 
                                Quaternion.Euler(_switchOffRotation, _objectToRotate.eulerAngles.y, _objectToRotate.eulerAngles.z);
                        break;
                    case AxisToRotate.y:
                        if(_objectToRotate.eulerAngles.y == _switchOffRotation)
                            _objectToRotate.rotation = 
                                Quaternion.Euler(_objectToRotate.eulerAngles.x, _switchOnRotation, _objectToRotate.eulerAngles.z);
                        else
                            _objectToRotate.rotation = 
                                Quaternion.Euler(_objectToRotate.eulerAngles.x, _switchOffRotation, _objectToRotate.eulerAngles.z);
                        break;
                    case AxisToRotate.z:
                        if(_objectToRotate.eulerAngles.z == _switchOffRotation)
                            _objectToRotate.rotation = 
                                Quaternion.Euler(_objectToRotate.eulerAngles.x, _objectToRotate.eulerAngles.y, _switchOnRotation);
                        else
                            _objectToRotate.rotation = 
                                Quaternion.Euler(_objectToRotate.eulerAngles.x, _objectToRotate.eulerAngles.y, _switchOffRotation);
                        break;
                }
            }
            //perform action
            if(_switchAction != null)
                _switchAction.PerformAction();
        }
    }

}


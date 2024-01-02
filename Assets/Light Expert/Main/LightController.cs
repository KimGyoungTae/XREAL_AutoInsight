using System.Collections;
using UnityEngine;
using UnityEngine.Events;
namespace LightMaster {
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Light))]
    [HelpURL("https://www.google.com/")] /*
    !   ADD HELP URL!

    */
    [AddComponentMenu("Light /Light Controller")]
    public class LightController : MonoBehaviour {
        #region Variables
        [ListPopup(typeof(LightManager), "Tags")]
        public string Tag;

        [Tooltip("Default / Timer. Timer opens up Time based variable (for flickering, blinking lights etc.)")]
        public LightControllTypes LightType;

        [Tooltip("Enabled Status when pressing Play")]
        public bool DefaultEnabledState;

        [Tooltip("Current Attached Light2D")]
        private Light _thisLight;

        [Tooltip("Enables \"ColorGradientVariables\" field, used for lerping through Colors")]
        public bool ColorGradient;

        [Tooltip("Enables \"ColorSwitchVariables\" field, used for switching through Colors")]
        public bool ColorSwitch;

        [Tooltip("Enables \"LuminousGradientVariables\" field, used for setting the intensity higher/lower over time")]
        public bool SmoothIntensity;

        [Tooltip("Enables \"Smooth Turning On & Off Variables\" field, used for smoothly turning on and off the light")]
        public bool SmoothSwitching;

        [Tooltip("Enables Events")]
        public bool EnableEvents;

        [SerializeField] [Tooltip("If the Light is currently Blocked")]
        private bool isBlocked = false;

        #region Variable Groups
        [InspectorName("Timer")] [Tooltip("A collection of variables, controlling the timer")]
        public TimerLightVariables timerLightVariables;

        [InspectorName("Lerpes through Colors")] [Tooltip("A collection of variables, controlling the colors to lerp through")]
        public ColorGradientVariables colorGradientVariables;

        [InspectorName("Switches through Colors")] [Tooltip("A collection of variables, controlling the colors to switch through")]
        public ColorSwitchVariables colorSwitchVariables;

        [InspectorName("Intensity Change Variables")] [Tooltip("A collection of variables, controlling the Intensity change of the Light")]
        public LightIntensity intensityVariables;

        public SmoothTurnOnOff smoothOnOffVariables;

        [InspectorName("Events")] [Tooltip("A collection of events")]
        public Events events;
        #endregion

        #endregion

        private void Awake() {
            _thisLight = GetComponent<Light>();
            if(LightType == LightControllTypes.Timer)
                StartCoroutine(BeginTimer());

            if(SmoothIntensity)
                SmoothLuminousSetup();
            if(ColorSwitch)
                ColorSwitchSetup();
            if(SmoothSwitching)
                SmoothTurningSetup();

            if(ColorGradient)
                ColorGradientSetup();
        }

        
        private void FixedUpdate() {
            if(isBlocked) {
                if(_intensityTimerCache != 0)
                    _intensityTimerCache = _thisLight.intensity;
                _thisLight.intensity = 0;
                return;
            }
                

            if(ColorGradient)
                ColorGradientChange();
            if(ColorSwitch)
                ColorSwitchChange();
            if(SmoothIntensity)
                SmoothLuminousChange();

            if(isTurningOn)
                TurnOnSmoothCalc();
            if(isTurningOff)
                TurnOffSmoothCalc();
        }

        #region Color Gradient
        Gradient _gradient;
        private bool direction = true;
        private float _gradientSpeed, _gradientStatus = 0;
        private void ColorGradientChange() {
            if(direction) {
                _gradientStatus += _gradientSpeed * Time.fixedDeltaTime;
            } else {
                _gradientStatus -= _gradientSpeed * Time.fixedDeltaTime;
            }
            if(_gradientStatus > 1) {
                _gradientStatus = 1;
            } else if(_gradientStatus < 0) {
                _gradientStatus = 0;
            }

            _thisLight.color = _gradient.Evaluate(_gradientStatus);

            if(_gradientStatus >= 1) {
                if(colorGradientVariables.reverse) {
                    direction = false;
                } else {
                    _gradientStatus = 0;
                }
            } else if(_gradientStatus <= 0) {
                if(colorGradientVariables.reverse) {
                    direction = true;
                } else {
                    _gradientStatus = 1;
                }
            }
        }
        private void ColorGradientSetup() {
            _gradient = colorGradientVariables.colorGradient;
            _gradientSpeed = 1f / colorGradientVariables.colorGradientSpeed;
        }
        #endregion

        #region Color Switch
        private float _switchCounter = 0;
        private float _switchTimer;
        private int _switchColorIndex = 0;
        private void ColorSwitchChange() {
            _switchCounter += Time.fixedDeltaTime;
            if(_switchCounter >= _switchTimer) {
                _switchCounter = 0;
                _switchColorIndex++;
                if(_switchColorIndex < colorSwitchVariables.colors.Length) {
                    _thisLight.color = colorSwitchVariables.colors[_switchColorIndex];
                } else {
                    _switchColorIndex = 0;
                    _thisLight.color = colorSwitchVariables.colors[_switchColorIndex];
                }
            }
        }
        public void ColorSwitchSetup() {
            _switchTimer = colorSwitchVariables.ColorSwitchTimer;
        }

        #endregion

        #region Intensity
        private void SmoothLuminousSetup() {
            lMin = intensityVariables.minIntensity;
            lMax = intensityVariables.maxIntensity;
            lSpeed = intensityVariables.ChangeSpeed;
            dir = intensityVariables.StartIncreasing;
            float delta = lMax - lMin;
            float step = delta / lSpeed;
            lSpeedPerSeconds = step;
        }
        private float lMin, lMax, lSpeed;
        private float lSpeedPerSeconds;
        private bool dir = false; // false => min, true => max
        private void SmoothLuminousChange() {
            if(dir) {
                _thisLight.intensity += lSpeedPerSeconds * Time.fixedDeltaTime;
                if(_thisLight.intensity >= lMax)
                    dir = false;
            } else {
                _thisLight.intensity -= lSpeedPerSeconds * Time.fixedDeltaTime;
                if(_thisLight.intensity <= lMin)
                    dir = true;
            }
        }
        #endregion

        #region Smooth Turn On/Off
        private bool isTurningOn = false, isTurningOff = false;
        private float turnOnIntePSec = 0, turnOffIntePSec = 0;
        public void TurnOnSmooth () => isTurningOn = true;
        public void TurnOffSmooth() => isTurningOff = true;
        
        private void TurnOnSmoothCalc() {
            _thisLight.intensity += turnOnIntePSec * Time.fixedDeltaTime;
            if(_thisLight.intensity >= smoothOnOffVariables.maxIntensity) {
                isTurningOn = false;
                _thisLight.intensity = smoothOnOffVariables.maxIntensity;
            }    
        }
        private void TurnOffSmoothCalc() {
            _thisLight.intensity -= turnOffIntePSec * Time.fixedDeltaTime;
            if(_thisLight.intensity <= smoothOnOffVariables.minIntensity) {
                isTurningOff = false;
                _thisLight.intensity = smoothOnOffVariables.minIntensity;
            }   
        }

        private void SmoothTurningSetup() {
            turnOnIntePSec = smoothOnOffVariables.maxIntensity / smoothOnOffVariables.goOnTimer;
            turnOffIntePSec = smoothOnOffVariables.minIntensity + smoothOnOffVariables.maxIntensity / smoothOnOffVariables.goOffTimer;
        }

        
        #endregion

        #region Set Values
        public void SetValue(bool lightValue) {
            _thisLight.enabled = lightValue;
            SendEvent();
        }
        #endregion

        #region Set Toggle
        public void Toggle() {
            if(SmoothSwitching) {
                if(_thisLight.intensity == smoothOnOffVariables.maxIntensity) {
                    TurnOffSmooth();
                } else {
                    TurnOnSmooth();
                }
            } else {
                _thisLight.enabled = !_thisLight.enabled;
            }
            SendEvent();
        }
        #endregion

        #region Set Blocked
        public void SetBlockValue(bool blocked) {
            isBlocked = blocked;
        }

        public void ToggleBlockValue() {
            isBlocked = !isBlocked;
        }
        #endregion

        #region Send Events
        private void SendEvent() {
            if(EnableEvents) {
                if(_thisLight.enabled) {
                    events.OnLightsTurnedOn.Invoke();
                } else {
                    events.OnLightsTurnedOff.Invoke();
                }
            }
        }
        #endregion

        #region Timer IEnumerators
        private IEnumerator BeginTimer() {
            //       SendData(DefaultEnabledState);
            yield return new WaitForSeconds(timerLightVariables.StartDelay);
            _intensityTimerCache = _thisLight.intensity;
            StartCoroutine(Timer());
        }

        private float _intensityTimerCache;
        private IEnumerator Timer() {
            if(isBlocked) {
                yield return null;
                StartCoroutine(Timer());
            }

            float timerOn = timerLightVariables.TimerOnLength;
            float timerOff = timerLightVariables.TimerOffLength;
            if(timerLightVariables.Randomness) {
                timerOn += Random.Range(-timerLightVariables.RandomnessRange, timerLightVariables.RandomnessRange);
                timerOff += Random.Range(-timerLightVariables.RandomnessRange, timerLightVariables.RandomnessRange);
            }

            //_thisLight.enabled = true;
            _thisLight.intensity = _intensityTimerCache;
            _intensityTimerCache = _thisLight.intensity;
            yield return new WaitForSeconds(timerOn);

            //_thisLight.enabled = false;
            _thisLight.intensity = 0;
            yield return new WaitForSeconds(timerOff);
            StartCoroutine(Timer());
        }

        #endregion
    }
}


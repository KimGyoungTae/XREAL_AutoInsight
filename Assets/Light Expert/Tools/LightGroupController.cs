using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightMaster {
    [AddComponentMenu("Light /Light Group Controller")]
    public class LightGroupController : MonoBehaviour {
        [SerializeField] private List<Light> Lights = new List<Light>();

        private void OnValidate() {
            for(int i = 0; i < Lights.Count; i++) {
                if(Lights[i] != null) {
                    if(Lights[i].gameObject.TryGetComponent(out LightController lc)) {
                        Debug.LogWarning(gameObject.name + " is used for Light Group Controller, and Light Controller!");
                    }
                }
            }
        }
        #region Variables
        [Tooltip("Default / Timer. Timer opens up Time based variable (for flickering, blinking lights etc.)")]
        public LightControllTypes LightType;

        [Tooltip("Enabled Status when pressing Play")]
        public bool DefaultEnabledState;

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

        #region Variable Groups
        [InspectorName("Timer")]
        [Tooltip("A collection of variables, controlling the timer")]
        public TimerLightVariables timerLightVariables;

        [InspectorName("Lerpes through Colors")]
        [Tooltip("A collection of variables, controlling the colors to lerp through")]
        public ColorGradientVariables colorGradientVariables;

        [InspectorName("Switches through Colors")]
        [Tooltip("A collection of variables, controlling the colors to switch through")]
        public ColorSwitchVariables colorSwitchVariables;

        [InspectorName("Intensity Change Variables")]
        [Tooltip("A collection of variables, controlling the Intensity change of the Light")]
        public LightIntensity intensityVariables;

        public SmoothTurnOnOff smoothOnOffVariables;

        [InspectorName("Events")]
        [Tooltip("A collection of events")]
        public Events events;
        #endregion

        #endregion

        private void Awake() {
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
                

            Color clr = _gradient.Evaluate(_gradientStatus);
            foreach(Light l in Lights) { l.color = clr; }

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
                    foreach(Light l in Lights) {
                        l.color = colorSwitchVariables.colors[_switchColorIndex];
                    }
                } else {
                    _switchColorIndex = 0;
                    foreach(Light l in Lights) {
                        l.color = colorSwitchVariables.colors[_switchColorIndex];
                    }
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
                foreach(Light l in Lights) {
                    l.intensity += lSpeedPerSeconds * Time.fixedDeltaTime;
                }
                if(Lights[0].intensity >= lMax)
                    dir = false;
            } else {
                foreach(Light l in Lights) {
                    l.intensity -= lSpeedPerSeconds * Time.fixedDeltaTime;
                }
                if(Lights[0].intensity <= lMin)
                    dir = true;
            }
        }
        #endregion

        #region Smooth Turn On/Off
        private bool isTurningOn = false, isTurningOff = false;
        private float turnOnIntePSec = 0, turnOffIntePSec = 0;
        public void TurnOnSmooth() => isTurningOn = true;
        public void TurnOffSmooth() => isTurningOff = true;

        private void TurnOnSmoothCalc() {
            foreach(Light l in Lights) {
                l.intensity += turnOnIntePSec * Time.fixedDeltaTime;
            }
            if(Lights[0].intensity >= smoothOnOffVariables.maxIntensity) {
                isTurningOn = false;
                foreach(Light l in Lights) {
                    l.intensity = smoothOnOffVariables.maxIntensity;
                }
            }
        }
        private void TurnOffSmoothCalc() {
            foreach(Light l in Lights) {
                l.intensity -= turnOffIntePSec * Time.fixedDeltaTime;
            }
            if(Lights[0].intensity <= smoothOnOffVariables.minIntensity) {
                isTurningOff = false;
                foreach(Light l in Lights) {
                    l.intensity = smoothOnOffVariables.minIntensity;
                }
            }
        }

        private void SmoothTurningSetup() {
            turnOnIntePSec = smoothOnOffVariables.maxIntensity / smoothOnOffVariables.goOnTimer;
            turnOffIntePSec = smoothOnOffVariables.minIntensity + smoothOnOffVariables.maxIntensity / smoothOnOffVariables.goOffTimer;
        }


        #endregion

        #region Set & Toggle Values
        public void SetValue(bool lightValue) {
            foreach(Light l in Lights) {
                l.enabled = lightValue;
            }
            SendEvent();
        }

        public void Toggle() {
            if(SmoothSwitching) {
                if(Lights[0].intensity == smoothOnOffVariables.maxIntensity) {
                    TurnOffSmooth();
                } else {
                    TurnOnSmooth();
                }
            } else {
                foreach(Light l in Lights) {
                    l.enabled = !l.enabled;
                }
            }
            SendEvent();
        }

        private void SendEvent() {
            if(EnableEvents) {
                if(Lights[0].enabled) {
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
            _intensityTimerCache = Lights[0].intensity;
            StartCoroutine(Timer());
        }

        private float _intensityTimerCache;
        private IEnumerator Timer() {
            float timerOn = timerLightVariables.TimerOnLength;
            float timerOff = timerLightVariables.TimerOffLength;
            if(timerLightVariables.Randomness) {
                timerOn += Random.Range(-timerLightVariables.RandomnessRange, timerLightVariables.RandomnessRange);
                timerOff += Random.Range(-timerLightVariables.RandomnessRange, timerLightVariables.RandomnessRange);
            }
            foreach(Light l in Lights) {
                l.intensity = _intensityTimerCache;
            }
            _intensityTimerCache = Lights[0].intensity;
            yield return new WaitForSeconds(timerOn);
            foreach(Light l in Lights) {
                l.intensity = 0;
            }
            yield return new WaitForSeconds(timerOff);
            StartCoroutine(Timer());
        }
        #endregion
        public void SetLight(List<Light> newLights) {
            Lights = newLights;
        }
        public List<Light> GetLights() {
            return Lights;
        }
    }
}

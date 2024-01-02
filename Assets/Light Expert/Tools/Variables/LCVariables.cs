using UnityEngine;
using UnityEngine.Events;
namespace LightMaster {
    public enum LightControllTypes {
        /// <summary> Default, non timed Light </summary>
        Default,
        /// <summary> Timed Light, with different Variables </summary>
        Timer
    }


    #region Timer
    /// <summary> Variables of the Light Built in Timer </summary>
    [System.Serializable]
    public class TimerLightVariables {
        [Tooltip("Time the Light is enabled (in secs.)")]
        public float TimerOnLength;

        [Tooltip("Time the Light is dsiabled (in secs.)")]
        public float TimerOffLength;

        [Tooltip("Delay until the Timer starts (in secs.)")]
        public float StartDelay;

        [Tooltip("If the Delay/Timer should get randomized")]
        public bool Randomness;

        [Tooltip("Randomizes the Light (in secs.)")]
        public float RandomnessRange;
    }
    #endregion
    

    #region Color Gradient
    /// <summary> Variables of the Color Gradient Option </summary>
    [System.Serializable]
    public class ColorGradientVariables {
        [Tooltip("Color Gradient that should be used")]
        public Gradient colorGradient;

        [Tooltip("Speed of Colors in seconds")]
        [Min(0)] public float colorGradientSpeed;

        [Tooltip("If the Gradient should go backwards as soon as it reaches the end")]
        public bool reverse;
    }
    #endregion


    #region Color Switch
    [System.Serializable]
    public class ColorSwitchVariables {
        [Tooltip("Colors that should be changed through")]
        public Color[] colors;

        [Tooltip("Time in seconds before the next color will appear")] [Min(0f)]
        public float ColorSwitchTimer;
    }
    #endregion


    #region Intensity
    /// <summary> Variables of the Light Intensity Change </summary>
    [System.Serializable]
    public class LightIntensity {
        [Tooltip("Intensity")] [Min(0)]
        public float minIntensity;

        [Tooltip("Intensity")]
        public float maxIntensity;

        [Tooltip("Intensity change from max to min / min to max (in secs.)")]
        [Range(0, 10f)] public float ChangeSpeed;

        [Tooltip("If the Intenstiy should start Increasing (true) or Decreasing (false) on Start")]
        public bool StartIncreasing;
    }
    #endregion


    #region Smooth Turn On/Off
    /// <summary> Variables of the Light smoothly turning On/Off </summary>
    [System.Serializable]
    public class SmoothTurnOnOff {
        [Tooltip("On Timer")] [Min(0)]
        public float goOnTimer;

        [Tooltip("Off Timer")] [Min(0)]
        public float goOffTimer;

        [Min(0)] [Tooltip("The Min/target intensity")]
        public float minIntensity;

        [Tooltip("The max/target intensity")]
        public float maxIntensity;
    }
    #endregion


    #region Events
    [System.Serializable]
    public class Events {
        [Tooltip("All events that should get called, as soon as the Lights turn on")]
        public UnityEvent OnLightsTurnedOn;
        [Tooltip("All events that should get called, as soon as the Lights turn off")]
        public UnityEvent OnLightsTurnedOff;
    }
    #endregion


}
using UnityEngine;

namespace LightMaster {
    /// <summary> Extended Console with extra variables, espacially for debugging "Light Master" functions </summary>
    public class LightMasterConsole {
        private static LightConsoleVariables variables; // variables (color, prefix etc.) that should be used
        // set up the console with the correct variables
        public static void SetupConsole(LightConsoleVariables var) { 
            variables = var;
        }
        /// <summary> Send a normal Debug.Log message  </summary>
        /// <param name="message">Message that should be printed</param>
        public static void SendMessage(string message) {
            if(!variables.showLog)
                return;

            message = EditString(message);
            Debug.Log(message);
        }
        /// <summary> Send a Debug.LogWarning message  </summary>
        /// <param name="message">Message that should be printed</param>
        public static void SendWarning(string message) {
            if(!variables.showWarning)
                return;

            message = EditString(message);
            Debug.LogWarning(message);
        }
        /// <summary> Send a Debug.LogError message  </summary>
        /// <param name="message">Message that should be printed</param>
        public static void SendError(string message) {
            if(!variables.showError)
                return;

            message = EditString(message);
            Debug.LogError(message);
        }

        // Edits the message, by adding the color and the prefix
        private static string EditString(string originalMessage) {
            string result = "";
            if(variables.showPrefix)
                result = variables.prefixClrStr + variables.prefixText + "</color>";
            result += variables.textClrStr + originalMessage + "</color>";
            return result;
        }
    }


    [System.Serializable]
    public class LightConsoleVariables {
        [Tooltip("Prefix")]
        public string prefixText = "";
        [Tooltip("Color of the Prefix")]
        public Color prefixColor = Color.white;
        [Tooltip("Color of the Main Text")]
        public Color textColor = Color.white;
        
        [Tooltip("Enables if the Log should be shown")]
        public bool
            showPrefix = false,
            showLog = false,
            showWarning = false,
            showError = false;

        /// <summary> String format of the Colors Hexadecimal (without Alpha) </summary>
        public string prefixClrStr, textClrStr;
        // Sets the Colors to strings in:
        // <color=[hex code of color]>
        public void SetColorsToString() { 
            prefixClrStr = ColorUtility.ToHtmlStringRGB(prefixColor);
            prefixClrStr = "<color=#" + prefixClrStr + ">";
            textClrStr = ColorUtility.ToHtmlStringRGB(textColor);
            textClrStr = "<color=#" + textClrStr + ">";
        }
    }
}


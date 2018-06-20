using UnityEditor;
using UnityEngine;

namespace WebVR.Editor
{
    [InitializeOnLoad]
    public class WebVRSettingsWindow : EditorWindow
    {
        static WebVRSettingsWindow window;

        static WebVRSettingsWindow()
        {
            EditorApplication.update += Update;
        }

        static void Update()
        {
            
            if (!PlayerSettings.virtualRealitySupported)
            {
                window = GetWindow<WebVRSettingsWindow>(true);                               
            
                window.minSize = new Vector2(320, 440);
                window.title = "WebVR Settings";
            }
            
            EditorApplication.update -= Update;
        }

        private void OnGUI()
        {
            if(PlayerSettings.virtualRealitySupported)
            {
                GUILayout.Label("PlayerSettings.VRSupported is enabled");
            }
 
            
            EditorGUILayout.HelpBox("Recommended project settings for WebVR:", MessageType.Warning);

            if (!PlayerSettings.virtualRealitySupported)                   
            {
                if (GUILayout.Button("Enable PlayerSettings.VRSupported to test in Editor"))
                {
                    PlayerSettings.virtualRealitySupported = true;
                    
                    Debug.Log("Virtual Reality Enabled");
                }
            }
        }
    }
}
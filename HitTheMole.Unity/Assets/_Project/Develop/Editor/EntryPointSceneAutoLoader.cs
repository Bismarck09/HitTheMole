using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace _Project.Develop.Editor
{
    [InitializeOnLoad]
    public static class EntryPointSceneAutoLoader
    {
        static EntryPointSceneAutoLoader()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.ExitingEditMode)
                return;

            string sceneName = SceneManager.GetActiveScene().name;
            EditorSceneManager.playModeStartScene = sceneName is "Gameplay" or "MainMenu" ? FindStartScene() : null;
        }

        private static SceneAsset FindStartScene()
        {
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (scene.enabled && Path.GetFileNameWithoutExtension(scene.path) == "Bootstrap")
                    return AssetDatabase.LoadAssetAtPath<SceneAsset>(scene.path);
            }

            return null;
        }
    }
}

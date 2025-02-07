using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.IO;
using System.Linq;

public class DynamicSceneSwitcher : EditorWindow
{
    private Vector2 scrollPosition;
    private string[] scenePaths;

    [MenuItem("Tools/Dynamic Scene Switcher")]
    public static void ShowWindow()
    {
        // Create the UI
		GetWindow<DynamicSceneSwitcher>("Scene Switcher");
	}

	private void RefreshSceneList()
    {
        // Get All Scenes in the Project
		scenePaths = AssetDatabase.FindAssets("t:Scene").Select(AssetDatabase.GUIDToAssetPath).ToArray();
	}

    private void OnGUI()
    {
		RefreshSceneList();

		GUILayout.Label("All scenes in the project:", EditorStyles.boldLabel);

        if (GUILayout.Button("Refresh scenes list"))
        {
            RefreshSceneList();
        }

        if (scenePaths == null || scenePaths.Length == 0)
        {
			GUILayout.Label("No scene found");
			return;
		}

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        foreach (string scenePath in scenePaths)
        {
            if (GUILayout.Button(Path.GetFileNameWithoutExtension(scenePath)) && EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
				EditorSceneManager.OpenScene(scenePath);
			}
        }

        EditorGUILayout.EndScrollView();
    }
}
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine.SceneManagement;

public static class SceneEnumGenerator
{
	private const string EnumFilePath = "Assets/Game/Scripts/Container/ScenesEnum.cs";

	[MenuItem("Tools/Generate Scenes Enum")]
	public static void GenerateScenesEnum()
	{
		// Get all scene paths in the build settings
		int sceneCount = SceneManager.sceneCountInBuildSettings;
		string[] scenes = new string[sceneCount];
		for (int i = 0; i < sceneCount; i++)
		{
			scenes[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
		}

		// Start creating the enum code
		string enumCode = "public enum ScenesName\n{\n    " + string.Join(",\n    ", scenes.Select(sceneName => sceneName.Replace(" ", "_").Replace("-", "_"))) + "\n}";

		// Ensure directory exists and write the enum code to a C# file
		Directory.CreateDirectory(Path.GetDirectoryName(EnumFilePath));
		File.WriteAllText(EnumFilePath, enumCode);

		// Refresh Unity AssetDatabase 
		AssetDatabase.Refresh();
	}
}
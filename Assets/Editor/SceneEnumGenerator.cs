using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine.SceneManagement;

public static class SceneEnumGenerator
{
	private const string EnumFilePath = "Assets/Game/Scripts/Container/SceneEnum.cs";

	[MenuItem("Tools/Generate Scene Enum")]
	public static void GenerateSceneEnum()
	{
		// Get all scene paths in the build settings
		int sceneCount = SceneManager.sceneCountInBuildSettings;
		string[] scenePaths = new string[sceneCount];
		for (int i = 0; i < sceneCount; i++)
		{
			scenePaths[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
		}

		// Start creating the enum code
		string enumCode = "public enum SceneName\n{\n    " + string.Join(",\n    ", scenePaths.Select(sceneName => sceneName.Replace(" ", "_").Replace("-", "_"))) + "\n}";

		// Ensure directory exists and write the enum code to a C# file
		Directory.CreateDirectory(Path.GetDirectoryName(EnumFilePath));
		File.WriteAllText(EnumFilePath, enumCode);

		// Refresh Unity AssetDatabase 
		AssetDatabase.Refresh();
	}
}
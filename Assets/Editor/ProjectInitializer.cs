using UnityEditor;
using UnityEngine;
using System.IO;

[InitializeOnLoad]
public static class ProjectInitializer
{
    static ProjectInitializer()
    {
        string rootFolder = $"Game";

		// List of subfolders to create
		string[] folders = new string[]
        {
            rootFolder,

            $"{rootFolder}/Animations",

            $"{rootFolder}/Arts",
            $"{rootFolder}/Arts/Sprites",
            
            $"{rootFolder}/Audio",
            $"{rootFolder}/Audio/Musics",
            $"{rootFolder}/Audio/SFX",

            $"{rootFolder}/Inputs",

            $"{rootFolder}/Prefabs",
            $"{rootFolder}/Prefabs/UI",
            $"{rootFolder}/Prefabs/Managers",

            $"{rootFolder}/Scenes",
            $"{rootFolder}/Scenes/Block Out",

            $"{rootFolder}/ScriptableObjects",
            $"{rootFolder}/ScriptableObjects/RSE",
            $"{rootFolder}/ScriptableObjects/RSO",
            $"{rootFolder}/ScriptableObjects/SSO",
            $"{rootFolder}/ScriptableObjects/Template",

            $"{rootFolder}/Scripts",
            $"{rootFolder}/Scripts/RSE",
            $"{rootFolder}/Scripts/RSO",
            $"{rootFolder}/Scripts/SSO",
            $"{rootFolder}/Scripts/UI",

            $"ScriptTemplates",
        };

		// Check if the root folder already exists; if not, create all the subfolders
		string rootPath = Path.Combine(Application.dataPath, rootFolder);

        if (!Directory.Exists(rootPath))
        {
			Directory.CreateDirectory(rootPath);

			foreach (var folder in folders)
			{
				string folderPath = Path.Combine(Application.dataPath, folder);

				if (!Directory.Exists(folderPath))
				{
					Directory.CreateDirectory(folderPath);
				}
			}

			// Refresh Unity AssetDatabase 
			AssetDatabase.Refresh();
		}
    }
}

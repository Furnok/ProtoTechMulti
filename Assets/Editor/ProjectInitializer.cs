using UnityEditor;
using UnityEngine;
using System.IO;

[InitializeOnLoad]
public static class ProjectInitializer
{
    static ProjectInitializer()
    {
        // Vérifie si la structure de base existe déjà
        if (Directory.Exists(Application.dataPath + "/Game")) return;

        string rootFolder = $"Game";

        // Liste des dossiers à créer
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

        // Création des dossiers s'ils n'existent pas déjà
        foreach (string folder in folders)
        {
            string folderPath = Path.Combine(Application.dataPath, folder);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        // Forcer Unity à rafraîchir l'AssetDatabase
        AssetDatabase.Refresh();
    }
}

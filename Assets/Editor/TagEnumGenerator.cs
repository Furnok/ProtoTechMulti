using System.IO;
using System.Linq;
using UnityEditor;

public static class TagEnumGenerator
{
    private const string EnumFilePath = "Assets/Game/Scripts/Container/TagsEnum.cs";

    [MenuItem("Tools/Generate Tags Enum")]
    public static void GenerateTagsEnum()
    {
        string[] tags = UnityEditorInternal.InternalEditorUtility.tags;

        // Start creating the enum code
        string enumCode = "public enum TagsName\n{\n    " + string.Join(",\n    ", tags.Select(tags => tags.Replace(" ", "_").Replace("-", "_"))) + "\n}";

        // Ensure directory exists and write the enum code to a C# file
        Directory.CreateDirectory(Path.GetDirectoryName(EnumFilePath));
        File.WriteAllText(EnumFilePath, enumCode);

        // Refresh Unity AssetDatabase 
        AssetDatabase.Refresh();
    }
}

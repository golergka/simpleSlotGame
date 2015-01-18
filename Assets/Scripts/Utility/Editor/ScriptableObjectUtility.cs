using System.IO;
using UnityEngine;
using UnityEditor;

public class ScriptableObjectUtility
{
	public static void CreateAsset<T> ()
		where T : ScriptableObject
	{
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		if (path == "")
		{
			path = "Assets";
		}
		else if (Path.GetExtension(path) != "")
		{
			path = path.Replace(Path.GetFileName(path), "");
		}

		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).ToString() + ".asset");

		CreateAssetAtPath<T>(assetPathAndName);
	}

	public static T CreateAssetAtPath<T>(string _Path)
		where T : ScriptableObject
	{
		var asset = ScriptableObject.CreateInstance<T>();
		AssetDatabase.CreateAsset(asset, _Path);
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
		return asset;
	}
}

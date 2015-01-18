using UnityEngine;
using UnityEditor;
using System.Collections;

public class CellTypeAsset
{
	[MenuItem("Assets/Create/CellType")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<CellType>();
	}
}

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;
using System.IO;

public class CellTypeAsset
{
	[MenuItem("Assets/Create/CellType")]
	public static void CreateCellType()
	{
		ScriptableObjectUtility.CreateAsset<CellType>();
	}
}

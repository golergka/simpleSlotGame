using UnityEngine;
using UnityEditor;
using System.Collections;

public class CombinationTypeAsset
{
	[MenuItem("Assets/Create/CombinationType")]
	public static void CreateCombinationType()
	{
		ScriptableObjectUtility.CreateAsset<CombinationType>();
	}
}

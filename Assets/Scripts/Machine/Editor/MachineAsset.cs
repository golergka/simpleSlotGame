using UnityEngine;
using UnityEditor;
using System.Collections;

public class MachineAsset
{
	[MenuItem("Assets/Create/Machine")]
	public static void CreateMachine()
	{
		ScriptableObjectUtility.CreateAsset<Machine>();
	}
}

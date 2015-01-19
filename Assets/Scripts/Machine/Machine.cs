using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Machine : ScriptableObject
{
	public int						ReelCount;
	public int						CellCount;
	public List<Line>				Lines;
	public List<CellType>			CellTypes;
	public List<CombinationType>	CombinationTypes;

	public IEnumerable<Line> TakeLines(int _Amount)
	{
		for(int i = 0; i < _Amount; i++)
		{
			yield return Lines[i];
		}
	}
}

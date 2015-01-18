using System;
using System.Collections.Generic;

[Serializable]
public class Machine
{
	public int						ReelCount;
	public int						CellCount;
	public List<Line>				Lines;
	public List<CellType>			CellTypes;
	public List<CombinationType>	CombinationTypes;
}

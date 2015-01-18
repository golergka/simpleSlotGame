using System;
using System.Collections.Generic;

public class Combination
{
	internal Combination(
			CombinationType		_Type,
			IEnumerable<Cell>	_Cells
		)
	{
		Type = _Type;
		Cells = _Cells;
	}

	public readonly IEnumerable<Cell>	Cells;
	public readonly CombinationType		Type;
}

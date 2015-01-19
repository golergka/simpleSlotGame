using System;

public class Cell
{
	public Cell(
			int			_ReelNumber,
			int			_CellNumber,
			CellType	_Type
		)
	{
		ReelNumber = _ReelNumber;
		CellNumber = _CellNumber;
		Type	= _Type;
	}

	public readonly int			ReelNumber;
	public readonly int			CellNumber;
	public readonly CellType	Type;

	public override string ToString()
	{
		return ReelNumber + " : " + CellNumber;
	}

}

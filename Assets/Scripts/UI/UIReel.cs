using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIReel : MonoBehaviour
{
	#region Configuration

	public UICell CellPrefab;

	#endregion

	#region Current state

	List<UICell> m_Cells = new List<UICell>();

	#endregion

	#region Public interface

	public void FillReel(Reel _Reel)
	{
		for(int i = 0; i < _Reel.Cells.Count; i++)
		{
			CreateCell(_Reel.Cells[i], i, _Reel.Cells.Count);
		}
	}

	#endregion

	#region Service methods

	void CreateCell(Cell _Cell, int _Index, int _MaxIndex)
	{
		var cell = (UICell) Instantiate(CellPrefab, Vector3.zero, Quaternion.identity);
		cell.transform.SetParent(transform, false);
		m_Cells.Add(cell);

		var cellTransform = (RectTransform) cell.transform;
		cellTransform.anchorMin = new Vector2(0, (float) _Index / _MaxIndex);
		cellTransform.anchorMax = new Vector2(1, (1 + (float) _Index) / _MaxIndex);
	}

	#endregion
}

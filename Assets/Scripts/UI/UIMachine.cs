using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class UIMachine : MonoBehaviour
{

	#region Configuration

	public UICell CellPrefab;

	#endregion

	#region Current state

	Dictionary<Cell, UICell> m_Cells = new Dictionary<Cell, UICell>();

	#endregion

	#region Animations

	public void PresentSpin(Spin _Spin)
	{
		foreach(var r in m_Cells.Values)
		{
			Destroy(r.gameObject);
		}
		m_Cells.Clear();
		for(int i = 0; i < _Spin.Reels.Count; i++)
		{
			CreateReel(_Spin.Reels[i], i, _Spin.Reels.Count);
		}
		//StartCoroutine(ShowWinnersCoroutine(_Spin.CombinationsWon));
	}

	void CreateReel(Reel _Reel, int _Index, int _MaxIndex)
	{
		for(int i = 0; i < _Reel.Cells.Count; i++)
		{
			var cell = (UICell) Instantiate(CellPrefab, Vector3.zero, Quaternion.identity);
			cell.transform.SetParent(transform, false);

			var cellTransform = (RectTransform) cell.transform;
			cellTransform.anchorMin = new Vector2((float) _Index / _MaxIndex, (float)i / _Reel.Cells.Count);
			cellTransform.anchorMax = new Vector2((float)(_Index + 1) / _MaxIndex, (float)(i + 1) / _Reel.Cells.Count);

			cell.Cell = _Reel.Cells[i];
			m_Cells[_Reel.Cells[i]] = cell;
		}
	}

	#endregion
}

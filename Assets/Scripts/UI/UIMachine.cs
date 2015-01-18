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

	List<UICell>	m_Cells;

	#endregion

	#region Animations

	IEnumerator PresentSpin(Spin _Spin)
	{
		var clear = ClearSpin();
		while (clear.MoveNext()) { yield return clear.Current; }

		var field = FillField(_Spin.Reels);
		while(field.MoveNext()) { yield return field.Current; }

		foreach(var u in m_Cells)
		{
			u.AnimateWin();
		}
	}

	IEnumerator ClearSpin()
	{
		return null;
	}

	IEnumerator FillField(ReadOnlyCollection<Reel> _Reels)
	{
		for(int i = 0; i < _Reels.Count; i++)
		{
			var reel = FillReel(_Reels[i], i);
			while(reel.MoveNext())
			{
				yield return reel.Current;
			}
		}
	}

	IEnumerator FillReel(Reel _Reel, int _ReelIndex)
	{
		for(int i = 0; i < _Reel.Cells.Count; i++)
		{
			var cell = FillCell(_Reel.Cells[i], _ReelIndex, i);
			while(cell.MoveNext())
			{
				yield return cell.Current;
			}
		}
	}

	IEnumerator FillCell(Cell _Cell, int _ReelIndex, int _CellIndex)
	{
		return null;
	}

	#endregion
}

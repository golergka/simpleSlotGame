using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class UIMachine : MonoBehaviour
{

	#region Configuration

	public UIReel ReelPrefab;

	#endregion

	#region Current state

	List<UIReel>	m_Reels = new List<UIReel>();

	#endregion

	#region Animations

	public void PresentSpin(Spin _Spin)
	{
		foreach(var r in m_Reels)
		{
			Destroy(r.gameObject);
		}
		m_Reels.Clear();
		for(int i = 0; i < _Spin.Reels.Count; i++)
		{
			CreateReel(_Spin.Reels[i], i, _Spin.Reels.Count);
		}
		StartCoroutine(ShowWinnersCoroutine(_Spin.CombinationsWon));
	}

	void CreateReel(Reel _Reel, int _Index, int _MaxIndex)
	{
		var reel = (UIReel) Instantiate(ReelPrefab, Vector3.zero, Quaternion.identity);
		reel.transform.SetParent(transform, false);
		m_Reels.Add(reel);

		var reelTransform = (RectTransform) reel.transform;
		reelTransform.anchorMin = new Vector2((float)_Index / _MaxIndex, 0);
		reelTransform.anchorMax = new Vector2((1 + (float) _Index) / _MaxIndex, 1);

		reel.FillReel(_Reel);
	}

	IEnumerator ShowWinnersCoroutine(ReadOnlyCollection<Combination> _Combinations)
	{
		foreach(var combination in _Combinations)
		{
			foreach(var cell in combination.Cells)
			{
				var uiCell = UICell.GetCell(cell);
				uiCell.ShowWinner(1f);
			}
			yield return new WaitForSeconds(1f);
		}
	}

	#endregion
}

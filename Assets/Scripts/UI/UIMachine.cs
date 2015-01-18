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

	void PresentSpin(Spin _Spin)
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
	}

	void CreateReel(Reel _Reel, int _Index, int _MaxIndex)
	{
		var reel = (UIReel) Instantiate(ReelPrefab, Vector3.zero, Quaternion.identity);
		reel.transform.SetParent(transform, false);
		m_Reels.Add(reel);

		var reelTransform = (RectTransform) reel.transform;
		reelTransform.anchorMin = new Vector2(_Index / _MaxIndex, 0);
		reelTransform.anchorMax = new Vector2((1 + _Index) / _MaxIndex, 1);
	}

	#endregion
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UICell : MonoBehaviour
{
	#region Configuration

	public Image Image;
	public Image Background;

	public Color UsualBackground;
	public Color HighlightBackground;

	#endregion

	#region Target

	Cell m_Cell;
	public Cell Cell
	{
		get { return m_Cell; }
		set
		{
			m_Cell = value;
			Image.sprite = value.Type.Image;
		}
	}

	#endregion

	#region Animations

	public void ShowWinner(float _Seconds)
	{
		var c = ShowWinnerCoroutine(_Seconds);
		StartCoroutine(c);
	}

	IEnumerator ShowWinnerCoroutine(float _Seconds)
	{
		var color = Background.color;
		var a = color.a;
		color.a = 1f;
		Background.color = color;
		yield return new WaitForSeconds(_Seconds);
		color.a = a;
		Background.color = color;
	}

	bool m_Highlight;
	public bool Highlight
	{
		get { return m_Highlight; }
		set
		{
			Background.color = value ? HighlightBackground : UsualBackground;
			m_Highlight = value;
		}
	}

	#endregion

}

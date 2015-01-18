using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UICell : MonoBehaviour
{
	#region Static UICell directory

	static Dictionary<Cell, UICell> m_Cells = new Dictionary<Cell, UICell>();

	public static UICell GetCell(Cell _Cell)
	{
		return (m_Cells.ContainsKey(_Cell) ? m_Cells[_Cell] : null);
	}

	#endregion

	#region Configuration

	public Image Image;
	public Image Background;

	#endregion

	#region Target

	Cell m_Cell;
	public Cell Cell
	{
		get { return m_Cell; }
		set
		{
			if (m_Cell != null)
			{
				m_Cells.Remove(m_Cell);
			}
			m_Cell = value;
			Image.sprite = value.Type.Image;
			if (value != null)
			{
				m_Cells[value] = this;
			}
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

	#endregion

	#region Engine methods

	void OnDestroy()
	{
		if (m_Cell != null)
		{
			m_Cells.Remove(m_Cell);
		}
	}

	#endregion
}

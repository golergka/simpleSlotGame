using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(RectTransform))]
public class UICell : MonoBehaviour
{
	#region Configuration

	public Image Image;
	public Image Background;

	public Color UsualBackground;
	public Color HighlightBackground;

	public Vector2	PutOffset;
	public float	PutTime;

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

	public IEnumerator PutCell()
	{
		var rectTransform = (RectTransform) transform;
		rectTransform.anchoredPosition = PutOffset;
		var finishTime = Time.time + PutTime;
		do
		{
			yield return new WaitForEndOfFrame();
			rectTransform.anchoredPosition += -PutOffset * (Time.deltaTime / PutTime);
		}
		while(Time.time < finishTime);
		rectTransform.anchoredPosition = Vector2.zero;
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

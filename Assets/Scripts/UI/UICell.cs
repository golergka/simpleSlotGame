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
	public Vector2	PutRandom;
	public float	PutTime;

	public Vector2	DropOffset;
	public Vector2	DropRandom;
	public float	DropDelay;
	public float	DropTime;

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
		var putOffset = new Vector2(
				PutOffset.x + Random.Range(-PutRandom.x, PutRandom.x),
				PutOffset.y + Random.Range(-PutRandom.y, PutRandom.y)
			);
		rectTransform.anchoredPosition = putOffset;
		var finishTime = Time.time + PutTime;
		do
		{
			yield return new WaitForEndOfFrame();
			rectTransform.anchoredPosition += -putOffset * (Time.deltaTime / PutTime);
		}
		while(Time.time < finishTime);
		rectTransform.anchoredPosition = Vector2.zero;
	}

	public void DropCell()
	{
		StartCoroutine(DropCellCoroutine());
	}

	IEnumerator DropCellCoroutine()
	{
		yield return new WaitForSeconds(Random.Range(0f, DropTime));
		var rectTransform = (RectTransform) transform;
		var dropOffset = new Vector2(
				DropOffset.x + Random.Range(-DropRandom.x, DropRandom.x),
				DropOffset.y + Random.Range(-DropRandom.y, DropRandom.y)
			);
		var finishTime = Time.time + DropTime;
		do
		{
			yield return new WaitForEndOfFrame();
			rectTransform.anchoredPosition += dropOffset * (Time.deltaTime / DropTime);
		}
		while(Time.time < finishTime);
		Destroy(gameObject);
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

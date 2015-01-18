using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICell : MonoBehaviour
{
	#region Public interface

	Cell m_Cell;
	public Cell Cell
	{
		get { return m_Cell; }
		set
		{
			m_Cell = value;
			GetComponent<Image>().sprite = value.Type.Image;
		}
	}

	#endregion
}

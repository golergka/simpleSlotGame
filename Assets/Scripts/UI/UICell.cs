using UnityEngine;
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
			throw new System.NotImplementedException();
		}
	}

	#endregion

	#region Animations

	public void AnimateWin()
	{
		throw new System.NotImplementedException();
	}

	#endregion
}

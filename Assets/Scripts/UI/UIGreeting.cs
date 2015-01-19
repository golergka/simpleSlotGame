using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class UIGreeting : MonoBehaviour
{
	#region Helper properties

	Animator m_Animator;
	Animator Animator
	{
		get
		{
			if (m_Animator == null)
			{
				m_Animator = GetComponent<Animator>();
			}
			return m_Animator;
		}
	}

	#endregion

	#region Configuration

	public Text Text;
	public Game Game;

	#endregion

	#region Engine methods

	void Start()
	{
		Game.OnSpin += delegate(Spin _Spin)
		{
			Animator.SetInteger("TotalWin", _Spin.TotalWin);
			Text.text = _Spin.TotalWin.ToString();
		};
	}

	#endregion
}

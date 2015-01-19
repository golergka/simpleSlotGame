using UnityEngine;
using System.Collections;

public class UITutorial : MonoBehaviour
{
	#region Configuration

	public Game Game;

	#endregion

	#region Engine methods

	void Start()
	{
		System.Action<Spin> onSpin = delegate(Spin _Spin)
		{
			Game.OnSpin -= onSpin;
			Destroy(gameObject);
		};
		Game.OnSpin += onSpin;
	}

	#endregion
}

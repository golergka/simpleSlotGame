using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	public static Game Instance { get; private set; }

	#region Configuration

	public Machine		Machine;
	public UIMachine	UIMachine;

	#endregion

	void Awake()
	{
		Instance = this;
	}

	public void Spin()
	{
		UIMachine.PresentSpin(new Spin(
				Machine, 
				Machine.Lines.AsReadOnly(),
				new System.Random()
			));
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIBalance : MonoBehaviour
{
	#region Configuration

	public Text Bet;
	public Text Lines;
	public Text TotalBet;
	public Text TotalWin;

	public Button	IncreaseBet;
	public Button	DecreaseBet;
	public Button	IncreaseLines;
	public Button	DecreaseLines;

	public Game	Game;

	#endregion

	#region Engine methods

	// Use this for initialization
	void Start ()
	{
		Game.OnLines(delegate(int _Lines)
		{
			Lines.text = _Lines.ToString();
			DecreaseLines.interactable = Game.CanDecreaseLines();
			IncreaseLines.interactable = Game.CanIncreaseLines();
		});
		Game.OnBet(delegate(int _Bet)
		{
			Bet.text = _Bet.ToString();
			DecreaseBet.interactable = Game.CanDecreaseBet();
			IncreaseBet.interactable = Game.CanIncreaseBet();
		});
		Game.OnTotalBet(delegate(int _TotalBet)
		{
			TotalBet.text = _TotalBet.ToString();
		});
		Game.OnSpin += delegate(Spin _Spin)
		{
			TotalWin.text = _Spin.TotalWin.ToString();
		};
	}

	#endregion
}

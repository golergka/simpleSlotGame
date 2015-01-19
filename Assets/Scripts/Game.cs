using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	public static Game Instance { get; private set; }

	#region Configuration

	public Machine		Machine;

	public int MinBet;
	public int MaxBet;
	public int BetStep;

	#endregion

	#region Engine methods

	void Awake()
	{
		Instance = this;
		m_Bet = MinBet;
		m_Lines = Machine.MinLines;
	}

	#endregion

	#region Spinning

	public void MaxLines()
	{
		Lines = Machine.Lines.Count;
		Spin();
	}

	public void Spin()
	{
		if (OnSpin != null)
		{
			OnSpin(new Spin(
					Machine, 
					Machine.TakeLines(m_Lines),
					new System.Random(),
					Bet
				));
		}
	}

	public event System.Action<Spin> OnSpin;

	#endregion

	#region Lines

	int m_Lines;
	int Lines
	{
		get { return m_Lines; }
		set
		{
			if ((value > m_Lines && CanIncreaseLines())
			|| (value < m_Lines && CanDecreaseLines()))
			{
				m_Lines = value;
				if (m_OnLines != null)
				{
					m_OnLines(m_Lines);
				}
				if (m_OnTotalBet != null)
				{
					m_OnTotalBet(TotalBet);
				}
			}
		}
	}

	public bool CanIncreaseLines()
	{
		return m_Lines < Machine.Lines.Count;
	}

	public bool CanDecreaseLines()
	{
		return m_Lines > Machine.MinLines;
	}

	public void IncreaseLines()
	{
		Lines++;
	}

	public void DecreaseLines()
	{
		Lines--;
	}

	public void OnLines(System.Action<int> _Callback)
	{
		_Callback(m_Lines);
		m_OnLines += _Callback;
	}
	event System.Action<int> m_OnLines;

	#endregion

	#region Bet

	int m_Bet;
	int Bet
	{
		get { return m_Bet; }
		set
		{
			if ((value > m_Bet && CanIncreaseBet())
			|| (value < m_Bet && CanDecreaseBet()))
			{
				m_Bet = value;
				if (m_OnBet != null)
				{
					m_OnBet(m_Bet);
				}
				if (m_OnTotalBet != null)
				{
					m_OnTotalBet(TotalBet);
				}
			}
		}
	}

	public bool CanIncreaseBet()
	{
		return m_Bet < MaxBet;
	}

	public bool CanDecreaseBet()
	{
		return m_Bet > MinBet;
	}

	public void IncreaseBet()
	{
		Bet += BetStep;
	}

	public void DecreaseBet()
	{
		Bet -= BetStep;
	}

	public void OnBet(System.Action<int> _Callback)
	{
		_Callback(m_Bet);
		m_OnBet += _Callback;
	}
	event System.Action<int> m_OnBet;

	#endregion

	#region Total bet

	int TotalBet
	{
		get
		{
			return m_Bet * m_Lines;
		}
	}

	public void OnTotalBet(System.Action<int> _Callback)
	{
		_Callback(TotalBet);
		m_OnTotalBet += _Callback;
	}
	event System.Action<int> m_OnTotalBet;

	#endregion
}

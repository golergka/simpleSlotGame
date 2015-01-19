using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	public static Game Instance { get; private set; }

	#region Configuration

	public Machine		Machine;
	public UIMachine	UIMachine;

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

	#region Public interface

	public void Spin()
	{
		UIMachine.PresentSpin(new Spin(
				Machine, 
				Machine.TakeLines(m_Lines),
				new System.Random()
			));
	}

	#endregion

	#region Lines

	int m_Lines;

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
		if (CanIncreaseLines())
		{
			m_Lines++;
			if (m_OnLines != null)
			{
				m_OnLines(m_Lines);
			}
			if (m_OnTotalbet != null)
			{
				m_OnTotalbet(TotalBet);
			}
		}
	}

	public void DecreaseLines()
	{
		if (CanDecreaseLines())
		{
			m_Lines--;
			if (m_OnLines != null)
			{
				m_OnLines(m_Lines);
			}
			if (m_OnTotalbet != null)
			{
				m_OnTotalbet(TotalBet);
			}
		}
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
		if (CanIncreaseBet())
		{
			m_Bet += BetStep;
			if (m_OnBet != null)
			{
				m_OnBet(m_Bet);
			}
			if (m_OnTotalbet != null)
			{
				m_OnTotalbet(TotalBet);
			}
		}
	}

	public void DecreaseBet()
	{
		if (CanDecreaseBet())
		{
			m_Bet -= BetStep;
			if (m_OnBet != null)
			{
				m_OnBet(m_Bet);
			}
			if (m_OnTotalbet != null)
			{
				m_OnTotalbet(TotalBet);
			}
		}
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
		m_OnTotalbet += _Callback;
	}
	event System.Action<int> m_OnTotalbet;

	#endregion
}

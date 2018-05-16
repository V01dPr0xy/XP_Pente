using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using eTypes;

public class Game : MonoBehaviour
{
	public static Game m_instance;
	[SerializeField] public eMode m_mode;
	[SerializeField] public Player m_player1;
	[SerializeField] public Player m_player2;
	[SerializeField] public Player m_playerAI;

	void Start()
	{
		m_instance = this;
	}

	void Update()
	{

	}
}

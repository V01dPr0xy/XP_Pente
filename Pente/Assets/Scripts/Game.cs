using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using eTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Game : MonoBehaviour {
    public static Game m_instance;
	public bool isPlayingGame = false;
    [SerializeField] public eMode m_mode;
    [SerializeField] public Player m_player1;
    [SerializeField] public Player m_player2;
    [SerializeField] public Player m_playerAI;
    [SerializeField] public Board m_board;
    [SerializeField] public UnityEngine.UI.Text m_winUI;

    [SerializeField] public Material[] m_Materials;
    public Player[] m_players = new Player[3];

    private PlacementCircle m_highlightedCircle = null;
    public Player m_currentPlayer = null;

    void Start() {
        m_instance = this;
        m_currentPlayer = m_player1;

        m_players[0] = m_player1;
        m_players[1] = m_player2;
        m_players[2] = m_playerAI;
    }

    /// <summary>
    /// 9x 39
    /// square and odd
    /// 
    /// 20 second timer
    /// notif for timer has stopped before turn change
    /// save load
    /// menu should pause timer/game
    /// </summary>

     void Update() {

		if (isPlayingGame) {
			PlacementCircle circle = null;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) circle = hit.collider.gameObject.GetComponent<PlacementCircle>();

			if (circle) circle.Highlight();
			if (circle != m_highlightedCircle && m_highlightedCircle != null) m_highlightedCircle.Hide();
			if (Input.GetMouseButtonDown(0) && circle != null) {
				if (circle.PlacePiece(m_currentPlayer)) {
					SwitchPlayers();
				}
			}
			m_highlightedCircle = circle;
		}
    }

    public void PlayerWon() {
        Time.timeScale = 0.0f;
        m_winUI.text = m_currentPlayer.Name + " won!";
        m_winUI.gameObject.SetActive(true);
    }

    private void SwitchPlayers() {
        if (m_currentPlayer == m_player1) {
            switch (m_mode) {
                case eMode.PVP:
                    m_currentPlayer = m_player2;
                    break;
                case eMode.PVE:
                    m_currentPlayer = m_playerAI;
                    break;
            }
        } else {
            m_currentPlayer = m_player1;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using eTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

public class Game : MonoBehaviour {
    public static Game m_instance;
    public bool m_isPlayingGame = false;
    [SerializeField] public eMode m_mode;
    [SerializeField] public Player m_player1;
    [SerializeField] public Player m_player2;
    [SerializeField] public Player m_playerAI;
    [SerializeField] public Board m_board;
    [SerializeField] public Material[] m_Materials;
    [SerializeField] public TextMeshProUGUI m_player1Timer;
    [SerializeField] public TextMeshProUGUI m_player2Timer;
    [SerializeField] [Range(1.0f, 30.0f)] float m_turnTime = 20.0f;
    public Player[] m_players = new Player[3];

    private PlacementCircle m_highlightedCircle = null;
    public Player m_currentPlayer = null;
    private float m_turnTimer = 0.0f;
    private TextMeshProUGUI m_currentTimerDisplay = null;
    private bool m_firstTurn = true;
    private bool m_secondTurn = true;

    public eMode Mode { get { return m_mode; } set { m_mode = value; } }
    public float TurnTimer { get { return m_turnTimer; } set { m_turnTimer = value; } }
    public float TurnTime { get { return m_turnTime; } }
    public bool FirstTurn { get { return m_firstTurn; } set { m_firstTurn = value; } }
    public bool SecondTurn { get { return m_secondTurn; } set { m_secondTurn = value; } }

    void Start() {
        m_instance = this;
        m_currentPlayer = m_player1;

        m_players[0] = m_player1;
        m_players[1] = m_player2;
        m_players[2] = m_playerAI;
        m_currentTimerDisplay = m_player1Timer;
        m_turnTimer = m_turnTime;
        m_player2Timer.text = "";
        m_player1.Name = "Player 1";
        m_player2.Name = "Player 2";
        m_playerAI.Name = "HAL 9000";
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
        if (m_isPlayingGame) {
            if (m_currentTimerDisplay) m_currentTimerDisplay.text = m_turnTimer.ToString().Substring(0, (m_turnTimer < 10.0f) ? 1 : 2) + "s";
            PlacementCircle circle = null;
            if (m_turnTimer > 0.0f) {

                if (m_currentPlayer.Equals(m_player1) || (m_currentPlayer.Equals(m_player2))) {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit)) circle = hit.collider.gameObject.GetComponent<PlacementCircle>();


                    if (Input.GetMouseButtonDown(0) && circle != null) {
                        if (circle.PlacePiece(m_currentPlayer)) {
                            SwitchPlayers();
                        }
                    }
                } else {
                    circle = m_playerAI.SelectionCircle;
                }
            } else {
                SwitchPlayers();
            }
            m_turnTimer -= Time.deltaTime;
            if (circle) {
                if (!FirstTurn && !SecondTurn || !m_currentPlayer.Equals(m_player1)) {
                    circle.Highlight();
                } else if (FirstTurn) {
                    if (Convert.ToInt32(circle.m_coordinate.x) == 0 && Convert.ToInt32(circle.m_coordinate.y) == 0) circle.Highlight();
                } else if (SecondTurn) {
                    if (circle.m_coordinate.magnitude >= 2.9f) circle.Highlight();
                }
            }
            if (circle != m_highlightedCircle && m_highlightedCircle != null) m_highlightedCircle.Hide();
            m_highlightedCircle = circle;
        }
    }

    public void PlayerWon() {
        Time.timeScale = 0.0f;
        Game.m_instance.m_isPlayingGame = false;
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
            //Timer text
            if (m_currentTimerDisplay) m_currentTimerDisplay = m_player2Timer;
            m_player1Timer.text = "";
        } else {
            m_currentPlayer = m_player1;
            //Timer text
            if (m_currentTimerDisplay) m_currentTimerDisplay = m_player1Timer;
            m_player2Timer.text = "";
        }
        m_turnTimer = m_turnTime;
    }

}
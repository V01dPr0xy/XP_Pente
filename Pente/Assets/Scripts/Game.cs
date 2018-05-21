using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using eTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Game : MonoBehaviour {
    public static Game m_instance;
    [SerializeField] public eMode m_mode;
    [SerializeField] private Player m_player1;
    [SerializeField] private Player m_player2;
    [SerializeField] private Player m_playerAI;
    [SerializeField] private Board m_board;

    [SerializeField] public Material[] m_Materials;
    public Player[] m_players = new Player[3];

    private PlacementCircle m_highlightedCircle = null;
    private Player m_currentPlayer = null;
    private SaveData m_saveBoard = new SaveData();

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

    public void Save() {
        m_saveBoard.currentBoard = m_board.GetSaveData();
        m_saveBoard.currentPlayer = m_currentPlayer.GetSaveData();
        m_saveBoard.player1 = m_player1.GetSaveData();
        m_saveBoard.player2 = m_player2.GetSaveData();
        m_saveBoard.playerAI = m_playerAI.GetSaveData();
        m_saveBoard.mode = m_mode;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "testSave.dat");
        bf.Serialize(file, m_saveBoard);
        file.Close();
    }


    public void Load() {
        if (File.Exists(Application.persistentDataPath + "testSave.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "testSave.dat", FileMode.Open);
            m_saveBoard = (SaveData)bf.Deserialize(file);
            file.Close();
            m_board.LoadSaveData(m_saveBoard.currentBoard);// = m_saveBoard.m_currentBoard;
            m_player1.LoadSaveData(m_saveBoard.player1);// = m_saveBoard.m_player1;
            m_player2.LoadSaveData(m_saveBoard.player2);// = m_saveBoard.m_player2;
            m_playerAI.LoadSaveData(m_saveBoard.playerAI);// = m_saveBoard.m_playerAI;
            m_currentPlayer = m_players[m_saveBoard.currentPlayer.id];
            

            m_mode = m_saveBoard.mode;
        }
    }

    void Update() {
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Board : MonoBehaviour {

    [Serializable]
    public struct BoardExtension {
        [SerializeField] GameObject m_extension;
        [SerializeField] private Vector2 m_offset;
        [SerializeField] private float m_cameraDistance;
        [SerializeField] private int m_size;

        public GameObject Extension { get { return m_extension; } }
        public Vector2 Offset { get { return m_offset; } }
        public float CameraDistance { get { return m_cameraDistance; } }
        public float Size { get { return m_size; } }
    }

    [SerializeField] List<PlacementCircle> m_placementCircles;
    [SerializeField] List<BoardExtension> m_extensions = new List<BoardExtension>();
    [SerializeField] Slider m_slider = null;
    [SerializeField] float m_baseCameraDistance = -10.0f;
    [SerializeField] int[,] m_boardArray;


    public List<PlacementCircle> PlacementCircles { get { return m_placementCircles; } set { m_placementCircles = value; } }

    private void Start() {
        m_placementCircles = new List<PlacementCircle>(GetComponentsInChildren<PlacementCircle>());
        CenterBoard();
    }

    public SaveData.BoardData GetSaveData() {
        SaveData.BoardData save = new SaveData.BoardData();
        List<SaveData.PlacementCircleData> circles = new List<SaveData.PlacementCircleData>();

        foreach (PlacementCircle item in m_placementCircles) {
            SaveData.PlacementCircleData hmm = new SaveData.PlacementCircleData();
            hmm.coordinate = new SaveData.Vector2Data(item.m_coordinate.x, item.m_coordinate.y);
            if (item.m_piece != null) hmm.ownerId = item.m_piece.Owner.ID;
            else hmm.ownerId = -1;
            circles.Add(hmm);
        }

        save.placementCircles = circles;
        save.sliderValue = (int)m_slider.value;
        return save;
    }

    public void LoadSaveData(SaveData.BoardData save) {
        m_slider.value = save.sliderValue;
        foreach (var item in m_placementCircles) {
            item.Clear();
        }
        foreach (PlacementCircle current in m_placementCircles) {
            foreach (SaveData.PlacementCircleData saved in save.placementCircles) {
                if (current.m_coordinate.x == saved.coordinate.x &&
                    current.m_coordinate.y == saved.coordinate.y) {
                    if (saved.ownerId != -1) current.PlacePiece(Game.m_instance.m_players[saved.ownerId]);
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Sets Board Position and Size Based on m_slider.value
    /// </summary>
    public void CenterBoard() {
        int size = (int)((m_slider.value * 2) + 7);
        transform.position = Vector3.zero;
        //sets the base distance the camera needs to be at to see the full board at minimum size
        Vector3 cameraPos = Camera.main.transform.position;
        cameraPos.z = m_baseCameraDistance;
        Camera.main.transform.position = cameraPos;
        for (int i = 0; i < m_extensions.Count; i++) {
            if (m_extensions[i].Size > size) {
                m_extensions[i].Extension.SetActive(false);
            } else if (m_extensions[i].Size <= size) {
                m_extensions[i].Extension.SetActive(true);
                if (m_extensions[i].Size == size) {
                    transform.position -= new Vector3(m_extensions[i].Offset.x, m_extensions[i].Offset.y);
                    //resets the camera position based on m_slider.value
                    cameraPos = Camera.main.transform.position;
                    cameraPos.z = m_extensions[i].CameraDistance;
                    Camera.main.transform.position = cameraPos;
                }
            }
        }
        foreach (var circle in m_placementCircles) {
            circle.UpdateCoordinates();
        }

    }

    public int[,] ToArray() {
        m_boardArray = new int[(int)((m_slider.value * 2) + 7), (int)((m_slider.value * 2) + 7)];

        int offset = ((int)((m_slider.value * 2) + 7)) /2 ;

        foreach (PlacementCircle item in m_placementCircles) {
            if (item.m_piece != null) {
                m_boardArray[(int)item.m_coordinate.x + offset, (int)item.m_coordinate.y + offset] = item.m_piece.Owner.ID;
            } else m_boardArray[(int)item.m_coordinate.x + offset, (int)item.m_coordinate.y + offset] = -1;
        }

        return m_boardArray;
    }

    public static bool CheckForWin(int[,] currentState, int x, int y) {

        int player = currentState[x, y];

        int top = 0;
        bool continueTop = true;
        int bottom = 0;
        bool continueBottom = true;
        int left = 0;
        bool continueLeft = true;
        int right = 0;
        bool continueRight = true;


        int topLeft = 0;
        bool continueTopLeft = true;
        int topRight = 0;
        bool continueTopRight = true;
        int bottomLeft = 0;
        bool continueBottomLeft = true;
        int bottomRight = 0;
        bool continueBottomRight = true;

        for (int i = 1; i < 5; i++) {
            //Right
            if (x - i >= 0 && continueRight) {
                if (currentState[x - i, y] == player) right++;
                else continueRight = false;
            }
            //Left
            if (x + i < currentState.Length && continueLeft) {
                if (currentState[x + i, y] == player) left++;
                else continueLeft = false;
            }
            if (left + right + 1 >= 5) return true;
            //Top
            if (y - i >= 0 && continueTop) {
                if (currentState[x, y - i] == player) top++;
                else continueTop = false;
            }
            //Bottom
            if (y + i < currentState.Length && continueBottom) {
                if (currentState[x, y + i] == player) bottom++;
                else continueBottom = false;
            }
            if (top + bottom + 1 >= 5) return true;

            //Diagonals
            //Top Right
            if (x + i < currentState.Length && y - i >= 0 && continueTopRight) {
                if (currentState[x + i, y - i] == player) topRight++;
                else continueTopRight = false;
            }
            //Bottom Left
            if (x - i >= 0 && y + i < currentState.Length && continueBottomLeft) {
                if (currentState[x - i, y + i] == player) bottomLeft++;
                else continueBottomLeft = false;
            }
            if (topRight + bottomLeft + 1 >= 5) return true;

            //Top Left
            if (x - i >= 0 && y - i >= 0 && continueTopLeft) {
                if (currentState[x - i, y - i] == player) top++;
                else continueTop = false;
            }
            //Bottom Right
            if (x + i < currentState.Length && y + i < currentState.Length && continueBottomRight) {
                if (currentState[x + i, y + i] == player) bottom++;
                else continueBottom = false;
            }
            if (topLeft + bottomRight + 1 >= 5) return true;

        }

        return false;
    }
}

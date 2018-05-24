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
    [SerializeField] public Slider m_slider = null;
    [SerializeField] float m_baseCameraDistance = -10.0f;
    [SerializeField] int[,] m_boardArray;

    public int size;
    private List<PlacementCircle> m_openCircles;


    public List<PlacementCircle> PlacementCircles { get { return m_placementCircles; } set { m_placementCircles = value; } }
    public List<PlacementCircle> OpenPlacementCircles { get { return m_openCircles; } set { m_openCircles = value; } }

    private void Start() {
        m_placementCircles = new List<PlacementCircle>(GetComponentsInChildren<PlacementCircle>());
        m_openCircles = new List<PlacementCircle>(m_placementCircles);
        CenterBoard();

        Menu.m_instance.boardSize.text = (((System.Convert.ToInt32(Game.m_instance.m_board.m_slider.value) * 2) + 7)) + " x " + (((System.Convert.ToInt32(Game.m_instance.m_board.m_slider.value) * 2) + 7));

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

    public void ClearBoard() {
        foreach (var item in m_placementCircles) {
            item.Clear();
        }
    }

    public void LoadSaveData(SaveData.BoardData save) {
        m_slider.value = save.sliderValue;
        ClearBoard();
        if (save.placementCircles != null)
            foreach (PlacementCircle current in m_placementCircles) {
                foreach (SaveData.PlacementCircleData saved in save.placementCircles) {
                    if (current.m_coordinate.x == saved.coordinate.x &&
                        current.m_coordinate.y == saved.coordinate.y) {
                        if (saved.ownerId != -1) current.PlacePieceForSave(Game.m_instance.m_players[saved.ownerId]);
                        break;
                    }
                }
            }
    }

    /// <summary>
    /// Sets Board Position and Size Based on m_slider.value
    /// </summary>
    public void CenterBoard() {
        size = (int)((Convert.ToInt32(m_slider.value) * 2) + 7);
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
        foreach (var circle in m_placementCircles) {
            circle.UpdateNeighborReferences();
        }

        //Menu.m_instance.ViewSliderValue();
    }

    public int[,] ToArray() {
        m_boardArray = new int[((Convert.ToInt32(m_slider.value) * 2) + 7), ((Convert.ToInt32(m_slider.value) * 2) + 7)];

        for (int i = 0; i < ((Convert.ToInt32(m_slider.value) * 2) + 7); i++) {
            for (int j = 0; j < ((Convert.ToInt32(m_slider.value) * 2) + 7); j++) {
                m_boardArray[i, j] = -1;
            }
        }
        int offset = ((Convert.ToInt32(m_slider.value) * 2) + 7) / 2;

        foreach (PlacementCircle item in m_placementCircles) {
            if (item.m_piece != null) {
                m_boardArray[Convert.ToInt32(item.m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(item.m_coordinate.y) - offset)] = item.m_piece.Owner.ID;
            } //else m_boardArray[(int)item.m_coordinate.x + offset, (int)item.m_coordinate.y + offset] = -1;
        }

        return m_boardArray;
    }
}

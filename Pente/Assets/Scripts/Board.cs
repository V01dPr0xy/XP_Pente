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
    [SerializeField] [Range(9, 39)] private int m_size = 9;
    [SerializeField] Slider m_slider = null;
    [SerializeField] float m_baseCameraDistance = -10.0f;


    public List<PlacementCircle> PlacementCircles { get { return m_placementCircles; } set { m_placementCircles = value; } }

    private void Start() {
        m_placementCircles = new List<PlacementCircle>(GetComponentsInChildren<PlacementCircle>());
        CenterBoard();
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
}

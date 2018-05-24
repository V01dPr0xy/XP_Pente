using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AI : Player {
    [SerializeField] [Range(0.0f, 5.0f)] float m_highlightTime = 3.0f;

    private float m_highlightTimer = 0.0f;


    private void Update() {
        if (Game.m_instance.m_currentPlayer.Equals(this)) {
            m_highlightTimer -= Time.deltaTime;
            if (m_selectionCircle == null) {
                PlacePiece();
            }
            if (m_highlightTimer <= 0.0f) {
                m_selectionCircle.PlacePiece(this);
                Game.m_instance.TurnTimer = 0.0f;
            }
        } else {
            m_highlightTimer = m_highlightTime;
            m_selectionCircle = null;
        }
    }

    public override bool PlacePiece() {
        List<PlacementCircle> activeCircles = new List<PlacementCircle>();
        foreach (var pc in Game.m_instance.m_board.OpenPlacementCircles) {
            if (pc.gameObject.activeInHierarchy) activeCircles.Add(pc);
        }
        int rand = UnityEngine.Random.Range(0, activeCircles.Count);
        m_selectionCircle = activeCircles[rand];
        return true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class SaveData {

    public struct Vector2Data {
        float x;
        float y;
        public Vector2Data(float x, float y) {
            this.x = x;
            this.y = y;
        }
    }

    public struct PlacementCircleData {
        public float radius;
        public List<PlacementCircleData> neighbors;
        public Vector2Data coordinate;
        public PieceData piece;

        public PlacementCircleData(float radius, List<PlacementCircleData> neighbors, Vector2Data coordinate, PieceData piece) {
            this.radius = radius;
            this.neighbors = neighbors;
            this.coordinate = coordinate;
            this.piece = piece;
        }
    }

    public struct PlayerData {
        public string name;
        public int captures;
        public int pieceMaterial;

        public PlayerData(string name, int captures, int pieceMaterial) {
            this.name = name;
            this.captures = captures;
            this.pieceMaterial = pieceMaterial;
        }
    }

    public struct BoardData {
        public int sliderValue;
        public List<PlacementCircleData> placementCircles;

        public BoardData(int sliderValue, List<PlacementCircleData> placementCircles) {
            this.sliderValue = sliderValue;
            this.placementCircles = placementCircles;
        }
    }

    public struct PieceData {

    }

    public struct GameData {

    }


    //public Player m_currentPlayer;
    //public Player m_player1;
    //public Player m_player2;
    //public Player m_playerAI;
    //public int mode;
    //public Board m_currentBoard;


}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//text size 220%
[Serializable]
public class SaveData {
    [Serializable]
    public struct Vector2Data {
        public float x;
        public float y;
        public Vector2Data(float x, float y) {
            this.x = x;
            this.y = y;
        }
    }
    [Serializable]
    public struct PlacementCircleData {
        public Vector2Data coordinate;
        public int ownerId;


        public PlacementCircleData( Vector2Data coordinate, int ownerId) {
            this.coordinate = coordinate;
            this.ownerId = ownerId;
        }
    }
    [Serializable]
    public struct PlayerData {
        public string name;
        public int id;
        public int captures;
        public int pieceMaterial;

        public PlayerData(string name, int id, int captures, int pieceMaterial) {
            this.name = name;
            this.id = id;
            this.captures = captures;
            this.pieceMaterial = pieceMaterial;
        }
    }
    [Serializable]
    public struct BoardData {
        public int sliderValue;
        public List<PlacementCircleData> placementCircles;

        public BoardData(int sliderValue, List<PlacementCircleData> placementCircles) {
            this.sliderValue = sliderValue;
            this.placementCircles = placementCircles;
        }
    }
    [Serializable]
    public struct PieceData {
        public int ownerId;
        public Vector2Data coordinate;

        public PieceData(int ownerId, Vector2Data coordinate) {
            this.ownerId = ownerId;
            this.coordinate = coordinate;
        }
    }


	public string Id;
    public eTypes.eMode mode;
    public PlayerData currentPlayer;
    public PlayerData player1;
    public PlayerData player2;
    public PlayerData playerAI;
    public BoardData currentBoard;


}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[Serializable]
public class Player : MonoBehaviour
{
    //[SerializeField] Material m_pieceMaterial;
    [SerializeField] int m_id;
    [SerializeField] int m_pieceMaterial;
	[SerializeField] TMP_InputField m_text;
	[SerializeField] private int m_numberOfCaptures = 0;

	public string Name { get { return m_text.text; } set { m_text.text = value; } }
    [SerializeField] public Material PieceMaterial { get { return Game.m_instance.m_Materials[m_pieceMaterial]; } }

    public int ID { get { return m_id; } set { m_id = value; } }

    void Start()
	{
		Name = "Player";
	}

	/// <summary>
	/// Checks if you can place a piece and places if true
	/// </summary>
	/// <returns></returns>
	public virtual bool PlacePiece()
	{

		throw new NotImplementedException();
	}

    public SaveData.PlayerData GetSaveData() {
        SaveData.PlayerData save = new SaveData.PlayerData();

        save.captures = m_numberOfCaptures;
        save.id = m_id;
        save.name = Name;
        save.pieceMaterial = m_pieceMaterial;

        return save;
    }

    public void LoadSaveData(SaveData.PlayerData save) {
        m_numberOfCaptures = save.captures;
        Name = save.name;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
	[SerializeField] Material m_pieceMaterial;
	[SerializeField] TMP_InputField m_text;
	[SerializeField] private int m_numberOfCaptures = 0;

	public string Name { get { return m_text.text; } set { m_text.text = value; } }
    public Material PieceMaterial { get { return m_pieceMaterial; } }

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
}

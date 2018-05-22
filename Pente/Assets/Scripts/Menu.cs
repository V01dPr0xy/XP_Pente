using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour {

	List<SaveData> m_saves = new List<SaveData>();
	[SerializeField] TMP_Dropdown m_savesList;

	[SerializeField] GameObject titleMenu;
	[SerializeField] GameObject gameMenu;
	[SerializeField] public TextMeshProUGUI boardSize;
	public static Menu m_instance;

	private void Start()
	{
		LoadFromFile();
		m_instance = this;
		List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
		foreach (SaveData item in m_saves)
		{
			options.Add(new TMP_Dropdown.OptionData(item.ToString()));
		}
		m_savesList.AddOptions(options);
		Time.timeScale = 0.0f;

	}


	public void ChoosePVE()
	{
		titleMenu.SetActive(false);
		gameMenu.SetActive(true);
		Time.timeScale = 1.0f;
		Game.m_instance.isPlayingGame = true;
	}

	public void ChoosePVP()
	{
		titleMenu.SetActive(false);
		gameMenu.SetActive(true);
		Time.timeScale = 1.0f;
		Game.m_instance.isPlayingGame = true;


	}
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "SavesList.dat");
		bf.Serialize(file, m_saves);
		file.Close();
	}

	public void CreateNewSave()
	{
		SaveData saveBoard = new SaveData();
		saveBoard.currentBoard = Game.m_instance.m_board.GetSaveData();
		saveBoard.currentPlayer = Game.m_instance.m_currentPlayer.GetSaveData();
		saveBoard.player1 = Game.m_instance.m_player1.GetSaveData();
		saveBoard.player2 = Game.m_instance.m_player2.GetSaveData();
		saveBoard.playerAI = Game.m_instance.m_playerAI.GetSaveData();
		saveBoard.mode = Game.m_instance.m_mode;
		m_saves.Add(saveBoard);
		Save();
	}

	public void LoadFromFile()
	{
		if (File.Exists(Application.persistentDataPath + "SavesList.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "SavesList.dat", FileMode.Open);
			m_saves = (List<SaveData>)bf.Deserialize(file);
			file.Close();
		}
	}

	public void Load()
	{
		if (m_savesList.options.Count != 0)
		{
			string heck = "";
			LoadFromFile();
			SaveData currentSave = new SaveData();
			foreach (SaveData item in m_saves)
			{
				if (item.Id.Equals(heck)) currentSave = item;
			}

			Game.m_instance.m_board.LoadSaveData(currentSave.currentBoard);
			Game.m_instance.m_player1.LoadSaveData(currentSave.player1);
			Game.m_instance.m_player2.LoadSaveData(currentSave.player2);
			Game.m_instance.m_playerAI.LoadSaveData(currentSave.playerAI);
			Game.m_instance.m_currentPlayer = Game.m_instance.m_players[currentSave.currentPlayer.id];
			Game.m_instance.m_mode = currentSave.mode;
			Game.m_instance.m_winUI.gameObject.SetActive(false);
		}
	}

	public void UpdateBoardSizeValue()
	{
		Menu.m_instance.boardSize.text = (((System.Convert.ToInt32(Game.m_instance.m_board.m_slider.value) * 2) + 7)) + " x " + (((System.Convert.ToInt32(Game.m_instance.m_board.m_slider.value) * 2) + 7));

	}

}

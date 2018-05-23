using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour {

	List<SaveData> m_saves = new List<SaveData>();
	[SerializeField] TMP_Dropdown m_savesListTitleMenu;
	[SerializeField] TMP_Dropdown m_savesListSaveMenu;


	[SerializeField] GameObject titleMenu;
	[SerializeField] GameObject gameMenu;
	[SerializeField] GameObject saveMenu;

	[SerializeField] public TextMeshProUGUI boardSize;

	[SerializeField] public TMP_InputField m_newSaveInput;
	[SerializeField] public TMP_Dropdown m_existingSaves;
	[SerializeField] GameObject m_warning;

	[SerializeField] public GameObject triaDetectedPlayer1;


	public static Menu m_instance;

	private void Start()
	{
		LoadFromFile();
		m_instance = this;
		LoadOptionDropdowns();
		Time.timeScale = 0.0f;
		m_warning.SetActive(false);
		triaDetectedPlayer1.SetActive(false);
		

	}
	public void ReturnToTitle()
	{
		LoadOptionDropdowns();
		titleMenu.SetActive(true);
		gameMenu.SetActive(false);
		Time.timeScale = 0.0f;
		Game.m_instance.isPlayingGame = false;
		m_warning.SetActive(false);
		triaDetectedPlayer1.SetActive(false);

	}
	public void ReturnToGame()
	{
		titleMenu.SetActive(false);
		saveMenu.SetActive(false);
		gameMenu.SetActive(true);
		Time.timeScale = 1.0f;
		Game.m_instance.isPlayingGame = true;
	}

	public void OpenSaveMenu()
	{
		LoadOptionDropdowns();
		saveMenu.SetActive(true);
		gameMenu.SetActive(false);
		m_warning.SetActive(false);
		//Time.timeScale = 0.0f;
		Game.m_instance.isPlayingGame = false;
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

	public void LoadOptionDropdowns()
	{
		LoadFromFile();
		List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
		foreach (SaveData item in m_saves)
		{
			options.Add(new TMP_Dropdown.OptionData(item.ToString()));
		}
		m_savesListTitleMenu.AddOptions(options);
		m_savesListSaveMenu.AddOptions(options);

	}

	public void SaveNewFile()
	{
		string saveId = m_newSaveInput.text;

		bool valid = true;
		foreach (SaveData item in m_saves)
		{
			if (item.Id.Equals(saveId)) valid = false;
		}

		if (valid)
		{
			m_warning.SetActive(false);

			CreateNewSave(saveId);
			LoadOptionDropdowns();
		}
		else
		{
			m_warning.SetActive(true);
		}

	}

	public void OverwriteFile()
	{
		string saveId = m_existingSaves.options[m_existingSaves.value].text;
		SaveData file = new SaveData();

		foreach (SaveData item in m_saves)
		{
			if (saveId.Equals(item.Id))
			{
				file = item;
			}
		}

		m_saves.Remove(file);
		CreateNewSave(file);
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "SavesList.dat");
		bf.Serialize(file, m_saves);
		file.Close();
	}

	public void CreateNewSave(string id)
	{
		SaveData saveBoard = new SaveData();
		saveBoard.Id = id;
		saveBoard.currentBoard = Game.m_instance.m_board.GetSaveData();
		saveBoard.currentPlayer = Game.m_instance.m_currentPlayer.GetSaveData();
		saveBoard.player1 = Game.m_instance.m_player1.GetSaveData();
		saveBoard.player2 = Game.m_instance.m_player2.GetSaveData();
		saveBoard.playerAI = Game.m_instance.m_playerAI.GetSaveData();
		saveBoard.mode = Game.m_instance.m_mode;
		m_saves.Add(saveBoard);
		Save();
	}

	public void CreateNewSave(SaveData existingSave)
	{
		existingSave.currentBoard = Game.m_instance.m_board.GetSaveData();
		existingSave.currentPlayer = Game.m_instance.m_currentPlayer.GetSaveData();
		existingSave.player1 = Game.m_instance.m_player1.GetSaveData();
		existingSave.player2 = Game.m_instance.m_player2.GetSaveData();
		existingSave.playerAI = Game.m_instance.m_playerAI.GetSaveData();
		existingSave.mode = Game.m_instance.m_mode;
		m_saves.Add(existingSave);
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
		if (m_savesListTitleMenu.options.Count != 0)
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
			ReturnToGame();
		}

	}

	public void UpdateBoardSizeValue()
	{
		Menu.m_instance.boardSize.text = (((System.Convert.ToInt32(Game.m_instance.m_board.m_slider.value) * 2) + 7)) + " x " + (((System.Convert.ToInt32(Game.m_instance.m_board.m_slider.value) * 2) + 7));

	}

}

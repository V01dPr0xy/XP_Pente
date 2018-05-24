using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;


public class Menu : MonoBehaviour {

    List<SaveData> m_saves = new List<SaveData>();
    [SerializeField] int m_numSaves = 0;
    [SerializeField] TMP_Dropdown m_savesListTitleMenu;
    [SerializeField] TMP_Dropdown m_savesListSaveMenu;


    [SerializeField] GameObject titleMenu;
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject saveMenu;

    [SerializeField] GameObject returnToMenu;
    [SerializeField] GameObject quitgameMenu;

    [SerializeField] public GameObject tria;
    [SerializeField] public GameObject tessera;
    [SerializeField] public GameObject win;
                    
    [SerializeField] public TextMeshProUGUI triaText;
    [SerializeField] public TextMeshProUGUI tesseraText;
    [SerializeField] public TextMeshProUGUI winText;


    [SerializeField] public TextMeshProUGUI boardSize;

    [SerializeField] public TMP_InputField m_newSaveInput;
    [SerializeField] public TMP_Dropdown m_existingSaves;
    [SerializeField] GameObject m_warning;


    public static Menu m_instance;

    private void Start() {
        win.SetActive(false);
        tria.SetActive(false);
        tessera.SetActive(false);
        LoadFromFile();
        m_instance = this;
        LoadOptionDropdowns();
        Time.timeScale = 0.0f;
        m_warning.SetActive(false);
        titleMenu.SetActive(true);
        gameMenu.SetActive(false);
        saveMenu.SetActive(false);
        returnToMenu.SetActive(false);
        quitgameMenu.SetActive(false);


    }
    public void ReturnToTitle() {
        Game.m_instance.FirstTurn = true;
        Game.m_instance.SecondTurn = true;
        win.SetActive(false);
        tria.SetActive(false);
        tessera.SetActive(false);
        Game.m_instance.TurnTimer = Game.m_instance.TurnTime;
        Game.m_instance.m_board.ClearBoard();
        Game.m_instance.m_currentPlayer = Game.m_instance.m_player1;
        LoadOptionDropdowns();
        titleMenu.SetActive(true);
        gameMenu.SetActive(false);
        Time.timeScale = 0.0f;
        Game.m_instance.m_isPlayingGame = false;
        m_warning.SetActive(false);
        returnToMenu.SetActive(false);
        quitgameMenu.SetActive(false);
    }
    public void ReturnToGame() {
        win.SetActive(false);
        tria.SetActive(false);
        tessera.SetActive(false);
        returnToMenu.SetActive(false);
        quitgameMenu.SetActive(false);
        titleMenu.SetActive(false);
        saveMenu.SetActive(false);
        gameMenu.SetActive(true);
        Time.timeScale = 1.0f;
        Game.m_instance.m_isPlayingGame = true;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void QuitDuringGame() {
        gameMenu.SetActive(false);
        quitgameMenu.SetActive(true);
        Game.m_instance.m_isPlayingGame = false;
    }

    public void ReturnToMenuDuringGame() {
        gameMenu.SetActive(false);
        returnToMenu.SetActive(true);
        Game.m_instance.m_isPlayingGame = false;
    }

    public void OpenSaveMenu() {
        LoadOptionDropdowns();
        saveMenu.SetActive(true);
        gameMenu.SetActive(false);
        m_warning.SetActive(false);
        //Time.timeScale = 0.0f;
        Game.m_instance.m_isPlayingGame = false;
    }

    public void ChoosePVE() {
        Game.m_instance.m_player2.gameObject.SetActive(false);
        Game.m_instance.m_playerAI.gameObject.SetActive(true);

        titleMenu.SetActive(false);
        gameMenu.SetActive(true);
        Time.timeScale = 1.0f;
        Game.m_instance.m_isPlayingGame = true;
        Game.m_instance.Mode = eTypes.eMode.PVE;
    }

    public void ChoosePVP() {
        Game.m_instance.m_playerAI.gameObject.SetActive(false);
        Game.m_instance.m_player2.gameObject.SetActive(true);

        titleMenu.SetActive(false);
        gameMenu.SetActive(true);
        Time.timeScale = 1.0f;
        Game.m_instance.m_isPlayingGame = true;
        Game.m_instance.Mode = eTypes.eMode.PVP;

    }

    public void LoadOptionDropdowns() {
        m_savesListTitleMenu.ClearOptions();
        m_savesListSaveMenu.ClearOptions();

        LoadFromFile();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (SaveData item in m_saves) {
            options.Add(new TMP_Dropdown.OptionData(item.Id));
        }
        m_numSaves = m_saves.Count;
        m_savesListTitleMenu.AddOptions(options);
        m_savesListSaveMenu.AddOptions(options);

    }

    public void SaveNewFile() {
        string saveId = m_newSaveInput.text;

        bool valid = true;
        foreach (SaveData item in m_saves) {
            if (item.Id.Equals(saveId)) valid = false;
        }

        if (valid) {
            m_warning.SetActive(false);

            CreateNewSave(saveId);
            LoadOptionDropdowns();
        } else {
            m_warning.SetActive(true);
        }

    }

    public void OverwriteFile() {
        string saveId = m_existingSaves.options[m_existingSaves.value].text;
        SaveData file = new SaveData();

        foreach (SaveData item in m_saves) {
            if (saveId.Equals(item.Id)) {
                file = item;
            }
        }

        m_saves.Remove(file);
        CreateNewSave(file);
    }

    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "SavesList4.dat");
        bf.Serialize(file, m_saves);
        file.Close();
    }

    public void CreateNewSave(string id) {
        SaveData saveBoard = new SaveData();
        saveBoard.Id = id;
        saveBoard.currentBoard = Game.m_instance.m_board.GetSaveData();
        saveBoard.currentPlayer = Game.m_instance.m_currentPlayer.GetSaveData();
        saveBoard.player1 = Game.m_instance.m_player1.GetSaveData();
        saveBoard.player2 = Game.m_instance.m_player2.GetSaveData();
        saveBoard.playerAI = Game.m_instance.m_playerAI.GetSaveData();
        saveBoard.mode = Game.m_instance.m_mode;
        saveBoard.firstTurn = Game.m_instance.FirstTurn;
        saveBoard.secondTurn = Game.m_instance.SecondTurn;
        m_saves.Add(saveBoard);
        Save();
    }

    public void CreateNewSave(SaveData existingSave) {
        existingSave.currentBoard = Game.m_instance.m_board.GetSaveData();
        existingSave.currentPlayer = Game.m_instance.m_currentPlayer.GetSaveData();
        existingSave.player1 = Game.m_instance.m_player1.GetSaveData();
        existingSave.player2 = Game.m_instance.m_player2.GetSaveData();
        existingSave.playerAI = Game.m_instance.m_playerAI.GetSaveData();
        existingSave.mode = Game.m_instance.m_mode;
        existingSave.firstTurn = Game.m_instance.FirstTurn;
        existingSave.secondTurn = Game.m_instance.SecondTurn;

        m_saves.Add(existingSave);
        Save();
    }

    public void LoadFromFile() {
        if (File.Exists(Application.persistentDataPath + "SavesList4.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "SavesList4.dat", FileMode.Open);
            m_saves = (List<SaveData>)bf.Deserialize(file);
            file.Close();
        }
    }

    public void Load() {
        if (m_savesListTitleMenu.options.Count != 0) {
            string heck = m_savesListTitleMenu.options[m_savesListTitleMenu.value].text;
            LoadFromFile();
            SaveData currentSave = new SaveData();
            foreach (SaveData item in m_saves) {
                if (item.Id.Equals(heck)) currentSave = item;
            }

            Game.m_instance.m_board.LoadSaveData(currentSave.currentBoard);
            Game.m_instance.m_player1.LoadSaveData(currentSave.player1);
            Game.m_instance.m_player2.LoadSaveData(currentSave.player2);
            Game.m_instance.m_playerAI.LoadSaveData(currentSave.playerAI);
            Game.m_instance.m_currentPlayer = Game.m_instance.m_players[currentSave.currentPlayer.id];
            Game.m_instance.m_mode = currentSave.mode;
            Game.m_instance.SecondTurn = currentSave.secondTurn;
            Game.m_instance.FirstTurn = currentSave.firstTurn;
            if (currentSave.mode == eTypes.eMode.PVE) {
                Game.m_instance.m_player2.gameObject.SetActive(false);
                Game.m_instance.m_playerAI.gameObject.SetActive(true);
            } else {
                Game.m_instance.m_player2.gameObject.SetActive(true);
                Game.m_instance.m_playerAI.gameObject.SetActive(false);
            }
            if (win) win.gameObject.SetActive(false);
            ReturnToGame();
        }

    }

    public void UpdateBoardSizeValue() {
        Menu.m_instance.boardSize.text = (((System.Convert.ToInt32(Game.m_instance.m_board.m_slider.value) * 2) + 7)) + " x " + (((System.Convert.ToInt32(Game.m_instance.m_board.m_slider.value) * 2) + 7));

    }

}

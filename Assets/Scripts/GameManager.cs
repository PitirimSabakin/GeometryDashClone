using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    [SerializeField] private float speedMap;
    [SerializeField] private TMP_Text textAttempt;
    [SerializeField] private GameObject panel;

    private Button pauseBtn;
    private Button exitBtn;
    private Button restartBtn;
    private Button continueBtn;
    

    private Player playerScript;

    private Vector3 startPositionX;
    private int attempt = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        startPositionX = floor.transform.position;
        attempt = 1;

        ButtonInitialization();
        ContinueGame();
    }

    // Update is called once per frame
    void Update()
    {
        MapMove();
    }

    //the map moves creating the illusion of cube movement
    private void MapMove()
    {
        floor.transform.Translate(Vector2.left * Time.deltaTime * speedMap);
    }

    //When player die, map return to the start position 
    public void ReturnPositionMap()
    {
        floor.transform.position = startPositionX;
        attempt++;
        textAttempt.text ="Attempt " + attempt.ToString();
    }

    private void ButtonInitialization()
    {
        pauseBtn = GameObject.Find("ButtonPause").GetComponent<Button>();
        exitBtn = panel.transform.GetChild(0).GetComponent<Button>();
        restartBtn = panel.transform.GetChild(1).GetComponent<Button>();
        continueBtn = panel.transform.GetChild(2).GetComponent<Button>();

        pauseBtn.onClick.AddListener(Pause);
        exitBtn.onClick.AddListener(ExitInMenu);
        restartBtn.onClick.AddListener(Restart);
        continueBtn.onClick.AddListener(ContinueGame);
    }

    private void Pause()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    private void ExitInMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Restart()
    {
        playerScript.DeathHandler();
        ContinueGame();
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}

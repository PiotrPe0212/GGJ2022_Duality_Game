using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player1_Controller player1;
    [SerializeField] private Player2_Controller player2;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject EndPanel;
    [SerializeField] private GameObject leftWin;
    [SerializeField] private GameObject rightWin;
     private AudioSource themeSong;
    private int gameState;
    private float Player1Health;
    private float Player2Health;
    private float healthLooseStep;
    public static bool playVsComputer;

    public event Action ResetParameters;
    public void PlayClick()
    {
        switchState(1);
        playVsComputer = false;
    }

    public void PlayClickVsComputer()
    {
        switchState(1);
        playVsComputer = true;
    }

    public void PlayAgainClick()
    {
        switchState(1);
    }
    public void ExitClick()
    {
        Application.Quit();
    }

    public void MainMenuCLick()
    {
        switchState(0);
    }

    private void Awake()
    {
        player1.HealthLoose += Player1HealthLoos;
        player2.HealthLoose += Player2HealthLoos;
    }
    private void OnDestroy()
    {
        player1.HealthLoose -= Player1HealthLoos;
        player2.HealthLoose -= Player2HealthLoos;
    }
 
    void Start()
    {
        themeSong = gameObject.GetComponent<AudioSource>();
        healthLooseStep = Player1_Controller.healthLoose;

        // 0 -menu, 1- game, 2-endPanel;
        switchState(0);


    }

    void FixedUpdate()
    {
      
      
         if(gameState == 1)
        {
    
            if (Player1Health <= 0)
            {
                rightWin.SetActive(true);
                leftWin.SetActive(false);
                switchState(2);
              
            }

            if(Player2Health <= 0)
            {
                rightWin.SetActive(false);
                leftWin.SetActive(true);
                switchState(2);
            }

        }
       
    }

    void Player1HealthLoos()
    {
        Player1Health -= healthLooseStep;
    }

    void Player2HealthLoos ()
    {
        Player2Health -= healthLooseStep;

    }

    void switchState(int state)
    {
        switch (state)
        {
            case 0:
                gameState = 0;
                Time.timeScale = 0;
                themeSong.Stop();
                MenuPanel.SetActive(true);
                EndPanel.SetActive(false);
                resetFunction();
                break;
            case 1:
                gameState = 1;
                Time.timeScale = 1;
                themeSong.Play();
                MenuPanel.SetActive(false);
                EndPanel.SetActive(false);
                
                break;
            case 2:
                gameState = 2;
                Time.timeScale = 0;
                themeSong.Stop();
                MenuPanel.SetActive(false);
                EndPanel.SetActive(true);
                resetFunction();
                break;
            default:
                gameState = 0;
                Time.timeScale = 0;
                themeSong.Stop();
                MenuPanel.SetActive(true);
                EndPanel.SetActive(false);
                resetFunction();
                break;
        }
    }

    void resetFunction()
    {
        
        Player1Health = Player1_Controller.initialHealth;
        Player2Health = Player2_Controller.initialHealth;
        ResetParameters();
    }
}

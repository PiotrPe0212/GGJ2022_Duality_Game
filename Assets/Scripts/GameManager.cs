using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Player1_Controller player1;
    [SerializeField] private Player2_Controller player2;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject EndPanel;
    private int gameState;
    private float Player1Health;
    private float Player2Health;
    private float healthLooseStep;


    public event Action ResetParameters;
    public void PlayClick()
    {
        switchState(1);
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
        // 0 -menu, 1- game, 2-endPanel;
        switchState(0);
        healthLooseStep = Player1_Controller.healthLoose;

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(gameState);
      
         if(gameState == 1)
        {
            Debug.Log("play");
            if (Player1Health <= 0 || Player2Health <= 0)
            {
                switchState(2);
                Debug.Log("end");
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
                MenuPanel.SetActive(true);
                EndPanel.SetActive(false);
                resetFunction();
                break;
            case 1:
                gameState = 1;
                Time.timeScale = 1;
                MenuPanel.SetActive(false);
                EndPanel.SetActive(false);
                break;
            case 2:
                gameState = 2;
                Time.timeScale = 0;
                MenuPanel.SetActive(false);
                EndPanel.SetActive(true);
                resetFunction();
                break;
            default:
                gameState = 0;
                Time.timeScale = 0;
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

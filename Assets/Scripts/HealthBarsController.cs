using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarsController : MonoBehaviour
{

    [SerializeField] private Player1_Controller Player1;
    [SerializeField] private Player2_Controller Player2;
    [SerializeField] private GameObject Player1Bar;
    [SerializeField] private GameObject Player2Bar;
    [SerializeField] private GameManager gameManager;
    private float Player1Health;
    private  float Player2Health;
    private Slider sliderPlayer1;
    private Slider sliderPlayer2;
    private float healthLoose;
    private void Awake()
    {
        Player1.HealthLoose += Player1HealthLoos;
        Player2.HealthLoose += Player2HealthLoos;
        gameManager.ResetParameters += resetParameters;
    }

    private void OnDestroy()
    {
        Player1.HealthLoose -= Player1HealthLoos;
        Player2.HealthLoose -= Player2HealthLoos;
        gameManager.ResetParameters -= resetParameters;
    }
    // Start is called before the first frame update
    void Start()
    {

      
        resetParameters();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Player1HealthLoos()
    {
        Player1Health -= healthLoose;
        sliderPlayer1.value = Player1Health;

    }
    void Player2HealthLoos()
    {
        Player2Health -= healthLoose;
        sliderPlayer2.value = Player2Health;
    }

    void resetParameters()
    {
        sliderPlayer1 = Player1Bar.GetComponent<Slider>();
        sliderPlayer2 = Player2Bar.GetComponent<Slider>();
        Player1Health = Player1_Controller.initialHealth;
        Player2Health = Player2_Controller.initialHealth;
        healthLoose = Player1_Controller.healthLoose;
        sliderPlayer1.value = Player1Health;
        sliderPlayer2.value = Player2Health;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float time;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private EnemyMovement enemyMovement;

    private int minutes;
    private int seconds;

    // Start is called before the first frame update
    void Start()
    {
       playerController = FindObjectOfType<PlayerController>();
       enemyMovement = FindObjectOfType<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        minutes = (int) time / 60;
        seconds = (int) time % 60;
        showText();
    }

    void showText()
    {
        if(playerController.isWon == false && playerController.isLose == false)
        {
            if(minutes < 10)
            {
                if(seconds < 10){
                    timeText.GetComponent<TextMeshProUGUI>().text = "0" + minutes + ":0" + seconds;
                }
                else
                {
                    timeText.GetComponent<TextMeshProUGUI>().text = "0" + minutes + ":" + seconds;
                }
            }
            else
            {
                timeText.GetComponent<TextMeshProUGUI>().text = minutes + ":" + seconds;
            }
        }
        else
        {
            if(playerController.isWon == true)
            {
                timeText.GetComponent<TextMeshProUGUI>().text = "You Win!!";
            }
            else
            {
                timeText.GetComponent<TextMeshProUGUI>().text = "Game Over";
                playerController.EndMove();
                enemyMovement.EndMove();
            }
        }

        if(minutes <= 0 && seconds <= 0)
        {
            timeText.GetComponent<TextMeshProUGUI>().text = "Game Over";
            playerController.EndMove();
            enemyMovement.EndMove();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GameObject player;
    public GameObject hpText;

	void Start ()
    {
	}
	
	void Update ()
    {
        var text = GetComponent<Text>();
        if(player)
        {
            text.text = "Score: " + player.GetComponent<Player>().PlayerScore;
        }

        if (player)
            hpText.GetComponent<Text>().text = "HP: " + player.GetComponent<Player>().PlayerHP;

        else
            hpText.GetComponent<Text>().text = "HP: 0";
    }
}

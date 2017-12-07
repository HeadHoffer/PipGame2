using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GameObject Player;
    public GameObject HPText;

	void Start ()
    {
	}
	
	void Update ()
    {
        var text = GetComponent<Text>();
        text.text = "Score: " + Player.GetComponent<SpaceShip>().PlayerScore;

        var hpText = HPText.GetComponent<Text>();
        hpText.text = "HP: " + Player.GetComponent<SpaceShip>().PlayerHP;
    }
}

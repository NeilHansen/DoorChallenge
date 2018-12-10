using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

    private Player player;
    public int playerNumber;

    // Use this for initialization
    void Start () {
        player = Rewired.ReInput.players.GetPlayer(playerNumber);
    }
	
	// Update is called once per frame
	void Update () {
		if(player.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene("MyMugstersLevel");
        }
	}
}

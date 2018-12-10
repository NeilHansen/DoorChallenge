using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
public class CarController : MonoBehaviour {

    private Player player;
    public int playerNumber;
    public float speed;
    public float speedMultiplier;

    public GameObject Player;

    private Rigidbody myBody;
	// Use this for initialization
	void Start () {
        player = Rewired.ReInput.players.GetPlayer(playerNumber);
        myBody =   this.gameObject.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        if(player.GetButton("Vroom"))
        {
           speed = speedMultiplier;
        }
        else
        {
            speed = 10;
        }

        if (player.GetButton("ExitCar"))
        {
            Player.gameObject.SetActive(true);
            Player.transform.position = this.transform.position + new Vector3(2,0,2);
            this.gameObject.GetComponent<CarController>().enabled = false;
            Player.GetComponent<PlayerController>().Driving = false;
        }

        float newRotation = transform.localEulerAngles.y + player.GetAxis("HorizontalDrive");
        transform.localEulerAngles = new Vector3(0f, newRotation, 0f);

        Vector3 input = (transform.right * player.GetAxis("VerticalMove"));
        myBody.AddForce(input * Time.deltaTime * speed, ForceMode.Impulse);
    }

 
}

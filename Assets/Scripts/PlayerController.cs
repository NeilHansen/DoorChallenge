using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour {

    private Player player;
    public int playerNumber;

    public float speed;

    private bool BarrelHeld = false;
    public bool Driving = false;
    private GameObject heldObject;
    private GameObject Car;

    public int collectiblesFound;
    // Use this for initialization
    void Start () {
        player = Rewired.ReInput.players.GetPlayer(playerNumber);
	}
	
	// Update is called once per frame
	void Update () {

        if (player.GetAxis("HorizontalMove") > 0.0f)
        {
            //  Debug.Log("MoveForward");
            transform.position -= transform.forward * Time.deltaTime * speed;
        }
        if (player.GetAxis("HorizontalMove") < 0.0f)
        {
            //    Debug.Log("MoveBackward");
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        if (player.GetAxis("VerticalMove") > 0.0f)
        {
            // Debug.Log("MoveRight");
            transform.position += transform.right * Time.deltaTime * speed;
        }
        if (player.GetAxis("VerticalMove") < 0.0f)
        {
            // Debug.Log("MoveLeft");
            transform.position -= transform.right * Time.deltaTime * speed;
        }

        if(BarrelHeld)
        {
            if(player.GetButton("Throw"))
            {
                this.gameObject.transform.DetachChildren();
                heldObject.GetComponent<Explosive>().Explode();
                BarrelHeld = false;
            }
        }

       

    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Explosive")
        {
            Debug.Log("CanPickUP");
            if (player.GetButtonDown("PickUp") && !BarrelHeld)
            {
                heldObject = collider.gameObject;
                collider.transform.SetParent(this.gameObject.transform);
                BarrelHeld = true;
                Debug.Log("PickUP");
            }
        }

        if(collider.gameObject.tag == "Car")
        {
            if (player.GetButtonDown("PickUp") && !BarrelHeld && !Driving)
            {
                Car = collider.gameObject;
                collider.gameObject.GetComponent<CarController>().enabled = true;
                this.gameObject.SetActive(false);
                Driving = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collectible")
        {
            collectiblesFound++;
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

    private Vector3 startingPos;
    private Color OGbarrelColor;
    private Color barrelColor;
    public GameObject explosionCollider;

    public GameObject barrelPrefab;
	// Use this for initialization
	void Start () {
       OGbarrelColor = this.gameObject.GetComponent<MeshRenderer>().material.color;
       startingPos = this.gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<MeshRenderer>().material.color = barrelColor;
    }

    public void Explode()
    {
        StartCoroutine("splode");
        StartCoroutine("Flash");
    }

    IEnumerator splode()
    {
        explosionCollider.SetActive(true);
        yield return new WaitForSeconds(2.5f);
       
       // yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
        //GameObject barrel = Instantiate(barrelPrefab, startingPos, Quaternion.identity) as GameObject;
        StopAllCoroutines();
        yield return null;
    }

    IEnumerator Flash()
    {
        yield return new WaitForSeconds(0.5f);
        barrelColor = Color.white;
        yield return new WaitForSeconds(0.5f);
        barrelColor = OGbarrelColor;
        StartCoroutine("Flash");
        yield return null;
    }

   

    private void OnDestroy()
    {
      
    }
}

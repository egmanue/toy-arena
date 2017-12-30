using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    //inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    public float turnspeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(inputFront))
        {
            transform.Rotate(turnspeed * Time.deltaTime, 0, 0);
        }

        //Rotation du perso à gauche
        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnspeed * Time.deltaTime, 0);
        }

        //Rotation du perso à droite
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnspeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(inputBack))
        {
            transform.Rotate(-turnspeed * Time.deltaTime, 0, 0);
        }

    }
}

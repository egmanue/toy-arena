using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    public Slider healthbar;
    public HealthCharacter playerhealth;
    public LancerBomb curbomb;
    public Text Hptext;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthbar.maxValue = playerhealth.maxhealth;
        healthbar.value = playerhealth.currenthealth;
        Hptext.text = "0" + curbomb.currentbomb;
    }
}

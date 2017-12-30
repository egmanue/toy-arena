using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPic : MonoBehaviour {

    public int dmgpicplayer;
    public int dmgpicmonster;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "monster1")
        {
            other.gameObject.GetComponent<HealthMonster>().HurtPic(dmgpicmonster);
        }

        if (other.gameObject.tag == "player")
        {
            other.gameObject.GetComponent<HealthCharacter>().TakedamagePic(dmgpicplayer);
        }
    }
}


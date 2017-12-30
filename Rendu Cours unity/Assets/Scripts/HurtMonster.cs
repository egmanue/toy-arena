using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtMonster : MonoBehaviour {

    public int damagesattaque;
    public GameObject DamageVisu1;
    public Transform hitpoint;


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "monster1" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            other.gameObject.GetComponent<HealthMonster>().HurtMonster(damagesattaque);
            Instantiate(DamageVisu1, hitpoint.position, hitpoint.rotation);
        }
    }
}

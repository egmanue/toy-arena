using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPowerMonster : MonoBehaviour {

    public int damagespower;
    public GameObject DamageVisu1;
    public Transform hitpoint;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "monster1" && Input.GetKeyDown(KeyCode.Mouse1))
        {
            other.gameObject.GetComponent<HealthMonster>().HurtMonster(damagespower);
            Instantiate(DamageVisu1, hitpoint.position, hitpoint.rotation);
        }
    }
}

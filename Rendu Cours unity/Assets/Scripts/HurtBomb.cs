using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBomb : MonoBehaviour {

    public int damagebomb;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "monster1")
        {
            other.gameObject.GetComponent<HealthMonster>().HurtBomb(damagebomb);
            Destroy(gameObject);
        }
    }
}

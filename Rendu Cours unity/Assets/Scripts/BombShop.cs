using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShop : MonoBehaviour {

    public LancerBomb takebomb;

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
        if (other.gameObject.name == "Player")
        {
            takebomb.currentbomb += 1;
            Destroy(gameObject);
        }
    }
}

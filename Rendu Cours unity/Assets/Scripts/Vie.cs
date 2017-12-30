﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vie : MonoBehaviour {

    public int life;



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
            other.gameObject.GetComponent<HealthCharacter>().TakeLife(life);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerBomb : MonoBehaviour
{
    public int maxbomb;
    public int currentbomb;
    public float forcelancer = 40f;
    public GameObject bombprefab;



    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.E) && currentbomb >= 1)
            {
                BombLancer();

            }
    }

    void BombLancer()
    {
        GameObject go = Instantiate(bombprefab, transform.position, transform.rotation);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * forcelancer);
        currentbomb -= 1;

    }
}
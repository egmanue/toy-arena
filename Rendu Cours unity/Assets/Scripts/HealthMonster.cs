using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMonster : MonoBehaviour {

    //Santé du joueur
    public int monstermaxhealth;
    public int monstercurrenthealth;

    //Animation du joueur
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        monstercurrenthealth = monstermaxhealth;
    }

    void Update()
    {
        if (monstercurrenthealth <= 0)
        {
            monstercurrenthealth = 0;
            Destroy(gameObject);
        }
    }

    public void HurtMonster(int damagesattaque)
    {
        monstercurrenthealth -= damagesattaque;
        anim.SetTrigger("Damage");
    }

    public void HurtPowerMonster(int damagespower)
    {
        monstercurrenthealth -= damagespower;
        anim.SetTrigger("Damage");
    }

    public void HurtBomb(int damagebomb)
    {
        monstercurrenthealth -= damagebomb;
        anim.SetTrigger("Damage");
    }

    public void HurtPic(int dmgpicmonster)
    {
        monstercurrenthealth -= dmgpicmonster;
        anim.SetTrigger("Damage");
    }

    public void Setmaxhealth()
    {
        monstercurrenthealth = monstermaxhealth;
    }
}

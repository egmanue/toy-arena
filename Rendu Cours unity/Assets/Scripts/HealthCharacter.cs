using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCharacter : MonoBehaviour {

    //Santé du joueur
    public int maxhealth;
    public int currenthealth;
    bool isDead;

    //Animation du joueur
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        currenthealth = maxhealth;
        isDead = false;
    }

    void Update()
    {
        if (currenthealth <= 0)
        {
            currenthealth = 0;
            isDead = true;
            anim.SetBool("Death", isDead);
            Destroy(gameObject, 2);
        }
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
         anim.SetTrigger("Damages");
        }
    }

    public void TakedamagePic(int dmgpicplayer)
    {
        currenthealth -= dmgpicplayer;
        if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Damages");
        }
    }

    public void TakeLife(int life)
    {
        currenthealth += life;
    }

    public void Setmaxhealth()
    {
        currenthealth = maxhealth;
    }
}


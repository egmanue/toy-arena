using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMotor : MonoBehaviour
{
    //Distance entre le joueur et l'ennemi
    private float Distance;

    //Cible de le héros
    public Transform Target;

    // Distance de poursuite
    public float chaseRange = 5;

    //Portée des attaques
    public float attackRange = 1f;

    //Agent de navigation
    private UnityEngine.AI.NavMeshAgent agent;

    //Animation du monster
    private Animator anim;

    private GameObject thePlayer;

    // Cooldown des attaques
    public float attackRepeatTime = 1;
    private float attackTime;


    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
        attackTime = Time.time;
    }

    void Update()
    {

            //Le monstre cherche le joueur
            Target = GameObject.Find("Player").transform;

            //Calcule de la distance entre le joueur et l'ennemi
            Distance = Vector3.Distance(Target.position, transform.position);

            // Quand le perso est loin on ne fait rien
            if (Distance > chaseRange)
            {
                anim.SetFloat("Walk", 0);
            }

            // Quand le perso est proche et on le charge
            if (Distance < chaseRange && Distance > attackRange)
            {
                anim.SetFloat("Walk", 1);
                agent.destination = Target.position;
            }

            // Quand on attaque le perso
            if (Distance < attackRange)
            {
                agent.destination = transform.position;
                transform.LookAt(Target);

                if (Time.time > attackTime)
                {
                    anim.SetTrigger("Attack");
                    attackTime = Time.time + attackRepeatTime;
                }
          
        }

        }
    }







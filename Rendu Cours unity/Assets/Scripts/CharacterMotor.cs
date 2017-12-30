using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMotor : MonoBehaviour {

    //Animation du personnage
    Animator anim;

    //Vitesse de déplacement
    public float walkspeed;
    public float runspeed;
    public float turnspeed;
    private float speed = 0;
    private float targetSpeed = 0;


    //inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    //Saut et le collider
    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;

    //variables concernant l'attaque
    private bool isAttacking;
    private bool isAttackPower;

    bool IsGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.25f);
    }

    void Start () {
        anim = GetComponent<Animator>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }
	
	void Update () {

        //Personnage qui avance
        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, speed * Time.deltaTime);

                if(!isAttacking && !isAttackPower)
                {
                    targetSpeed = walkspeed;
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Attack();
                }
                if(Input.GetKeyDown(KeyCode.Mouse1))
                {
                    AttackPower();
                }
            }

            //Personnage qui court
            if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
                targetSpeed = runspeed;
            }

            //Personnage qui recule
            if (Input.GetKey(inputBack))
            {
                transform.Translate(0, 0, speed * Time.deltaTime);

                if (!isAttacking && !isAttackPower)
                {
                    targetSpeed = -walkspeed;
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Attack();
                }
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    AttackPower();
                }
            }

            //Rotation du perso à gauche
            if (Input.GetKey(inputLeft))
            {
                transform.Rotate(0, -turnspeed * Time.deltaTime, 0);
            }

            //Rotation du perso à droite
            if (Input.GetKey(inputRight))
            {
                transform.Rotate(0, turnspeed * Time.deltaTime, 0);
            }

            //Animation Wait
            if (!Input.GetKey(inputFront) && !Input.GetKey(inputBack))
            {
                if (!isAttacking && !isAttackPower)
                {
                    targetSpeed = 0;
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Attack();
                }
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    AttackPower();
                }

            }

            //Personnage qui saute
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
                v.y = jumpSpeed.y;

                gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
                anim.SetFloat("Jump", 1);
            }
            else if (IsGrounded())
            {
                anim.SetFloat("Jump", 0);
            }
            
            speed = Mathf.Lerp(speed, targetSpeed, Time.deltaTime * 5);
            anim.SetFloat("Speed", speed);

            //Attaque du perso

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }

            //Attaque Power du perso
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                AttackPower();
            }

        }

    public void Attack()
    {
        isAttacking = true;
        anim.SetTrigger("Attaque");
        isAttacking = false;
    }

    public void AttackPower()
    {
        isAttackPower = true;
        anim.SetTrigger("Power Attaque");
        isAttackPower = false;
    }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public bool useoffsetvalues;

    //rotation caméra
    public float rotateSpeed;

    public Transform pivot;

	// Use this for initialization
	void Start () {
		
        if (!useoffsetvalues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        //position x de la souris et rotation
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        //position y de la souris et rotation
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        //Limite de la rotation de la caméra
        if (pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x <180)
        {
            pivot.rotation = Quaternion.Euler(45f, 0, 0);
        }


        //Rotation de la caméra basé sur le joueur
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
        }
        transform.LookAt(target);
	}
}

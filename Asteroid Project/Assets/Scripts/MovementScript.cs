using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody charRigidBody;
    //This is where character controller is stored which will then be attached to the object

    //[SerializeField] float jumpSpeed = 20.0f;
    [SerializeField] float gravity = 1.0f;
    float yVelocity = 0.0f;
    //These are the variables for the our jumping movement

    [SerializeField] float movespeed = 5.0f;
    public float h;
    public float v;
    //These are the variables for our movement on the ground

    // Use this for initialization
    void Start()
    {
        charRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame, this checks for player input
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        //Here we get the values of H and V, and save them using the Input class

        Vector3 direction = new Vector3(h, 0, v);
        Vector3 velocity = direction * movespeed;

        charRigidBody.position += velocity * Time.deltaTime;
    }


}

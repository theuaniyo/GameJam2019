using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public int moveSpeed;
    public int jumpPower;
    private String groundTag = "Ground";
    private bool jumping;
    private int saltos;
    private Transform tf;

    private Vector3 startPosition;

    private Vector3 endPosition;

    private bool subiendoCarril = false;

    private bool bajandoCarril = false;

    private float lerpValue = 0;

    public float movementTime = 5;


    
    


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        tf = GetComponent<Transform>();

        saltos = 0;

}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            saltos++;

            if(saltos == 2)
            {
                jumping = true;
            }


            
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           if(tf.position.z < 1 && !subiendoCarril && !bajandoCarril)
            {

                startPosition = tf.position;

                endPosition = new Vector3(tf.position.x, tf.position.y, tf.position.z + 3);
  
                subiendoCarril = true;

           }


        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (tf.position.z > -2 && !bajandoCarril && !subiendoCarril)
            {

                startPosition = tf.position;

                endPosition = new Vector3(tf.position.x, tf.position.y, tf.position.z - 3);

                bajandoCarril = true;

            }


        }

        if (subiendoCarril)
        {
            if(tf.position.z < 1)
            {
                lerpValue += Time.deltaTime / movementTime;
                tf.position = Vector3.Lerp(new Vector3(tf.position.x, tf.position.y, startPosition.z), 
                                            new Vector3(tf.position.x, tf.position.y, endPosition.z),
                                            lerpValue);

            }
            else
            {
                lerpValue = 0;
                subiendoCarril = false;
            }

        }

        if (bajandoCarril)
        {
            if (tf.position.z > -2)
            {
                lerpValue += Time.deltaTime / movementTime;
                tf.position = Vector3.Lerp(new Vector3(tf.position.x, tf.position.y, startPosition.z),
                                            new Vector3(tf.position.x, tf.position.y, endPosition.z),
                                            lerpValue);

            }
            else
            {
                lerpValue = 0;
                bajandoCarril = false;
            }



        }




    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals(groundTag))
        {
            jumping = false;

            saltos = 0;

        }
    }
}
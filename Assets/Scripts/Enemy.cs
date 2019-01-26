using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public List<Transform> positionMarks;

    private Vector3 startPosition;

    private Vector3 endPosition;

    private Transform tf;

    private int i = 0;

    private int numbMarks;

    public int movementTime;

    private float lerpValue = 0;

    private bool following = false;


    // Start is called before the first frame update
    void Start()
    {

        tf = GetComponent<Transform>();

        startPosition = tf.position;

        numbMarks = positionMarks.Count;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!following)
        {
            
            endPosition = positionMarks[i].position;

            Debug.Log(positionMarks[i].position);

            following = true;
        }
        else
        {
            if(lerpValue < 1)
            {
                lerpValue += Time.deltaTime / movementTime;

                tf.position = Vector3.Lerp(new Vector3(startPosition.x, tf.position.y, startPosition.z),
                                                   new Vector3(endPosition.x, tf.position.y, endPosition.z),
                                                   lerpValue);
            }
            else
            {
                if(i < numbMarks - 1) {

                    i++;

                    startPosition = endPosition;

                    following = false;

                    lerpValue = 0;

                }
                else
                {
                    i = 0;

                    startPosition = endPosition;

                    following = false;

                    lerpValue = 0;
                }

                
            }
            


        }

       

        


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indidibiningui : MonoBehaviour
{

    public GameObject fire;
    private bool gameStart;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Player>().enabled = false;
        gameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStart){
            if (Input.GetKey(KeyCode.Return))
            {
                fire.SetActive(true);
                gameObject.GetComponent<Player>().enabled = true;
                gameStart = true;
            }
        }
    }
}

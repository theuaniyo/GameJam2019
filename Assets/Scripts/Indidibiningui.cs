using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Indidibiningui : MonoBehaviour
{

    public GameObject fire;
    private bool gameStart;

    public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Player>().enabled = false;

        fire.SetActive(false);
        gameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStart){
            if (Input.anyKeyDown)
            {
                fire.SetActive(true);
                gameObject.GetComponent<Player>().enabled = true;
                gameStart = true;

                text.SetText("");

            }
        }

        
    }
}

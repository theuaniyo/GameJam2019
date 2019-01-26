using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform enemyPosition;
    public int moveSpeed;
    public Transform[] route;
    private float lerpValue;


    // Start is called before the first frame update
    void Start()
    {
        enemyPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform t in route)
        {
            while (enemyPosition.position != t.position)
            {
                lerpValue += Time.deltaTime / moveSpeed;
                enemyPosition.position = Vector3.Lerp(enemyPosition.position, t.position, lerpValue);
                Debug.Log();
            }
        }
    }
}
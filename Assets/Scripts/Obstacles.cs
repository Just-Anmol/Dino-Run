using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float leftEdge;

    // Start is called before the first frame update
    void Start()
    {
        // calculating the obstacle position so it can be deleted 
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;        
    }

    // Update is called once per frame
    void Update()
    {
        // Moving obstacles
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;

        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}

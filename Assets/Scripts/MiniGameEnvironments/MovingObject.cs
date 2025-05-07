using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{

    public float moveSpeed = 2f;


    
    void Start()
    {
        
    }

    
    void Update()
    {
        
        if (!MinigameManager.GameStarted)
            return;
        if (MinigameManager.GameOvered)
            return;
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -40f)
        {
            Destroy(gameObject); 
        }
        
    }
}

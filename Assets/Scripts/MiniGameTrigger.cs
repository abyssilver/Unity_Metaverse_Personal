using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniGameTrigger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "SkullGameScene";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Trigger: " + collision.name); 
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Detected! Loading Scene..."); 
            SceneManager.LoadScene(sceneToLoad);

            Debug.Log("SkullGameScene 진입 완료됨!");
        }

    }


}

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float playerYPos;

    public GameObject Particle;
    void Start()
    {
        playerYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManger.instance.gameStarted)
        {
            if (!Particle.activeInHierarchy)
            {
                Particle.SetActive(true);
            }
             if (Input.GetMouseButtonDown(0))
            {
                playerYPos = -playerYPos;

                transform.position = new Vector3(transform.position.x, playerYPos, transform.position.z);
            }
            
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            GameManger.instance.UpdateLives();
            GameManger.instance.ShakeCamera();
        }
    }
}

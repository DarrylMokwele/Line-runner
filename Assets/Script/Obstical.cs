using UnityEngine;

public class Obstical : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector2.left * speed * Time.deltaTime);

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -14f)
        {
            Destroy(gameObject);
            GameManger.instance.UpdateScore();
        }
      
    }
}

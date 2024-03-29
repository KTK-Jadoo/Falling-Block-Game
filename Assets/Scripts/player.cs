using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class player : MonoBehaviour
{
    public float speed = 8;
    float screenHalfWidthInWorldUnits;
    public event System.Action OnPlayerDeath;



    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }


    // trial comment, to check github desktop is working well.
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Blocker")
        {
            if (OnPlayerDeath != null) 
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}

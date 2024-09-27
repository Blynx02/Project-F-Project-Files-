using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable_Door : MonoBehaviour
{
    private bool closed = false;
    public float speed;
    public void Open_Door()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 3), speed * Time.deltaTime);
    }
    
    public void Close_Door()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - 3), speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Dialogue") == 4)
        {
            if (!closed)
            {
                Close_Door();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            closed= true;
        }
    }
}

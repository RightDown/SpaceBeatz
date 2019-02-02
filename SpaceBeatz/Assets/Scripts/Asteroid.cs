using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotationSpeed;
    public float moveSpeed;
    public float damage;
    public float score;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rocket>().Life -= damage;
            Destroy(gameObject);
        }
        else if (collision.name.Equals("AsteroidEnd"))
        {
            Destroy(gameObject);
        }
        else if (collision.name.Equals("GivePoint"))
        {
            GameManager.instance.score += score;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private Transform target;
    public float speed;
    public float stopDistance;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void EnemyFollow()
    {
        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
    void Update()
    {
        EnemyFollow();

        if (transform.position.x < 6)
        {
            transform.position = new Vector3(6, transform.position.y, transform.position.x);
        }
        if (transform.position.x > 17)
        {
            transform.position = new Vector3(17, transform.position.y, transform.position.x);
        }
        if (transform.position.y < -0.7f)
        {
            transform.position = new Vector3(transform.position.x, -0.7f, transform.position.x);
        }
        if (transform.position.y > -0.7f)
        {
            transform.position = new Vector3(transform.position.x, -0.7f, transform.position.x);
        }
    }
}

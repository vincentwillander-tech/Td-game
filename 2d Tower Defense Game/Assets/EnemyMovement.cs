using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;
    float maxSpeed = 5f;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.2f)
        {
            pathIndex++;

            if (pathIndex == LevelManager.main.path.Length)
            {
                Destroy(gameObject);
                return;
                
            } else { target = LevelManager.main.path[pathIndex]; }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        if (Vector2.Dot(rb.linearVelocity, direction) < maxSpeed)
        {
            rb.AddForce(direction * moveSpeed);
        }

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}


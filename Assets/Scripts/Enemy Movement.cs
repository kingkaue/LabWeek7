using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public float speed = 3.0f;
    private Rigidbody rb;
    private Vector3 rbTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (rbTarget - rb.position).normalized;
        rb.linearVelocity = direction * speed;
        if (Vector3.Distance(rb.position, rbTarget) < 0.5f)
        {
            rbTarget = (rbTarget == point1.transform.position) ? point2.transform.position : point1.transform.position;
        }
    }
}

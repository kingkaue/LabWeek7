using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public float speed = 3.0f;
    private Rigidbody rb;
    private Vector3 rbTarget;
    private GameObject player;

    private NavMeshAgent m_Agent;
    public Transform[] waypoints;
    private int currentLocation = 0;
    private bool chasingPlayer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rbTarget = point1.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        m_Agent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy movement week 7
        if (!chasingPlayer && !m_Agent.pathPending && m_Agent.remainingDistance < 0.2f)
        {
            MoveToNextLocation();
        }

        if (chasingPlayer)
        {
            m_Agent.SetDestination(player.transform.position);
        }

        /*
        Vector3 direction = (rbTarget - rb.position).normalized;
        Debug.DrawRay(rb.position, direction * 2, Color.magenta);
        rb.linearVelocity = direction * speed;
        if (Vector3.Distance(rb.position, rbTarget) < 0.5f)
        {
            rbTarget = (rbTarget == point1.transform.position) ? point2.transform.position : point1.transform.position;
        }
        */

        /*//Interaction with player
        gameObject.transform.forward = direction;
        Vector3 toTarget = player.transform.position - gameObject.transform.position;
        Vector3 forward = gameObject.transform.forward;
        float dot = Vector3.Dot(forward, player.transform.position.normalized);

        if (dot > 0)
        {
            Debug.Log("Found player!");
        }*/
    }

    void MoveToNextLocation()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        m_Agent.SetDestination(waypoints[currentLocation].position);
        currentLocation = (currentLocation + 1) % waypoints.Length;
    }

    // Enemy collision with player
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Player detected, initiating attack!");
            chasingPlayer = true;
            m_Agent.destination = player.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Player out of range, returning to patrol");
            chasingPlayer = false;
            MoveToNextLocation();
        }
    }
}

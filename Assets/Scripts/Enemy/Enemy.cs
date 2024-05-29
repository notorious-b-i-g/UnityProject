using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private NavMeshAgent agent;
    private Rigidbody2D rb;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(player.position);
        if (agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            Vector2 direction = (agent.steeringTarget - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            Debug.Log("Velocity after collision start: " + rb.velocity);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            Debug.Log("Velocity after collision end: " + rb.velocity);
        }
    }
}

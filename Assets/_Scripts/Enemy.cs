using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float forceFactor = 3;
    private NavMeshAgent agent;
    private GameObject player;
    private Rigidbody rb;

    private float reActivationTimer = 0;
    private float reActivationTimerMax = 3f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        agent = GetComponent<NavMeshAgent>();
        if (!agent.enabled)
        {
            reActivationTimer += Time.deltaTime;
        }
        else
        {
            agent.SetDestination(player.transform.position);
            transform.forward = Vector3.Slerp(transform.position, player.transform.position - transform.position, 100);
        }

        if (reActivationTimer >= reActivationTimerMax)
        {
            agent.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wave"))
        {
            agent = GetComponent<NavMeshAgent>();
            agent.enabled = false;
            reActivationTimer = 0f;
            rb.AddForce(-transform.forward * forceFactor, ForceMode.Impulse);
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            ScoreUI.Instance.IncreaseScore();
        }
    }
}

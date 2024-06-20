using UnityEngine;
using UnityEngine.AI;

public class FishAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range = 10f; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("MoveToRandomPosition", 0, 5f); 
    }

    void MoveToRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, range, 1))
        {
            Vector3 finalPosition = hit.position;
            agent.SetDestination(finalPosition);
        }
    }
}

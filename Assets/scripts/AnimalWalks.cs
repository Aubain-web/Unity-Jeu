using UnityEngine;
using UnityEngine.AI;

public class AnimalMovement : MonoBehaviour
{
	private NavMeshAgent agent;
	private Vector3 destination;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		SetRandomDestination();
		
	}

	void Update()
	{
		if (!agent.pathPending && agent.remainingDistance < 0.5f)
		{
			SetRandomDestination();
		}
	}

	void SetRandomDestination()
	{
		Vector3 randomDirection = Random.insideUnitSphere * 50f; 
		randomDirection += transform.position;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, 50f, 1); 
		destination = hit.position;
		agent.SetDestination(destination);
	}
}

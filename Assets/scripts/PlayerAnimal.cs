using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	public float interactRadius = 5f; 

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.D))
		{
			InteractWithClosestAnimal();
		}
	}

	void InteractWithClosestAnimal()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactRadius);
		GameObject closestAnimal = null;
		float closestDistance = interactRadius;

		foreach (Collider collider in hitColliders)
		{
			if (collider.CompareTag("Animal")) 
			{
				float distance = Vector3.Distance(transform.position, collider.transform.position);
				if (distance < closestDistance)
				{
					closestAnimal = collider.gameObject;
					closestDistance = distance;
					//Destroy(closestAnimal);
				}
			}
		}

		if (closestAnimal != null)
		{
			Destroy(closestAnimal);
			Debug.Log("Nearest animal eliminated: " + closestAnimal.name);
		}
		else
		{
			Debug.LogWarning("No animal within 5 meters to eliminate.");
		}
	}
}

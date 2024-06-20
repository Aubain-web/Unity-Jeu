using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public Transform animalContainer; 
    public Transform player; 
    public CountManager countManager; 

    private float killDistance = 5f; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            KillClosestAnimal();
        }
    }

    private void KillClosestAnimal()
    {
        GameObject closestAnimal = null;
        float closestDistance = killDistance;

        foreach (Transform animalTransform in animalContainer)
        {
            GameObject animal = animalTransform.gameObject;
            float distance = Vector3.Distance(player.position, animal.transform.position);
            if (distance < closestDistance)
            {
                closestAnimal = animal;
                closestDistance = distance;
            }
        }

        if (closestAnimal != null)
        {
            Destroy(closestAnimal); // Destroy the animal
            Debug.Log("Animal killed: " + closestAnimal.name);
            countManager.UpdateAnimalCount(); // Update animal count
        }
        else
        {
            Debug.LogWarning("No animal within 5 meters to kill.");
        }
    }
}

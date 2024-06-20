using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class qualityLife : MonoBehaviour
{
	[SerializeField]
	private int startLife = 100;

	[SerializeField]
	private Text LifeLeft;

	public TreeManager treeManager; // conteneur des arbres
	public Transform animals ; //conteneur des animaux

	private int cutTreeCount = 0; //arbres coupées
	private bool isAccelerated = false; //accélération
	private Coroutine decreaseLifeCoroutine; 

	private float killDistance = 5f; 

	void Start()
	{
		LifeLeft.text = "Quality: " + startLife + "%";
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.X))
		{
			treeManager.CutClosestTree();
			cutTreeCount = treeManager.GetCountCutTrees();

			Debug.Log("Number of trees cut: " + cutTreeCount);

			if (cutTreeCount >= 3 && decreaseLifeCoroutine == null)
			{
				decreaseLifeCoroutine = StartCoroutine(DecreaseLifeOverTime());
			}
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			KillClosestAnimal();
		}
	}

	IEnumerator DecreaseLifeOverTime()
	{
		while (startLife > 0)
		{
			yield return new WaitForSeconds(isAccelerated ? 0.05f : 1f); 
			startLife--;

			if (startLife < 60)
			{
				LifeLeft.text = "Bad quality: " + startLife + "%";
			}
			else
			{
				LifeLeft.text = "Quality: " + startLife + "%";
			}
		}

		LifeLeft.text = "You died : 0%";
		Debug.Log("Environment Bad !!!");
	}

	private void KillClosestAnimal()
	{
		GameObject closestAnimal = null;
		float closestDistance = killDistance;

		foreach (Transform animalTransform in animals)
		{
			GameObject animal = animalTransform.gameObject;
			float distance = Vector3.Distance(transform.position, animal.transform.position);
			if (distance < closestDistance)
			{
				closestAnimal = animal;
				closestDistance = distance;
			}
		}

		if (closestAnimal != null)
		{
			Destroy(closestAnimal); 
			Debug.Log("Animal killed: " + closestAnimal.name);

			if (decreaseLifeCoroutine != null)
			{
				StartCoroutine(AccelerateCoroutine()); 
				Debug.Log("Starting acceleration coroutine.");
			}
		}
		else
		{
			Debug.LogWarning("No animal within 5 meters to kill.");
		}
	}

	IEnumerator AccelerateCoroutine()
	{
		isAccelerated = true;
		Debug.Log("Acceleration started.");
		yield return new WaitForSeconds(5f); 
		isAccelerated = false;
		Debug.Log("Acceleration ended.");
	}
}

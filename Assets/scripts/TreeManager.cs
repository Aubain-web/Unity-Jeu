using UnityEngine;

public class TreeManager : MonoBehaviour
{
	public Transform treeContainer; // arbres gameObject
	public Transform player; // le joueur
	public CountManager countManager; // compter

	private float cutDistance = 10f; 
	private int countCutTrees = 0;

	void Start()
	{
		if (treeContainer == null || treeContainer.childCount == 0)
		{
			Debug.LogWarning("No trees referenced in the container.");
		}
		else
		{
			Debug.Log("Number of referenced trees: " + treeContainer.childCount);
		}
	}

	public void CutClosestTree()
	{
		if (treeContainer == null || treeContainer.childCount == 0)
		{
			Debug.LogWarning("No trees to cut.");
			return;
		}

		Transform closestTree = null;
		float closestDistance = cutDistance;

		foreach (Transform tree in treeContainer)
		{
			if (tree != null)
			{
				float distance = Vector3.Distance(player.position, tree.position);
				if (distance < closestDistance)
				{
					closestTree = tree;
					closestDistance = distance;
				}
			}
		}

		if (closestTree != null)
		{
			Destroy(closestTree.gameObject); 
			Debug.Log("Tree cut: " + closestTree.name);
			countCutTrees++; 
			countManager.UpdateTreeCount(); 
		}
		else
		{
			Debug.LogWarning("No tree close enough to cut.");
		}
	}

	//avoir le nombre d'arbres coupés
	public int GetCountCutTrees()
	{
		return countCutTrees;
	}
}

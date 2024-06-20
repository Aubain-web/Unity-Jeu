using UnityEngine;

public class TreeCutterInput : MonoBehaviour
{
    public TreeManager treeManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (treeManager != null)
            {
                treeManager.CutClosestTree();
            }
            else
            {
                Debug.LogError("TreeManager est null. Assurez-vous qu'il est assigné dans l'Inspecteur.");
            }
        }
    }
}

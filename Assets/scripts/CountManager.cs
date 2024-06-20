using UnityEngine;
using UnityEngine.UI;

public class CountManager : MonoBehaviour
{
    public Text countText; // Reference to the UI Text component
    public Transform treeContainer; // Container holding all tree GameObjects
    public Transform animalContainer; // Container holding all animal GameObjects

    private int treeCount;
    private int animalCount;

    void Start()
    {
        // Initialize counts
        treeCount = treeContainer.childCount;
        animalCount = animalContainer.childCount;

        // Update the UI
        UpdateCountText();
    }

    public void UpdateTreeCount()
    {
        treeCount = treeContainer.childCount;
        UpdateCountText();
    }

    public void UpdateAnimalCount()
    {
        animalCount = animalContainer.childCount;
        UpdateCountText();
    }

    private void UpdateCountText()
    {
        countText.text = "Trees: " + treeCount + " | Animals: " + animalCount;
    }
}

using UnityEngine;
using UnityEngine.UI;

// A hidden clue! Search furniture to find all 5 clues.
// When you have all 5, the key to the front door appears!
public class Clue : MonoBehaviour
{
    [HideInInspector] public bool found = false;

    [Header("Drag the key object here (starts hidden)")]
    public GameObject doorKey;

    [Header("Show clue count here")]
    public Text clueText;

    private static int cluesFound = 0;
    private const int cluesNeeded = 5;

    public void Collect()
    {
        if (found) return;
        found = true;
        cluesFound++;

        Debug.Log("Found a clue! (" + cluesFound + "/" + cluesNeeded + ")");

        // Hide this clue's sparkle
        gameObject.SetActive(false);

        if (clueText) clueText.text = "Clues: " + cluesFound + "/" + cluesNeeded;

        if (cluesFound >= cluesNeeded)
        {
            Debug.Log("You found all 5 clues! The key appears!");
            if (doorKey) doorKey.SetActive(true);
        }
    }

    // Call this when starting a new game
    public static void ResetClues()
    {
        cluesFound = 0;
    }
}

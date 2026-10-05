using UnityEngine;
using UnityEngine.UI;

// The witch! She starts away from home.
// When you unlock the front door with the key, she appears and shouts:
// "How dare you leave! I'm going to catch you!"
// Then she chases you - run and follow the glowing lights!
public class WitchChase : MonoBehaviour
{
    [Header("Drag the brave girl here")]
    public Transform girl;

    [Header("How fast the witch flies")]
    public float chaseSpeed = 4f;

    [Header("Show witch's words here")]
    public Text witchText;

    [Header("The glowing trail home (starts hidden)")]
    public GameObject glowTrail;

    private bool chasing = false;

    // Call this when the girl unlocks the front door
    public void StartChase()
    {
        gameObject.SetActive(true);
        chasing = true;

        if (witchText)
        {
            witchText.text = "How dare you leave! I'm going to catch you!";
        }
        Debug.Log("The witch is chasing you! RUN!");

        // The glowing lights appear to guide you home
        if (glowTrail) glowTrail.SetActive(true);
    }

    void Update()
    {
        if (!chasing || girl == null) return;

        // Fly toward the girl
        transform.position = Vector2.MoveTowards(
            transform.position,
            girl.position,
            chaseSpeed * Time.deltaTime
        );
    }

    // If the witch catches you, she drags you back to the house!
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BraveGirl>() != null)
        {
            Debug.Log("The witch caught you! Back to the old house...");
            // Reset: put the girl back at the start, witch goes away
            // (Hook up your own reset logic here)
        }
    }
}

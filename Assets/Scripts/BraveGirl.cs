using UnityEngine;

// The brave little girl! Move with WASD / arrow keys (or touch joystick).
// Walk up to furniture and press E (or tap it) to search for clues.
public class BraveGirl : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Searching")]
    public float searchRange = 2f;
    public KeyCode searchKey = KeyCode.E;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        // Search when pressing E
        if (Input.GetKeyDown(searchKey))
        {
            SearchNearby();
        }
    }

    void FixedUpdate()
    {
        if (rb) rb.velocity = moveInput * speed;
        else transform.Translate(moveInput * speed * Time.deltaTime);
    }

    // Tap-to-search for touch screens
    public void TapSearch()
    {
        SearchNearby();
    }

    void SearchNearby()
    {
        // Find the closest searchable object in range
        Clue[] clues = FindObjectsOfType<Clue>();
        Clue closest = null;
        float bestDist = searchRange;

        foreach (Clue c in clues)
        {
            if (c.found) continue;
            float d = Vector2.Distance(transform.position, c.transform.position);
            if (d < bestDist)
            {
                bestDist = d;
                closest = c;
            }
        }

        if (closest != null)
        {
            closest.Collect();
        }
        else
        {
            Debug.Log("Nothing to search here...");
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

// The glowing lights that lead the brave girl home!
// Follow the glowing trail while the witch chases you.
// Reach the last light and you're HOME SAFE!
public class GlowTrail : MonoBehaviour
{
    [Header("Put the glowing lights in order, first to last")]
    public Transform[] lights;

    [Header("Show this when you make it home")]
    public Text winText;

    private int nextLight = 0;

    void Start()
    {
        // Light up only the first one
        UpdateLights();
    }

    // Call this when the girl touches a glowing light
    public void TouchLight(int lightIndex)
    {
        if (lightIndex != nextLight) return;

        nextLight++;
        Debug.Log("Following the lights... (" + nextLight + "/" + lights.Length + ")");

        if (nextLight >= lights.Length)
        {
            Win();
        }
        else
        {
            UpdateLights();
        }
    }

    void UpdateLights()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            // Only the next light glows brightly
            var glow = lights[i].GetComponent<SpriteRenderer>();
            if (glow) glow.color = (i == nextLight) ? Color.white : new Color(1, 1, 1, 0.3f);
        }
    }

    void Win()
    {
        Debug.Log("YOU MADE IT HOME!");
        if (winText) winText.text = "YOU MADE IT HOME! The End";
    }
}

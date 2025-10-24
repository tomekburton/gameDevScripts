using UnityEngine;
using UnityEngine.UI;

// Attach to empty gameObject - GUI controller
public class guiCreate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        goldBox();
        healthBar();
    }

    // Handles logic of showing amount of health - To change visuals
    private void healthBar()
    {
        float healthBarWidth = Screen.width * 0.2f;
        float healthBarHeight = Screen.height * 0.08f;
        float healthBarX = Screen.width * 0.05f;  // Distance from left edge
        float healthBarY = Screen.height * 0.05f; // Distance from top edge

        float healthPercentage = Mathf.Clamp01(healthScript.playerHealth / healthScript.playerMaxHealth);

        // Background of Box
        GUIStyle backgroundStyle = new GUIStyle(GUI.skin.box);
        GUI.Box(new Rect(healthBarX, healthBarY, healthBarWidth, healthBarHeight), "", backgroundStyle);

        // Make Red Texture
        Texture2D redTexture = new Texture2D(1, 1);
        redTexture.SetPixel(0, 0, Color.darkRed);
        redTexture.Apply();

        GUI.DrawTexture(new Rect(healthBarX, healthBarY, healthBarWidth * healthPercentage, healthBarHeight), redTexture);  

        // Amount of health
        GUIStyle textStyle = new GUIStyle(GUI.skin.label);
        textStyle.fontSize = Mathf.RoundToInt(Screen.height * 0.04f);
        textStyle.alignment = TextAnchor.MiddleCenter;
        textStyle.normal.textColor = Color.white;
        textStyle.fontStyle = FontStyle.Italic;
    
        GUI.Label(new Rect(healthBarX, healthBarY, healthBarWidth, healthBarHeight), healthScript.playerHealth + " / " + healthScript.playerMaxHealth, textStyle);
    }

    // Handles logic of showing amount of gold - To change visuals
    private void goldBox()
    {
        float goldBoxWidth = Screen.width * 0.2f;
        float goldBoxHeight = Screen.height * 0.08f;
        float goldBoxX = Screen.width * 0.05f;  // Distance from left edge
        float goldBoxY = Screen.height * 0.15f; // Distance from top edge

        // Gold Texture
        Texture2D goldTexture = new Texture2D(1, 1);
        goldTexture.SetPixel(0, 0, Color.gold);
        goldTexture.Apply();

        GUI.DrawTexture(new Rect(goldBoxX, goldBoxY, goldBoxWidth, goldBoxHeight), goldTexture);

        // Label
        GUIStyle textstyle = new GUIStyle(GUI.skin.label);
        textstyle.fontSize = Mathf.RoundToInt(Screen.height * 0.04f);
        textstyle.alignment = TextAnchor.MiddleCenter;
        textstyle.fontStyle = FontStyle.Italic;

        GUI.Label(new Rect(goldBoxX, goldBoxY, goldBoxWidth, goldBoxHeight), "Gold: " + goldCounter.gold, textstyle);
    }
}

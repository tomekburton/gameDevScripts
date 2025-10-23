using Unity.Mathematics;
using UnityEngine;

public class healthScript : MonoBehaviour
{
    public static float playerHealth = 100;
    public static float playerMaxHealth = 100;
    public static bool isPlayerAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    // Method to update Health and kill player from anywhere
    public static float updateHealth(float amount)
    {
        GameObject player = storeSelf.player; // Reference from storeSelf.cs

        // Player health stays between 0 and max health
        playerHealth = math.clamp(playerHealth + amount, 0f, playerMaxHealth); 
        
        // Kills player when health = 0 - Should return player to a different scene possibly
        if (playerHealth <= 0f)
        {
            Debug.Log("You are Dead");
            isPlayerAlive = false;
            Destroy(player);
            playerHealth = 0f;
        }
        return playerHealth;
    }
}

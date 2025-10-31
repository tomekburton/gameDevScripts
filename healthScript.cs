using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

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
        // For testing only remove after 
        if (Keyboard.current.rightAltKey.isPressed)
        {
            Debug.Log("Health is Down");
            updateHealth(-1);
        }
        if (Keyboard.current.leftAltKey.isPressed)
        {
            updateHealth(1);
        }
    }
    
    // Method to update Health and kill player from anywhere. Use this method and not simply playerHealth -= 1
    // Don't need to include armourAffected if you want to keep it true
    public static float updateHealth(float amount, bool armourAffected = true)
    {
        GameObject player = storeSelf.player; // Reference from storeSelf.cs
        float totReductionFactor = amount - amount * (armourController.armourAmount / (armourController.armourAmount + armourController.armourReductionFactor));
        
        if (armourAffected)
        {
            amount -= amount * (armourController.armourAmount / (armourController.armourAmount + armourController.armourReductionFactor));
        }
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
        Debug.Log("Health reduced by: ");
        Debug.Log(totReductionFactor);
        return playerHealth;
    }
}

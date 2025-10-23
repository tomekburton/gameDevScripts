using Unity.Mathematics;
using UnityEngine;

public class healthScript : MonoBehaviour
{
    public static float playerHealth = 100;
    public static float playerMaxHealth = 100;
    public static bool isPlayerAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        // if (player == null)
        // {
        //     Debug.LogError("healthScript: Player GameObject not assigned in the Inspector", this);
        // }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public static float updateHealth(float amount)
    {
        GameObject player = storeSelf.player;

        playerHealth = math.clamp(playerHealth + amount, 0f, playerMaxHealth);
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

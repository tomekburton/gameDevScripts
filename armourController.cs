using UnityEngine;

public class armourController : MonoBehaviour
{
    // Between 0 and 1 affects the damage dealt by most attacks
    public static float armourAmount = 0.0f; // Set to 0.5 for testing - change back
    public static float armourReductionFactor = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Potentially add bool result to prevent going over the amount (100%) -- actually not doing this
    public static void changeArmourAmount(float amount)
    {
        // armourAmount = Mathf.Clamp01(armourAmount + amount);
        armourAmount += amount;
    }
    
}

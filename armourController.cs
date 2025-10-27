using UnityEngine;

public class armourController : MonoBehaviour
{
    // Between 0 and 1 affects the damage dealt by most attacks
    public static float armourAmount = 0.5f; // Set to 0.5 for testing - change back
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void changeArmound(float amount)
    {
        armourAmount = Mathf.Clamp01(armourAmount + amount);
    }
    
}

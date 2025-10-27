using UnityEngine;

public class armourController : MonoBehaviour
{
    public static float armourAmount = 0.0f; // Between 0 and 1 affects the damage dealt by most attacks
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
        armour = Mathf.Clamp01(armourAmount + amount);
    }
    
}

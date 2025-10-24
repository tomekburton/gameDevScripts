using UnityEngine;
using UnityEngine.InputSystem;

public class goldCounter : MonoBehaviour
{
    public static int gold = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // For testing only remove after 
        if (Keyboard.current.leftBracketKey.isPressed)
        {
            changeGoldAmount(-1);
        }
        if (Keyboard.current.rightBracketKey.isPressed)
        {
            changeGoldAmount(1);
        }
    }

    public static bool changeGoldAmount(int amount)
    {
        gold += amount;
        if (gold < 0)
        {
            gold -= amount;
            return false;
        }
        return true;
    }
}

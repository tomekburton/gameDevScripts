using UnityEngine;

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

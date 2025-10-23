using UnityEngine;

// Script should be attached to main player parent gameObject
public class storeSelf : MonoBehaviour
{


    // Allows for access of player gameObject anywhere
    public static GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = gameObject;
        if (player == null)
        {
            Debug.LogError("storeSelf: Player GameObject not assigned in the Inspector", this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

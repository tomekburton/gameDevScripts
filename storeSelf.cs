using UnityEngine;

public class storeSelf : MonoBehaviour
{

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

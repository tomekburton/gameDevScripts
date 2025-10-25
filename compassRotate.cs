using UnityEngine;

// Attach to compass UI element
public class compassRotate : MonoBehaviour
{
    public Transform player;
    public RectTransform compass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Don't know if this works, might have to add manually
        if (player == null)
        {
            player = storeSelf.player.transform;
        }
        compass = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Sets compass to follow global rotation as opposed to player - eulerAngles represents "rotation in world space"
        if (player != null)
        {
            float playerRotation = player.eulerAngles.y;
            compass.rotation = Quaternion.Euler(0f, 0f, playerRotation);

        }
    }
}

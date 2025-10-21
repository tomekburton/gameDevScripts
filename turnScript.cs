using UnityEngine;

public class turnScript : MonoBehaviour
{

    public float mouseXInput;
    public float horizontalRotSpeed = 5f;

    public float verticalRotSpeed = 5f;
    public float minPitch = -80f, maxPitch = 80f;
    float pitch;

    // head transform is what rotates up and down
    [Header("Add head/part that rotates here")]
    public Transform head;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalRotation();
        verticalRotation();
    }

    void horizontalRotation()
    {
        mouseXInput = Input.GetAxis("Mouse X") * horizontalRotSpeed;
        transform.Rotate(Vector3.up * mouseXInput);
    }

    void verticalRotation()
    {
        
        float mouseYInput = Input.GetAxis("Mouse Y") * verticalRotSpeed;

        pitch = Mathf.Clamp(pitch + mouseYInput, minPitch, maxPitch);

        head.localRotation = Quaternion.Euler(-pitch, 0f, 0f);
    }
}

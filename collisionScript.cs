using UnityEngine;

public class collisionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnChildCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            Debug.Log("You hit the ground");
        }
        else
        {
            Debug.Log("You hit something else");
        }
    }
}

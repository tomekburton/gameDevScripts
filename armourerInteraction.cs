using TMPro;
using UnityEngine;

public class armourerInteraction : MonoBehaviour
{
    private bool inRange = false;


    private Camera mainCam;

    public GameObject dialoguePanel;
    public TextMeshProUGUI armourerShopInfo;
    public TextMeshProUGUI armourerBuyButton;

    public GameObject armourerGUI;

    public GameObject rayPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // GameObject player = storeSelf.player;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); // Remember to set mainCamera tag to MainCamera
        
        if (armourerGUI != null)
        {
            armourerGUI.SetActive(false);
        }
    }   

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (IsVisibleToCam(mainCam) && isFacingCamera(mainCam))
            {
                Debug.Log("Showing cast");
                showUI();
            } 
        } else
        {
            armourerGUI.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("In range");
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    bool isFacingCamera(Camera mainCamera)
    {
        Vector3 toNPC = (transform.position - mainCamera.transform.position).normalized;
        float dotProduct = Vector3.Dot(mainCamera.transform.forward, toNPC);

        return dotProduct > 0.6f;
    }

    bool IsVisibleToCam(Camera mainCamera)
    {
        // Debug.Log("Sending Cast");
        Vector3 directionToCamera = mainCamera.transform.position - transform.position;
        // Ray ray = new Ray(transform.position, directionToCamera);
        Vector3 origin = rayPoint.transform.position;
        int layerMask = ~LayerMask.GetMask("Player", "Ignore Raycast", "NPC"); // for example
        // True if no obstacles between you and the camera
        Debug.Log("Shooting something");
        Debug.Log(!Physics.Raycast(origin, directionToCamera, directionToCamera.magnitude, layerMask));
        return !Physics.Raycast(origin, directionToCamera, directionToCamera.magnitude, layerMask);

        // if (Physics.Raycast(ray, out RaycastHit hit, directionToCamera.magnitude, layerMask))
        // {
        //     Debug.Log("Hit something");
        //     Debug.Log(hit.transform);
        //     Debug.Log(mainCamera.transform);
        //     Debug.Log(hit.transform == mainCamera.transform);
        //     return hit.transform == mainCamera.transform;
        // }
        // Debug.Log("hit nothing");
        // return true;
    }

    void showUI()
    {
        armourerGUI.SetActive(true);
    }
}

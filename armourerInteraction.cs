using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class armourerInteraction : MonoBehaviour
{
    private bool inRange = false;


    private Camera mainCam;

    public GameObject dialoguePanel;
    public TextMeshProUGUI armourerShopInfo;
    public GameObject armourerBuyButton;

    public TextMeshProUGUI armourerSaleInfo;

    [Header("Parent Object")]
    public GameObject armourerGUI;

    public GameObject rayPoint;

    private bool showingUI = false;


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
                // Debug.Log("Showing cast");
                showUI();
            }
        }
        else
        {
            armourerGUI.SetActive(false);
            armourerSaleInfo.text = "";
            showingUI = false;
        }
        
        if (showingUI)
        {
            if (Keyboard.current.bKey.wasPressedThisFrame)
            {
                if (goldCounter.changeGoldAmount(-50))
                {
                    armourController.changeArmourAmount(5f);
                    armourerSaleInfo.text = "Added 5 armour, you now take less damage!";            
                } else
                {
                    armourerSaleInfo.text = "Not enough Gold to buy armour";
                }
            }
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
        // Debug.Log("Shooting something");
        // Debug.Log(!Physics.Raycast(origin, directionToCamera, directionToCamera.magnitude, layerMask));
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
        showingUI = true;
    }

    private void armourBox()
    {
        float armourBoxWidth = Screen.width * 0.2f;
        float armourBoxHeight = Screen.height * 0.08f;
        float armourBoxX = Screen.width * 0.75f;  // Distance from left edge
        float armourBoxY = Screen.height * 0.05f; // Distance from top edge

        // Armour Texture
        Texture2D armourTexture = new Texture2D(1, 1);
        armourTexture.SetPixel(0, 0, Color.darkGray);
        armourTexture.Apply();

        GUI.DrawTexture(new Rect(armourBoxX, armourBoxY, armourBoxWidth, armourBoxHeight), armourTexture);

        // Label
        GUIStyle textstyle = new GUIStyle(GUI.skin.label);
        textstyle.fontSize = Mathf.RoundToInt(Screen.height * 0.04f);
        textstyle.alignment = TextAnchor.MiddleCenter;
        textstyle.fontStyle = FontStyle.Italic;

        GUI.Label(new Rect(armourBoxX, armourBoxY, armourBoxWidth, armourBoxHeight), "Armour: " + Math.Round(armourController.armourAmount, 2), textstyle);
    }

    void OnGUI()
    {
        if (showingUI)
        {
            armourBox();
        }
    }
}

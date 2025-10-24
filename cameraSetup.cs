using Unity.VisualScripting;
using UnityEngine;

public class cameraSetup : MonoBehaviour
{

    public Camera mainCamera;
    public Camera miniMapCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setupMainCamera();
        setupMiniMapCamera();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void setupMainCamera()
    {
        mainCamera.depth = 0;
        mainCamera.rect = new Rect(0, 0, 1, 1);
        mainCamera.tag = "MainCamera";
    }
    
    void setupMiniMapCamera()
    {
        miniMapCamera.depth = 1;
        miniMapCamera.rect = new Rect(0.75f, 0f, 0.25f, 0.25f);

        miniMapCamera.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandScript : MonoBehaviour
{
    public Material mat;
    private Material originalMat;
    // Start is called before the first frame update
    void Start()
    {
        originalMat = GetComponentInChildren<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float mouseNormX = mouseX / screenWidth;
        float mouseNormY = mouseY / screenHeight;
        WandOrientation(mouseNormX, mouseNormY);

        if (Input.GetMouseButtonDown(0))
        {
            GetComponentInChildren<MeshRenderer>().material = mat;
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponentInChildren<MeshRenderer>().material = originalMat;
        }
    }

    void WandOrientation(float mouseNormX, float mouseNormY)
    {
        float xAngle = (-75f * (mouseNormY - 0.5f));
        float yAngle = (75f * (mouseNormX - 0.5f));
        Vector3 motion = new Vector3(xAngle, yAngle, 0f);
        transform.localEulerAngles = motion;
    }

}

using TMPro;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float maxRayDistance = 5f;
    [SerializeField] private Material Common;
    [SerializeField] private Material Look;
    [SerializeField] private Material Selected;
    [SerializeField] private GameObject canvas;
    [SerializeField] private float distance = 1.5f;
    [SerializeField] private float height = 1.0f;
    [SerializeField] private TMP_Text infoText;

    private bool isVisible = false;
    private GameObject LookObject;
    private GameObject selectedObject;

    void Update()
    {
        SelectingObject();

        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            if (LookObject != null)
            {
                if (selectedObject != null)
                {
                    SetMaterial(selectedObject, Common);
                }

                selectedObject = LookObject;
                SetMaterial(selectedObject, Selected);
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Down, OVRInput.Controller.RTouch))
        {
            isVisible = !isVisible;
            canvas.SetActive(isVisible);

            if (isVisible) { 
                FollowCamera();
                GetNameObject();
            }
        }
    }

    void SelectingObject()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        RaycastHit hit;

        if (LookObject != null && LookObject != selectedObject)
        {
            SetMaterial(LookObject, Common);
        }

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("GrabBox"))
            {
                LookObject = hitObject;

                if (LookObject != selectedObject)
                {
                    SetMaterial(LookObject, Look);
                }
                return;
            }
        }
    }

    void SetMaterial(GameObject obj, Material mat)
    {
        Renderer rend = obj.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material = mat;
        }
    }

    void GetNameObject()
    {
        if (selectedObject != null) {
            infoText.text = "Об'єкт: " + selectedObject.name;
        }
    }

    public void DeleteObject()
    {
        if (selectedObject != null)
        {
            Destroy(selectedObject);
            selectedObject = null;
        }
    }

    void FollowCamera()
    {
        Vector3 forward = cameraTransform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 targetPosition = cameraTransform.position + forward * distance;
        targetPosition.y = cameraTransform.position.y + height;

        canvas.transform.position = targetPosition;
        canvas.transform.rotation = Quaternion.LookRotation(forward);
    }


}

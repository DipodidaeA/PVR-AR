using Unity.VisualScripting;
using UnityEngine;

public class CanvasPlayer : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float distance = 1.5f;
    [SerializeField] private float height = 1.0f;
    private bool isVisible = false;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            isVisible = !isVisible;
            canvas.SetActive(isVisible);

            if (isVisible) { FollowCamera(); }
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

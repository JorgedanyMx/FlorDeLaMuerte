using UnityEngine;

public class MousePosition2D : MonoBehaviour 
{
    [SerializeField] private Camera mainCamera;  

    private void Update()
    {
        GetMousePosition();
    }
    
    private Vector3 GetMousePosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        transform.position = mouseWorldPosition;
        return mouseWorldPosition;
    }
}
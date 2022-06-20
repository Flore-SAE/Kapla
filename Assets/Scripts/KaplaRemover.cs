using UnityEngine;

public class KaplaRemover : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void Remove(Vector2 mousePosition)
    {
        var ray = mainCamera.ScreenPointToRay(mousePosition);
        var intersect = Physics2D.GetRayIntersection(ray);
        if(intersect.collider != null)
            Destroy(intersect.transform.gameObject);
    }
}
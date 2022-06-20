using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject kapla;
    public Transform parent;

    private void Awake()
    {
        if(parent.lossyScale != Vector3.one)
            Debug.LogError("Non unit vector on parent scale, please fix it or expect bugs.");
    }

    public void Spawn(Transform reference)
    {
        if(!enabled)
            return;
        var newKapla = Instantiate(kapla, parent);
        newKapla.transform.position = reference.position;
        newKapla.transform.rotation = reference.rotation;
        newKapla.transform.localScale = reference.lossyScale;
    }
}

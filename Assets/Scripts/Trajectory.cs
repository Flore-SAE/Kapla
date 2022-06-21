using UnityEngine;

[RequireComponent(typeof(Canon))]
public class Trajectory : MonoBehaviour
{
    public int dotsNumber;
    public GameObject dotPrefab;
    public float dotSpacing;
    [Range(0.01f, 0.3f)] public float dotMinScale;
    [Range(0.3f, 1f)] public float dotMaxScale;

    private GameObject dotsParent;
    private Canon canon;
    private Transform[] dotsList;
    private Vector2 pos;
    private float timeStamp;

    private void Awake()
    {
        canon = GetComponent<Canon>();
    }

    private void Start()
    {
        dotsParent = new GameObject("DotsParent");
        PrepareDots();
    }

    private void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];
        dotPrefab.transform.localScale = Vector3.one * dotMaxScale;

        var scale = dotMaxScale;
        var scaleFactor = scale / dotsNumber;

        for (var i = 0; i < dotsNumber; i++)
        {
            dotsList[i] = Instantiate(dotPrefab, dotsParent.transform).transform;

            dotsList[i].localScale = Vector3.one * scale;
            if (scale > dotMinScale)
                scale -= scaleFactor;
        }
    }

    private void UpdateDots()
    {
        timeStamp = dotSpacing;
        var position = transform.position;
        var mass = canon.projectile.mass;
        for (var i = 0; i < dotsNumber; i++)
        {
            pos.x = position.x + canon.appliedForce.x * timeStamp;
            var appliedGravity = Physics2D.gravity.magnitude * mass * mass * timeStamp * timeStamp / 2f;
            pos.y = position.y + canon.appliedForce.y * timeStamp - appliedGravity;
            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }

    private void Update()
    {
        UpdateDots();
    }
}

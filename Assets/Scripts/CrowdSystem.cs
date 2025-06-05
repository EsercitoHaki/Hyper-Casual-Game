using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header("Elments")]
    [SerializeField] private Transform runnersParent;

    [Header("Setting")]
    [SerializeField] private float radius;
    [SerializeField] private float angel;

    void Start()
    {

    }

    void Update()
    {
        PlaceRunner();
    }

    private void PlaceRunner()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Vector3 childLocalPosition = PlayerRunnerLoaclPositions(i);
            runnersParent.GetChild(i).localPosition = childLocalPosition;
        }
    }

    private Vector3 PlayerRunnerLoaclPositions(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angel);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angel);

        return new Vector3(x, 0, z);
    }
}

using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Chunk[] chunkPrefab;

    void Start()
    {
        Vector3 chunkPosition = Vector3.zero;

        for (int i = 0; i < 5; i++)
        {
            Chunk chunkToCreate = chunkPrefab[Random.Range(0, chunkPrefab.Length)];

            if (i > 0)
            {
                chunkPosition.z += chunkToCreate.GetLength() / 2f;
            }

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
            chunkPosition.z += chunkInstance.GetLength() / 2f;
        }
    }

    void Update()
    {
        
    }
}

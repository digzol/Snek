using UnityEngine;
using UnityEngine.Serialization;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;

    public float spawnRange;

    public float spawnFrequency;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnFrequency, spawnFrequency);
    }

    private void Spawn()
    {
        var pos = new Vector2(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange));

        Instantiate(foodPrefab, pos, Quaternion.identity, gameObject.transform);
    }
}

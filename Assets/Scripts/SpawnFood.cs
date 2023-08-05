using UnityEngine;

public class SpawnFood : MonoBehaviour {
    public GameObject FoodPrefab;
        
    public float SpawnRange;
    public float SpawnFrequency;
    
    private void Start() {
        InvokeRepeating(nameof(Spawn), SpawnFrequency, SpawnFrequency);
    }

    private void Spawn() {
        var pos = new Vector2(Random.Range(-SpawnRange, SpawnRange), Random.Range(-SpawnRange, SpawnRange));
        
        Instantiate(FoodPrefab, pos, Quaternion.identity, gameObject.transform);
    }
}

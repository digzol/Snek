using UnityEngine;

public class spin : MonoBehaviour
{
    public float SpeedMin = 5.0f;
    public float SpeedMax = 200.0f;
    public float Multiplier = 1.0f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(SpeedMin, SpeedMax) * Multiplier * Time.deltaTime));
    }
}
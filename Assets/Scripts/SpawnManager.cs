using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRangeXMax;
    private float spawnRangeXMin;
    private float spawnRangeZMax;
    private float spawnRangeZMin;
    public float timeInGame = 7.0f;

    void Start() {
        CalculateSpawnRanges();
        // Ubica un alimento en un espacio de la escena.
        transform.position = GenerateSpawnPosition();
        // Destruye el objeto sino es tomado.
        StartCoroutine(FoodCountDown());
    }

    void CalculateSpawnRanges() {
        Vector3 center = new Vector3(1f, 6f, 3f);
        Vector3 size = new Vector3(27f, 1f, 15f);

        // Calcula los rangos de spawn
        spawnRangeXMin = center.x - size.x / 2;
        spawnRangeXMax = center.x + size.x / 2;
        spawnRangeZMin = center.z - size.z / 2;
        spawnRangeZMax = center.z + size.z / 2;
    }

    private Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(spawnRangeXMin, spawnRangeXMax);
        float spawnPosZ = Random.Range(spawnRangeZMin, spawnRangeZMax);
        Vector3 randomPos = new Vector3(spawnPosX, 5.5f, spawnPosZ);
        return randomPos;
    }

    private IEnumerator FoodCountDown() {
        yield return new WaitForSeconds(timeInGame);
        Destroy(gameObject);
    }
}

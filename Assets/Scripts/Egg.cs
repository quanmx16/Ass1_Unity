using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject[] eggPrefabs; // Prefab của đối tượng cần sinh ra
    public Transform[] spawnEggPoints; // Các vị trí mà đối tượng sẽ được sinh ra
    public float spawnInterval = 1f; // Khoảng thời gian giữa các lần sinh ra đối tượng

    private float spawnTimer; // Đếm thời gian giữa các lần sinh ra
    private int currentSpawnIndex; // Chỉ số của vị trí hiện tại để sinh ra đối tượng

    private void Start()
    {
        spawnTimer = spawnInterval;
        currentSpawnIndex = 0;
    }

    private void Update()
    {
        // Đếm ngược thời gian để sinh ra đối tượng tiếp theo
        spawnTimer -= Time.deltaTime;

        // Kiểm tra nếu đến thời điểm sinh ra đối tượng mới
        if (spawnTimer <= 0f)
        {
            SpawnObject();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnObject()
    {
        // Kiểm tra xem có vị trí để sinh ra đối tượng hay không
        if (spawnEggPoints.Length == 0)
        {
            Debug.LogWarning("Không có vị trí để sinh ra đối tượng!");
            return;
        }

        int randomIndex = Random.Range(0, spawnEggPoints.Length);
        int randomEggIndex = Random.Range(0, eggPrefabs.Length);

        // Sinh ra đối tượng tại vị trí ngẫu nhiên đã chọn
        Instantiate(eggPrefabs[randomEggIndex], spawnEggPoints[randomIndex].position, Quaternion.identity);

        
    }
  
}

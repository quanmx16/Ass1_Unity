using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject[] eggPrefabs; // Prefab của đối tượng cần sinh ra
    public Transform[] spawnEggPoints; // Các vị trí mà đối tượng sẽ được sinh ra
    public float spawnInterval = 1f; // Khoảng thời gian giữa các lần sinh ra đối tượng

    private float spawnTimer; // Đếm thời gian giữa các lần sinh ra
    //private int currentSpawnIndex; // Chỉ số của vị trí hiện tại để sinh ra đối tượng
    private int eggCount = 0;
    private GameObject chicken;
    private Animator animator;
    private void Start()
    {
        spawnTimer = spawnInterval;
        //currentSpawnIndex = 0;
    }

    private void Update()
    {
        // Đếm ngược thời gian để sinh ra đối tượng tiếp theo
        spawnTimer -= Time.deltaTime;

        // Kiểm tra nếu đến thời điểm sinh ra đối tượng mới
        if (spawnTimer <= 0f)
        {
            eggCount++;
            SpawnObject();
            spawnTimer = spawnInterval;
            if (eggCount % 5 == 0 && spawnInterval > 0.8f)
            {
                eggCount = 0;
                spawnInterval -= 0.2f;
            }
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

        int randomIndex = Random.Range(0, spawnEggPoints.Length - 1);
        //int randomIndex = 0;
        int randomEggIndex = Random.Range(0, eggPrefabs.Length);
        chicken = GameObject.Find("Chicken_" + (randomIndex + 1).ToString());
        animator = chicken.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("Lay_egg", true);
            Instantiate(eggPrefabs[randomEggIndex], spawnEggPoints[randomIndex].position - new Vector3(0, 1, 0), Quaternion.identity);
        }

    }

}

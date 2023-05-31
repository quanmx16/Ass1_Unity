using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggFail : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Camera mainCamera;
    private float screenBoundaryLeft;
    private float screenBoundaryRight;
    private float screenBoundaryTop;
    private float screenBoundaryBottom;
    private float position;
    // Start is called before the first frame update
    void Start()
    {

        mainCamera = Camera.main;
        // Calculate the boundaries of the screen in world coordinates
        float objectWidth = GetComponent<Renderer>().bounds.extents.x;
        float objectHeight = GetComponent<Renderer>().bounds.extents.y;

        screenBoundaryLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + objectWidth;
        screenBoundaryRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - objectWidth;
        screenBoundaryTop = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - objectHeight;
        screenBoundaryBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + objectHeight;
        position = Random.Range(screenBoundaryLeft, screenBoundaryRight);
    }

    // Update is called once per frame

    void Update()
    {
        Vector3 movement = new Vector3(position, transform.position.y - 1f, 0f);
        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;

        // Clamp the fish's position within the screen boundaries
        //float clampedX = Mathf.Clamp(newPosition.x, screenBoundaryLeft, screenBoundaryRight);
        float clampedY = Mathf.Clamp(newPosition.y, screenBoundaryBottom, screenBoundaryTop);
        newPosition = new Vector3(position, clampedY, 0f);

        transform.position = newPosition;
    }
}

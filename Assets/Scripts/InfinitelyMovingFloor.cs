using UnityEngine;

public class InfinitelyMovingFloor : MonoBehaviour
{
    public GameObject floorPrefab;
    private Camera mainCamera;

    private bool isNewFloorCreated = false;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStatus.Play)
        {
            transform.Translate(new Vector3(0, 0, -4f * Time.deltaTime));
            // Whenever the edge of the floor is 4 meters away from the camera's far clip plane create a new floor to maintain the
            // Illusion of infinite floor
            if (!isNewFloorCreated)
            {
                float floorEdgeZLocation = gameObject.transform.position.z + (gameObject.transform.localScale.z / 2.0f);
                if (floorEdgeZLocation - mainCamera.farClipPlane - mainCamera.transform.position.z <= 4)
                {
                    Instantiate(floorPrefab,
                                new Vector3(0, 0, floorEdgeZLocation + (gameObject.transform.localScale.z / 2.0f)),
                                Quaternion.identity);
                    isNewFloorCreated = true;
                }
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class InteractableGeneratingFloor : MonoBehaviour
{
    public GameObject blueShpere;
    public GameObject coin;
    public GameObject ironBall;
    public GameObject bomb;
    private float[] possibleLanePositions = { -2f, 2f, 0f };
    private static float GENERATE_Z_MIN = -23f;
    private static float GENERATE_Z_MAX = 25f;
    // Start is called before the first frame update
    void Start()
    {

        // Extract default position values for interactable prefabs;

        Vector3 blueSphereDefaultPosition = blueShpere.transform.position;
        Vector3 coinDefaultPosition = coin.transform.position;
        Vector3 ironBallDefaultPosition = ironBall.transform.position;
        Vector3 bombDefaultPosition = bomb.transform.position;

        // Instantiate collectible and obstacles on the floor

        GenerateBombs(3, bombDefaultPosition);
        GenerateInteractable(5, blueShpere);
        GenerateInteractable(5, coin);
        GenerateInteractable(5, ironBall);
    }

    // Update is called once per frame
    void Update()
    {

    }



    void GenerateBombs(int bombCount, Vector3 bombDefaultPosition)
    {
        for (int i = 0; i < bombCount; i++)
        {

            float currentLanePosition = possibleLanePositions[Random.Range(0, 3)];
            // Every bomb can span one, two, or three lanes.
            int laneCount = Random.Range(1, 4);
            float bombZPosition = Random.Range(
                gameObject.transform.position.z - gameObject.transform.localScale.z / 2f ,
                gameObject.transform.position.z + gameObject.transform.localScale.z / 2f );
            for (int j = 0; j < laneCount; j++)
            {
                // For each lane craete a bomb
                GameObject currentBomb = Instantiate(bomb, new Vector3(currentLanePosition, bombDefaultPosition.y, bombZPosition), Quaternion.identity);
                currentBomb.transform.parent = gameObject.transform;
                currentLanePosition = GetAnotherLanePosition(currentLanePosition);
            }

        }
    }

    void GenerateInteractable(int interactableCount, GameObject interactablePrefab)
    {
        for (int i = 0; i < interactableCount; i++)
        {
            float currentLanePosition = possibleLanePositions[Random.Range(0, 3)];
            float interactableZPosition = Random.Range(
                gameObject.transform.position.z - gameObject.transform.localScale.z / 2f ,
                gameObject.transform.position.z + gameObject.transform.localScale.z / 2f );
            GameObject currentInteractable = Instantiate(
                interactablePrefab,
                new Vector3(currentLanePosition, interactablePrefab.transform.position.y, interactableZPosition),
                Quaternion.identity);
            currentInteractable.transform.parent = gameObject.transform;
        }
    }


    private float GetAnotherLanePosition(float currentLanePosition)
    {
        foreach (float lanePosition in possibleLanePositions)
        {
            if (lanePosition != currentLanePosition)
            {
                return lanePosition;
            }
        }
        return currentLanePosition;
    }
}

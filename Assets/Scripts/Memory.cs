using UnityEngine;

public class Memory : MonoBehaviour
{

    public GameObject cardPrefab;
    public int width = 4;
    public int height = 4;
    public float spacing = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateGrid();
    }

    
    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x * spacing, 0, y * spacing);

                Instantiate(
                cardPrefab,
                position,
                Quaternion.identity,
                transform
                );
            }
        }
    }
}

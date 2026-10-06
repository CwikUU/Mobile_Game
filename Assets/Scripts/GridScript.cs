using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{

    private int lastScreenWidth;
    private int lastScreenHeight;

    public RectTransform gridRectTransform;
    public GridLayoutGroup gridLayout;
    public float spacing = 10f; // Adjust the spacing as needed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastScreenWidth = Screen.width;
        lastScreenHeight = Screen.height;

        OnScreenSizeChanged();
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width != lastScreenWidth || Screen.height != lastScreenHeight)
        {
            lastScreenWidth = Screen.width;
            lastScreenHeight = Screen.height;
            // Call your method to handle the screen size change
            OnScreenSizeChanged();
        }
    }

    void OnScreenSizeChanged()
    {
        float padding = Mathf.Min(Screen.width, Screen.height) * 0.1f; // 10% padding
        float size = Mathf.Min(Screen.width, Screen.height) * 0.8f;
        float cellSize = (size - spacing * 3) / 4f ;
        gridLayout.cellSize = new Vector2(cellSize, cellSize*1.5f);
        gridLayout.spacing = new Vector2(spacing, spacing);
        gridLayout.padding.left = Mathf.RoundToInt(padding);
        gridLayout.padding.right = Mathf.RoundToInt(padding);
    }
}

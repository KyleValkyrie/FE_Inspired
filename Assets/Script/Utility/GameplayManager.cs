using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance { get; private set; }

    void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Header("Prefabs")]
    public GameObject gridPrefab;
    public GameObject cursorPrefab;

    private GameObject gridInstance;
    private GameObject cursorInstance;
    

    void Start()
    {
        InitializeGrid();
        InitializeCursor();
    }

    void InitializeGrid()
    {
        if (gridPrefab != null)
        {
            gridInstance = Instantiate(gridPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Grid prefab not assigned in GameplayManager.");
        }
    }

    void InitializeCursor()
    {
        if (cursorPrefab != null)
        {
            cursorInstance = Instantiate(cursorPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Cursor prefab not assigned in GameplayManager.");
        }
    }

    public GameObject GetGrid() => gridInstance;
    public GameObject GetCursor() => cursorInstance;
}

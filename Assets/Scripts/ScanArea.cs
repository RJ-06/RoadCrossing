using UnityEngine;

public class ScanArea : MonoBehaviour
{
    [SerializeField]
    private int rows = 3; // Number of rows in the grid
    [SerializeField]
    private int columns = 3; // Number of columns in the grid
    [SerializeField]
    private float squareSize = 1f; // Size of the squares
    [SerializeField]
    private GameObject grid;
    public bool[,] hitNodes; // 2D array to track hit nodes

    [SerializeField]
    private float requiredFillPercentage = 50f; // Percentage of the area that must be filled
    [SerializeField]
    public bool enoughGridFilled = false; // Flag indicating if enough of the grid is filled

    [SerializeField]
    private int fillCheckMode = 1; // Mode to determine whether the grid is filled enough

    [SerializeField]
    private int numScans = 1;

    //private string eventScriptObjectName = "Event"; // Name of the script to check for

    private GameObject eventScriptObject; // Reference to the object with the event script

    public GameObject barrier;

    [SerializeField]
    Material nodeMatDeactive;
    [SerializeField]
    Material nodeMatActive;

    void Start()
    {
        hitNodes = new bool[rows, columns]; // Initialize the hitNodes array
        SpawnGrid(); // Method to spawn the grid
    }

    void Update()
    {
        CheckGridFilled(); // Check if the grid is filled based on the selected mode
    }

    // Method to spawn the grid of squares
    void SpawnGrid()
    {
        // Calculate margin between squares
        float marginX = squareSize / 2f;
        float marginY = squareSize / 2f;

        // Calculate spacing between squares
        Vector3 gridSize = GetObjectSize(grid);
        float spacingX = (gridSize.x - marginX * 2) / (columns - 1);
        float spacingY = (gridSize.y - marginY * 2) / (rows - 1);

        // Adjust spacing if only one row or column
        if (columns == 1) spacingX = 0;
        if (rows == 1) spacingY = 0;

        // Loop through rows and columns to spawn squares
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calculate spawn position for the current square
                Vector3 spawnPosition = new Vector3(
                    col * spacingX - gridSize.x / 2f + marginX,
                    row * spacingY - gridSize.y / 2f + marginY,
                    0
                );

                // Create a cube as a square
                GameObject spawnedSquare = GameObject.CreatePrimitive(PrimitiveType.Cube);
                spawnedSquare.transform.SetParent(gameObject.transform); // Set the parent as this object

                // Set position and size of the square
                spawnedSquare.transform.localPosition = spawnPosition;
                spawnedSquare.transform.localScale = new Vector3(squareSize, squareSize, squareSize);

                // Assign the RaycastNode layer to the spawned square
                spawnedSquare.layer = LayerMask.NameToLayer("RaycastNode");


                // Attach and setup NodeController script to the spawned square
                NodeController nodeController = spawnedSquare.AddComponent<NodeController>();
                nodeController.Init(nodeMatActive, nodeMatDeactive, this, row, col);
            }
        }
    }

    // Method to get the size of an object
    Vector3 GetObjectSize(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        Transform t = obj.gameObject.transform;
        if (renderer != null)
        {
            return t.localScale;
        }
        else
        {
            Debug.LogWarning("Renderer component not found on object: " + obj.name);
            return Vector3.one;
        }
    }

    // Method to check if the grid is filled based on the selected mode
    void CheckGridFilled()
    {
        // Return early if enough grid is already filled
        if (enoughGridFilled)
        {
            return;
        }

        if (fillCheckMode == 1)
        {
            CheckGridFilledPercentage(); // Check grid filled percentage
        }
        else if (fillCheckMode == 2)
        {
            CheckGridFilledOneNodePerColumn(); // Check at least one node per column
        }
        else
        {
            Debug.LogError("Invalid fill check mode: " + fillCheckMode);
        }

        
    }


    // Method to check grid filled percentage
    void CheckGridFilledPercentage()
    {
        int filledCount = 0;
        int totalCount = rows * columns;

        // Count filled nodes
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (hitNodes[row, col])
                {
                    filledCount++;
                }
            }
        }

        // Calculate filled percentage
        float filledPercentage = (float)filledCount / totalCount * 100f;

        // Check if the required fill percentage is met
        enoughGridFilled = filledPercentage >= requiredFillPercentage;
        if (enoughGridFilled)
        {
            EventManager.instance.score++;
            Scoring.onCross();
        }
    }

    // Method to check at least one node per column
    void CheckGridFilledOneNodePerColumn()
    {
        // Check if at least one node in each column has been hit
        for (int col = 0; col < columns; col++)
        {
            bool columnFilled = false;
            for (int row = 0; row < rows; row++)
            {
                if (hitNodes[row, col])
                {
                    columnFilled = true;
                    break;
                }
            }

            if (!columnFilled)
            {
                enoughGridFilled = false;
                return;
            }
        }

        numScans--;
        resetGrid();
        if(numScans <= 0)
        {
            enoughGridFilled = true;
            barrier.SetActive(false);
            this.gameObject.SetActive(false);
            //EventManager.instance.score++;
            Scoring.onCross();
            Debug.Log("scanned!");
            
        }
    }

    void resetGrid()
    {
        hitNodes = new bool[rows, columns];
    }
}

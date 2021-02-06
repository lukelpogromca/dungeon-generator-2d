using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG2D;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.Tilemaps;
using DG2D.Enums;

public class LevelLoader : MonoBehaviour
{
    private GeneratorCore generator = new GeneratorCore() { gameBoardWidth = 70, gameBoardHeight = 70, roomCount = 10, eventRoomCount = 2, breakNumber = 30, populationCount = 30, generations = 100, mutationGrowX = 3, mutationGrowY = 4, mutationGrowProb = 70, mutationTrimProb = 70 };

    public GameObject mainScreen;
    public GameObject loadingScreen;
    public Slider progressBar;
    public Button playButton;
    public Camera mainCamera;
    public Vector3Int origin = Vector3Int.zero;

    public Tile emptyTile;
    public Tile floorTile;
    public Tile wallTile;
    public Tile doorTile;

    private GameObject gridHolder;
    private GameObject backgroundTilemapHolder;
    private GameObject floorTilemapHolder;
    private GameObject wallsTilemapHolder;
    private GameObject doorsTilemapHolder;

    // Start is called before the first frame update
    private void Awake()
    {
        playButton.onClick.AddListener(GenerateLevel);
    }
    void Start()
    {
        mainScreen.SetActive(true);
        loadingScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = generator.Progress;
    }
    private async void GenerateLevel()
    {
        mainScreen.SetActive(false);
        loadingScreen.SetActive(true);
        generator.Initialize();
        await Task.Run(() => generator.GeneratePopulation()).ContinueWith(x => generator.EvolvePopulation());
        DrawScene();
    }
    private void DrawScene()
    {
        gridHolder = new GameObject("Grid");
        gridHolder.transform.parent = gameObject.transform;
        Grid grid = gridHolder.AddComponent<Grid>();
        backgroundTilemapHolder = new GameObject("Background", typeof(Tilemap), typeof(TilemapRenderer));
        floorTilemapHolder = new GameObject("Floor", typeof(Tilemap), typeof(TilemapRenderer));
        wallsTilemapHolder = new GameObject("Walls", typeof(Tilemap), typeof(TilemapRenderer));
        doorsTilemapHolder = new GameObject("Doors", typeof(Tilemap), typeof(TilemapRenderer));
        backgroundTilemapHolder.transform.parent = gridHolder.transform;
        floorTilemapHolder.transform.parent = gridHolder.transform;
        wallsTilemapHolder.transform.parent = gridHolder.transform;
        doorsTilemapHolder.transform.parent = gridHolder.transform;

        mainScreen.SetActive(false);
        loadingScreen.SetActive(false);

        for (int i = 0; i < generator.GameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < generator.GameBoard.GetLength(1); j++)
            {
                DungeonTile currentTile = generator.GameBoard[i, j];

                if (currentTile == DungeonTile.Empty)
                    backgroundTilemapHolder.GetComponent<Tilemap>().SetTile(new Vector3Int(j, i, 0) + origin, emptyTile);
                else if (currentTile == DungeonTile.Floor)
                    floorTilemapHolder.GetComponent<Tilemap>().SetTile(new Vector3Int(j, i, 0) + origin, floorTile);
                else if (currentTile == DungeonTile.Wall)
                    wallsTilemapHolder.GetComponent<Tilemap>().SetTile(new Vector3Int(j, i, 0) + origin, wallTile);
                else if (currentTile == DungeonTile.Door)
                    doorsTilemapHolder.GetComponent<Tilemap>().SetTile(new Vector3Int(j, i, 0) + origin, doorTile);
            }
        }
    }
}

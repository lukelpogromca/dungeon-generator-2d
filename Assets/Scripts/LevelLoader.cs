using UnityEngine;
using DG2D;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.Tilemaps;
using DG2D.Enums;

public class LevelLoader : MonoBehaviour
{
    private GeneratorCore generator = new GeneratorCore() { gameBoardWidth = 70, gameBoardHeight = 70, roomCount = 20, eventRoomCount = 2, breakNumber = 40, populationCount = 30, generations = 200, mutationGrowX = 3, mutationGrowY = 4, mutationGrowProb = 70, mutationTrimProb = 70 };

    public GameObject mainScreen;
    public GameObject loadingScreen;
    public GameObject settingsScreen;
    public Slider progressBar;
    public Text progressText;
    public InputField gameBoardWidthIF;
    public InputField gameBoardHeightIF;
    public InputField roomCountIF;
    public InputField eventRoomCountIF;
    public InputField populationCountIF;
    public InputField generationsIF;
    public InputField mutationGrowXIF;
    public InputField mutationGrowYIF;
    public Slider mutationGrowProbSlider;
    public Slider mutationTrimProbSlider;

    public Camera overviewCamera;
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
        gameBoardHeightIF.onValidateInput += (string s, int i, char c) => LessThanZero(c);
        gameBoardWidthIF.onValidateInput += (string s, int i, char c) => LessThanZero(c);
        roomCountIF.onValidateInput += (string s, int i, char c) => LessThanZero(c);
        eventRoomCountIF.onValidateInput += (string s, int i, char c) => LessThanZero(c);
        populationCountIF.onValidateInput += (string s, int i, char c) => LessThanZero(c);
        generationsIF.onValidateInput += (string s, int i, char c) => LessThanZero(c);
        mutationGrowXIF.onValidateInput += (string s, int i, char c) => LessThanZero(c);
        mutationGrowYIF.onValidateInput += (string s, int i, char c) => LessThanZero(c);
    }
    void Start()
    {
        mainScreen.SetActive(true);
        loadingScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = generator.Progress;
        progressText.text = (int)(generator.Progress * 100) + "%";
    }
    public async void GenerateLevel()
    {
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

        PositionOverviewCamera();
        mainScreen.SetActive(false);
        loadingScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ApplyGeneratorParameters()
    {
        int.TryParse(gameBoardWidthIF.text, out generator.gameBoardWidth);
        int.TryParse(gameBoardHeightIF.text, out generator.gameBoardHeight);
        int.TryParse(roomCountIF.text, out generator.roomCount);
        int.TryParse(eventRoomCountIF.text, out generator.eventRoomCount);
        int.TryParse(populationCountIF.text, out generator.populationCount);
        int.TryParse(generationsIF.text, out generator.generations);
        int.TryParse(mutationGrowXIF.text, out generator.mutationGrowX);
        int.TryParse(mutationGrowYIF.text, out generator.mutationGrowY);
        generator.mutationGrowProb = (int)mutationGrowProbSlider.value;
        generator.mutationTrimProb = (int)mutationTrimProbSlider.value;

        generator.breakNumber = (int)(generator.roomCount * 1.75);
}
    public char LessThanZero (char character)
    {
        if (character == '-')
            return '\0';
        else return character;
    }
    public void FeedDataToInputFields()
    {
        gameBoardWidthIF.text = generator.gameBoardWidth.ToString();
        gameBoardHeightIF.text = generator.gameBoardHeight.ToString();
        roomCountIF.text = generator.roomCount.ToString();
        eventRoomCountIF.text = generator.eventRoomCount.ToString();
        populationCountIF.text = generator.populationCount.ToString();
        generationsIF.text = generator.generations.ToString();
        mutationGrowXIF.text = generator.mutationGrowX.ToString();
        mutationGrowYIF.text = generator.mutationGrowY.ToString();
        mutationGrowProbSlider.value = generator.mutationGrowProb;
        mutationTrimProbSlider.value = generator.mutationTrimProb;

    }
    private void PositionOverviewCamera()
    {
        float sizeFromHeight = (1f / 2) * generator.GameBoard.GetLength(0);
        float sizeFromWidth = (1f / 2) * generator.GameBoard.GetLength(1) / overviewCamera.aspect;
        overviewCamera.orthographicSize = sizeFromHeight > sizeFromWidth ? sizeFromHeight : sizeFromWidth;
        Vector3 cameraPos = new Vector3(origin.x + generator.GameBoard.GetLength(1) / 2f, origin.y + generator.GameBoard.GetLength(0) / 2f, 0f);
        overviewCamera.GetComponent<Transform>().position = cameraPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG2D.Enums;
using System;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;
using DG2D.Globals;
using DG2D.Utils;
using System.Linq;

namespace DG2D
{
    public class GeneratorCore : MonoBehaviour
    {
        private Phenotype[] population;

        public int gameBoardHeight;
        public int gameBoardWidth;
        public int roomCount;
        public int eventRoomCount;
        public int breakNumber;
        public int populationCount;
        public int generations;
        public int mutationGrowX;
        public int mutationGrowY;
        [Range(0, 100)]
        public int mutationGrowProb;
        [Range(0, 100)]
        public int mutationTrimProb;
        public Vector3Int origin = Vector3Int.zero;

        public DungeonTile[,] currentGameBoard;

        public Tile emptyTile;
        public Tile floorTile;
        public Tile wallTile;
        public Tile doorTile;

        private GameObject gridHolder;
        private GameObject backgroundTilemapHolder;
        private GameObject floorTilemapHolder;
        private GameObject wallsTilemapHolder;
        private GameObject doorsTilemapHolder;
        public void Initialize()
        {
            population = new Phenotype[populationCount];
        }
        public void Awake()
        {
            Initialize();

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
        }
        private void Draw()
        {
            for(int i = 0; i < currentGameBoard.GetLength(0); i++)
            {
                for(int j = 0; j < currentGameBoard.GetLength(1); j++)
                {
                    DungeonTile currentTile = currentGameBoard[i, j];

                    if (currentTile == DungeonTile.Empty)
                        backgroundTilemapHolder.GetComponent<Tilemap>().SetTile(new Vector3Int(j, i, 0) + origin, emptyTile);
                    else if(currentTile == DungeonTile.Floor)
                        floorTilemapHolder.GetComponent<Tilemap>().SetTile(new Vector3Int(j, i, 0) + origin, floorTile);
                    else if(currentTile == DungeonTile.Wall)
                        wallsTilemapHolder.GetComponent<Tilemap>().SetTile(new Vector3Int(j, i, 0) + origin, wallTile);
                    else if(currentTile == DungeonTile.Door)
                        doorsTilemapHolder.GetComponent<Tilemap>().SetTile(new Vector3Int(j, i, 0) + origin, doorTile);
                }
            }
        }
        public void Start()
        {
            for (int i = 0; i < population.Length; i++)
                population[i] = GeneratePhenotype();

            FitnessComparer comparer = new FitnessComparer(this);
            Phenotype[] childrenPopulation = new Phenotype[populationCount];

            for (int i = 0; i < generations; i++)
            {
                Array.Sort(population, comparer);
                Array.Clear(childrenPopulation, 0, childrenPopulation.Length);

                for(int j = 0; j < population.Length; j += 2)
                {
                    if (j + 1 == population.Length)
                        childrenPopulation[j] = population[j];
                    else
                    {
                        Phenotype leftChild;
                        Phenotype rightChild;

                        Crossover(population[j], population[j + 1], out leftChild, out rightChild);

                        if (Random.Range(1, 100) <= mutationGrowProb)
                            MutationGrow(leftChild);
                        if (Random.Range(1, 100) <= mutationGrowProb)
                            MutationGrow(rightChild);
                        if (Random.Range(1, 100) <= mutationTrimProb)
                            MutationTrim(leftChild);
                        if (Random.Range(1, 100) <= mutationTrimProb)
                            MutationTrim(rightChild);

                        childrenPopulation[j] = leftChild;
                        childrenPopulation[j + 1] = rightChild;
                    }
                }
                Array.Sort(childrenPopulation, comparer);
                Array.Copy(childrenPopulation, 0, population, population.Length / 2, population.Length / 2);
            }
            Array.Sort(population, comparer);
            currentGameBoard = population[0].GameBoard;
            Draw();
            Debug.LogFormat("Candidate selected! Room count: {0}, Fitness value: {1}", population[0].Root.Count, Evaluate(population[0]));
            Debug.LogFormat("Execution time: {0}", Time.realtimeSinceStartup);
        }
        private Phenotype GeneratePhenotype()
        {
            int breakCounter = breakNumber;
            int roomCounter = roomCount;
            currentGameBoard = new DungeonTile[gameBoardHeight, gameBoardWidth];
            TreeNode root = new TreeNode(RoomDefinitions.GetRandomRoom());
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            while(queue.Any())
            {
                breakCounter--;
                if (breakCounter == 0)
                {
                    foreach (TreeNode element in queue)
                        element.Dispose();
                    queue.Clear();
                    Debug.LogFormat("Break number reached! Break counter: {0}, Room counter: {1}", breakCounter, roomCounter);
                    break;
                }
                TreeNode currentNode = queue.Dequeue();

                    if (currentNode.ParentNode != null)
                    {
                        if (!AttachRoom(currentNode.ParentNode, currentNode))
                        {
                            currentNode.Dispose();
                            queue.Enqueue(new TreeNode(RoomDefinitions.GetRandomRoom()) { ParentNode = currentNode.ParentNode });
                            continue;
                        }
                    }
                    else
                    {
                        Vector2Int pos = new Vector2Int(gameBoardWidth / 2, gameBoardHeight /2);//new Vector2Int(Random.Range(0, gameBoardWidth), Random.Range(0, gameBoardHeight));
                        if (!TryPlaceRoom(currentNode, pos))
                        {
                            currentNode = new TreeNode(RoomDefinitions.GetRandomRoom());
                            queue.Enqueue(currentNode);
                            continue;
                        }
                    }
                roomCounter--;
                if (roomCounter == 0)
                {
                    foreach (TreeNode element in queue)
                        element.Dispose();
                    queue.Clear();
                    Debug.LogFormat("Room count reached! Break counter: {0}, Room counter: {1}", breakCounter, roomCounter);
                    break;
                }
                foreach (var door in currentNode.Entrances.Where(x => x.Value == false))
                        queue.Enqueue(new TreeNode(RoomDefinitions.GetRandomRoom()) { ParentNode = currentNode });
            }
            DungeonTile[,] board = currentGameBoard;
            return new Phenotype(root, board);
        }
        private bool TryPlaceRoomTiles(DungeonTile[,] roomTiles,  Vector2Int position)
        {
            DungeonTile[,] boardCopy = (DungeonTile[,])currentGameBoard.Clone();

            for (int i = 0; i < roomTiles.GetLength(0); i++)
            {
                for(int j = 0; j < roomTiles.GetLength(1); j++)
                {
                    try
                    {
                        if (roomTiles[i, j] == DungeonTile.Empty || boardCopy[i + position.y, j + position.x] == roomTiles[i, j])
                            continue;
                        else if (boardCopy[i + position.y, j + position.x] == DungeonTile.Empty)
                            boardCopy[i + position.y, j + position.x] = roomTiles[i, j];
                        else
                            return false;

                    }
                    catch (IndexOutOfRangeException)
                    {
                        return false;
                    }
                }
            }
            currentGameBoard = boardCopy;
            return true;
        }
        private bool AttachRoom(TreeNode parentNode, TreeNode childNode)
        {
            DungeonTile[,] roomTiles;
            IList<Vector2Int> doorPositions;

            List<Vector2Int> parentDoorPositions = parentNode.Entrances.Where(x => x.Value == false).Select(x => x.Key).ToList();

            parentDoorPositions.Shuffle();
            foreach (Vector2Int parentDoorPosition in parentDoorPositions)
            {
                DungeonComponent.GetTileDataMethods.Shuffle();
                foreach ( GetTileDataDelegate method in DungeonComponent.GetTileDataMethods)
                {
                    childNode.TileData = method;
                    roomTiles = childNode.GetTileData(out doorPositions);
                    doorPositions.Shuffle();
                    foreach (Vector2Int doorPosition in doorPositions)
                    {
                        Vector2Int position = parentNode.WorldPosition + parentDoorPosition - doorPosition;
                        Vector2Int relativePosition = parentDoorPosition - doorPosition;
                        if (position == parentNode.WorldPosition && doorPosition == parentDoorPosition) //Issue: Two rooms on top of each other.
                            continue;

                        if (TryPlaceRoomTiles(roomTiles, position))
                        {
                            childNode.LocalPosition = relativePosition;
                            childNode.TileData = method;
                            Dictionary<Vector2Int, bool> temp = doorPositions.ToDictionary(x => x, x => false);
                            temp[doorPosition] = true;
                            childNode.Entrances = temp;
                            parentNode.Entrances[parentDoorPosition] = true;
                            childNode.ParentEntrance = parentDoorPosition;
                            childNode.LocalParentEntrance = doorPosition;

                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool TryPlaceRoom(TreeNode treeNode, Vector2Int position)
        {
            IList<Vector2Int> doorPositions;
            DungeonTile[,] roomTiles;

            DungeonComponent.GetTileDataMethods.Shuffle();
            foreach (GetTileDataDelegate method in DungeonComponent.GetTileDataMethods)
            {
                treeNode.TileData = method;
                roomTiles = treeNode.GetTileData(out doorPositions);

                if (TryPlaceRoomTiles(roomTiles, position))
                {
                    treeNode.LocalPosition = position;
                    treeNode.TileData = method;
                    Dictionary<Vector2Int, bool> temp = doorPositions.ToDictionary(x => x, x => false);
                    treeNode.Entrances = temp;
                    return true;
                }
            }
            return false;
        }
        private void Clean()
        {
            for (int i = 0; i < currentGameBoard.GetLength(0); i++)
                for (int j = 0; j < currentGameBoard.GetLength(1); j++)
                    currentGameBoard[i, j] = DungeonTile.Empty;
        }
        private void Crossover(Phenotype leftParent, Phenotype rightParent, out Phenotype leftChild, out Phenotype rightChild)
        {
            leftChild = new Phenotype(leftParent);
            rightChild = new Phenotype(rightParent);

            TreeNode leftBranch = leftChild.Root.GetRandomChild();
            TreeNode rightBranch = rightChild.Root.GetRandomChild();

            if (leftBranch is null || rightBranch is null)
                return;

            TreeNode leftTrunk = leftBranch.ParentNode;
            TreeNode rightTrunk = rightBranch.ParentNode;

            leftBranch.Detach();
            rightBranch.Detach();

            RegeneratePhenotype(leftChild);
            RegeneratePhenotype(rightChild);

            AttachBranch(leftTrunk, rightBranch, leftChild);
            AttachBranch(rightTrunk, leftBranch, rightChild);
        }
        private void AttachBranch(TreeNode parentNode, TreeNode childNode, Phenotype parentPhenotype)
        {
            currentGameBoard = parentPhenotype.GameBoard;
            childNode.ParentNode = parentNode;
            List<Vector2Int> parentDoorPositions = parentNode.Entrances.Where(x => x.Value == false).Select(x => x.Key).ToList();
            Vector2Int childDoorPosition = childNode.LocalParentEntrance;
            bool attached = false;
            foreach(Vector2Int pos in parentDoorPositions)
            {
                Vector2Int pos1 = pos - childDoorPosition;
                if(TryPlaceRoomTiles(childNode.GetTileData(out _), parentNode.WorldPosition + pos1))
                {
                    childNode.LocalPosition = pos1;
                    parentNode.Entrances[pos] = true;
                    childNode.ParentEntrance = pos;
                    attached = true;
                    break;
                }
            }
            if (attached)
            {
                Queue<TreeNode> bfq = new Queue<TreeNode>();
                foreach (TreeNode tn in childNode.ChildrenNodes)
                    bfq.Enqueue(tn);

                while (bfq.Any())
                {
                    TreeNode currentNode = bfq.Dequeue();
                    if (TryPlaceRoomTiles(currentNode.GetTileData(out _), currentNode.WorldPosition))
                    {
                        foreach (TreeNode grandChildrenNode in currentNode.ChildrenNodes)
                            bfq.Enqueue(grandChildrenNode);
                    }
                    else
                    {
                        currentNode.Detach();
                        currentNode.Dispose();
                    }
                }
            }
            else
                childNode.Dispose();
            parentPhenotype.GameBoard = currentGameBoard;
        }

        private void RegeneratePhenotype(Phenotype phenotype)
        {
            Queue<TreeNode> bfq = new Queue<TreeNode>();
            bfq.Enqueue(phenotype.Root);
            currentGameBoard = phenotype.GameBoard;
            Clean();
            while (bfq.Any())
            {
                TreeNode currentNode = bfq.Dequeue();
                PlaceRoomTiles(currentNode.GetTileData(out _), currentNode.WorldPosition);

                foreach (TreeNode child in currentNode.ChildrenNodes)
                    bfq.Enqueue(child);
            }
        }
        private void PlaceRoomTiles(DungeonTile[,] roomTiles, Vector2Int position)
        {
            for (int i = 0; i < roomTiles.GetLength(0); i++)
                for (int j = 0; j < roomTiles.GetLength(1); j++)
                {
                    if (roomTiles[i, j] == DungeonTile.Empty)
                        continue;
                    else
                        currentGameBoard[i + position.y, j + position.x] = roomTiles[i, j];
                }
        }
        private void MutationTrim(Phenotype phenotype)
        {
            TreeNode rand = phenotype.Root.GetRandomChild();
            if (rand is null)
                return;
            rand.Detach();
            rand.Dispose();
            RegeneratePhenotype(phenotype);
        }
        private void MutationGrow(Phenotype phenotype)
        {
            currentGameBoard = phenotype.GameBoard;
            List<TreeNode> openRooms = phenotype.Root.ToList().Where(a => a.Entrances.Any(b => b.Value == false)).ToList();
            int x = openRooms.Count < mutationGrowX ? openRooms.Count : mutationGrowX;
            int y = mutationGrowY;
            int counter = 0;
            Queue<TreeNode> bfq = new Queue<TreeNode>();
            openRooms.Shuffle();

            for(int i = 0; i < x; i++)
            {
                TreeNode branch = new TreeNode(RoomDefinitions.GetRandomRoom()) { ParentNode = openRooms[i] };
                bfq.Enqueue(branch);
                counter = 0;
                while (bfq.Any())
                {
                    TreeNode currentNode = bfq.Dequeue();
                    if (AttachRoom(currentNode.ParentNode, currentNode))
                    {
                        foreach (var door in currentNode.Entrances.Where(o => o.Value == false))
                            bfq.Enqueue(new TreeNode(RoomDefinitions.GetRandomRoom()) { ParentNode = currentNode });
                    }
                    else
                    {
                        currentNode.Dispose();
                    }

                    counter++;
                    if (counter == y)
                    {
                        foreach (TreeNode element in bfq)
                            element.Dispose();
                        bfq.Clear();
                        break;
                    }

                }
            }
            phenotype.GameBoard = currentGameBoard;
            
        }
        public float Evaluate(Phenotype phenotype)
        {
            float roomCountMultiplier = .5f;
            float eventRoomCountMultiplier = .8f;
            float nonHallwayCountMultiplier = .2f;

            int roomCounter = 0;
            int standardRoomCounter = 0;
            int eventRoomCounter = 0;
            int deadEndCounter = 0;
            int roomConnections = 0;
            int hallwayConnections = 0;

            Queue<TreeNode> bfq = new Queue<TreeNode>();
            bfq.Enqueue(phenotype.Root);
            while(bfq.Any())
            {
                TreeNode currentNode = bfq.Dequeue();
                roomCounter++;
                if (currentNode.GetComponentType() == ComponentType.Standard)
                    standardRoomCounter++;
                if (currentNode.GetComponentType() == ComponentType.Event)
                    eventRoomCounter++;
                if (currentNode.GetComponentType() == ComponentType.Hallway)
                {
                    deadEndCounter += currentNode.Entrances.Where(x => x.Value == false).Count();
                    roomConnections += currentNode.ChildrenNodes.Where(x => x.GetComponentType() == ComponentType.Standard || x.GetComponentType() == ComponentType.Event).Count();
                    hallwayConnections += currentNode.ChildrenNodes.Where(x => x.GetComponentType() == ComponentType.Hallway).Count();
                }

                foreach (TreeNode childNode in currentNode.ChildrenNodes)
                {
                    bfq.Enqueue(childNode);
                }

            }
            float hallwayFactor = roomConnections * .3f + hallwayConnections * .2f - deadEndCounter * .5f;

            return (standardRoomCounter + eventRoomCounter) * nonHallwayCountMultiplier + hallwayFactor - (Math.Abs(roomCount - roomCounter) * roomCountMultiplier + Math.Abs(eventRoomCount - eventRoomCounter) * eventRoomCountMultiplier);
        }
    }
    public class FitnessComparer : IComparer<Phenotype>
    {
        private GeneratorCore generatorInstance;
        private FitnessComparer()
        {

        }
        public FitnessComparer(GeneratorCore generatorInstance)
        {
            this.generatorInstance = generatorInstance;
        }
        public int Compare(Phenotype x, Phenotype y)
        {
            return Math.Sign(generatorInstance.Evaluate(y) - generatorInstance.Evaluate(x));
        }
    }
}

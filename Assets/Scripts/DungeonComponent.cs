using System.Collections.Generic;
using DG2D.Enums;
using UnityEngine;

namespace DG2D
{
    public delegate DungeonTile[,] GetTileDataDelegate(DungeonComponent component, out IList<Vector2Int> doorPositions);
    public class DungeonComponent
    {
        private DungeonTile[,] tileData;
        private ComponentType componentType;
        public static List<GetTileDataDelegate> GetTileDataMethods = new List<GetTileDataDelegate> { GetTileDataUp, GetTileDataDown, GetTileDataLeft, GetTileDataRight };
        public ComponentType ComponentType { get { return componentType; } }

        private DungeonComponent()
        {
        }
        public DungeonComponent(DungeonTile[,] tileData, ComponentType componentType)
        {
            this.tileData = tileData;
            this.componentType = componentType;
        }
        public static DungeonTile[,] GetTileDataUp(DungeonComponent component, out IList<Vector2Int> doorPositions)
        {
            DungeonTile[,] ret = (DungeonTile[,])component.tileData.Clone();
            doorPositions = GetDoorLocations(ret);
            return ret;
        }
        public static DungeonTile[,] GetTileDataRight(DungeonComponent component, out IList<Vector2Int> doorPositions)
        {
            doorPositions = new List<Vector2Int>();
            int w = component.tileData.GetLength(0);
            int h = component.tileData.GetLength(1);
            DungeonTile[,] ret = new DungeonTile[h, w];
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    ret[i, j] = component.tileData[w - j - 1, i];
                    if (ret[i, j] == DungeonTile.Door)
                        doorPositions.Add(new Vector2Int(j, i));
                }
            }
            return ret;
        }
        public static DungeonTile[,] GetTileDataLeft(DungeonComponent component, out IList<Vector2Int> doorPositions)
        {
            doorPositions = new List<Vector2Int>();
            int w = component.tileData.GetLength(0);
            int h = component.tileData.GetLength(1);
            DungeonTile[,] ret = new DungeonTile[h, w];
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    ret[i, j] = component.tileData[j, h - i - 1];
                    if (ret[i, j] == DungeonTile.Door)
                        doorPositions.Add(new Vector2Int(j, i));
                }
            }
            return ret;
        }
        public static DungeonTile[,] GetTileDataDown(DungeonComponent component, out IList<Vector2Int> doorPositions)
        {
            doorPositions = new List<Vector2Int>();
            int w = component.tileData.GetLength(1);
            int h = component.tileData.GetLength(0);
            DungeonTile[,] ret = new DungeonTile[h, w];
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    ret[i, w - 1 - j] = component.tileData[h - 1 - i, j];
                    if (ret[i, j] == DungeonTile.Door)
                        doorPositions.Add(new Vector2Int(j, i));
                }
            }
            return ret;
        }
        private static List<Vector2Int> GetDoorLocations(DungeonTile[,] tileData)
        {
            List<Vector2Int> result = new List<Vector2Int>();
            for(int i = 0; i < tileData.GetLength(0); i++)
            {
                for(int j = 0; j < tileData.GetLength(1); j++)
                {
                    if (tileData[i, j] == DungeonTile.Door)
                        result.Add(new Vector2Int(j, i));
                }
            }
            return result;
        }
    }
}

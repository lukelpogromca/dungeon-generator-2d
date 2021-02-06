using DG2D.Enums;

namespace DG2D.Globals
{
    public static class RoomDefinitions
    {
        private static readonly DungeonComponent[] data =
        {
                new DungeonComponent(new DungeonTile[3, 5]
                {
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall},
                    { DungeonTile.Door, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Door},
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall},
                }, ComponentType.Hallway),
                new DungeonComponent(new DungeonTile[4, 4]
                {
                    { DungeonTile.Wall, DungeonTile.Door, DungeonTile.Wall, DungeonTile.Empty},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Door},
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall}
                }, ComponentType.Hallway),
                new DungeonComponent(new DungeonTile[4, 5]
                {
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall},
                    { DungeonTile.Door, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Door},
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Wall},
                    { DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Door, DungeonTile.Wall, DungeonTile.Empty},
                }, ComponentType.Hallway),
                new DungeonComponent(new DungeonTile[13, 13]
                {
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall,  DungeonTile.Wall,  DungeonTile.Door,  DungeonTile.Wall,  DungeonTile.Wall,  DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Wall,  DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Wall,  DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Wall,  DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Wall,  DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall },
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall },
                    { DungeonTile.Door, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Door },
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall },
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Wall,  DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Wall,  DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Wall,  DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Wall,  DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall,  DungeonTile.Wall,  DungeonTile.Door,  DungeonTile.Wall,  DungeonTile.Wall,  DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                }, ComponentType.Standard),
                 new DungeonComponent(new DungeonTile[7, 13]
                {
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Door, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Door, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Door},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall},
                }, ComponentType.Standard),
                new DungeonComponent(new DungeonTile[7, 7]
                {
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Door, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Door, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall}
                }, ComponentType.Standard),
                new DungeonComponent(new DungeonTile[9, 15]
                {
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Door, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Door },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall },
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall },
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Door, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Door, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                }, ComponentType.Standard),
                new DungeonComponent(new DungeonTile[10, 10]
                {
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Door, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Door},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Door, DungeonTile.Wall, DungeonTile.Wall},
                }, ComponentType.Standard),
                new DungeonComponent(new DungeonTile[10, 11]
                {
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Door, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall},
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall},
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty},
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty},
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Door, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty},
                }, ComponentType.Standard),
                new DungeonComponent(new DungeonTile[13, 13]
                {
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall,  DungeonTile.Wall,  DungeonTile.Door,  DungeonTile.Wall,  DungeonTile.Wall,  DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Wall,  DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Empty },
                    { DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Empty },
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Wall },
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall },
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Wall,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall },
                    { DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall },
                    { DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Wall },
                    { DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor, DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Empty },
                    { DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Floor, DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Empty },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Wall,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Floor,  DungeonTile.Wall,  DungeonTile.Wall, DungeonTile.Wall, DungeonTile.Empty, DungeonTile.Empty },
                    { DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Wall,  DungeonTile.Wall,  DungeonTile.Door,  DungeonTile.Wall,  DungeonTile.Wall,  DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty, DungeonTile.Empty },
                }, ComponentType.Event)




        };
        public static DungeonComponent GetRandomRoom()
        {
            int i = Utils.Utils.DG2DRand.Next(0, data.Length);
            return data[i];
        }
    }
}

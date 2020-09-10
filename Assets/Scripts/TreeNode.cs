using System.Collections.Generic;
using UnityEngine;
using DG2D.Enums;
using Random = UnityEngine.Random;
using System.Linq;

namespace DG2D
{
    public class TreeNode
    {
        public IList<TreeNode> ChildrenNodes { get { return childrenNodes; } }
        public TreeNode ParentNode { get { return parentNode; } set { parentNode = value; value?.ChildrenNodes.Add(this); } }
        public Vector2Int WorldPosition { get { return parentNode is null ?  LocalPosition :  parentNode.WorldPosition + LocalPosition; }}
        public Vector2Int LocalPosition { get; set; }
        public Dictionary<Vector2Int, bool> Entrances { get; set; }
        public Vector2Int ParentEntrance { get; set; }
        public Vector2Int LocalParentEntrance { get; set; }
        public int Count { get { return CountChildren() + 1; } }
        public GetTileDataDelegate TileData { get; set; } = DungeonComponent.GetTileDataUp;

        private List<TreeNode> childrenNodes;
        private DungeonComponent dungeonComponent;
        private TreeNode parentNode = null;
        private TreeNode()
        {
        }
        public TreeNode(DungeonComponent dungeonComponent)
        {
            this.dungeonComponent = dungeonComponent;
            childrenNodes = new List<TreeNode>();
            Entrances = new Dictionary<Vector2Int, bool>();
        }
        public TreeNode(TreeNode treeNode)
        {
            dungeonComponent = treeNode.dungeonComponent;
            LocalPosition = treeNode.LocalPosition;
            Entrances = new Dictionary<Vector2Int, bool>(treeNode.Entrances);
            ParentEntrance = treeNode.ParentEntrance;
            LocalParentEntrance = treeNode.LocalParentEntrance;
            TileData = treeNode.TileData;

            childrenNodes = new List<TreeNode>();
            foreach(TreeNode childrenNode in treeNode.childrenNodes)
            {
                childrenNodes.Add(new TreeNode(childrenNode) { parentNode = this });
            }

        }
        public void Dispose()
        {
            childrenNodes.Clear();
            parentNode?.ChildrenNodes.Remove(this);
        }
        private int CountChildren()
        {
            int n = 0;
            foreach (TreeNode child in childrenNodes)
            {
                n += child.CountChildren();
            }
            return childrenNodes.Count + n;
        }
        public void Detach()
        {
            if (!(parentNode is null))
            {
                Entrances[LocalParentEntrance] = false;
                parentNode.Entrances[ParentEntrance] = false;
                parentNode.ChildrenNodes.Remove(this);
                parentNode = null;
            }
        }
        public TreeNode GetRandomChild()
        {
            int rand = Random.Range(0, CountChildren() - 1);
            TreeNode result = null;
            Queue<TreeNode> bfq = new Queue<TreeNode>();
            foreach (TreeNode child in childrenNodes)
                bfq.Enqueue(child);
            int counter = 0;
            while(bfq.Any())
            {
                result = bfq.Dequeue();
                if (counter == rand)
                    break;
                counter++;
                foreach (TreeNode child in result.ChildrenNodes)
                    bfq.Enqueue(child);
            }
            return result;
        }
        public DungeonTile[,] GetTileData(out IList<Vector2Int> doorPositions) => TileData(dungeonComponent, out doorPositions);
        public ComponentType GetComponentType() => dungeonComponent.ComponentType;
        public IList<TreeNode> ToList()
        {
            List<TreeNode> result = new List<TreeNode>(childrenNodes);
            foreach (TreeNode child in childrenNodes)
                result.AddRange(child.ToList());

            return result;
        }
    }
}

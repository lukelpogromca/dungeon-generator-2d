using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG2D.Enums;

namespace DG2D
{
    public class Phenotype
    {
        public TreeNode Root { get { return root; } }
        public DungeonTile[,] GameBoard { set { gameBoard = value; } get { return gameBoard; } }

        private DungeonTile[,] gameBoard;
        private TreeNode root;
        public Phenotype(TreeNode root, DungeonTile[,] gameBoard)
        {
            this.root = root;
            this.gameBoard = gameBoard;
        }
        public Phenotype(Phenotype phenotype)
        {
            root = new TreeNode(phenotype.root);
            gameBoard = (DungeonTile[,])phenotype.gameBoard.Clone();
        }
    }
}

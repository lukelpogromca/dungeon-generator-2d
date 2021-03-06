﻿namespace DG2D
{
    public class Phenotype
    {
        public TreeNode Root { get { return root; } }

        private TreeNode root;
        public Phenotype(TreeNode root)
        {
            this.root = root;
        }
        public Phenotype(Phenotype phenotype)
        {
            root = new TreeNode(phenotype.root);
        }
    }
}

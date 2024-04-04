using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GraphProcessor;
using Unity.VisualScripting;
using UnityEngine;

namespace UnityBehaviorTree.Core
{
    public abstract class CompositeNode : BTNode
    {
        [Input(name = "In")]
        public int Input;

        [Output(name = "Out")]
        public int Output;
        
        protected List<BTNode> _children = new List<BTNode>();
        
        public List<BTNode> Children => _children;

        public CompositeNode() : base()
        {
            _children = new List<BTNode>();
        }
        
        public CompositeNode(List<BTNode> children) : base()
        {
            _children = children;
        }
        
        protected override void OnStart()
        {
            _children = _children.OrderBy(o => o.position.x).ToList();
        }

        public override BTNode Clone()
        {
            return (BTNode)this.MemberwiseClone();
        }
    }
}
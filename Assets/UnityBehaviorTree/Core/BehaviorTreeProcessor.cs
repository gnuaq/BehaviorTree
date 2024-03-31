using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphProcessor;
using Unity.VisualScripting;
using UnityBehaviorTree.Core.Action;
using UnityBehaviorTree.Core.Composite;
using UnityEditor.VersionControl;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

namespace UnityBehaviorTree.Core
{
    public class BehaviorTreeProcessor : BaseGraphProcessor
    {
        private RootNode _rootNode;

        public BehaviorTreeProcessor(BaseGraph graph) : base(graph)
        {
            // _nodes.Add(new Sequence(new List<BTNode>{new Wait(), new Log()}));
            GenerateTreeByGraph();
        }

        public void GenerateTreeByGraph()
        {
            List<RootNode> rootNodes = graph.nodes.OfType<RootNode>().ToList();
            if (rootNodes.Count == 1)
            {
                _rootNode = rootNodes[0];
            }
            else
            {
                throw new ArgumentException("graph must have only one root node");
            }
            
            foreach (var edge in graph.edges)
            {
                var inNode = edge.inputNode as BTNode;
                var outNode = edge.outputNode as BTNode;
                AddChild(outNode, inNode);
            }
            
            _rootNode = _rootNode.Clone() as RootNode;
        }

        public void AddChild(BTNode parent, BTNode child)
        {
            if (parent is DecoratorNode decorator)
            {
                decorator.Child = child;
            }

            if (parent is RootNode rootNode)
            {
                rootNode.Child = child;
            }

            if (parent is CompositeNode composite)
            {
                composite.Children.Add(child);
            }
        }

        public override void UpdateComputeOrder()
        {

        }

        public override void Run()
        {
            if (_rootNode.Status != BTNode.EStatus.Success)
            {
                _rootNode.OnProcess();
            }
        }
    }
}
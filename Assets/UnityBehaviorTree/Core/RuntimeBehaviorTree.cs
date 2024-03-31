using GraphProcessor;
using UnityEngine;

namespace UnityBehaviorTree.Core
{
    public class RuntimeBehaviorTree: MonoBehaviour
    {
        public BaseGraph graph;
        public BehaviorTreeProcessor processor;

        private void Start()
        {
            if (graph != null)
                processor = new BehaviorTreeProcessor(graph);
        }


        void Update()
        {
            if (graph != null)
            {
                processor.Run();
            }
        }
    }
}
using GraphProcessor;
using UnityEngine;

namespace UnityBehaviorTree.Editor
{
    public class BehaviorTreeGraphWindows : BaseGraphWindow
    {
        protected override void InitializeWindow(BaseGraph graph)
        {
            titleContent = new GUIContent("Behavior Tree Graph");

            if (graphView == null)
            {
                graphView = new BaseGraphView(this);
                // graphView.Add(new CustomToolbarView(graphView));
            }

            rootView.Add(graphView);
        }
    }
}
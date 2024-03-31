using GraphProcessor;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace UnityBehaviorTree.Editor
{
    public class BehaviorTreeGraphCallbacks
    {
        [MenuItem("Assets/Create/BehaviorTreeGraph", false, 10)]
        public static void CreateGraphPorcessor()
        {
            var graph = ScriptableObject.CreateInstance< BaseGraph >();
            ProjectWindowUtil.CreateAsset(graph, "BehaviorTreeGraph.asset");
        }

        [OnOpenAsset(0)]
        public static bool OnBaseGraphOpened(int instanceID, int line)
        {
            var asset = EditorUtility.InstanceIDToObject(instanceID) as BaseGraph;

            if (asset != null)
            {
                EditorWindow.GetWindow<BehaviorTreeGraphWindows>().InitializeGraph(asset as BaseGraph);
                return true;
            }
            return false;
        }
    }
}
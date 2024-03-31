using GraphProcessor;
using UnityEditor;
using UnityEngine;

namespace UnityBehaviorTree.Core.Action
{
    [System.Serializable, NodeMenuItem("BehaviorTree/Action/Log")]
    public class Log : ActionNode
    {
        [SerializeField]
        private string _msg = "abc";
        
        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }

        protected override EStatus OnUpdate()
        {
            Debug.Log($"Log: {_msg}");
            _status = EStatus.Success;
            return _status;
        }
    }
}
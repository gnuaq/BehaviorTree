using System.Threading;
using GraphProcessor;
using UnityEditor;
using UnityEngine;

namespace UnityBehaviorTree.Core.Action
{
    [System.Serializable, NodeMenuItem("BehaviorTree/Action/Wait")]
    public class Wait : ActionNode
    {
        [SerializeField]
        private float _duration = 3;

        private float _time;

        protected override void OnStart()
        {
            _time = 0;
        }

        protected override void OnStop()
        {
        }

        protected override EStatus OnUpdate()
        {
            if (_time < _duration)
            {
                _time += Time.deltaTime;
                _status = EStatus.Running;
            }
            else
            {
                _status =  EStatus.Success;
            }

            return _status;
        }
    }
}
using GraphProcessor;
using UnityEngine;
using UnityEngine.Serialization;

namespace UnityBehaviorTree.Core.Decorator
{
    [System.Serializable, NodeMenuItem("BehaviorTree/Decorator/Repeat")]
    public class Repeat : DecoratorNode
    {
        [SerializeField]
        private int _numCycles = 0;

        private int _currentCycle = 0;
        protected override void OnStart()
        {
            _currentCycle = 0;
        }

        protected override void OnStop()
        {
        }

        protected override EStatus OnUpdate()
        {
            for (int i = _currentCycle; i < _numCycles; i++)
            {
                _currentCycle = i;
                Child.OnProcess();
                switch (Child.Status)
                {
                    case EStatus.Success:
                        continue;
                    case EStatus.Running:
                        return _status = EStatus.Running;
                    case EStatus.Failed:
                        return _status = EStatus.Failed;
                    default:
                        return _status = EStatus.Failed;
                }
            }

            return _status = EStatus.Success;
        }
    }
}
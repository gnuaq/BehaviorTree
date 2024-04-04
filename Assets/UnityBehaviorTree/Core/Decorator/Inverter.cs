using GraphProcessor;
using UnityEngine.SubsystemsImplementation;

namespace UnityBehaviorTree.Core.Decorator
{
    [System.Serializable, NodeMenuItem("BehaviorTree/Decorator/Inverter")]
    public class Inverter : DecoratorNode
    {
        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }

        protected override EStatus OnUpdate()
        {
            Child.OnProcess();
            switch (Child.Status)
            {
                case EStatus.Success:
                    return _status = EStatus.Failed;
                case EStatus.Failed:
                    return _status = EStatus.Success;
                case EStatus.Running:
                    return _status = EStatus.Running;
                default:
                    return _status = EStatus.Failed;
            }
        }
    }
}
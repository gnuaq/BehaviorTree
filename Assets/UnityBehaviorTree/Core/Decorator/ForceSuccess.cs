using GraphProcessor;

namespace UnityBehaviorTree.Core.Decorator
{
    [System.Serializable, NodeMenuItem("BehaviorTree/Decorator/ForceSuccess")]
    public class ForceSuccess : DecoratorNode
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
            if (Child.Status == EStatus.Running)
            {
                return _status = EStatus.Running;
            }
            
            return _status = EStatus.Success;
        }
    }
}
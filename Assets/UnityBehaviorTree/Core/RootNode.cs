using GraphProcessor;

namespace UnityBehaviorTree.Core
{
    [System.Serializable, NodeMenuItem("BehaviorTree/Root")]
    public class RootNode : BTNode
    {
        private BTNode _child;

        public BTNode Child
        {
            set => _child = value;
            get => _child;
        }
        
        [Output(name = "Out", allowMultiple = false)]
        public int Output;
        
        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }

        protected override EStatus OnUpdate()
        {
            _child.OnProcess();
            return _status = _child.Status;
        }
        
        public override BTNode Clone()
        {
            return (BTNode)this.MemberwiseClone();
        }
    }
}
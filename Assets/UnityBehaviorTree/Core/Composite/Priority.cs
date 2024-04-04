using System.Collections.Generic;
using System.Linq;
using GraphProcessor;

namespace UnityBehaviorTree.Core.Composite
{
    [System.Serializable, NodeMenuItem("BehaviorTree/Composite/Priority")]
    public class Priority : CompositeNode
    {
        protected int _current = 0;
        
        public Priority() : base() { }
        
        public Priority(List<BTNode> children) : base()
        {
            _children = children;
        }
        
        public override string name => "Sequence";

        protected override void OnStart()
        {
            base.OnStart();
            _current = 0;
        }

        protected override void OnStop()
        {
        }

        protected override EStatus OnUpdate()
        {
            for (int i = _current; i < _children.Count; ++i)
            {
                _current = i;
                _children[i].OnProcess();
                switch (_children[i].Status)
                {
                    case EStatus.Running:
                        return _status = EStatus.Running;
                    case EStatus.Success:
                        return _status = EStatus.Success;
                    case EStatus.Failed:
                        continue;
                    default:
                        return _status = EStatus.Failed;
                }
            }

            return _status = EStatus.Failed;
        }
    }
}
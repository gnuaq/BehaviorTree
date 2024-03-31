using System.Collections.Generic;
using System.Linq;
using GraphProcessor;
using UnityEngine.SubsystemsImplementation;

namespace UnityBehaviorTree.Core.Composite
{
    [System.Serializable, NodeMenuItem("BehaviorTree/Composite/Sequence")]
    public class Sequence : CompositeNode
    {
        protected int _current = 0;
        
        public Sequence() : base() { }
        
        public Sequence(List<BTNode> children) : base()
        {
            _children = children;
        }
        
        public override string name => "Sequence";

        protected override void OnStart()
        {
            _children = _children.OrderBy(o => o.position.x).ToList();
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
                        continue;
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
using GraphProcessor;
using UnityBehaviorTree.Core.Composite;
using UnityEditor;
using UnityEngine;

namespace UnityBehaviorTree.Core
{
    [System.Serializable]
    public abstract class BTNode : BaseNode
    {
        public enum EStatus
        {
            None,
            Running,
            Failed,
            Success,
        }

        private bool _started;
        
        protected EStatus _status;

        public EStatus Status => _status;
        public bool Started => _started;

        public BTNode()
        {
            _status = EStatus.None;
            _started = false;
        }

        public EStatus Tick()
        {
            if (!_started)
            {
                _started = true;
                OnStart();
            }

            OnUpdate();

            if (_status != EStatus.Running)
            {
                OnStop();
                _started = false;
            }

            return _status;
        }

        protected void Attach(BTNode btNode)
        {
            
        }
        
        protected override void Process()
        {
            Tick();
        }

        protected abstract void OnStart();
        protected abstract void OnStop();
        protected abstract EStatus OnUpdate();
        public abstract BTNode Clone();
    }
}
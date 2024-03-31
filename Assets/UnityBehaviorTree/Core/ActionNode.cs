using GraphProcessor;
using UnityEngine.Serialization;

namespace UnityBehaviorTree.Core
{
    public abstract class ActionNode : BTNode
    {
        [Input(name = "In")]
        public int Input;
        
        public override BTNode Clone()
        {
            return (BTNode)this.MemberwiseClone();
        }
    }
}
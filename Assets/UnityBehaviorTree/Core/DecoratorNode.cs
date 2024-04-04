using GraphProcessor;

namespace UnityBehaviorTree.Core
{
    public abstract class DecoratorNode : BTNode
    {
        [Input(name = "In")]
        public int Input;

        [Output(name = "Out", allowMultiple = false)]
        public int Output;
        
        private BTNode _child;

        public BTNode Child
        {
            set => _child = value;
            get => _child;
        }
        
        public override BTNode Clone()
        {
            return (BTNode)this.MemberwiseClone();
        }
    }
}
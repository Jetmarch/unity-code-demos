using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;

namespace Modules.Dialogues
{
    public class DialogueEdgeView : Edge
    {
        [UsedImplicitly]
        public DialogueEdgeView()
        {
            
        }

        public string GetInputId()
        {
            return ((DialogueNodeView)this.input.node).GetId();
        }

        public string GetOutputId()
        {
            return ((DialogueNodeView)this.output.node).GetId();
        }

        public int GetOutputIndex()
        {
            return ((DialogueNodeView)output.node).IndexOfOutputPort(output);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Modules.Dialogues
{
    public class DialogueLoader
    {
        public static void LoadDialogue(DialogueConfig config, DialogueGraphView graphView)
        {
            graphView.ResetState();

            if (config == null)
            {
                Debug.LogWarning("Dialogue config is null");
                return;
            }
            
            var nodeViews = new List<DialogueNodeView>();

            foreach (DialogueConfig.Node node in config.nodes)
            {
                DialogueNodeView nodeView = graphView.CreateNode(node.id, node.editorPosition);
            
                nodeView.SetMessage(node.message);
                
                foreach(var choice in node.choices)
                {
                    nodeView.CreateChoice(choice);
                }
                
                nodeViews.Add(nodeView);
            }
            
            foreach (DialogueConfig.Edge edge in config.edges)
            {
                string outputId = edge.outputNodeId;
                var outputNode = nodeViews.First(it => it.GetId() == outputId);
                
                string inputId = edge.inputNodeId;
                var inputNode = nodeViews.First(it => it.GetId() == inputId);
                
                int outputIndex = edge.outputIndex;
                graphView.CreateEdge(outputNode, outputIndex, inputNode);
            }
            
            graphView.SetRootNode(config.rootId);
        }
    }
}
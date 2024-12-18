using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Modules.Dialogues
{
    public static class DialogueSaver
    {
        public static void SaveDialogueAsNew(DialogueGraphView graph, out DialogueConfig config)
        {
            var path = EditorUtility.SaveFilePanelInProject("Save file", "Dialogue", "asset", "");
            config = ScriptableObject.CreateInstance<DialogueConfig>();
            AssetDatabase.CreateAsset(config, path);
            
            SaveDialogue(graph, config);
        }

        public static void SaveDialogue(DialogueGraphView graph, DialogueConfig config)
        {
            config.nodes = ConvertNodes(graph);
            config.edges = ConvertEdges(graph);

            if (graph.TryGetRootNode(out DialogueNodeView rootNode))
            {
                config.rootId = rootNode.GetId();
            }
            
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private static DialogueConfig.Node[] ConvertNodes(DialogueGraphView graph)
        {
            var nodeViews = graph.GetNodes();
            int count = nodeViews.Length;
            
            var nodes = new DialogueConfig.Node[count];

            for (int i = 0; i < count; i++)
            {
                var nodeView = nodeViews[i];
                var node = new DialogueConfig.Node
                {
                    id = nodeView.GetId(),
                    message = nodeView.GetMessage(),
                    editorPosition = nodeView.GetPosition().position,
                    choices = ConvertChoices(nodeView)
                };

                nodes[i] = node;
            }

            return nodes;
        }

        private static string[] ConvertChoices(DialogueNodeView node)
        {
            var choiceViews = node.GetChoices();
            int count = choiceViews.Length;
            
            var choices = new string[count];

            for (int i = 0; i < count; i++)
            {
                var choiceView = choiceViews[i];
                choices[i] = choiceView.GetText();
            }

            return choices;
        }

        private static DialogueConfig.Edge[] ConvertEdges(DialogueGraphView graph)
        {
            var edgeViews = graph.GetEdges();
            int count = edgeViews.Length;
            
            var edges = new DialogueConfig.Edge[count];

            for (int i = 0; i < count; i++)
            {
                DialogueEdgeView edgeView = edgeViews[i];
                DialogueConfig.Edge edge = new DialogueConfig.Edge
                {
                    inputNodeId = edgeView.GetInputId(),
                    outputNodeId = edgeView.GetOutputId(),
                    outputIndex = edgeView.GetOutputIndex()
                };
                
                edges[i] = edge;
            }
            
            return edges;
        }
        
    }
}
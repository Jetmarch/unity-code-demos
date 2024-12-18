using System;

namespace Modules.Dialogues.Scripts
{
    public sealed class Dialogue
    {
        public string CurrentMessage => _node.message;
        public string[] CurrentChoices => _node.choices;

        private readonly DialogueConfig _config;
        private DialogueConfig.Node _node;

        public Dialogue(DialogueConfig config)
        {
            _config = config;

            if (config.FindRootNode(out DialogueConfig.Node node))
            {
                _node = node;
            }
            else
            {
                throw new Exception("Root node is not found!");
            }
        }

        public bool MoveNext(int choiceIndex)
        {
            return _config.FindNextNode(_node.id, choiceIndex, out _node);
        }
    }
}
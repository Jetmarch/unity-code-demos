using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Modules.Dialogues
{
    public class DialogueChoiceView : VisualElement
    {
        public event Action<DialogueChoiceView> OnDelete;

        private TextField _textAnswer;
        private Port _port;
        public DialogueChoiceView(string answer)
        {
            CreateButtonDelete();
            CreateTextAnswer(answer);
            CreatePortOutput();
            style.flexDirection = FlexDirection.Row;
        }

        public string GetText()
        {
            return _textAnswer.text;
        }

        public bool IsPort(Port port)
        {
            return _port == port;
        }
        
        public Port GetPort()
        {
            return _port;
        }

        private void CreateButtonDelete()
        {
            Button button = new Button
            {
                text = "X",
                clickable = new Clickable(OnDeleteClicked)
            };
            button.AddToClassList("dialogue-node-remove-choice-button");
            this.Add(button);
        }

        private void OnDeleteClicked()
        {
            OnDelete?.Invoke(this);
        }

        private void CreateTextAnswer(string answer)
        {
            _textAnswer = new TextField
            {
                value = answer,
                multiline = false,
                style =
                {
                    width = 128
                }
            };
            Add(_textAnswer);
        }
        
        private void CreatePortOutput()
        {
            _port = Port.Create<DialogueEdgeView>(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, null);
            _port.portColor = Color.yellow;
            Add(_port);
        }

        
    }
}
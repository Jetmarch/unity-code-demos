using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Modules.Dialogues
{
    public class DialogueNodeView : Node
    {
        private readonly string _id;
        private readonly List<DialogueChoiceView> _choices;

        private TextField _textMessage;
        private Port _inputPort;
        private bool _isRoot;

        public DialogueNodeView(string id)
        {
            _id = id;
            this.title = "Dialogue Node";
            _choices = new List<DialogueChoiceView>();

            CreateTextMessage();
            CreatePortInput();
            CreateButtonAddChoice();
            ApplyStyles();
            RefreshExpandedState();
        }

        public DialogueChoiceView[] GetChoices()
        {
            return _choices.ToArray();
        }

        public string GetMessage()
        {
            return _textMessage.text;
        }

        public void SetMessage(string message)
        {
            _textMessage = new TextField
            {
                value = message,
                multiline = true,
            };
        }

        public int IndexOfOutputPort(Port port)
        {
            for (int i = 0; i < _choices.Count; i++)
            {
                var choice = _choices[i];
                if (choice.IsPort(port))
                {
                    return i;
                }
            }

            throw new Exception("Index of port is not found!");
        }

        public bool IsRoot()
        {
            return _isRoot;
        }
        
        public void CreateChoice(string answer)
        {
            DialogueChoiceView choice = new DialogueChoiceView(answer);
            choice.OnDelete += this.DeleteChoice;
            _choices.Add(choice);
            outputContainer.Add(choice);
            RefreshExpandedState();
        }
        
        private void CreateTextMessage()
        {
            _textMessage = new TextField
            {
                value = "Enter message here",
                multiline = true,
            };
            
            _textMessage.AddToClassList("dialogue-node-text-message");
            extensionContainer.Add(_textMessage);
        }
        
        private void CreateButtonAddChoice()
        {
            Button button = new Button
            {
                text = "Add Choice",
                clickable = new Clickable(this.OnCreateChoiceClicked)
            };
            
            button.AddToClassList("dialogue-node-add-choice-button");
            mainContainer.Add(button);
        }

        private void OnCreateChoiceClicked()
        {
            CreateChoice("Enter Answer...");
        }

        private void DeleteChoice(DialogueChoiceView choice)
        {
            choice.OnDelete -= this.DeleteChoice;
            _choices.Remove(choice);
            outputContainer.Remove(choice);
            RefreshExpandedState();
        }
        
        private void ApplyStyles()
        {
            this.mainContainer.AddToClassList("dialogue-node-main-container");
        }
        
        private void CreatePortInput()
        {
            _inputPort = Port.Create<DialogueEdgeView>(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, null);
            _inputPort.portName = "Input";
            inputContainer.Add(_inputPort);
        }

        public void SetRoot(bool isRoot)
        {
            _isRoot = isRoot;
            style.backgroundColor = isRoot 
                ? new Color(0.92f, 0.76f, 0f) 
                : new Color(0.53f, 0.53f, 0.56f);
        }

        public string GetId()
        {
            return _id;
        }

        public Port GetOutputPort(int outputIndex)
        {
            return _choices[outputIndex].GetPort();
        }

        public Port GetInputPort()
        {
            return _inputPort;
        }
    }
}
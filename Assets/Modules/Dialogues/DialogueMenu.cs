
using UnityEditor;
using UnityEngine;

namespace Modules.Dialogues
{
    public sealed class DialogueMenu
    {
        [MenuItem("Window/Dialogues")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<DialogueWindow>("Dialogue");
        }
    }
}
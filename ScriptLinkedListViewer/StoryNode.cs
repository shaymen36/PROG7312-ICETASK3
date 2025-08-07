namespace ScriptLinkedListViewer
{
    public class StoryNode
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public StoryNode? Next { get; set; }

        public StoryNode(int number, string text)
        {
            Number = number;
            Text = text;
            Next = null;
        }
    }
}

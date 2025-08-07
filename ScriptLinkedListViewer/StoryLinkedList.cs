using System.Collections.Generic;

namespace ScriptLinkedListViewer
{
    public class StoryLinkedList
    {
        public StoryNode? Head { get; private set; }

        public void Add(int number, string text)
        {
            var newNode = new StoryNode(number, text);
            newNode.Next = Head;
            Head = newNode;
        }

        public void Sort()
        {
            if (Head == null || Head.Next == null) return;

            bool swapped;
            do
            {
                swapped = false;
                StoryNode? current = Head;
                StoryNode? prev = null;

                while (current?.Next != null)
                {
                    if (current.Number > current.Next.Number)
                    {
                        var tmp = current.Next;
                        current.Next = tmp.Next;
                        tmp.Next = current;

                        if (prev == null)
                            Head = tmp;
                        else
                            prev.Next = tmp;

                        swapped = true;
                        prev = tmp;
                    }
                    else
                    {
                        prev = current;
                        current = current.Next;
                    }
                }
            } while (swapped);
        }

        public List<string> ToList()
        {
            List<string> lines = new();
            StoryNode? current = Head;
            while (current != null)
            {
                lines.Add(current.Text);
                current = current.Next;
            }
            return lines;
        }
    }
}

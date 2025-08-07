using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScriptLinkedListViewer
{
    public partial class Form1 : Form
    {
        private ListBox lstFullScript;
        private Label lblSingleLine;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnToggleView;

        private readonly (int, string)[] rawScript = new (int, string)[]
        {
            (3, "With every line of code mastered, Alex gains experience points..."),
            (12, "The tale of Alex, the IT student-turned-digital-legend..."),
            (4, "The Firewall Fortress looms ahead..."),
            (2, "Armed with a trusty keyboard..."),
            (1, "In the virtual realm of Cybersphere, our hero..."),
            (7, "Along the journey, Alex forges alliances..."),
            (10, "Victory is hard-won, but Alex’s leadership..."),
            (11, "Celebrated as a digital hero..."),
            (9, "In a climactic battle, Alex and the Syntax Sentinels..."),
            (5, "Inside the fortress, a virtual reality riddle awaits..."),
            (6, "Emerging victorious, Alex discovers the hidden Repository..."),
            (8, "The guild faces its nemesis in the form of the Malware Marauders...")
        };

        private StoryLinkedList script = new();
        private List<string> sortedScript = new();
        private int currentIndex = 0;
        private bool isFullView = true;

        public Form1()
        {
            InitializeComponent();
            InitializeGUI();
            LoadScript();
        }

        private void InitializeGUI()
        {
            this.Text = "Script Viewer (Linked List)";
            this.Width = 800;
            this.Height = 500;

            // ListBox for full script
            lstFullScript = new ListBox
            {
                Top = 10,
                Left = 10,
                Width = 760,
                Height = 300
            };
            this.Controls.Add(lstFullScript);

            // Label for single line view
            lblSingleLine = new Label
            {
                Top = 10,
                Left = 10,
                Width = 760,
                Height = 100,
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font("Segoe UI", 12),
                AutoSize = false
            };
            this.Controls.Add(lblSingleLine);

            // Button: Previous
            btnPrevious = new Button
            {
                Text = "⏮️ Previous",
                Top = 320,
                Left = 10,
                Width = 120
            };
            btnPrevious.Click += BtnPrevious_Click;
            this.Controls.Add(btnPrevious);

            // Button: Next
            btnNext = new Button
            {
                Text = "▶️ Next",
                Top = 320,
                Left = 140,
                Width = 120
            };
            btnNext.Click += BtnNext_Click;
            this.Controls.Add(btnNext);

            // Button: Toggle View
            btnToggleView = new Button
            {
                Text = "🔄 Toggle View",
                Top = 320,
                Left = 270,
                Width = 160
            };
            btnToggleView.Click += BtnToggleView_Click;
            this.Controls.Add(btnToggleView);
        }

        private void LoadScript()
        {
            foreach (var (num, text) in rawScript)
            {
                script.Add(num, text);
            }

            script.Sort();
            sortedScript = script.ToList();
            DisplayFullScript();
        }

        private void DisplayFullScript()
        {
            isFullView = true;
            lstFullScript.Visible = true;
            lblSingleLine.Visible = false;
            lstFullScript.Items.Clear();
            foreach (var line in sortedScript)
            {
                lstFullScript.Items.Add(line);
            }
        }

        private void DisplaySingleLine()
        {
            isFullView = false;
            lstFullScript.Visible = false;
            lblSingleLine.Visible = true;
            lblSingleLine.Text = sortedScript[currentIndex];
        }

        private void BtnNext_Click(object? sender, EventArgs e)
        {
            if (!isFullView && currentIndex < sortedScript.Count - 1)
            {
                currentIndex++;
                DisplaySingleLine();
            }
        }

        private void BtnPrevious_Click(object? sender, EventArgs e)
        {
            if (!isFullView && currentIndex > 0)
            {
                currentIndex--;
                DisplaySingleLine();
            }
        }

        private void BtnToggleView_Click(object? sender, EventArgs e)
        {
            if (isFullView)
                DisplaySingleLine();
            else
                DisplayFullScript();
        }
    }
}

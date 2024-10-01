using Northwoods.Go.Models;
using Northwoods.Go;
using Northwoods.Go.Tools;

namespace FlowchartMaker
{
    public partial class Form1 : Form
    {
        public Diagram diagram;

        public Form1()
        {
            InitializeComponent();

            contextMenuStrip1.Items.Insert(0, new ToolStripLabel("Add node") { Font = new System.Drawing.Font(DefaultFont, System.Drawing.FontStyle.Bold) });
            contextMenuStrip1.Items.Insert(1, new ToolStripSeparator());
            diagramControl1.ContextMenuStrip = contextMenuStrip1;

            diagram = diagramControl1.Diagram;
            diagram.ElementDoubleClicked += (s, e) =>
            {
                var part = (e.Subject as GraphObject).Part;
                if (part is Link) return;
                EditNodeForm.Reveal(diagram, (string)part.Key);
            };
            Setup();
        }

        private void Setup()
        {
            diagram.UndoManager.IsEnabled = true;
            diagram.ToolManager.DraggingTool.IsGridSnapEnabled = true;
            diagram.ToolManager.MouseWheelBehavior = WheelMode.Zoom;

            diagram.NodeTemplateMap.Add("Start", StartNodeTemplate());
            diagram.NodeTemplateMap.Add("Process", ProcessNodeTemplate());
            diagram.NodeTemplateMap.Add("Decision", DecisionNodeTemplate());
            diagram.NodeTemplateMap.Add("End", EndNodeTemplate());

            // Define the node and link data
            var nodeDataList = new List<NodeData>()
            {
                new NodeData { Key = "Start", Category = "Start", Text = "Start", Position = new Northwoods.Go.Point(-70, -240) },
                new NodeData { Key = "Process", Category = "Process", Text = "Process", Position = new Northwoods.Go.Point(-80, -130) },
                new NodeData { Key = "Decision", Category = "Decision", Text = "Decision", Position = new Northwoods.Go.Point(-100, -20) },
                new NodeData { Key = "End", Category = "End", Text = "End", Position = new Northwoods.Go.Point(-70, 160) }
            };

            var linkDataList = new List<LinkData>
            {
                new LinkData { From = "Start", To = "Process", FromSpot = "Bottom", FromPort = "Out", ToPort = "InTop" },
                new LinkData { From = "Process", To = "Decision", FromSpot = "Bottom", FromPort = "Out", ToPort = "In" },
                new LinkData { From = "Decision", To = "End", FromSpot = "Bottom", FromPort = "Yes", ToPort = "InTop" },
                new LinkData { From = "Decision", To = "Process", FromSpot = "Right", FromPort = "No", ToPort = "InRight" }
            };


            diagram.LinkTemplate =
            new Link
            {
                Routing = LinkRouting.Normal,
                RelinkableFrom = true,
                RelinkableTo = true,
                ToShortLength = 2
            }
                //.Bind("FromSpot", Spot.Parse)
                //.Bind("ToSpot", Spot.Parse)
                //.Bind("FromEndSegmentLength")
                //.Bind("ToEndSegmentLength")
                .Add(
                    new Shape(),
                    new Shape { ToArrow = "Standard" }
                );

            diagram.Model = new MyModel
            {
                LinkFromPortIdProperty = "FromPort",  // required information:
                LinkToPortIdProperty = "ToPort",      // identifies data property names
                NodeDataSource = nodeDataList,
                LinkDataSource = linkDataList
            };

            foreach (var node in diagram.Nodes) node.Position = ((NodeData)node.Data).Position;
        }

        private Node StartNodeTemplate()
        {
            var template = new Node("Auto")
            {
                MinSize = new Northwoods.Go.Size(50, 30),
                FromSpot = Spot.Bottom,
            }
            .Bind(new Northwoods.Go.Models.Binding("Position", "Position").MakeTwoWay())
            .Add(
                new Shape { Fill = "white", Stroke = "black", StrokeWidth = 2 }
                .Bind("Fill", "BackColor"),
                new Northwoods.Go.Panel("Spot")
                .Add(
                    new TextBlock
                    {
                        Alignment = Spot.Center,
                        Margin = new Margin(10, 10)
                    }
                    .Bind("Text", "Text")
                    .Bind("Stroke", "ForeColor"),
                    new Shape
                    {
                        Width = 6,
                        Height = 6,
                        Alignment = new Spot(0.5, 1, 0, 5),
                        PortId = "Out",
                        FromLinkable = true
                    }
                )
            );
            return template;
        }

        private Node EndNodeTemplate()
        {
            var template = new Node("Auto")
            {
                MinSize = new Northwoods.Go.Size(50, 30),
                ToSpot = Spot.AllSides
            }
            .Bind(new Northwoods.Go.Models.Binding("Position", "Position").MakeTwoWay())
            .Add(
                new Shape { Fill = "white", Stroke = "black", StrokeWidth = 2 }
                .Bind("Fill", "BackColor"),
                new TextBlock
                {
                    Alignment = Spot.Center,
                    Margin = new Margin(10, 10)
                }
                .Bind("Text", "Text")
                .Bind("Stroke", "ForeColor"),
                new Shape
                {
                    Fill = null,
                    Stroke = null,
                    Width = 6,
                    Height = 6,
                    Alignment = Spot.Top,
                    PortId = "InTop",
                    ToLinkable = true
                },
                new Shape
                {
                    Fill = null,
                    Stroke = null,
                    Width = 6,
                    Height = 6,
                    Alignment = Spot.Left,
                    PortId = "InLeft",
                    ToLinkable = true
                },
                new Shape
                {
                    Fill = null,
                    Stroke = null,
                    Width = 6,
                    Height = 6,
                    Alignment = Spot.Right,
                    PortId = "InRight",
                    ToLinkable = true
                },
                new Shape
                {
                    Fill = null,
                    Stroke = null,
                    Width = 6,
                    Height = 6,
                    Alignment = Spot.Bottom,
                    PortId = "InBottom",
                    ToLinkable = true
                }
            );
            return template;
        }

        private Node ProcessNodeTemplate()
        {
            var template = new Node("Auto")
            {
                MinSize = new Northwoods.Go.Size(50, 30),
                FromSpot = Spot.BottomSide,
                ToSpot = Spot.NotBottomSide
            }
            .Bind(new Northwoods.Go.Models.Binding("Position", "Position").MakeTwoWay())
            .Add(
                new Shape { Fill = "white", Stroke = "black", StrokeWidth = 2 }
                .Bind("Fill", "BackColor"),
                new Northwoods.Go.Panel("Spot")
                .Add(
                    new TextBlock
                    {
                        Alignment = Spot.Center,
                        Margin = new Margin(10, 10)
                    }.Bind("Text", "Text")
                    .Bind("Stroke", "ForeColor"),
                    new Shape
                    {
                        Fill = null,
                        Stroke = null,
                        Width = 6,
                        Height = 6,
                        Alignment = Spot.Top,
                        PortId = "InTop",
                        ToLinkable = true
                    },
                    new Shape
                    {
                        Fill = null,
                        Stroke = null,
                        Width = 6,
                        Height = 6,
                        Alignment = Spot.Left,
                        PortId = "InLeft",
                        ToLinkable = true
                    },
                    new Shape
                    {
                        Fill = null,
                        Stroke = null,
                        Width = 6,
                        Height = 6,
                        Alignment = new Spot(1, 0.5, 10, 0),
                        PortId = "InRight",
                        ToLinkable = true
                    },
                    new Shape
                    {
                        Width = 6,
                        Height = 6,
                        Alignment = new Spot(0.5, 1, 0, 10),
                        PortId = "Out",
                        FromLinkable = true
                    }
                )
            );
            return template;
        }

        private Node DecisionNodeTemplate()
        {
            var template = new Node("Auto")
            {
                ToSpot = Spot.TopLeftSides,
            }
            .Bind(new Northwoods.Go.Models.Binding("Position", "Position").MakeTwoWay())
            .Add(
                new Northwoods.Go.Panel("Spot")
                .Add(
                    new Shape("Diamond") { Fill = "white", Stroke = "black", StrokeWidth = 2 }
                    .Bind("Fill", "BackColor"),
                    new TextBlock
                    {
                        Alignment = Spot.Center,
                        Margin = new Margin(10, 10)
                    }
                    .Bind("Text", "Text")
                    .Bind("Stroke", "ForeColor"),
                    new Shape
                    {
                        Fill = null,
                        Stroke = null,
                        Width = 6,
                        Height = 6,
                        Alignment = Spot.Top,
                        PortId = "In",
                        ToLinkable = true
                    },
                    new TextBlock("Yes") { Alignment = new Spot(0.5, 1, 20, 0) },
                    new Shape
                    {
                        Width = 6,
                        Height = 6,
                        Alignment = Spot.Bottom,
                        PortId = "Yes",
                        FromLinkable = true
                    },
                    new TextBlock("No") { Alignment = new Spot(1, 0.5, 0, 20) },
                    new Shape
                    {
                        Width = 6,
                        Height = 6,
                        Alignment = Spot.Right,
                        PortId = "No",
                        FromLinkable = true
                    }
                )
            );
            return template;
        }

        public class MyModel : GraphLinksModel<NodeData, string, object, LinkData, string, string> { }
        public class NodeData
        {
            // redefined some methods because the suggested way of doing this adds a bunch of junk data to the saved json file
            public string Key { get; set; }
            public string Category { get; set; } = "";
            public string Text { get; set; }
            public Northwoods.Go.Point Position { get; set; }
            public string ForeColor { get; set; } = "black";
            public string BackColor { get; set; } = "white";
        }
        public class LinkData
        {
            // redefined some methods because the suggested way of doing this adds a bunch of junk data to the saved json file
            public string Key { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public string FromSpot { get; set; }
            public string ToSpot { get; set; }
            public string FromPort { get; set; }
            public string ToPort { get; set; }
        }

        private void openFlowchartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Json files (*.json)|*.json",
                Title = "Open flowchart"
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                using StreamReader reader = new(openFileDialog.FileName);
                string flowchart = reader.ReadToEnd();
                diagram.Model = MyModel.FromJson<MyModel>(flowchart);
            }
            catch (IOException ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }

        private void saveFlowchartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Json file|*.json";
            saveFileDialog1.Title = "Save flowchart";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName == "") return;
            string savedFlowchart = diagram.Model.ToJson();
            File.WriteAllText(saveFileDialog1.FileName, savedFlowchart);
            MessageBox.Show("Saved flowchart to " + saveFileDialog1.FileName, "Saved flowchart", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearFlowchartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diagram.Model = new MyModel();
        }

        private void enableGridlinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diagram.Grid.Visible = !diagram.Grid.Visible;
        }

        private void enableGridsnapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!diagram.ToolManager.DraggingTool.IsGridSnapEnabled)
            {
                diagram.ToolManager.DraggingTool.IsGridSnapEnabled = true;
                enableGridsnapToolStripMenuItem.Text = "Disable gridsnap";
            }
            else
            {
                diagram.ToolManager.DraggingTool.IsGridSnapEnabled = false;
                enableGridsnapToolStripMenuItem.Text = "Enable gridsnap";
            }
        }

        private void startEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nodedata = new NodeData { Key = "Start", Category = "Start", Text = "Start" };
            diagram.Model.AddNodeData(nodedata);
            diagram.UpdateAllRelationshipsFromData();
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nodedata = new NodeData { Key = "End", Category = "End", Text = "End" };
            diagram.Model.AddNodeData(nodedata);
            diagram.UpdateAllRelationshipsFromData();
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNodeForm.Reveal(diagram, "process");
        }

        private void decisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNodeForm.Reveal(diagram, "decision");
        }
    }
}
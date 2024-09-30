using Northwoods.Go.Models;
using Northwoods.Go;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            .Add(
                new Shape { Fill = "white", Stroke = "black", StrokeWidth = 2 },
                new Northwoods.Go.Panel("Spot")
                .Add(
                    new TextBlock
                    {
                        Alignment = Spot.Center,
                        Margin = new Margin(10, 10)
                    }.Bind("Text", "Text"),
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
            .Add(
                new Shape { Fill = "white", Stroke = "black", StrokeWidth = 2 },
                new TextBlock { Alignment = Spot.Center, Margin = new Margin(10, 10) }
                .Bind("Text", "Text"),
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
            .Add(
                new Shape { Fill = "white", Stroke = "black", StrokeWidth = 2 },
                new Northwoods.Go.Panel("Spot")
                .Add(
                    new TextBlock
                    {
                        Alignment = Spot.Center,
                        Margin = new Margin(10, 10)
                    }.Bind("Text", "Text"),
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
            .Add(
                new Northwoods.Go.Panel("Spot")
                .Add(
                    new Shape("Diamond") { Fill = "white", Stroke = "black", StrokeWidth = 2 },
                    new TextBlock
                    {
                        Alignment = Spot.Center,
                        Margin = new Margin(10, 10)
                    }.Bind("Text", "Text"),
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

                //for some reason i can't get the positions to load using MyModel.FromJson, so i am parsing the json file manually to get them.
                JObject root = JsonConvert.DeserializeObject<JObject>(flowchart);

                // node data
                JToken[] nodeDataSource = root.GetValue("NodeDataSource").ToArray();
                var nodeDataList = new List<NodeData>();
                foreach (JToken token in nodeDataSource)
                {
                    string key = token.Value<string>("key");
                    string category = token.Value<string>("category");
                    string text = token.Value<string>("text");
                    string[] xy = token.Value<string>("position").Split(" ");
                    Northwoods.Go.Point location = new Northwoods.Go.Point(double.Parse(xy[0]), double.Parse(xy[1]));
                    nodeDataList.Add(new NodeData { Key = key, Category = category, Text = text, Position = location });
                }

                // link data
                JToken[] linkDataSource = root.GetValue("LinkDataSource").ToArray();
                var linkDataList = new List<LinkData>();
                foreach (JToken token in linkDataSource)
                {
                    string from = token.Value<string>("from");
                    string to = token.Value<string>("to");
                    string fromPort = token.Value<string>("fromPort");
                    string toPort = token.Value<string>("toPort");
                    linkDataList.Add(new LinkData { From = from, To = to, FromPort = fromPort, ToPort = toPort });
                }

                // create new model
                diagram.Model = new MyModel
                {
                    LinkFromPortIdProperty = "FromPort",
                    LinkToPortIdProperty = "ToPort",
                    NodeDataSource = nodeDataList,
                    LinkDataSource = linkDataList
                };

                // update node positions
                foreach (var node in diagram.Nodes) node.Position = ((NodeData)node.Data).Position;

            }
            catch (IOException ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }

        private void saveFlowchartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var node in diagram.Nodes)
            {
                if (node.Data is NodeData data)
                {
                    data.Position = node.Position;
                }
            }
            string savedFlowchart = diagram.Model.ToJson();
            File.WriteAllText("flowchart.json", savedFlowchart);
            MessageBox.Show("Saved flowchart to flowchart.json", "Saved flowchart", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            AddNodeForm.nodeType = "process";
            AddNodeForm addNodeForm = new AddNodeForm();
            addNodeForm.Show();
        }

        private void decisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNodeForm.nodeType = "decision";
            AddNodeForm addNodeForm = new AddNodeForm();
            addNodeForm.Show();
        }
    }
}
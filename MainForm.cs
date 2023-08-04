using System;
using System.IO;
using System.Windows.Forms;

namespace player
{
    public partial class Main : Form
    {
        Bass bass = null;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>

        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// FOLDERs TREE & FILEs LIST
        /// </summary>

        private bool FillTree(TreeNodeCollection nodes)
        {
            nodes.Clear();

            try
            {
                foreach (string drive in Directory.GetLogicalDrives())
                {
                    ShellFileInfo finfo = new ShellFileInfo(drive);
                    TreeNode item = nodes.Add(drive, finfo.FileName);
                    string key = finfo.IconIndex.ToString();

                    if (!this.imageIcons.Images.ContainsKey(key))
                        this.imageIcons.Images.Add(key, finfo.IconImage);

                    item.Tag = drive;
                    item.ImageKey = key;
                    item.SelectedImageKey = key;
                    item.Nodes.Add("");
                }
            }
            catch { return (false); }

            return (true);
        }

        private bool FillTreeNode(TreeNodeCollection nodes, string path)
        {
            if (nodes.Count == 1 && nodes[0].Text == "") nodes.Clear();
            if (nodes.Count > 0) return (false);

            try
            {
                DirectoryInfo root = new DirectoryInfo(path);
                foreach (DirectoryInfo dir in root.GetDirectories())
                {
                    TreeNode item = nodes.Add(dir.FullName + '\\', dir.Name);
                    ShellFileInfo finfo = new ShellFileInfo(dir.FullName);
                    string key = finfo.IconIndex.ToString();

                    if (!this.imageIcons.Images.ContainsKey(key))
                        this.imageIcons.Images.Add(key, finfo.IconImage);

                    item.Tag = dir.FullName;
                    item.Text = finfo.FileName;
                    item.ImageKey = key;
                    item.SelectedImageKey = key;
                    item.Nodes.Add("");
                }
            }
            catch { return (false); }

            return (true);
        }

        private bool FillListItems(ListView.ListViewItemCollection items, string path)
        {
            items.Clear();

            try
            {
                DirectoryInfo root = new DirectoryInfo(path);
                foreach (FileInfo file in root.GetFiles())
                {
                    ShellFileInfo finfo = new ShellFileInfo(file.FullName);
                    string[] strs = { file.Name, Convert.ToString(file.Length / 1024) + "KB", finfo.FileType };
                    ListViewItem item = new ListViewItem(strs);
                    string key = finfo.IconIndex.ToString();

                    if (!this.imageIcons.Images.ContainsKey(key))
                        this.imageIcons.Images.Add(key, finfo.IconImage);

                    item.ImageKey = key;
                    item.Tag = file.FullName;
                    items.Add(item);
                }
            }
            catch { return (false); }

            return (true);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            bass = new Bass(Handle);
            
            //
            // window & split position
            //

            int x = (int)Program.ReadKey("Main\\X", Location.X);
            int y = (int)Program.ReadKey("Main\\Y", Location.Y);
            int w = (int)Program.ReadKey("Main\\Width", Size.Width);
            int h = (int)Program.ReadKey("Main\\Height", Size.Height);
            Location = new System.Drawing.Point(x, y);
            Size = new System.Drawing.Size(w, h);
            splitter.SplitterDistance = (int)Program.ReadKey("Main\\Splitter", splitter.SplitterDistance);

            //
            // list header
            // 

            listFiles.View = View.Details;
            listFiles.Columns.Add("Name", "Name", (int)Program.ReadKey("Main\\NameWidth", 300));
            listFiles.Columns.Add("Size", "Size", (int)Program.ReadKey("Main\\SizeWidth", 80));
            listFiles.Columns.Add("Type", "Type", (int)Program.ReadKey("Main\\TypeWidth", 120));

            //
            // prepare tree
            //

            treeFolders.BeginUpdate();
            // fill tree with drives
            FillTree(treeFolders.Nodes);
            // expand tree
            string path = (string)Program.ReadKey("Main\\Path", "");
            if (path.Length > 0)
            {
                if (path.EndsWith("\\")) path = path.Substring(0, path.Length - 1);
                string[] split = path.Split('\\'); path = "";
                TreeNodeCollection nodes = treeFolders.Nodes;
                foreach (string name in split)
                {
                    path += name + '\\';
                    TreeNode node = nodes[path];
                    if (node == null)
                        break;
                    FillTreeNode(node.Nodes, path);
                    treeFolders.SelectedNode = node;
                    nodes = node.Nodes;
                }
            }
            treeFolders.EndUpdate();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.WriteKey("Main\\", "Exist");
            Program.WriteKey("Main\\X", Location.X);
            Program.WriteKey("Main\\Y", Location.Y);
            Program.WriteKey("Main\\Width", Size.Width);
            Program.WriteKey("Main\\Height", Size.Height);
            Program.WriteKey("Main\\Splitter", splitter.SplitterDistance);

            Program.WriteKey("Main\\NameWidth", listFiles.Columns["Name"].Width);
            Program.WriteKey("Main\\SizeWidth", listFiles.Columns["Size"].Width);
            Program.WriteKey("Main\\TypeWidth", listFiles.Columns["Type"].Width);

            Program.WriteKey("Main\\Path", treeFolders.SelectedNode.Tag);
        }

        private void treeFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listFiles.BeginUpdate();
            FillListItems( listFiles.Items, e.Node.Tag.ToString() );
            listFiles.EndUpdate();
        }

        private void treeFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeFolders.BeginUpdate();
            FillTreeNode(e.Node.Nodes, e.Node.Tag.ToString());
            treeFolders.EndUpdate();
        }

        private void toolRionix_Click(object sender, EventArgs e)
        {
            toolRionix.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.rionix.com");
        }

        /// <summary>
        /// Play Sound on Events
        /// </summary>

        bool ignoreMouseEvent = true;
     
        private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            bass.Stop();
            if (listFiles.SelectedItems.Count == 0) return;

            FileInfo finfo = new FileInfo(listFiles.SelectedItems[0].Tag.ToString());
            uint offset = (toolOffset.Text.Length > 0) ? uint.Parse(this.toolOffset.Text) : 0;
            bass.Play(finfo.FullName, (ushort)offset);

            ignoreMouseEvent = true;
        }

        private void listFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                listFiles_SelectedIndexChanged(sender, e);
        }

        private void toolOffset_TextChanged(object sender, EventArgs e)
        {
            listFiles_SelectedIndexChanged(this.listFiles, e);
        }

        private void listFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (!ignoreMouseEvent)
            {
                ListViewItem lvi = listFiles.GetItemAt(e.X, e.Y);
                if (lvi != null && lvi.Selected)
                    listFiles_SelectedIndexChanged(this.listFiles, e);
            }
            ignoreMouseEvent = false;
        }
    }
}
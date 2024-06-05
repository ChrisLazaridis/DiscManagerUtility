

namespace Disc_Manager_Utility
{
    [Serializable]
    public class Disc
    {
        public TreeNode<FileSystemItem>? _root;
        public string? Name { get; set; }

        public Disc(string rootName)
        {
            _root = new TreeNode<FileSystemItem>(new FileSystemItem(rootName, ItemType.Directory));
        }

        public Disc()
        {

        }

        public void AddDirectory(string path)
        {
            var directories = path.Split(Path.DirectorySeparatorChar);
            var currentNode = _root;
            foreach (var directoryName in directories)
            {
                var existingNode = currentNode?.Children
                    .FirstOrDefault(node => node.Value?.Name == directoryName && node.Value.Type == ItemType.Directory);

                if (existingNode == null)
                {
                    var newDirectory = new FileSystemItem(directoryName, ItemType.Directory);
                    var newDirectoryNode = new TreeNode<FileSystemItem>(newDirectory);
                    currentNode?.Children.Add(newDirectoryNode);
                    currentNode = newDirectoryNode;
                }
                else
                {
                    currentNode = existingNode;
                }
            }
        }

        public void AddFile(string path)
        {
            var directories = path.Split(Path.DirectorySeparatorChar);
            var fileName = directories.Last();

            var currentNode = _root;
            for (var i = 0; i < directories.Length - 1; i++)
            {
                var directoryName = directories[i];
                var existingNode = currentNode?.Children
                    .FirstOrDefault(node => node.Value?.Name == directoryName && node.Value.Type == ItemType.Directory);

                if (existingNode == null)
                {
                    var newDirectory = new FileSystemItem(directoryName, ItemType.Directory);
                    var newDirectoryNode = new TreeNode<FileSystemItem>(newDirectory);
                    currentNode?.Children.Add(newDirectoryNode);
                    currentNode = newDirectoryNode;
                }
                else
                {
                    currentNode = existingNode;
                }
            }

            var newFile = new FileSystemItem(fileName, ItemType.File);
            var newFileNode = new TreeNode<FileSystemItem>(newFile);
            currentNode?.Children.Add(newFileNode);
        }

        public void Show()
        {
            ShowNode(_root, 0);
        }

        private void ShowNode(TreeNode<FileSystemItem>? node, int level)
        {
            if (node == null) return;
            var indentation = new string(' ', level * 4);
            Console.WriteLine($"{indentation}{node.Value?.Name}");

            foreach (var childNode in node.Children)
            {
                ShowNode(childNode, level + 1);
            }
        }

        public void SortByName()
        {
            SortNodeByName(_root);
        }

        private void SortNodeByName(TreeNode<FileSystemItem>? node)
        {
            if (node == null) return;
            node.Children.Sort((node1, node2) => node1.Value.Name.CompareTo(node2.Value?.Name));

            foreach (var childNode in node.Children)
            {
                SortNodeByName(childNode);
            }
        }

        public void SortByDate()
        {
            SortNodeByDate(_root);
        }

        private void SortNodeByDate(TreeNode<FileSystemItem>? node)
        {
            if (node == null) return;
            node.Children.Sort((node1, node2) => node1.Value.Date.CompareTo(node2.Value?.Date));

            foreach (var childNode in node.Children)
            {
                SortNodeByDate(childNode);
            }
        }

        public void AddEverythingFromDisc(DriveInfo drive, ProgressBar pb)
        {
            if (drive == null) return;

            var rootDirectory = drive.RootDirectory;

            pb.Invoke((MethodInvoker)delegate { pb.Style = ProgressBarStyle.Marquee; });
            pb.Invoke((MethodInvoker)delegate { pb.MarqueeAnimationSpeed = 30; });
            pb.Invoke((MethodInvoker)delegate { pb.Visible = true; });

            AddDirectoryRecursive(rootDirectory, pb);
        }

        private void AddDirectoryRecursive(DirectoryInfo directoryInfo, ProgressBar pb)
        {
            try
            {
                // Add the directory itself
                AddDirectory(directoryInfo.FullName);

                // Recursively add subdirectories
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    AddDirectoryRecursive(directory, pb);
                }

                // Add files in the directory
                foreach (var file in directoryInfo.GetFiles())
                {
                    AddFile(file.FullName);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Handle the case where we don't have permission to access a directory or file
                Console.WriteLine($"Access denied to {directoryInfo.FullName}");
            }
            catch (Exception ex)
            {
                // Handle other possible exceptions
                Console.WriteLine($"An error occurred accessing {directoryInfo.FullName}: {ex.Message}");
            }
        }

        public void ShowDisc(TreeView treeView)
        {
            // Clear the existing nodes in the treeView
            treeView.Invoke((MethodInvoker)delegate {
                treeView.Nodes.Clear();
            });

            // Create the root node in memory
            var rootLabel = $"{_root.Value?.Name}";
            TreeNode rootNode = new TreeNode(rootLabel);
            AddNodesToTreeNode(_root, rootNode);

            // Add the root node to the treeView
            treeView.Invoke((MethodInvoker)delegate {
                treeView.Nodes.Add(rootNode);
            });
        }

        private void AddNodesToTreeNode(TreeNode<FileSystemItem>? node, TreeNode treeNode)
        {
            if (node == null) return;

            foreach (var childNode in node.Children)
            {
                string label = $"({childNode.Value?.Date.ToString("yyyy-MM-dd")}) {childNode.Value?.Name}";
                if (childNode.Value.Type == ItemType.File)
                {
                    label = $"({childNode.Value.Date.ToString("yyyy-MM-dd")}) {childNode.Value.Name}";
                }

                TreeNode childTreeNode = new TreeNode(label);
                treeNode.Nodes.Add(childTreeNode);

                // Recursively add child nodes
                AddNodesToTreeNode(childNode, childTreeNode);
            }
        }

        private void ShowNode(TreeNode<FileSystemItem>? node, TreeNodeCollection treeNodeCollection,TreeView tv, int level)
        {
            if (node == null) return;

            var indentation = new string(' ', level * 4);
            var label = $"{indentation}{node.Value?.Name}";

            // Add the node to the treeView
            TreeNode treeNode = null;
            tv.Invoke((MethodInvoker)delegate {
                treeNode = treeNodeCollection.Add(label);
            });

            foreach (var childNode in node.Children)
            {
                // Recursively add child nodes
                ShowNode(childNode, treeNode.Nodes,tv, level + 1);
            }
        }

        //make a fast search algorithm that will return the node whose name is the same as the search string
        public TreeNode<FileSystemItem>? SearchNode(TreeNode<FileSystemItem>? node, string search)
        {
            if (node == null) return null;
            return node.Value?.Name == search ? node : node.Children.Select(childNode => SearchNode(childNode, search)).OfType<TreeNode<FileSystemItem>>().FirstOrDefault();
        }
        // make a fast search algorithm that will return the node whose name is the same as the search string whose date is in between two dates
        public TreeNode<FileSystemItem>? SearchNode(TreeNode<FileSystemItem>? node, string search, DateTime startDate, DateTime endDate)
        {
            if (node == null) return null;
            return node.Value?.Name == search && node.Value.Date >= startDate && node.Value.Date <= endDate ? node : node.Children.Select(childNode => SearchNode(childNode, search, startDate, endDate)).OfType<TreeNode<FileSystemItem>>().FirstOrDefault();
        }
        public TreeNode<FileSystemItem>? Search(string search, bool useDate, DateTime startDate, DateTime endDate)
        {
            return useDate ? SearchNode(_root, search, startDate, endDate) : SearchNode(_root, search);
        }
        // Search function to find all matching nodes
        public List<(TreeNode<FileSystemItem>, string)> SearchAll(string search)
        {
            var results = new List<(TreeNode<FileSystemItem>, string)>();
            SearchAllNodes(_root, search, results, "");
            return results;
        }

        // Recursive function to search all nodes
        private void SearchAllNodes(TreeNode<FileSystemItem>? node, string search, List<(TreeNode<FileSystemItem>, string)> results, string currentPath)
        {
            if (node?.Value == null) return;

            // Check if the current node matches the criteria
            if (node.Value.Name != null && node.Value.Type == ItemType.File && LevenshteinDistance(node.Value.Name, search) <= 2)
            {
                var filePath = string.IsNullOrEmpty(currentPath) ? node.Value.Name : currentPath + Path.DirectorySeparatorChar + node.Value.Name;
                results.Add((node, filePath));
            }

            // Recurse into children
            var newPath = string.IsNullOrEmpty(currentPath) ? node.Value.Name : currentPath + Path.DirectorySeparatorChar + node.Value.Name;
            foreach (var childNode in node.Children)
            {
                SearchAllNodes(childNode, search, results, newPath);
            }
        }
        private static int LevenshteinDistance(string s1, string s2)
        {
            var d = new int[s1.Length + 1, s2.Length + 1];

            for (var i = 0; i <= s1.Length; i++)
                d[i, 0] = i;

            for (var j = 0; j <= s2.Length; j++)
                d[0, j] = j;

            for (var i = 1; i <= s1.Length; i++)
            {
                for (var j = 1; j <= s2.Length; j++)
                {
                    var cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            return d[s1.Length, s2.Length];
        }
    }

   
    [Serializable]
    public enum ItemType
    {
        Directory,
        File
    }

    [Serializable]
    public class FileSystemItem
    {
        public string? Name { get; set; }
        public ItemType Type { get; set; }
        public DateTime Date { get; set; }

        public FileSystemItem() { }

        public FileSystemItem(string name, ItemType type)
        {
            Name = name;
            Type = type;
            Date = DateTime.Now;
        }
    }

    [Serializable]
    public class TreeNode<T>()
    {
        public T? Value { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new();

        public TreeNode(T value) : this()
        {
            Value = value;
        }
    }
}

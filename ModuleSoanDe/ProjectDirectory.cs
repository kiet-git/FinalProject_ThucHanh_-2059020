using System;
using System.IO;
using System.Collections.Generic;

namespace ModuleSoanDe
{
    public class ProjectDirectory
    {
        private string dir = Environment.CurrentDirectory;
        private Dictionary<string, string> _folderDir = new Dictionary<string, string>();

        public ProjectDirectory()
        {
            _folderDir.Add("bankDir", @"bank\");
            _folderDir.Add("answerDir", @"answer\");
            _folderDir.Add("resultDir", @"result\");
            _folderDir.Add("testDir", @"test\");
            _folderDir.Add("credentialDir", @"credential\");
        }

        public string getFolder(string name)
        {
            if(_folderDir.ContainsKey(name))
            {
                return _folderDir[name];
            }
            return "";
        }

        private string getProjDirectory()
        {
            return Directory.GetParent(Directory.GetParent(dir).Parent.FullName).FullName;
        }

        private string getSolutionDirectory()
        {
            return Directory.GetParent(getProjDirectory()).FullName;
        }
    }
}

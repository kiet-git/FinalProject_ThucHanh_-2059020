using System;
using System.IO;
using System.Collections.Generic;

namespace ModuleSoanDe
{

    public class FormDirectory
    {
        private string dir = Environment.CurrentDirectory;
        private Dictionary<string, string> _folderDir = new Dictionary<string, string>();

        public FormDirectory()
        {
            _folderDir.Add("bankDir", getProjDirectory() + @"\bank\");
            _folderDir.Add("answerDir", getProjDirectory() + @"\answer\");
            _folderDir.Add("resultDir", getSolutionDirectory() + @"\result\");
            _folderDir.Add("testDir", getSolutionDirectory() + @"\test\");
            _folderDir.Add("credentialDir", getProjDirectory() + @"\credential\");
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

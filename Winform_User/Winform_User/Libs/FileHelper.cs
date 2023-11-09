using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_User.Libs
{
    public class FileHelper
    {
        public string fileName;
        public string filePath;
        public string fileFullPath;
        public FileHelper()
        {
            this.fileName = "data_userinfo.txt";
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            this.filePath = projectDirectory + "\\Winform_User\\data";

            this.fileFullPath = this.filePath + "\\" + this.fileName;
        }

        /**
         * Write user info to text file
         */
        public void writeUser(string userInfo)
        {
            MessageBox.Show(this.filePath);
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Append text to an existing file named "data_userinfo.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, this.filePath + "/" + this.fileName), true))
            {
                outputFile.WriteLine(userInfo);
            }
        }
        /**
         * Convert userInfo to string
         */
        public string parseToString(string[] arrUserInfo)
        {
            //userInfo: username,password
            string strUserInfo = string.Join(",", arrUserInfo);
            return strUserInfo;
        }
        /**
         * 
         * Convert userInfo to array
         */
        public string[] parseToArray(string strUserInfo)
        {
            //userInfo: username,password
            var arrUserInfo = strUserInfo.Split(','); 
            return arrUserInfo;
        }

        public string[][] getUsers()
        {
            //List of users
            string[][] arrUsers = new string[][] { };
            int index = 0;
            //List of lines
            string[] lines = File.ReadLines(this.filePath + "/" + this.fileName).ToArray();
            foreach(string line in lines)
            {
                var arrUserInfo = this.parseToArray(line);
                arrUsers[index] = arrUserInfo;
                index++;

            }
            return arrUsers;
        }

        public int countLines()
        {
            var lineCount = File.ReadLines(this.fileFullPath).Count();
            return lineCount;
        }

        public void emptyFile()
        {
            File.Create(this.fileFullPath).Close();
        }
    }
}

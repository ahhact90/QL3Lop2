using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UTL
{
    public static class FileFolder
    {
        /// <summary>
        /// Delete all files in it after delete all folder in it later delete it
        /// </summary>
        /// <param name="dirInfo">DirectoryInfo object</param>
        /// <returns>is true then successfull else false</returns>
        private static bool EmptyFolder(DirectoryInfo dirInfo)
        {
            try
            {
                DeleteFile(dirInfo); // delete all files in it

                // Delete all folder in it
                foreach (DirectoryInfo sub in dirInfo.GetDirectories())
                    EmptyFolder(sub);

                dirInfo.Delete(); // delete it

                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Delete all files in folder & subfolder
        /// </summary>
        /// <param name="dirInfo">DirectoryInfo object</param>
        /// <param name="fileName">file name or extension need to delete</param>
        /// <param name="isFile">true is file else extension</param>
        /// <returns>is true then successfull else false</returns>
        private static bool EmptyFile(DirectoryInfo dirInfo, string fileName = null, bool isFile = true)
        {
            var oki = DeleteFile(dirInfo, fileName, isFile); // delete all files in it

            // Delete all in sub folder
            foreach (DirectoryInfo sub in dirInfo.GetDirectories())
                oki = oki && DeleteFile(sub, fileName, isFile);
            return oki;
        }

        /// <summary>
        /// Delete file in folder
        /// </summary>
        /// <param name="dirInfo">DirectoryInfo object</param>
        /// <param name="fileName">file name need to delete</param>
        /// <param name="isFile">true is file else extension</param>
        /// <returns>is true then successfull else false</returns>
        private static bool DeleteFile(DirectoryInfo dirInfo, string fileName = null, bool isFile = true)
        {
            try
            {
                if (fileName == null)
                {
                    // Delete all files in this folder
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        file.IsReadOnly = false; file.Delete();
                    }
                }
                else
                {
                    // Delete all files by fileName or extension
                    if (isFile)
                    {
                        foreach (FileInfo file in dirInfo.GetFiles())
                            if (file.Name == fileName)
                            {
                                file.IsReadOnly = false; file.Delete();
                            }
                    }
                    else
                    {
                        foreach (FileInfo file in dirInfo.GetFiles())
                            if (file.Extension == fileName)
                            {
                                file.IsReadOnly = false; file.Delete();
                            }
                    }
                }

                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Delete all files in it after delete all folder in it later delete it by folder name input
        /// </summary>
        /// <param name="dirInfo">DirectoryInfo object</param>
        /// <param name="folderName">folder name</param>
        private static void EmptyFolder(DirectoryInfo dirInfo, string folderName)
        {
            if (folderName.Trim() == "") return;

            if (dirInfo.Name == folderName) EmptyFolder(dirInfo);
            else
                foreach (DirectoryInfo sub in dirInfo.GetDirectories())
                    EmptyFolder(sub, folderName);
        }

        // -----------------------------[ public bellow - private above ]----------------------------- //

        /// <summary>
        /// Delete all files in it after delete all folder in it later delete it
        /// </summary>
        /// <param name="pathName">path folder name</param>
        /// <returns>is true then successfull else false</returns>
        public static bool EmptyFolder(string pathName)
        {
            return EmptyFolder(new DirectoryInfo(pathName));
        }

        /// <summary>
        /// Delete all files in it after delete all folder in it later delete it by folder name input
        /// </summary>
        /// <param name="pathName">path folder name</param>
        /// <param name="folderName">folder name</param>
        public static void EmptyFolder(string pathName, string folderName)
        {
            EmptyFolder(new DirectoryInfo(pathName), folderName);
        }

        /// <summary>
        /// Remove subversion (SVN) in this folder
        /// </summary>
        /// <param name="pathName">path folder name</param>
        public static void RemoveSVN(string pathName)
        {
            EmptyFolder(pathName, ".svn");
        }

        /// <summary>
        /// Release SKG solution - delete file & folder excess
        /// </summary>
        /// <param name="pathName">folder SKG solution released</param>
        public static void ReleaseSKG(string pathName, string appName = "SKG")
        {
            RemoveSVN(pathName);

            //EmptyFolder(pathName, "DBF");
            //EmptyFolder(pathName, "DOC");

            EmptyFile(pathName, ".manifest", false);
            EmptyFile(pathName, ".pdb", false);

            EmptyFile(pathName, appName + ".vshost.exe");
            EmptyFile(pathName, appName + ".vshost.exe.config");

            appName = "TST";
            EmptyFile(pathName, appName + ".vshost.exe");
            EmptyFile(pathName, appName + ".vshost.exe.config");
        }

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="fileName">path file name need to delete</param>
        /// <returns>is true then successfull else false</returns>
        public static bool DeleteFile(string fileName)
        {
            try
            {
                var f = new FileInfo(fileName) { IsReadOnly = false };
                f.Delete();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Delete file in folder
        /// </summary>
        /// <param name="pathName">path folder</param>
        /// <param name="fileName">file name</param>
        /// <returns>is true then successfull else false</returns>
        public static bool DeleteFile(string pathName, string fileName = null, bool isFile = true)
        {
            return DeleteFile(new DirectoryInfo(pathName), fileName, isFile);
        }

        /// <summary>
        /// Delete all files in folder & subfolder
        /// </summary>
        /// <param name="pathName">path name</param>
        /// <param name="fileName">file name or extension need to delete</param>
        /// <param name="isFile">true is file else extension</param>
        /// <returns>is true then successfull else false</returns>
        public static bool EmptyFile(string pathName, string fileName = null, bool isFile = true)
        {
            return EmptyFile(new DirectoryInfo(pathName), fileName, isFile);
        }
    }
}

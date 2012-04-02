using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using meshDatabase.Database;
using Microsoft.Win32;
using MpqLib.Mpq;

namespace meshDatabase
{

    public static class MpqManager
    {
        private static readonly List<string> Languages = new List<string>{"enUS", "enGB", "deDE"};
        private static readonly List<string> IgnoredMPQs = new List<string> {  };

        private static bool _initialized;
        private static bool _initializedDBC;
        private static readonly Dictionary<string, CArchive> _archives = new Dictionary<string, CArchive>();
        private static CArchive _locale;

        private static string GetWoWInstallPath()
        {
            var root = Registry.LocalMachine.OpenSubKey("SOFTWARE");
            if (root == null)
                return null;
            var be = root.OpenSubKey("Blizzard Entertainment");
            if (be == null)
                return null;
            var wow = root.OpenSubKey("World of Warcraft");
            if (wow == null)
                return null;
            wow.Close();
            return (string)wow.GetValue("InstallPath", null);
        }

        public static void Initialize(string path = null)
        {
            if (_initialized)
                return;
            _initialized = true;
            string root = path ?? GetWoWInstallPath();
            var files = Directory.GetFiles(root + "\\Data\\", "*.MPQ", SearchOption.TopDirectoryOnly).OrderByDescending(s => s);
            foreach (var file in files)
            {
                if (IgnoredMPQs.Contains(Path.GetFileName(file)))
                    continue;
                var archive = new CArchive(file);
                Console.WriteLine("Opened " + file + " with " + archive.FileCount + " files...");
                _archives.Add(Path.GetFileNameWithoutExtension(file), archive);
            }

            InitializeDBC(root);
        }

        public static void InitializeDBC(string path)
        {
            if (_initializedDBC)
                return;

            string root = path ?? GetWoWInstallPath();

            foreach (var language in Languages)
            {
                var dir = root + "\\Data\\" + language;
                if (!Directory.Exists(dir))
                    continue;

                var file = dir + "\\locale-" + language + ".mpq";
                if (!File.Exists(file))
                    continue;

                _locale = new CArchive(file);
                Console.WriteLine("Using locale: " + file);
                break;
            }

            _initializedDBC = true;
        }

        public static DBC GetDBC(string name)
        {
            string path = "DBFilesClient\\" + name + ".dbc";
            if (_locale == null || !_locale.FileExists(path))
                throw new FileNotFoundException("Unable to find DBC " + name);

            return new DBC(new CFileStream(_locale, path));
        }

        public static Stream GetFile(string path)
        {
            var archive = _archives.Values.FirstOrDefault(a => a.FileExists(path));
            if (archive == null)
                throw new FileNotFoundException("Unable to find " + path);
            var result = new CFileStream(archive, path);
            return result;
        }
    }

}
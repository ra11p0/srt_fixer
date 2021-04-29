using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srt_fixer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            OpenFileDialog open_item = new OpenFileDialog();
            bool done;
            string path;
            do
            {
                done = false;
                open_item.ShowDialog();
                path = open_item.FileName;
                done = fix_file(path);
                if (!done) if (MessageBox.Show("Process has not been completed!", "Fatal error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Cancel) Environment.Exit(0);
            } while (!done);
            MessageBox.Show("Process completed!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            Environment.Exit(0);
        }

        static bool fix_file(string path)
        {
            if (!System.IO.File.Exists(path))
                return false;
            string[] text_lines = System.IO.File.ReadAllLines(path);
            int counter = 0;
            foreach (string line in text_lines)
            {
                Console.Write("\n" + line + " -> ");
                text_lines[counter] = text_lines[counter].Replace("Ĺ›", "ś");
                text_lines[counter] = text_lines[counter].Replace("Ä™", "ę");
                text_lines[counter] = text_lines[counter].Replace("Ä…", "ą");
                text_lines[counter] = text_lines[counter].Replace("Ăł", "ó");
                text_lines[counter] = text_lines[counter].Replace("ĹĽ", "ż");
                text_lines[counter] = text_lines[counter].Replace("Ĺş", "ź");
                text_lines[counter] = text_lines[counter].Replace("Ä‡", "ć");
                text_lines[counter] = text_lines[counter].Replace("Ĺ„", "ń");
                text_lines[counter] = text_lines[counter].Replace("Ĺ‚", "ł");
                text_lines[counter] = text_lines[counter].Replace("Ĺš", "Ś");
                text_lines[counter] = text_lines[counter].Replace("Ĺ»", "Ż");
                counter++;
            }
            path = path.Replace(".", "_fixed.");
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(path))
            {
                foreach (string line in text_lines)
                {
                    writer.WriteLine(line);
                }
            }
            return true;
        }
    }
}

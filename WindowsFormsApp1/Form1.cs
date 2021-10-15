using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public int timess = 0;
        public string ec = "Error code: ";
        public bool rStatus;

        public string mPath = @"D:\Steam\steamapps\common\Kerbal Space Program\";
        void btnClickThis_Click(object sender, EventArgs e)
        {
            status1.Text = "Starting process...";
            string sourceDirName = mPath + "GameData";
            string destDirName = mPath + "Mods NOT IN USE";
            movee(sourceDirName, destDirName, "AA1");
            Directory.CreateDirectory(mPath + "GameData");
            sourceDirName = mPath + "Mods NOT IN USE/Squad";
            destDirName = mPath + "GameData/Squad";
            movee(sourceDirName, destDirName, "AA2");
            sourceDirName = mPath + "Mods NOT IN USE/SquadExpansion";
            destDirName = mPath + "GameData/SquadExpansion";
            movee(sourceDirName, destDirName, "AA3");
            if (rStatus == true)
            {
                status1.Text = "Mods successfully moved, game will launch fully stock!";
            }
            else
            {
                status1.Text = "Error detected when removing mods, if you accidently hit the button twice, that explains why.";
            }

        }
        void revertDS_Click(object sender, EventArgs e)
        {

            string sw;
            string dw; 
            sw = mPath + "GameData/SquadExpansion";
            dw = mPath + "Mods NOT IN USE/SquadExpansion";

            movee(sw, dw, "AB2");
            sw = mPath + "GameData/Squad";
            dw = mPath + "Mods NOT IN USE/Squad";
            movee(sw, dw, "AB1");
            try
            {
                Directory.Delete(@"D:\Steam\steamapps\common\Kerbal Space Program\GameData");
            }
            catch
            {
                errorLabel.Text = "ugh this again";
            } 
            string dsw = mPath + "Mods NOT IN USE";
            string ddw = mPath + "GameData";
            try
            {
                Directory.Move(dsw, ddw);
            }
            catch
            {
                
            }
            if (rStatus == true)
            {
                status1.Text = "Mods successfully moved back!";
            }
            else
            {
                status1.Text = "Error detected when moving mods back.";
            }

        }
        void movee(string sourceDirName, string destDirName, string errorCode)
        {
            try
            {
                Directory.Move(sourceDirName, destDirName);
                rStatus = true;
                errorLabel.Text = "";
            }
            catch (IOException exp)
            {
                //string moveError =  (exp.Message);
                Console.WriteLine("test");
                errorLabel.Text = ec + errorCode;
                rStatus = false;
            }
            timess++;
            string ttimes = timess.ToString();
            //status1.Text = ttimes;
        }
        public void yoyoyo(object sender, EventArgs e)
        { 
            try
            {
                string[] dirs = Directory.GetDirectories(@"c:\", "p*", SearchOption.TopDirectoryOnly);
                Console.WriteLine("The number of directories starting with p is {0}.", dirs.Length);
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }
            }
            catch 
            {

            }
        }

    }
        
    }


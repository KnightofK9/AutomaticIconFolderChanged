using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using Folder;
using Folder_icon_changed.Resources;
using System.Net;
using System.Diagnostics;
namespace Folder_icon_changed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LanguageSelect lang = new LanguageSelect();
        private string folderPath ="";
        private string iconPath = "";
        private List<string> folderToBeChanged = new List<string>();
        private List<string> icons = new List<string>();
        private List<string> iconsName = new List<string>();
        private List<IconDefinition> iconList = new List<IconDefinition>();
        public System.Diagnostics.Process p = new System.Diagnostics.Process();
        public MainWindow()
        {
            InitializeComponent();
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri("/Folder icon changed;component/Resources/en-US.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(dict);
        }
        private void SetLanguage(string language)
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (language)
            {
                    case "en-US":
                    dict.Source = new Uri("/Folder icon changed;component/Resources/en-US.xaml", UriKind.Relative);                 
                    break;
                    case "vn-VN":
                    dict.Source = new Uri("/Folder icon changed;component/Resources/vn-VN.xaml", UriKind.Relative);
                    break;
            }
            lang.ChangeLanguage(language);
            

        this.Resources.MergedDictionaries.Add(dict);
        
        }
        private bool IniExist(string path)
        {
           if( Directory.GetFiles(path, "desktop.ini").ToList().Count()!=0)
           {
               return true;
           }
           return false;

        }
        private List<string> FindInIconDef(List<IconDefinition> list, string substring)
        {
            List<string> result = new List<string>();
            int r = -1;
            foreach(IconDefinition i in list)
            {
                r = i.IconName.IndexOf(substring, StringComparison.OrdinalIgnoreCase);
                if(r!=-1)
                {
                    result.Add(i.IconPath);
                }
            }
            return result;
        }
        private void MixList(List<string> icons,List<string> iconsName,List<IconDefinition> iconList)
        {
            int i;
            for(i=0;i<icons.Count();i++)
            {
                iconList.Add(new IconDefinition()
                { 
                    IconName=iconsName[i],
                    IconPath=icons[i]
                });            
            }

        }
        private string SearchName(string folder, List<IconDefinition> iconDef)
        {
            //Return icon path which matches with search name, if no icon matched, return "No icon matched"
            int i=0;
            string searchingString;
            List<string> Result = new List<string>();
            Result.Add("No icon matched");
            searchingString="";
            if(folder.Count()<=3)
            {
                searchingString = folder;
                Result = FindInIconDef(iconDef, searchingString);
                if (Result.Count() > 0)
                {
                    return Result[0];
                }
                else return "No icon matched";
            }
            for (i = 0; i < 3;i++ )
            {
                searchingString += folder[i];
            }
            for(i=3;i<folder.Count();i++)
            {
                List<string> tempResult;
                searchingString+=folder[i];
                tempResult = FindInIconDef(iconDef, searchingString);
                if(tempResult.Count()==1)
                {
                    return tempResult[0];
                }
                if(tempResult.Count()==0)
                {
                    if(i>=0&&i<=(folder.Count()/2))
                    {
                        return "No icon matched";
                    }
                    if (Result.Count() != 0)
                    {
                        return Result[0];
                    }
                }
                Result = tempResult;
                
            }
            return Result[0];
            
        }
        private string ChangeFolderIcon(string folderPath, string iconPath)
        {
            string result = "";
           if(IniExist(folderPath)==true)
           {
               if (folderPath[folderPath.Count() - 1] != '\\')
                   File.Delete(folderPath + "\\desktop.ini");
               else File.Delete(folderPath + "desktop.ini");
           }
           if (IniExist(folderPath) == false)
           {
               FolderIconChanging.ChangeIcon(folderPath, iconPath);
               result += "Chaging icon\n";
           }
           return result;
         
        }
        private string SearchTask(List<string> folderToBeChanged, List<IconDefinition> iconList )
        {
            int length = folderToBeChanged.Count();
            int i, sCount, fCount;
            i = sCount=fCount = 0;
            string a,b, result;
            a =b= "";
            result= "";
            for(i=0;i<length;i++)
            {
                a = CutAndDelete(folderToBeChanged[i]).ToLower();

                if (ChangeIfHas.IsChecked == true && IniExist(folderToBeChanged[i]) == true)
                {
                    result+= folderToBeChanged[i]+ lang.changeIfNeed +".\n";
                    fCount++;
                    continue;
                }
                b = SearchName(a, iconList);
                if(b=="No icon matched")
                {
                    result += folderToBeChanged[i] + lang.iconNotFound;
                    fCount++;
                }
                else
                {
                    ChangeFolderIcon(folderToBeChanged[i],b);
                    result += folderToBeChanged[i] + lang.sucMat + b + "\n";
                    result+=ChangeFolderIcon(folderToBeChanged[i], b);
                    sCount++;
                }
            }
            result += sCount + lang.foldersComChan+ fCount + lang.foldersFaiChan;
            return result;
        }
        private string CutAndDelete(string a)
        {
            int i;
            string b = "";
            for (i = a.Count() - 1; a[i] != '\\'; i--) ;
            i++;
            for(;i<=a.Count()-1;i++)
            {
                if (a[i] != ' '&&a[i]!='_'&&a[i]!='-'&&a[i]!=','&&a[i]!='.')
                {
                    b += a[i];
                }
            }
            return b;


        }
        private void AddIconsName( List<string> iconsName, List<string> icons)
        {
            int i;
            for(i=0;i<icons.Count();i++)
            {
                iconsName.Add(CutAndDelete(icons[i]).ToLower());
            }
        }
       private void AddSubDirectories(List<string> folderToBeChanged, string root)
       {
          this.folderToBeChanged = Directory.GetDirectories(root).ToList();         
       }

       private void ShowResult(List<string> target,string title)
       {
            if(target.Count()==0)
            {
                
                Result.AppendText(lang.no+title+lang.foundPls+title+lang.folderAgain);
                return;
            }
           string result =lang.startSearching;
            foreach(string f in target)
            {
               result += f+"\n";
            }
            result += target.Count().ToString() + " " + title +lang.found+"\n";
            Result.AppendText(result);
            Result.ScrollToEnd();
       }
       private void ShowResult(string[] target, string title)
       {
           if (target.Count() == 0)
           {
               Result.AppendText(lang.no + title + lang.foundPls + title + lang.folderAgain);
               return;
           }
           string result = lang.startSearching;
           foreach (string f in target)
           {
               result += f + "\n";
           }
           result += target.Count().ToString() + " " + title + lang.found + "\n";
           Result.AppendText(result);
           Result.ScrollToEnd();
       }
        private void Folder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog animeFolderBrowse = new FolderBrowserDialog();
            if (animeFolderBrowse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Result.AppendText( "\\------------------------\n");
                folderPath = animeFolderBrowse.SelectedPath;
                AnimeFolderPath.Text = folderPath;
                AddSubDirectories(folderToBeChanged, folderPath);
                ShowResult(folderToBeChanged,lang.folder);
            }
        }

        private void Icon_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog iconFolderBrowse = new FolderBrowserDialog();
            if (iconFolderBrowse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Result.AppendText("\\------------------------\n");
                iconPath = iconFolderBrowse.SelectedPath ;
                IconFolderPath.Text = iconPath;
                icons = Directory.GetFiles(iconPath,"*.ico",SearchOption.AllDirectories).ToList();
                ShowResult(icons, "icons");
                //Convert icon paths into icon names
                if (icons.Count() != 0)
                {
                    AddIconsName(iconsName, icons);
                    Result.AppendText(lang.addIcon);
                    //Mix list icons and icons name into one 
                    MixList(icons, iconsName, iconList);
                    Result.AppendText(lang.mixIcon);
                }
            }
           
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Result.AppendText("\\------------------------\n"+SearchTask(folderToBeChanged, iconList));
            Result.ScrollToEnd();
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(lang.aboutContent, lang.about, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Result.AppendText("\\------------------------\nCurrent version 1.0.1.0");
            string info = "";
            GetUpdateInfo(ref info);
            Result.AppendText("\n"+ info);
            Result.ScrollToEnd();
            // print out page source

        }
        private void GetUpdateInfo(ref string info)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://onedrive.live.com/download?resid=766ED1F889A10B6B!42692&authkey=!AG0Ni1bOxReTC9k&ithint=file%2ctxt");
            // execute the request
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // we will read data via the response stream
            Stream resStream = response.GetResponseStream();
            string tempString = null;
            int count = 0;
            do
            {
                // fill the buffer with data
                count = resStream.Read(buf, 0, buf.Length);

                // make sure we read some data
                if (count != 0)
                {
                    // translate from bytes to ASCII text
                    tempString = Encoding.ASCII.GetString(buf, 0, count);

                    // continue building the string
                    sb.Append(tempString);
                }
            }
            while (count > 0); // any more data to read?
            info= sb.ToString();
        }
        private void HowToUse_Click(object sender, RoutedEventArgs e)
        {
            Result.AppendText("\\------------------------\n");
            Result.AppendText("Game icon download list(Please note that i do not own any of them, i did find them on the internet and get it on here for you):\n " + "--http://crussong.deviantart.com/art/The-All-In-One-Game-Icon-Pack-570-Icons-ICO-PNG-381703286 \n" + "--http://www.iconarchive.com/show/mega-games-pack-40-icons-by-3xhumed.html \n" + "\n");
            Result.AppendText("Anime icon download list(Please note that i do not own any of them, i did find them on the internet and get it on here for you):\n" + "--https://mega.co.nz/#!IB4TwCSJ!i9M0tBUzBeu3b1VNs0-nxr67ZSVXFkNQO5fEPIEIFBM (2k icon download) \n" + "--http://www.sakuraindex.jp/ \n" + "--http://foldericons.deviantart.com/gallery/36424558/Anime-Icon-Folder \n");
            Result.ScrollToEnd();
            System.Windows.MessageBox.Show(lang.howToUse, "How to use");


        }
        private void SetVN_Click(object sender, RoutedEventArgs e)
        {
            SetLanguage("vn-VN");
           if(EN_Menu.IsChecked==true)
           {
               EN_Menu.IsChecked = false;
           }
           VN_Menu.IsChecked = true;
        }
        private void SetEN_Click(object sender, RoutedEventArgs e)
       {
           SetLanguage("en-US");
            if(VN_Menu.IsChecked==true)
            {
                VN_Menu.IsChecked = false;
            }
            EN_Menu.IsChecked = true;
       }
        private void Hyperlink_MouseLeftButtonDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var hyperlink = (Hyperlink)sender;
            Process.Start(hyperlink.NavigateUri.ToString());
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            if(IniExist(folderPath)==true)
            {
                Result.AppendText(folderPath +" desktop.ini found\n");
                if (folderPath[folderPath.Count() - 1] != '\\')
                    File.Delete(folderPath + "\\desktop.ini");
                else File.Delete(folderPath + "desktop.ini");
                if(IniExist(folderPath)==true)
                {
                    Result.AppendText(folderPath + " desktop.ini failed deleting\n");
                }
                else
                {
                    Result.AppendText(folderPath + " desktop.ini deleted\n");
                    FolderIconChanging.ChangeIcon(folderPath, icons[1]);
                }
            }
            else
            {
                Result.AppendText(folderPath + " desktop.ini not found\n");
                FolderIconChanging.ChangeIcon(folderPath, icons[1]);
            }
        }
    }
    class IconDefinition 
    {
        private string _iconName="";
        private string _iconPath="";
        public string IconName
        {
            get{return _iconName;}
            set{_iconName=value;}
        }
        public string IconPath
        {
            get{return _iconPath;}
            set{_iconPath=value;} 
        }
        public override string ToString()
        { 
            string a ="Icon name: "+IconName+", icon path: "+IconPath+"\n";
            return a;
        }
    }

}

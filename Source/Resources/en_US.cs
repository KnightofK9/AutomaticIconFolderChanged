using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folder_icon_changed.Resources
{
    class LanguageSelect
    {
        public string iconNotFound = " icon not found\n";
        public string sucMat = " success matches with ";
        public string foldersComChan = " folders complete changed.\n";
        public string foldersFaiChan = " folder failed changing.\n";
        public string no = "No ";
        public string foundPls = " found, please select ";
        public string folderAgain = " folder again.\n";
        public string startSearching = "Start searching:\n";
        public string found = " found.\n";
        public string folder = "folders";
        public string addIcon = "Add icons name complete....\n";
        public string mixIcon = "Mix icons name complete....\n";
        public string iconName = "Icon name: ";
        public string iconPath = ", icon path: ";
        public string about = "About";
        public string changeIfNeed = " failed to change,folder has icon already";
        public string aboutContent = "Auto Folder Icon Changed version 1.0.0.0\nKnight of k9\nknightofk9@gmail.com\n2015 UIT HCM National University";
        public string howToUse = "Use this software when you need to change a lot of anime/game folder icon automatically.\n1.Click browse folder, browse to folder where you hold all your anime/game folder.\nNote: Anime/game folder name does not required case sensitive, however anime folder must be name in romanji letter, like Ore no imouto not English name like My litle sister can't be this cute, because almost all of anime icon\n download on the internet are romanji named.\n2.Click browse icon, browse to folder where you holl all your anime/game icon\n--You can download game icon from google, deviant art, here, for example : http://crussong.deviantart.com/art/The-All-In-One-Game-Icon-Pack-570-Icons-ICO-PNG-381703286 (The link now display in result box, go there and copy it to download) \n--Same way with anime, if you find that downloading anime icon pack by pack on the internet will take you a lot of time, i have find one with more over 2k icon here: \n--(The link now display in result box, go there and copy it to download)\n3.Click Change, and done. Please note that if the folder already has icon, the software will replace that icon with the one you browse ico file to.";
        public void ChangeLanguage(string language)
        {
            switch(language)
            {
                case "vn-VN":
                            sucMat = " phù hợp với ";
                            iconNotFound = " icon không tìm thấy\n";
                            foldersComChan = " thư mục hoàn thành thay đổi.\n";
                            foldersFaiChan = " thư mục thất bại khi thay đổi.\n";
                            no = "Không ";
                            foundPls = " tìm thấy, vui lòng chọn lại ";
                            folderAgain = " thư mục lần nữa.\n";
                            startSearching = "Bắt đầu tìm kiếm:\n";
                            found = " tìm thấy.\n";
                            folder = "thư mục";
                            addIcon = "Thêm icon hoàn thành....\n";
                            mixIcon = "Trộn icon hoàn thành....\n";
                            iconName = "Tên icon: ";
                            iconPath = ", đường dẫn icon: ";
                            about = "Về tác giả";
                            changeIfNeed = " thay đổi thất bại, folder đã được thay icon";
                            break;
                case "en-US":
                            iconNotFound = " icon not found\n";
                            sucMat = " success matches with ";
                            foldersComChan = " folders complete changed.\n";
                            foldersFaiChan = " folder failed changing.\n";
                            no = "No ";
                            foundPls = " found, please select ";
                            folderAgain = " folder again.\n";
                            startSearching = "Start searching:\n";
                            found = " found.\n";
                            folder = "folders";
                            addIcon = "Add icons name complete....\n";
                            mixIcon = "Mix icons name complete....\n";
                            iconName = "Icon name: ";
                            iconPath = ", icon path: ";
                            about = "About";
                            changeIfNeed = " failed to change,folder has icon already";
                            break;

            }
            
        }

    }
}

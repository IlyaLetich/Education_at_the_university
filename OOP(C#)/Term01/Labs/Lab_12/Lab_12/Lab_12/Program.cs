

namespace Lab_12
{
    internal class Programm
    {
        static void Main()
        {
            try
            {
                
                MRCLog mrcLog_01 = new MRCLog("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\mrclogfile.txt");
                MRCDiskInfo.OnUpdate += mrcLog_01.WriteActionInFile;
                MRCFileInfo.OnUpdate += mrcLog_01.WriteActionInFile;
                MRCDirInfo.OnUpdate += mrcLog_01.WriteActionInFile;

                //test DiskInfo
                MRCDiskInfo.ShowFreeSpace(@"D:\");
                MRCDiskInfo.ShowFileSystemInformation(@"D:\");
                MRCDiskInfo.ShowInformationAllDrivers();

                //test FileInfo
                MRCFileInfo.ShowFullPatch("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\mrclogfile.txt");
                MRCFileInfo.ShowFileInformation("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\mrclogfile.txt");
                MRCFileInfo.ShowFileDatesCreateAndUpdate("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\mrclogfile.txt");

                //test DirInfo
                MRCDirInfo.ShowAmountOfFile("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs");
                MRCDirInfo.ShowCreationTime("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12");
                MRCDirInfo.ShowAmountOfSubdirectories("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs");
                MRCDirInfo.ShowParentDirectory("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12");

                //test FileManger
                MRCFileManager.CreateDirectory("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\MRCInspect");
                MRCFileManager.CreateFile("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\MRCInspect\\mrcdirinfo.txt");

                MRCLog mrcLog_02 = new MRCLog("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\MRCInspect\\mrcdirinfo.txt");

                MRCFileManager.OnUpdate += mrcLog_02.WriteActionInFile;

                MRCFileManager.ShowListDirectoryAndFileDisk("D:\\");
                MRCFileManager.CopyFile("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\MRCInspect\\mrcdirinfo.txt");
                MRCFileManager.DeleteFile("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\MRCInspect\\mrcdirinfo.txt");
                MRCFileManager.CopyFileFromDirectory("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\MRCInspect", ".txt");

                MRCFileManager.MoveDirectory("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\MRCFiles\\", "C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\MRCInspect\\MRCFiles");

                MRCFileManager.CreateZipFromDirectory("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\MRCInspect\\MRCFiles");

                MRCFileManager.ShowDirectoryFromZip(@"C:\Users\Илья\Desktop\Пацей\ООП\Labs\Lab_12\MRCInspect\MRCFiles.zip", "C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_12\\UnArhive");
                
                Console.WriteLine("Enter day: ");
                int dayUser = int.Parse(Console.ReadLine());
                Console.WriteLine();
                MRCFileManager.FindInformationFromDay(dayUser);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
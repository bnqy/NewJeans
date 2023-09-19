using static System.Console;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;


//WorkWithDrives();
//WorkWithDirectories();
WorkWithFiles();
static void WorkWithDrives()
{
    WriteLine($"{"NAME", -30} | {"TYPE", -10} | {"FORMAT", -7} | {"SIZE (BYTES)", 18} | {"FREE SPACE", 18}");

    foreach (DriveInfo drive in DriveInfo.GetDrives())
    {
        if (drive.IsReady)
        {
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
                drive.Name,
                drive.DriveType,
                drive.DriveFormat,
                drive.TotalSize,
                drive.AvailableFreeSpace
                );
        }
        else
        {
            WriteLine($"{drive.Name,-30} | {drive.DriveType,-10}");
        }
    }
}


/*
 * 
 */

static void WorkWithDirectories()
{
    string newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "AAA", "BBB", "CCC", "DDD");

    WriteLine($"Working with {newFolder}");

    WriteLine($"Does it exist? {Exists(newFolder)}");

    WriteLine("Creating it...");
    CreateDirectory(newFolder);
    WriteLine($"Does it exist? {Exists(newFolder)}");

    Write("Confirm the directory exists, and then press ENTER: ");
    ReadLine();

    WriteLine("Deleting it...");
    Delete(newFolder);
    WriteLine($"Does it exist? {Exists(newFolder)}");
}


/*
 * 
 * 
 * 
 */

static void WorkWithFiles()
{
    string dir = Combine(GetFolderPath(SpecialFolder.Personal), "AAA", "NewFiles");
    CreateDirectory(dir);

    string txtFile = Combine(dir, "newfile1.txt");
    string backUpFile = Combine(dir, "newfile.bak");

    WriteLine($"Working with {txtFile}");

    WriteLine($"Does it exist? {File.Exists(txtFile)}");
    StreamWriter textWriter = File.CreateText(txtFile);
    textWriter.WriteLine("Hello, I will win! C# Just Watch!");
    textWriter.Close();

    File.Copy(sourceFileName: txtFile, 
        destFileName: backUpFile,
        overwrite: true
        );

    WriteLine($"Make sure file is created and press Enter to delete file");
    ReadLine();

    File.Delete(txtFile);

    StreamReader textReader = File.OpenText(backUpFile);
    WriteLine(textReader.ReadToEnd());
    textReader.Close();

    WriteLine($"Folder Name: {GetDirectoryName(txtFile)}");
    WriteLine($"File Name: {GetFileName(txtFile)}");
    WriteLine("File Name without Extension: {0}",
     GetFileNameWithoutExtension(txtFile));
    WriteLine($"File Extension: {GetExtension(txtFile)}");
    WriteLine($"Random File Name: {GetRandomFileName()}");
    WriteLine($"Temporary File Name: {GetTempFileName()}");


    FileInfo fileInfo = new(backUpFile);
    WriteLine($"{backUpFile}");
    WriteLine($"{fileInfo.Length} bytes");
    WriteLine($"Last access time: {fileInfo.LastAccessTime}");

}
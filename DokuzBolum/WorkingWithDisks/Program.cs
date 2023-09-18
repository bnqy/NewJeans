using static System.Console;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;


//WorkWithDrives();
WorkWithDirectories();
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


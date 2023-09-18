using static System.Console;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;

OutPutFileSystemInfo();
static void OutPutFileSystemInfo()
{
    WriteLine($"{"Path.PathSeparator", -33} {PathSeparator}");
    WriteLine($"{"Path.DirectorySeparatorChar", -33} {DirectorySeparatorChar}");
    WriteLine($"{"Directory.GetCurrentDirectory()", -33} {GetCurrentDirectory()}");
    WriteLine($"{"Environment.CurrentDirectory", -33} {CurrentDirectory}");
    WriteLine($"{"Environment.SystemDirectory", -33} {SystemDirectory}");
    WriteLine($"{"Path.GetTempPath()", -33} {GetTempPath()}");

    WriteLine("GetFolderPath(SpecialFolder");
    WriteLine("{0,-33} {1}", arg0: " .System)", arg1: GetFolderPath(SpecialFolder.System));
    WriteLine("{0,-33} {1}", arg0: " .ApplicationData)", arg1: GetFolderPath(SpecialFolder.ApplicationData));
    WriteLine("{0,-33} {1}", arg0: " .MyDocuments)", arg1: GetFolderPath(SpecialFolder.MyDocuments));
    WriteLine("{0,-33} {1}", arg0: " .Personal)", arg1: GetFolderPath(SpecialFolder.Personal));



}
Console.Clear();
Console.WriteLine("Godot New Version Updater");
Console.WriteLine("=========================");


// Define the directory and file names
string directory = @"C:\Program Files\Godot";
string currentFileName1 = "Godot_win64.exe";
string currentFileName2 = "Godot_win64_console.exe";
string newFilePattern1 = "Godot_v*_win64.exe";
string newFilePattern2 = "Godot_v*_win64_console.exe";
int fileChangeCount = 0;

try
{
    // Find the new version file
    var newVersionFile1 = Directory.GetFiles(directory, newFilePattern1)
        .Select(f => new FileInfo(f))
        .OrderByDescending(f => f.LastWriteTime)
        .FirstOrDefault();
    var newVersionFile2 = Directory.GetFiles(directory, newFilePattern2)
        .Select(f => new FileInfo(f))
        .OrderByDescending(f => f.LastWriteTime)
        .FirstOrDefault();

    // Rename the new version file to the old file name
    if (newVersionFile1 != null)
    {
        Console.WriteLine($"Replacing {currentFileName2} with {newVersionFile1.FullName}");

        // Delete the current file
        string currentFilePath1 = Path.Combine(directory, currentFileName1);
        if (File.Exists(currentFilePath1))
        {
            File.Delete(currentFilePath1);
        }

        File.Move(newVersionFile1.FullName, currentFilePath1);
        fileChangeCount++;
    }
    if (newVersionFile2 != null)
    {
        Console.WriteLine($"Replacing {currentFileName2} with {newVersionFile2.FullName}");

        // Delete the current file
        string currentFilePath2 = Path.Combine(directory, currentFileName2);
        if (File.Exists(currentFilePath2))
        {
            File.Delete(currentFilePath2);
        }

        File.Move(newVersionFile2.FullName, currentFilePath2);
        fileChangeCount++;
    }

}
catch (Exception ex)
{
    // Write the exception to the console
    Console.WriteLine("An error occurred: " + ex.Message);
}
finally
{
    // Wait for a key press before closing
    Console.WriteLine($"{fileChangeCount} files changed");
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}

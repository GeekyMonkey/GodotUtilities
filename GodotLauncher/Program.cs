using System.Diagnostics;

Console.Clear();
Console.WriteLine("Godot Launcher");
Console.WriteLine("==============");


string? file = Directory.GetFiles(".", "*.exe")
    .FirstOrDefault((f) =>
        f != null &&
        !f.Contains("console") &&
        !f.Contains("Launcher")
    , null);
if (file == null)
{
    Console.WriteLine("Godot exe not found in this folder.");
    Console.WriteLine("Run this program in the same folder where your Godot program is located.");
    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
}
else
{
    string options = "--rendering-driver opengl3";
    Console.WriteLine($"Running {file} {options}");
    Process.Start(file, options);
}
string sourceDirectory = "E:\\TBS\\unsorted\\"; // Location of unsorted files
string baseTargetDirectory = "E:\\TBS\\sorted\\"; // The location where you want sorted files

int count = 0;
int total = Directory.EnumerateFiles(sourceDirectory).Where(File => File.EndsWith(".JPG") || File.EndsWith(".CR3") || File.EndsWith(".MP4")).Count(); // Total count of files to be moved

foreach (string x in Directory.EnumerateFiles(sourceDirectory).Where(File => File.EndsWith(".JPG") || File.EndsWith(".CR3") || File.EndsWith(".MP4")))
{
    count++;

    int day = File.GetCreationTime(x).Day;
    int month = File.GetCreationTime(x).Month;
    int year = File.GetCreationTime(x).Year;

    Console.WriteLine(x);
    Console.WriteLine(day);
    Console.WriteLine(month);
    Console.WriteLine(year);

    string path = Path.Combine(baseTargetDirectory, year.ToString(), month.ToString(), day.ToString(), Path.GetFileName(x)); // Construct the path


    if (!Directory.Exists(Path.GetDirectoryName(path))) // If the path does not currently exist then create the directory
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
    }
    
    File.Move(x, path); // Move the file to the new location

    Console.WriteLine(count + " of " + total + " files sorted");

    Console.WriteLine("===============================================");
}
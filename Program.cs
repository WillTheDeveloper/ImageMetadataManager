string sourceDirectory = "E:\\TBS\\unsorted\\";
string baseTargetDirectory = "E:\\TBS\\sorted\\";

int count = 0;
int total = Directory.EnumerateFiles(sourceDirectory).Where(File => File.EndsWith(".JPG") || File.EndsWith(".CR3") || File.EndsWith(".MP4")).Count();

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

    string path = Path.Combine(baseTargetDirectory, year.ToString(), month.ToString(), day.ToString(), Path.GetFileName(x));


    if (!Directory.Exists(Path.GetDirectoryName(path)))
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
    }
    
    File.Move(x, path);

    Console.WriteLine(count + " of " + total + " files sorted");

    Console.WriteLine("===============================================");
}
string sourceDirectory = "D:\\AUTOMATION TESTING DIRECTORY\\ImageMetadata\\TBS";
string baseTargetDirectory = "D:\\AUTOMATION TESTING DIRECTORY\\ImageMetadata\\RAW";

int count = 0;

foreach (string x in Directory.EnumerateFiles(sourceDirectory).Where(File => File.EndsWith(".jpg|.cr3")))
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

    File.Move(x, path);

    Console.WriteLine(count + ": File moved to: " + path);

    Console.WriteLine("===============================================");
}
using DirectoryTraversal;

try
{
    foreach (var arg in args)
    {
        //Console.WriteLine($"\'{arg}\'");
    }
    var q = new UtilityParameters(args);

    Console.WriteLine(q.DirectoryPath);
    Console.WriteLine(q.OutputPath);
    Console.WriteLine(q.IsOnlyFileOutput);
    Console.WriteLine(q.HumanReadable);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
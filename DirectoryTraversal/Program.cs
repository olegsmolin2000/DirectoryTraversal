try
{
    var parameters = new UtilityParameters();

    parameters.ReadConsoleParameters(args);

    Console.WriteLine(parameters.DirectoryPath);
    Console.WriteLine(parameters.OutputPath);
    Console.WriteLine(parameters.IsOnlyFileOutput);
    Console.WriteLine(parameters.HumanReadable);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
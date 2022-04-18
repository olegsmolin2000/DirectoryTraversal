try
{
    var parameters = new UtilityParameters();
    parameters.ReadConsoleParameters(args);

    var traversor = new DirectoryTraverser(parameters);
    traversor.DoOutput();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
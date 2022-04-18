using System.Text;

try
{
    var parameters = new UtilityParameters();

    parameters.ReadConsoleParameters(args);

    //Console.WriteLine(parameters.DirectoryPath);
    //Console.WriteLine(parameters.OutputPath);
    //Console.WriteLine(parameters.IsOnlyFileOutput);
    //Console.WriteLine(parameters.HumanReadable);

    var traversor = new DirectoryTraverser(parameters);
    traversor.Traverse(parameters.DirectoryPath, traversor.Node);
    var sb = new StringBuilder();
    traversor.FillStringBuilder(traversor.Node, sb);
    Console.WriteLine(sb.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
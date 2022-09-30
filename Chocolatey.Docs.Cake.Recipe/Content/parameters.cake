public static class BuildParameters
{
    public static FilePath ProjectFilePath { get; private set; }
    public static DirectoryPath PublishDirectory { get; private set; }
    public static DirectoryPath OutputDirectory { get; private set; }
    public static BuildTasks Tasks { get; set; }
    public static Cake.Core.Configuration.ICakeConfiguration CakeConfiguration { get; private set; }
    public static string Target { get; private set; }

    static BuildParameters()
    {
        Tasks = new BuildTasks();
    }

    public static void PrintParameters(ICakeContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }

        context.Information("Printing Build Parameters...");
        context.Information("------------------------------------------------------------------------------------------");
        context.Information("ProjectFilePath: {0}", ProjectFilePath);
        context.Information("PublishDirectory: {0}", PublishDirectory);
        context.Information("OutputDirectory: {0}", OutputDirectory);
        context.Information("Target: {0}", Target);
        context.Information("------------------------------------------------------------------------------------------");
    }

    public static void SetParameters(
        ICakeContext context,
        FilePath projectFilePath,
        DirectoryPath publishDirectory = null,
        DirectoryPath outputDirectory = null)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }

        if (publishDirectory == null)
        {
            publishDirectory = context.MakeAbsolute(context.Directory("publish"));;
        }

        if (outputDirectory == null)
        {
            outputDirectory = context.MakeAbsolute(context.Directory("output"));;
        }

        ProjectFilePath = projectFilePath;
        PublishDirectory = publishDirectory;
        OutputDirectory = outputDirectory;
        CakeConfiguration = context.GetConfiguration();
        Target = context.Argument("target", "Default");
    }
}
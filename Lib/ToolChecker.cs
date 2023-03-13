namespace Elm_IDE.Lib;

using System.Diagnostics;

public static class ToolChecker
{
    readonly static string path = "Contents/Resources/Tools/";

	readonly static string elmVersion;
    readonly static string elmFormatVersion;
    readonly static string elmJsonVersion;
    readonly static string elmTestRSVersion;

    public static string ElmVersion { get => elmVersion; }

    public static string ElmFormatVersion { get => elmFormatVersion; }

    public static string ElmJsonVersion { get => elmJsonVersion; }

    public static string ElmTestRSVersion { get => elmTestRSVersion; }

    static ToolChecker()
	{
        Process process = new Process();
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;

        elmVersion = CheckForElmVersion(process);
        elmFormatVersion = CheckForElmFormatVersion(process);
        elmJsonVersion = CheckForElmJsonVersion(process);
        elmTestRSVersion = CheckForElmTestRSVersion(process);
    }

	private static string CheckForElmVersion(Process process)
	{
        return Read(process, "Elm");
    }

    private static string CheckForElmFormatVersion(Process process)
    {
        string output = Read(process, "elm-format", "");

        string version = output.Split(" ").ElementAt(1).Split("\n").ElementAt(0);

        return version;
    }

    private static string CheckForElmJsonVersion(Process process)
    {
        string output = Read(process, "elm-json");

        string version = output.Split(" ").ElementAt(1);

        return version;
    }

    private static string CheckForElmTestRSVersion(Process process)
    {
        string output = Read(process, "elm-test-rs");

        string version = output.Split(" ").ElementAt(1);

        return version;
    }

    private static string Read(Process process, string fileName, string arg = "--version")
    {
        process.StartInfo.FileName = path + fileName;
        process.StartInfo.Arguments = arg;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        return output;
    }
}


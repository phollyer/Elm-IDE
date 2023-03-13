namespace Elm_IDE;

using Elm_IDE.Lib;

public partial class AppShell : Shell
{
	public readonly string elmVersion;

	public AppShell()
	{
		InitializeComponent();

		elmVersion = ToolChecker.ElmVersion;
    }
}



using RetroC64;
using RetroC64.App;

public class HelloBasic : C64AppBasic
{
    public HelloBasic()
    {
        string basic = ToBASICString($"""
            TI$="000000"
            PRINT CHR$(147)
            PRINT TAB(10);"COMMODORE 64 CLOCK"
            T=TI
            PRINT TAB(10);"DATE: {DateTime.Now:dd.MM.yyyy}"
            PRINT TAB(10);"UPTIME: ";MID$(TI$,1,2);":";MID$(TI$,3,2);":";MID$(TI$,5,2)
            IF TI<T+30 THEN GOTO 70
            T=TI
            GOTO 20
            """);
        Console.WriteLine(basic);
        Text = basic;
    }

    private string ToBASICString(string input) =>
        string.Join(Environment.NewLine, input.Split(Environment.NewLine).Select((x, i) => ((i * 10) + 10) + " " + x));

    protected override void Initialize(C64AppInitializeContext context)
    {
        base.Initialize(context);
    }
}

public static class Program
{
    public static async Task Main(string[] args)
    {
        await C64AppBuilder.Run<HelloBasic>(args);
    }
}

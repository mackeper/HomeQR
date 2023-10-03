namespace HomeQR.Data.Targets;

public class UrlTarget : QrCodeTarget
{
    public required string Url { get; init; }
}

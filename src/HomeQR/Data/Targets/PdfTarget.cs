namespace HomeQR.Data.Targets;

public class PdfTarget : QrCodeTarget
{
    public required byte[] Pdf { get; init; }

    public required string FileName { get; init; }
}

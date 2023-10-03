namespace HomeQR.Data.Targets;

public abstract class QrCodeTarget
{
    public int Id { get; init; }

    public required string Name { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset UpdatedAt { get; init; }

    public required int QrCodeId { get; init; }

    public required QrCode QrCode { get; init; }

    public QrCodeTarget()
    {
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}

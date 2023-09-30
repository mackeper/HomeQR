namespace HomeQR.Data;

public class QrCodesService
{
    public Task<QrCode[]> GetQrCodes()
        => Task.FromResult(new[]
        {
            new QrCode(1, "Tvättmaskin", "https//realmoneycompany.com"),
            new QrCode(1, "Tvättmaskin", "https//realmoneycompany.com"),
            new QrCode(1, "Tvättmaskin", "https//realmoneycompany.com"),
            new QrCode(1, "Tvättmaskin", "https//realmoneycompany.com"),
            new QrCode(1, "Tvättmaskin", "https//realmoneycompany.com"),
            new QrCode(1, "Tvättmaskin", "https//realmoneycompany.com"),
        });
}

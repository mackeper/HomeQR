using HomeQR.Data.Targets;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using QRCoder;

namespace HomeQR.Data;

public class QrCode
{
    public int Id { get; init; }

    public required Guid Uuid { get; init; }

    public required string Name { get; init; }

    public required string Href { get; init; }

    public required IdentityUser IdentityUser { get; init; }

    public ICollection<QrCodeTarget> Targets { get; set; } = new List<QrCodeTarget>();

    public byte[] GetQrCode(NavigationManager navigationManager)
    {
        var uri = new Uri(navigationManager.BaseUri + "qrcodes/" + Uuid);
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(uri.ToString(), QRCodeGenerator.ECCLevel.Q);
        var qrCode = new PngByteQRCode(qrCodeData);
        return qrCode.GetGraphic(4, new byte[] { 0, 0, 0, 255 }, new byte[] { 255, 255, 255, 0 }, false);
    }
}

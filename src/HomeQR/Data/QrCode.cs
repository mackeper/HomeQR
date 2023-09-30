using QRCoder;

namespace HomeQR.Data;

public class QrCode
{
    public int Id { get; }
    public string Name { get; }

    public byte[] Code { get; }

    public string Href { get; }

    public QrCode(int id, string name, string href)
    {
        Id = id;
        Name = name;
        Code = GenerateQrCode(href);
        Href = href;
    }

    private static byte[] GenerateQrCode(string data)
    {
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new PngByteQRCode(qrCodeData);
        return qrCode.GetGraphic(4, new byte[] { 0, 0, 0, 255 }, new byte[] { 255, 255, 255, 0 }, false);
    }

}

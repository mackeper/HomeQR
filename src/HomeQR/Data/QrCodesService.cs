using HomeQR.Data.Targets;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HomeQR.Data;

public class QrCodesService
{
    private readonly ApplicationDbContext dbContext;
    private readonly AuthenticationStateProvider authenticationStateProvider;
    private readonly UserManager<IdentityUser> userManager;

    public QrCodesService(
        ApplicationDbContext dbContext,
        AuthenticationStateProvider authenticationStateProvider,
        UserManager<IdentityUser> userManager)
    {
        this.dbContext = dbContext;
        this.authenticationStateProvider = authenticationStateProvider;
        this.userManager = userManager;
    }

    private async Task<IdentityUser?> GetIdentityUser()
    {
        var authenticationState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authenticationState.User;
        return await userManager.GetUserAsync(user);
    }

    public async Task<IEnumerable<QrCode>> GetAll()
    {
        var identityUser = await GetIdentityUser();
        return await dbContext.QrCodes!.Where(qr => qr.IdentityUser == identityUser).ToListAsync();
    }

    public async Task<QrCode> Get(Guid uuid)
    {
        var identityUser = await GetIdentityUser();
        var qrCode = await dbContext.QrCodes!.SingleAsync(qrCode => qrCode.Uuid == uuid && qrCode.IdentityUser == identityUser);
        var targets = await dbContext.QrCodeTargets!.Where(qt => qt.QrCodeId == qrCode.Id).ToListAsync();
        qrCode.Targets = targets;
        return qrCode;
    }

    public async Task<QrCode?> Create(string name, string href)
    {
        var identityUser = await GetIdentityUser();

        if (identityUser is null)
            return null; // TODO return a result type (OneOf)

        var qrCode = new QrCode
        {
            Uuid = Guid.NewGuid(),
            Name = name,
            Href = href,
            IdentityUser = identityUser,
        };

        await dbContext.QrCodes!.AddAsync(qrCode);
        await dbContext.SaveChangesAsync();

        return qrCode;
    }

    public async Task Remove(QrCode qrCode)
    {
        dbContext.QrCodes!.Remove(qrCode);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddUrlTarget(QrCode qrCode, string name, string url)
    {
        var qrCodeTarget = new UrlTarget
        {
            Name = name,
            QrCode = qrCode,
            QrCodeId = qrCode.Id,
            Url = url,
        };

        qrCode.Targets.Add(qrCodeTarget);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddPdfTarget(QrCode qrCode, string name, string fileName, byte[] pdf)
    {
        var qrCodeTarget = new PdfTarget
        {
            Name = name,
            QrCode = qrCode,
            QrCodeId = qrCode.Id,
            Pdf = pdf,
            FileName = fileName,
        };

        qrCode.Targets.Add(qrCodeTarget);
        await dbContext.SaveChangesAsync();
    }
}

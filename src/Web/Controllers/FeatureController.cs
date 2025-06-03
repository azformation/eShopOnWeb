using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace Microsoft.eShopWeb.Web.Controllers;

public class FeatureController : Controller
{
    private readonly IFeatureManager _featureManager;

    public FeatureController(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.NewUI = await _featureManager.IsEnabledAsync("NewUI");
        ViewBag.MaintenanceMode = await _featureManager.IsEnabledAsync("MaintenanceMode");
        return View();
    }
}

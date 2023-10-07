using CMS_Assignment.Models;
using CMS_Assignment.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace CMS_Assignment.Controllers
{
    public class NewsletterController : SurfaceController
    {
        public NewsletterController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
        }


        [HttpPost]
        public IActionResult Index(NewsletterForm newsletterForm)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            using var mail = new MailService("no-reply@crito.com", "smtp.websupport.se", 465, "umbraco@vera.com", "Bytmig123!");

            //To sender
            mail.SendAsync(newsletterForm.Email, "Your newsletter request was received.", "Hi, your request was received and we will be in contact with you as soon as possible.").ConfigureAwait(false);

            //To us
            mail.NewsletterSendAsync("millernadragon@hotmail.com", $"{newsletterForm.Email} sent you a newsletter request.").ConfigureAwait(false);

            return LocalRedirect(newsletterForm.RedirectUrl ?? "/");
        }


    }
}

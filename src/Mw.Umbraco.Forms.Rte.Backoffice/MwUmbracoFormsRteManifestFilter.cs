﻿using Umbraco.Cms.Core.Manifest;
using System.Collections.Generic;

namespace Mw.Umbraco.Forms.Rte.Backoffice
{
    internal class MwUmbracoFormsRteManifestFilter : IManifestFilter
    {
        public void Filter(List<PackageManifest> manifests)
        {
            manifests.Add(new PackageManifest
            {
                PackageName = "Mw.Umbraco.Forms.Rte",
                Scripts = new[]
                {
                    "/App_Plugins/Mw.Umbraco.Forms.Rte/rte.controller.js"
                }
            });
        }
    }
}

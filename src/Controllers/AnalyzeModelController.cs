﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sqlbi.Bravo.Infrastructure;
using Sqlbi.Bravo.Infrastructure.Helpers;
using Sqlbi.Bravo.Models;
using Sqlbi.Bravo.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

namespace Sqlbi.Bravo.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class AnalyzeModelController : ControllerBase
    {
        private readonly IPBIDesktopService _pbidesktopService;
        private readonly IPBICloudService _pbicloudService;

        public AnalyzeModelController(IPBIDesktopService pbidesktopService, IPBICloudService pbicloudService)
        {
            _pbidesktopService = pbidesktopService;
            _pbicloudService = pbicloudService;
        }

        /// <summary>
        /// Returns a database model from the VPAX file stream
        /// </summary>
        /// <response code="200">Status200OK - Success</response>
        [HttpPost]
        [ActionName("GetModelFromVpax")]
        [Consumes(MediaTypeNames.Application.Octet)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TabularDatabase))]
        [ProducesDefaultResponseType]
        public IActionResult GetDatabaseFromVpax()
        {
            try
            {
                var database = VpaxToolsHelper.GetDatabaseFromVpax(stream: Request.Body);

                return Ok(database);
            }
            catch(BravoException ex)
            {
                return Problem(ex.ProblemDetail, ex.ProblemInstance, StatusCodes.Status400BadRequest);
            }
        }

        /// <summary>
        /// Returns a database model from a PBIDesktop instance
        /// </summary>
        /// <response code="200">Status200OK - Success</response>
        /// <response code="400">Status400BadRequest - See the "instance" and "detail" properties to identify the specific occurrence of the problem</response>
        [HttpPost]
        [ActionName("GetModelFromReport")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TabularDatabase))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult GetDatabaseFromPBIDesktopReport(PBIDesktopReport report)
        {
            try
            {
                var stream = _pbidesktopService.ExportVpax(report, includeTomModel: false, includeVpaModel: false, readStatisticsFromData: false, sampleRows: 0);
                var database = VpaxToolsHelper.GetDatabaseFromVpax(stream);

                return Ok(database);
            }
            catch (BravoException ex)
            {
                return Problem(ex.ProblemDetail, ex.ProblemInstance, StatusCodes.Status400BadRequest);
            }
        }

        /// <summary>
        /// Returns a database model from a PBICloud dataset
        /// </summary>
        /// <response code="200">Status200OK - Success</response>
        /// <response code="400">Status400BadRequest - See the "instance" and "detail" properties to identify the specific occurrence of the problem</response>
        /// <response code="401">Status401Unauthorized - Sign-in required</response>
        [HttpPost]
        [ActionName("GetModelFromDataset")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TabularDatabase))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetDatabaseFromPBICloudDataset(PBICloudDataset dataset)
        {
            if (await _pbicloudService.IsSignInRequiredAsync())
                return Unauthorized();

            try
            {
                var stream = _pbicloudService.ExportVpax(dataset, includeTomModel: false, includeVpaModel: false, readStatisticsFromData: false, sampleRows: 0);
                var database = VpaxToolsHelper.GetDatabaseFromVpax(stream);

                return Ok(database);
            }
            catch (BravoException ex)
            {
                return Problem(ex.ProblemDetail, ex.ProblemInstance, StatusCodes.Status400BadRequest);
            }
        }

        /// <summary>
        /// Returns a list of all PBICloud datasets
        /// </summary>
        /// <response code="200">Status200OK - Success</response>
        /// <response code="401">Status401Unauthorized - Sign-in required</response>
        [HttpGet]
        [ActionName("ListDatasets")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PBICloudDataset>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetPBICloudDatasets()
        {
            if (await _pbicloudService.IsSignInRequiredAsync())
                return Unauthorized();

            var datasets = await _pbicloudService.GetDatasetsAsync();
            return Ok(datasets);
        }

        /// <summary>
        /// Returns a list of all open PBIDesktop reports
        /// </summary>
        /// <response code="200">Status200OK - Success</response>
        [HttpGet]
        [ActionName("ListReports")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PBIDesktopReport>))]
        [ProducesDefaultResponseType]
        public IActionResult GetPBIDesktopReports(CancellationToken cancellationToken)
        {
            var reports = _pbidesktopService.GetReports(cancellationToken);
            return Ok(reports);
        }

        /// <summary>
        /// Returns a VPAX file stream from an active PBIDesktop report
        /// </summary>
        /// <response code="200">Status200OK - Success</response>
        /// <response code="400">Status400BadRequest - See the "instance" and "detail" properties to identify the specific occurrence of the problem</response>
        [HttpPost]
        [ActionName("ExportVpaxFromReport")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExportResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult ExportVpaxFromPBIDesktopReport(PBIDesktopReport report, CancellationToken cancellationToken)
        {
            var dialogResult = WindowDialogHelper.SaveFileDialog(fileName: report.ReportName, defaultExt: "VPAX", cancellationToken);
            if (dialogResult.Canceled == false)
            {
                Stream stream;
                try
                {
                    stream = _pbidesktopService.ExportVpax(report, includeTomModel: false, includeVpaModel: false, readStatisticsFromData: false, sampleRows: 0);
                }
                catch (TOMDatabaseException ex)
                {
                    return Problem(ex.ProblemDetail, ex.ProblemInstance, StatusCodes.Status400BadRequest);
                }

                if (cancellationToken.IsCancellationRequested == false)
                {
                    using var fileStream = System.IO.File.Create(dialogResult.Path!);
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }
            }

            return Ok(dialogResult);
        }

        /// <summary>
        /// Returns a VPAX file stream from a PBICloud dataset
        /// </summary>
        /// <response code="200">Status200OK - Success</response>
        /// <response code="400">Status400BadRequest - See the "instance" and "detail" properties to identify the specific occurrence of the problem</response>
        /// <response code="401">Status401Unauthorized - Sign-in required</response>
        [HttpPost]
        [ActionName("ExportVpaxFromDataset")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExportResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> ExportVpaxFromPBICloudDataset(PBICloudDataset dataset, CancellationToken cancellationToken)
        {
            if (await _pbicloudService.IsSignInRequiredAsync())
                return Unauthorized();

            var dialogResult = WindowDialogHelper.SaveFileDialog(fileName: dataset.DisplayName, defaultExt: "VPAX", cancellationToken);
            if (dialogResult.Canceled == false)
            {
                Stream stream;
                try
                {
                    stream = _pbicloudService.ExportVpax(dataset, includeTomModel: false, includeVpaModel: false, readStatisticsFromData: false, sampleRows: 0);
                }
                catch (TOMDatabaseException ex)
                {
                    return Problem(ex.ProblemDetail, ex.ProblemInstance, StatusCodes.Status400BadRequest);
                }

                if (cancellationToken.IsCancellationRequested == false)
                {
                    using var fileStream = System.IO.File.Create(dialogResult.Path!);
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }
            }

            return Ok(dialogResult);
        }
    }
}

/*!
 * Bravo for Power BI
 * Copyright (c) SQLBI corp. - All rights reserved.
 * https://www.sqlbi.com
*/

import * as sanitizeHtml from 'sanitize-html';

// All the strings used in the app
export const strings: any = {
    appUrl: "https://bravo.bi",
    appGithubUrl: "https://github.com/sql-bi/bravo",
    daxFormatterUrl: "https://www.daxformatter.com",
    appName: "Bravo for Power BI",
    menuCtrlTitle: "Collapse/Expand menu",
    addCtrlTitle: "Open",
    DaxFormatter: "Format DAX",
    AnalyzeModel: "Analyze Model",
    ManageDates: "Manage Dates",
    ExportData: "Export Data",
    BestPractices: "Best Practices",
    settingsCtrlTitle: "Settings",
    helpCtrlTitle: "Help",
    themeCtrlTitle: "Change Theme",
    signInCtrlTitle: "Sign In",
    signedInCtrlTitle: (name: string) => `Signed in as ${sanitizeHtml(name)}`,
    filterUnrefCtrlTitle: "Show Unreferenced Columns only",
    groupByTableCtrlTitle: "Group by Table",
    expandAllCtrlTitle: "Expand all",
    collapseAllCtrlTitle: "Collapse all",
    saveVpaxCtrlTile: "Save as VPAX",
    syncCtrlTitle: "Synchronize",
    goBackCtrlTitle: "Cancel and go back",

    defaultTabName: "Untitled",
    welcomeTitle: "Welcome to Bravo for Power BI",
    welcomeText: "Bravo is a powerful toolkit for your Power BI datasets that you can use to quick manage models, create date tables, export data, and more. Start by opening a dataset:",
    welcomeHelpTitle: "How to use Bravo?",
    welcomeHelpText: "Watch the videos below to learn how to use Bravo:",
    helpConnectVideo: "Connect Bravo to your Data",
    openSourcePayoff: `Bravo for Power BI is an open-source tool developed and mantained by SQLBI and the Github community. Join us at <a href="https://github.com/sql-bi/bravo" target="_blank" class="ext-link">github.com/sql-bi/bravo</a>`,
    quickActionAttachPBITitle: "Attach to Power BI Desktop",
    quickActionConnectPBITitle: "Connect to Power BI Service",
    quickActionOpenVPXTitle: "Open a Vertipaq Analyzer file",
    connectDialogTitle: "Open",
    connectDialogConnectPBIMenu: "Active Reports on Power BI Desktop",
    connectDialogAttachPBIMenu: "Datasets on powerbi.com",
    connectDialogOpenVPXMenu: "VPAX Files",
    connectDragFile: "Drag a VPAX file here or",
    connectBrowse: "Browse",
    connectNoReports: "No active reports found.<br>Open a report with Power BI Desktop and wait for it to appear here.",
    connectDatasetsTableNameCol: "Name",
    connectDatasetsTableEndorsementCol: "Endorsement",
    connectDatasetsTableOwnerCol: "Owner",
    connectDatasetsTableWorkspaceCol: "Workspace",
    dialogOK: "OK",
    dialogCancel: "Cancel",
    dialogOpen: "Open",
    confirmTabCloseMessage: "It seems you didn't save the changes to this document.<br>Are you sure to close it?",
    
  
    analyzeModelSummary: (size: number | string, columnsCount: number | string, unreferecedCount: number | string) => `Your dataset is <strong>${size}</strong> large and contains <strong>${columnsCount}</strong> columns, <span class="text-highlight"><strong>${unreferecedCount}</strong> of which ${unreferecedCount == 1 ? "is" : "are"} not referenced.</span>`,
    analyzeModelTableColColumn: "Column",
    analyzeModelTableColTable: "Table",
    analyzeModelTableColEntity: "Table \\ Column",
    analyzeModelTableColSize: "Size",
    analyzeModelTableColWeight: "Weight",
    analyzeModelTableColCardinality: "Cardinality",
    analyzeModelTableColCardinalityTooltip: "Number of unique elements",
    analyzeModelTableColRows: "Rows",
    otherColumnsRowName: "Smaller columns...",
    aggregatedTableName: "Multiple tables",
    savingVpax: "Generating VPAX...",
    columnWarningExplanation: `Unreferenced columns can generally be removed from the model to optimize performance. Before removing them, make sure you are not using these columns in any reports, which Bravo cannot determine.`,
    columnWarningTooltip: "This column is not referenced in your model.",
    daxFormatterSummary: (count: number) => `Your report contains <strong>${count} measures</strong> that can be formatted.`,
    daxFormatterTableColMeasure: "Measure",
    daxFormatterTableColTable: "Table",
    daxFormatterTableSelected: (count: number) => `${count} Selected`,
    daxFormatterOriginalCode: "Current",
    daxFormatterFormattedCode: "Formatted (Preview)",
    daxFormatterFormat: "Format Selected",
    daxFormatterAgreement: `To format DAX, Bravo sends your measures to the DAX Formatter service.`,
    daxFormatterPreviewDesc: "To generate a preview, Bravo needs to send this measure to the DAX Formatter service.",
    daxFormatterPreviewAllOption: "Preview all measures",
    daxFormatterPreviewButton: "Preview",
    daxFormatterPreviewAllButton: "Preview All",
    dataUsageLink: "How your data is used?", 
    dataUsageTitle: "How your data is used?",
    dataUsageMessage: `
        To format your code, Bravo sends the measures of this dataset to DAX Formatter, a service managed by SQLBI, over a secure connection.</>

        <p><strong>The service does not store your data anywhere.</strong></p>
        <p>Some information such as the most used DAX functions, a complexity index, and average query length can be saved for statistical purposes.</p>
        <p><a href="https://www.daxformatter.com" target="_blank">www.daxformatter.com</a></p>
        `,
    signIn: "Sign In",
    signOut: "Sign Out",
    searchPlaceholder: "Search",
    searchColumnPlaceholder: "Search Column",
    previewPlaceholder: "Select a measure to see the preview...",
    errorTitle: "Whoops...",
    errorGeneric: "Error",
    errorUnspecified: "Unspecified error.",
    errorRequestTimeout: "Request timeout.",
    errorNotConnected: "You're not connected to Power BI - please sign in to proceed.",
    errorDatasetsListing: "Unable to retrieve the list of datasets of Power BI Service.",
    errorReportsListing: "Unable to attach to Power BI Desktop.<br>Try to reset the application.",
    errorVPAXAlreadyOpened: (fileName: string) => `There is already an open VPX file called <strong>${
        sanitizeHtml(fileName, { allowedTags: [], allowedAttributes: {}})
    }</strong>.<br>Please close it before trying again.`,
    errorRetry: "Retry"
};

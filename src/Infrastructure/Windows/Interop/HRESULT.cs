﻿namespace Sqlbi.Bravo.Infrastructure.Windows.Interop
{
    /// <summary>
    /// https://github.com/dahall/Vanara/blob/3e1596ba7f60f6478e9efd0d5c1b30d102df9439/PInvoke/Shared/WinError/HRESULT.Values.cs
    /// </summary>
    internal class HRESULT
    {
        public const int S_OK = 0;
        //S_FALSE = 1,
        //DRAGDROP_S_DROP = 262400,
        //DRAGDROP_S_CANCEL = 262401,
        //DRAGDROP_S_USEDEFAULTCURSORS = 262402,
        //DISP_E_MEMBERNOTFOUND = -2147352573,
        //DISP_E_PARAMNOTFOUND = -2147352572,
        //DISP_E_UNKNOWNNAME = -2147352570,
        //DISP_E_EXCEPTION = -2147352567,
        //DISP_E_UNKNOWNLCID = -2147352564,
        //DISP_E_DIVBYZERO = -2147352558,
        //TYPE_E_BADMODULEKIND = -2147317571,
        //E_NOTIMPL = -2147467263,
        //E_NOINTERFACE = -2147467262,
        //E_POINTER = -2147467261,
        //E_ABORT = -2147467260,
        //E_FAIL = -2147467259,
        //OLE_E_ADVISENOTSUPPORTED = -2147221501,
        //OLE_E_NOCONNECTION = -2147221500,
        //OLE_E_PROMPTSAVECANCELLED = -2147221492,
        //OLE_E_INVALIDRECT = -2147221491,
        //DV_E_FORMATETC = -2147221404,
        //DV_E_TYMED = -2147221399,
        //DV_E_DVASPECT = -2147221397,
        //DRAGDROP_E_NOTREGISTERED = -2147221248,
        //DRAGDROP_E_ALREADYREGISTERED = -2147221247,
        //VIEW_E_DRAW = -2147221184,
        //INPLACE_E_NOTOOLSPACE = -2147221087,
        //STG_E_INVALIDFUNCTION = -2147287039,
        //STG_E_FILENOTFOUND = -2147287038,
        //STG_E_ACCESSDENIED = -2147287035,
        //STG_E_INVALIDPARAMETER = -2147286953,
        //STG_E_INVALIDFLAG = -2147286785,
        //E_OUTOFMEMORY = -2147024882,
        //E_ACCESSDENIED = -2147024891,
        //E_INVALIDARG = -2147024809,
        //E_ENDOFSTREAM = -2147024858,
        //E_FILELOAD = -2146232799,
        public const int E_FILENOTFOUND = -2147024894;
        public const int E_INVALID_DATA = -2147024883;
        //E_DIRECTORYNOTFOUND = -2147024893,
        //E_PATHTOOLONG = -2147024690,
        //E_IO = -2146232800,
        //RPC_E_CHANGED_MODE = -2147417850
    }
}

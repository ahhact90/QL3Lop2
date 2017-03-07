#region "Author"
/****************************************************************************************
 * Solution     : CUSC His Framework
 * Project code : APP1105
 * Author       : Dương Nguyễn Phú Cường
 * Company      : Cusc Software
 * Version      : 1.0.0.1
 * Created date : 29/03/2013
 ***************************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using CuscLibrary.DataTypes.Extensions;
using CuscLibrary.Text;
using CuscLibrary.Win.WinForm.DevEx.Utilities;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
//using UTL;
//using System.Collections.Generic;

namespace UTL
{
    public class ExcelManager : IDisposable
    {
        /* -------------------------------- Enums ------------------------------------ */
        #region "Enums"
        public enum RangeType
        {
            OneCell,
            OneRowMultiColumn,
            MultiRowOneColumn,
            MultiRowMultiColumn
        }

        public enum FileType
        {
            Xls2003,
            Xlsx2007
        }

        public enum EncodeType
        {
            Unicode,
            VNI,
            TCVN3,
        }

        public enum BorderOptions
        {
            Diagonal = Excel.XlBordersIndex.xlDiagonalDown,
            DiagonalUp = Excel.XlBordersIndex.xlDiagonalUp,
            EdgeBottom = Excel.XlBordersIndex.xlEdgeBottom,
            EdgeLeft = Excel.XlBordersIndex.xlEdgeLeft,
            EdgeRight = Excel.XlBordersIndex.xlEdgeRight,
            EdgeTop = Excel.XlBordersIndex.xlEdgeTop,
            InsideHorizontal = Excel.XlBordersIndex.xlInsideHorizontal,
            InsideVerticale = Excel.XlBordersIndex.xlInsideVertical
        }

        public enum BorderType
        {
            BorderOutside = 2,
            AllBorder = 1,
            None = 0
        }

        /// <summary>
        /// Line style options
        /// </summary>
        public enum BorderLineStyle
        {
            Continuous = Excel.XlLineStyle.xlContinuous,
            Dash = Excel.XlLineStyle.xlDash,
            DashDot = Excel.XlLineStyle.xlDashDot,
            DashDotDot = Excel.XlLineStyle.xlDashDotDot,
            Dot = Excel.XlLineStyle.xlDot,
            Double = Excel.XlLineStyle.xlDouble,
            SlantDashDot = Excel.XlLineStyle.xlSlantDashDot,
            None = Excel.XlLineStyle.xlLineStyleNone
        }

        //public enum VerticalAlign
        //{
        //    AlignBottom = Excel.XlVAlign.xlVAlignBottom,
        //    AlignCenter = Excel.XlVAlign.xlVAlignCenter,
        //    AlignDistributed = Excel.XlVAlign.xlVAlignDistributed,
        //    AlginJustify = Excel.XlVAlign.xlVAlignJustify,
        //    AlignTop = Excel.XlVAlign.xlVAlignTop,
        //    None = 0
        //}

        //public enum HorizontalAlign
        //{
        //    a = Excel.XlHAlign.xlHAlignCenter,
        //    b = Excel.XlHAlign.xlHAlignCenterAcrossSelection,
        //    c = Excel.XlHAlign.xlHAlignDistributed,
        //    d = Excel.XlHAlign.xlHAlignFill,
        //    e = Excel.XlHAlign.xlHAlignGeneral,
        //    f = Excel.XlHAlign.xlHAlignJustify,
        //}
        #endregion
        /* --------------------------------------------------------------------------- */

        /* --------------------------------- Events ---------------------------------- */
        #region "Events"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* ------------------------------- Variables --------------------------------- */
        #region "Variables"
        public const int MAX_ROW_XL2003 = 65536;
        public const int MAX_COLUMN_XL2003 = 256;
        private Excel.Application _excelApp;
        private Excel.Workbooks _excelWorkbooks;
        private Excel.Workbook _excelWorkbook;
        private Excel.Window _excelWindow;
        private Excel.Sheets _excelWorksheets;
        private Excel.Worksheet _excelWorksheet;
        private Excel.Range _excelRange;
        private object _missing = Missing.Value;
        private EncodeType _encode = EncodeType.Unicode;
        private Dictionary<GridBand, Size> _lstBandSize = new Dictionary<GridBand, Size>();
        #endregion
        /* --------------------------------------------------------------------------- */

        /* ------------------------------ Properties --------------------------------- */
        #region "Properties"

        #region "Excel Application Property"
        /// <summary>
        /// Show/Hide excel program.
        /// </summary>
        public bool ShowExcelProgram
        {
            get
            {
                return _excelApp.Visible;
            }
            set
            {
                _excelApp.Visible = value;
            }
        }

        public EncodeType Encode
        {
            get
            {
                return _encode;
            }
        }

        /// <summary>
        /// Get/Set font chữ mặc định.
        /// </summary>
        public string StandardFont
        {
            get
            {
                return _excelApp.StandardFont;
            }
            set
            {
                _excelApp.StandardFont = value;
            }
        }

        /// <summary>
        /// Get/Set kích cỡ font chữ mặc định.
        /// </summary>
        public double StandardFontSize
        {
            get
            {
                return _excelApp.StandardFontSize;
            }
            set
            {
                _excelApp.StandardFontSize = value;
            }
        }

        /// <summary>
        /// Get/Set display alerts.
        /// </summary>
        public bool DisplayAlerts
        {
            get
            {
                return _excelApp.DisplayAlerts;
            }
            set
            {
                _excelApp.DisplayAlerts = value;
            }
        }

        /// <summary>
        /// Get/Set screen updating.
        /// </summary>
        public bool ScreenUpdating
        {
            get
            {
                return _excelApp.ScreenUpdating;
            }
            set
            {
                _excelApp.ScreenUpdating = value;
            }
        }

        /// <summary>
        /// Get/Set định dạng mặc định khi save.
        /// </summary>
        public Excel.XlFileFormat DefaultSaveFormat
        {
            get
            {
                return _excelApp.DefaultSaveFormat;
            }
            set
            {
                _excelApp.DefaultSaveFormat = value;
            }
        }

        public Excel.XlCalculation CalculationType
        {
            get
            {
                return _excelApp.Calculation;
            }
            set
            {
                _excelApp.Calculation = value;
            }
        }
        #endregion

        #region "Excel Worksheet Property"
        /// <summary>
        /// Get Active worksheet
        /// </summary>
        public Excel.Worksheet ActiveWorksheet
        {
            get
            {
                return _excelWorkbook.ActiveSheet as Excel.Worksheet;
            }
        }

        /// <summary>
        /// Get the current number of worksheets
        /// </summary>
        public int WorksheetCount
        {
            get { return _excelWorkbook.Worksheets.Count; }
        }

        /// <summary>
        /// Return a list of worksheet names
        /// </summary>
        public List<string> WorksheetNames
        {
            get
            {
                Excel.Worksheet worksheetName;
                List<string> names = new List<string>();
                for (int i = 0; i < _excelWorkbook.Sheets.Count; i++)
                {
                    worksheetName = (Excel.Worksheet)_excelWorksheets.get_Item(i + 1);
                    names.Add(worksheetName.Name);
                }
                return names;
            }
        }

        /// <summary>
        /// Returns whether a worksheet has any values or not. Cells with white space are considered to be empty
        /// </summary>
        public bool WorksheetBlank
        {
            get
            {
                Excel.Range rangeBlank = _excelWorksheet.UsedRange;
                if (rangeBlank.Count == 1 && rangeBlank.Value2 == null)
                    return true;
                else
                    return false;
            }
        }
        #endregion

        #region "Excel Window Property"
        /// <summary>
        /// Get/Set display gridlines
        /// </summary>
        public bool DisplayGridLines
        {
            get
            {
                return _excelWindow.DisplayGridlines;
            }
            set
            {
                _excelWindow.DisplayGridlines = value;
            }
        }
        #endregion

        #region "Excel Range Property"
        public Excel.Range WorkingRange
        {
            get
            {
                return _excelRange;
            }
        }

        /// <summary>
        /// Get the address of current range you are working with
        /// </summary>
        public string GetRangeAddress
        {
            get
            {
                if (_excelRange == null)
                    return "null";
                else
                    return _excelRange.get_AddressLocal(_excelRange.Rows.Count, _excelRange.Columns.Count,
                        Excel.XlReferenceStyle.xlA1, null, _excelWorksheet.UsedRange).Replace("$", "");
            }
        }
        #endregion

        #endregion
        /* --------------------------------------------------------------------------- */

        /* -------------------------------- Methods ---------------------------------- */
        #region "Methods"
        /// <summary>
        /// Default constructor
        /// </summary>
        public ExcelManager(bool visible = false)
        {
            try
            {
                _excelApp = new Excel.Application();
                _excelWorkbooks = _excelApp.Workbooks;
                _excelWorkbook = _excelWorkbooks.Add();
                _excelWorksheet = (Excel.Worksheet)_excelWorkbook.ActiveSheet;
                _excelWorksheets = _excelWorkbook.Worksheets;
                //_excelWindow = _excelWorkbook.Windows[1];
                _excelApp.Visible = visible;
                this.SetEncode(this.Encode);

                //_excelApp.Calculation = Excel.XlCalculation.xlCalculationManual;
            }
            catch (Exception ex)
            {
                CleanUp();
                throw new Exception("Can't start Excel Application.");
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ExcelManager(string path, bool visible = false)
        {
            //if (!path.EndsWith("xls") && !path.EndsWith("xlsx") && !path.EndsWith("xlt"))
            //{
            //    throw new Exception("Invalid file format");
            //}
            //if (!File.Exists(path))
            //{
            //    throw new Exception("File does not exist");
            //}

            try
            {
                _excelApp = new Microsoft.Office.Interop.Excel.Application();
                _excelWorkbook = _excelApp.Workbooks.Add(path);
                _excelWorksheet = (Excel.Worksheet)_excelWorkbook.ActiveSheet;
                _excelWorksheets = _excelWorkbook.Worksheets;
                _excelApp.Visible = visible;
                this.SetEncode(this.Encode);

                //_excelApp.Calculation = Excel.XlCalculation.xlCalculationManual;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                CleanUp();
                throw new Exception("Can't not open file");
            }
        }

        public void SetEncode(EncodeType encode)
        {
            _encode = encode;
            //switch (encode)
            //{
            //    case EncodeType.Unicode:
            //        _excelApp.StandardFont = "Times new roman";
            //        break;
            //    case EncodeType.VNI:
            //        _excelApp.StandardFont = "VNI-Times";
            //        break;
            //    case EncodeType.TCVN3:
            //        _excelApp.StandardFont = ".VnTime";
            //        break;
            //    default:
            //        break;
            //}
        }

        /// <summary>
        /// Release system resources
        /// </summary>        
        public void CleanUp()
        {
            try
            {
                if (_excelWorkbook != null)
                {
                    _excelWorkbook.Close(false, null, null);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(_excelWorkbook);
                    _excelApp.Workbooks.Close();
                }
                if (_excelApp != null)
                {
                    _excelApp.Quit();
                    _excelApp.Workbooks.Close();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(_excelApp);
                }

                _excelApp = null;
                _excelWorksheets = null;
                _excelWorksheet = null;
                _excelWorkbook = null;
            }
            catch (Exception)
            {

            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Create a new excel document
        /// </summary>
        public bool Create(bool visible)
        {
            try
            {
                _excelApp = new Microsoft.Office.Interop.Excel.Application();
                _excelWorksheet = new Microsoft.Office.Interop.Excel.Worksheet();
                _excelWorkbook = (Excel.Workbook)(_excelApp.Workbooks.Add(_missing));
                _excelWorksheet = (Excel.Worksheet)_excelWorkbook.ActiveSheet;
                _excelWorksheets = _excelWorkbook.Worksheets;
                _excelApp.Visible = visible;
            }
            catch (Exception E)
            {
                CleanUp();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Open an exisiting excel Document
        /// </summary>
        public bool Open(string path, bool visible)
        {
            if (!path.EndsWith("xls") && !path.EndsWith("xlsx") && !path.EndsWith("xlt"))
            {
                Console.WriteLine("Invalid file format");
                return false;
            }
            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist");
                return false;
            }

            try
            {
                _excelApp = new Microsoft.Office.Interop.Excel.Application();
                _excelWorksheet = new Microsoft.Office.Interop.Excel.Worksheet();
                _excelWorkbook = _excelApp.Workbooks.Open(path, _missing, _missing, _missing, _missing, _missing, _missing, _missing, _missing, _missing, _missing, _missing, _missing, _missing, _missing);
                _excelWorksheet = (Excel.Worksheet)_excelWorkbook.ActiveSheet;
                _excelWorksheets = _excelWorkbook.Worksheets;
                _excelApp.Visible = visible;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                CleanUp();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Close Excel without saving changes
        /// </summary>
        public void Close()
        {
            CleanUp();
        }



        /// <summary>
        /// Saves the current excel document
        /// </summary>
        public void Save()
        {
            _excelWorkbook.Save();
        }

        /// <summary>
        /// Add a new worksheet
        /// </summary>
        /// <param name="name"></param>
        public void AddWorksheet(string name)
        {
            // Excel COM is disconnected

            _excelWorkbook.Worksheets.Add(_missing, _missing, _missing, _missing);
            Excel.Worksheet worksheetName = (Excel.Worksheet)_excelWorksheets.get_Item(1);
            worksheetName.Name = name;
        }

        /// <summary>
        /// Delete a worksheet by index. index start from 1 not 0
        /// </summary>
        /// <param name="index"></param>
        public void DeleteWorksheet(int index)
        {
            bool deleteCurrentSheet = false;

            if (index < 1)
                throw new Exception("Index out of bounds");
            if (index > _excelWorkbook.Sheets.Count)
                throw new Exception("Index out of bounds");

            //Check if we are deleting the worksheet that is being used. If so point it to another worksheet after deletion
            if (_excelWorksheet.Name.Equals(((Excel.Worksheet)_excelApp.Application.ActiveWorkbook.Sheets[index]).Name))
                deleteCurrentSheet = true;

            ((Excel.Worksheet)_excelApp.Application.ActiveWorkbook.Sheets[index]).Delete();

            if (deleteCurrentSheet)
                _excelWorksheet = (Excel.Worksheet)_excelWorksheets.get_Item(1);

        }

        /// <summary>
        /// Delete a worksheet by name
        /// </summary>
        /// <param name="name"></param>
        public void DeleteWorksheet(string name)
        {
            for (int i = 0; i < _excelWorkbook.Sheets.Count; i++)
            {
                Excel.Worksheet worksheetDelete = (Excel.Worksheet)_excelWorksheets.get_Item(i + 1);
                if (name.Equals(worksheetDelete.Name))
                {
                    DeleteWorksheet(i + 1);
                }
            }
        }



        public void SaveAs(FileType fileType, string fullPath)
        {
            // Error: Can not access file
            bool isUsingFile = IsUsingFile(fullPath);
            if (isUsingFile)
                throw new Exception("File is using");

            switch (fileType)
            {
                case FileType.Xls2003:
                    _excelWorkbook.SaveAs(fullPath, Excel.XlFileFormat.xlWorkbookNormal,
                        _missing, _missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                        _missing, _missing, _missing, _missing, _missing);
                    break;
                case FileType.Xlsx2007:
                    _excelWorkbook.SaveAs(fullPath, Excel.XlFileFormat.xlWorkbookDefault,
                        _missing, _missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                        _missing, _missing, _missing, _missing, _missing);
                    break;
                default:
                    break;
            }
        }

        public static bool IsUsingFile(string filepath)
        {
            FileStream stream = null;
            try
            {
                FileInfo fInfo = new FileInfo(filepath);
                stream = fInfo.OpenWrite();
                return false;
            }
            catch (Exception)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        public void AutoFitRow()
        {
            _excelRange.EntireRow.AutoFit();
        }

        public void AutoFitColumn()
        {
            _excelRange.EntireColumn.AutoFit();
        }





        /// <summary>
        /// Set the current worksheet by name
        /// </summary>
        /// <param name="name"></param>
        public void SetCurrentWorksheet(string name)
        {
            for (int i = 0; i < _excelWorkbook.Sheets.Count; i++)
            {
                Excel.Worksheet worksheetCurrent = (Excel.Worksheet)_excelWorksheets.get_Item(i + 1);
                if (name.Equals(worksheetCurrent.Name))
                {
                    _excelWorksheet = (Excel.Worksheet)_excelWorksheets.get_Item(i + 1);
                }
            }
        }

        /// <summary>
        /// Set the current worksheet by index
        /// </summary>
        /// <param name="index"></param>
        public void SetCurrentWorksheet(int index)
        {
            if (index < 1)
                throw new Exception("Index out of bounds");
            if (index > _excelWorkbook.Sheets.Count)
                throw new Exception("Index out of bounds");

            _excelWorksheet = (Excel.Worksheet)_excelWorksheets.get_Item(index);
        }


        #region "Range's Method"
        public ExcelManager SelectRange(int row, int column)
        {
            _excelRange = _excelWorksheet.get_Range(this.GetAddressByNum(row, column));
            return this;
        }

        public ExcelManager SelectRange(int startRow, int startColumn, int endRow, int endColumn)
        {
            _excelRange = _excelWorksheet.get_Range(this.GetAddressByNum(startRow, startColumn),
                this.GetAddressByNum(endRow, endColumn));
            return this;
        }

        /// <summary>
        /// Set the column ranges e.g A1 B30 or A1 A1 if you want.
        /// </summary>
        public ExcelManager SelectRange(string from, string to)
        {
            _excelRange = _excelWorksheet.get_Range(from, to);
            return this;
        }

        public ExcelManager SelectRange(string namedRange)
        {
            _excelRange = _excelWorksheet.get_Range(namedRange);
            return this;
        }

        public ExcelManager SelectRange()
        {
            this.SelectRange(1, 1, _excelWorksheet.Rows.Count,
                _excelWorksheet.Columns.Count);
            return this;
        }

        public ExcelManager SetRangeName(string name)
        {
            _excelRange.Name = name;
            return this;
        }

        public ExcelManager SetRangeName(Excel.Range range, string name)
        {
            _excelRange.Name = name;
            return this;
        }

        public ExcelManager MoveRange(int dx, int dy, bool moveEntireRange = true)
        {
            if (moveEntireRange)
                _excelRange = _excelRange.get_Offset(dx, dy).get_Resize(_excelRange.Rows.Count,
                    _excelRange.Columns.Count);
            else
                _excelRange = _excelRange.get_Offset(dx, dy);
            return this;
        }

        public ExcelManager MoveTo(int row, int column)
        {
            int dx = Math.Abs(_excelRange.Row - row);
            int dy = Math.Abs(_excelRange.Column - column);

            if (_excelRange.Row > row)
            {
                dx = -dx;
            }

            if (_excelRange.Column > column)
            {
                dy = -dy;
            }
            this.MoveRange(dx, dy);
            return this;
        }

        public ExcelManager ResizeRange(int row, int column)
        {
            _excelRange = _excelRange.get_Resize(row, column);
            return this;
        }

        public RangeType GetRangeType()
        {
            if (_excelRange.Count == 1)
                return RangeType.OneCell;

            if (_excelRange.Rows.Count == 1 && _excelRange.Columns.Count > 1)
                return RangeType.OneRowMultiColumn;

            if (_excelRange.Rows.Count > 1 && _excelRange.Columns.Count == 1)
                return RangeType.OneRowMultiColumn;

            return RangeType.MultiRowMultiColumn;
        }

        public string GetRangeAddress1()
        {
            return _excelRange.get_Address(false, false, Excel.XlReferenceStyle.xlA1, false, false);
        }

        public void TEst()
        {
            this.SetRangeValue("AAA");

            _excelRange = _excelRange.get_Resize(10, 10);
            _excelRange.Merge();
            _excelRange.Borders.Value = 1;
            this.SetRangeValue("DASDASDAS");

            _excelRange = _excelRange.get_Offset(2, 0).get_Resize(_excelRange.Rows.Count,
                _excelRange.Columns.Count);
            _excelRange.Borders.Value = 1;
            _excelRange.Merge();
            this.SetRangeValue("ADASDSA");
        }

        /// <summary>
        /// Set the value of the range
        /// </summary>
        public ExcelManager SetRangeValue(object value)
        {
            if (!(value is string))
            {
                _excelRange.Value2 = value;
                return this;
            }

            string str = value as string;
            bool isUpper = false;
            switch (this.Encode)
            {
                case EncodeType.Unicode:
                    _excelRange.Value2 = str;
                    break;
                case EncodeType.VNI:
                    _excelRange.Value2 = str;
                    break;
                case EncodeType.TCVN3:
                    isUpper = str.IsUpper();
                    str = TextConverter.Convert(str);
                    _excelRange.Value2 = str;
                    if (isUpper)
                        this.SetFontFamily(".VnTimeH");
                    else
                        this.SetFontFamily(".VnTime");
                    break;
                default:
                    break;
            }

            return this;
        }

        /// <summary>
        /// Set the value of the range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void SetRangeValue(object[,] value)
        {
            _excelRange.Value2 = value;
        }

        /// <summary>
        /// Set the value of the range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public ExcelManager SetRangeValue(object[] value)
        {
            _excelRange.Value2 = value;
            return this;
        }

        public ExcelManager SetRangeNumberFormat(string format)
        {
            _excelRange.NumberFormat = format;
            return this;
        }


        #endregion









        /// <summary>
        /// Formats the font in a cell, bold italic and underline take a bool as a value.
        /// Fontsize font color and font type are all nullable so you can write null if you dont want to specify
        /// </summary>
        public void FormatRangeFont(string from, string to, bool bold, bool italic, bool underline, double? fontSize, Color ? fontColor, string fontName)
        {
            _excelRange = _excelWorksheet.get_Range(from, to);

            _excelRange.Font.Bold = bold;
            _excelRange.Font.Italic = italic;
            _excelRange.Font.Underline = underline;

            if (fontSize != null)
                _excelRange.Font.Size = fontSize;
            if (fontColor != null)
                _excelRange.Font.Color = ColorTranslator.ToOle(fontColor.Value);
            if (!string.IsNullOrEmpty(fontName))
                _excelRange.Font.Name = fontName;
        }


        //public void FormatRange(string from, string to, Color? background, Align vertical, Align horizontal, BorderType borderType, BorderLineStyle borderStyle)
        //{
        //    _excelRange = _excelWorksheet.get_Range(from, to);

        //    if (background != null)
        //        _excelRange.Interior.Color = ColorTranslator.ToOle(background.Value);
        //    if (!vertical.Equals(Align.None))
        //        _excelRange.VerticalAlignment = vertical;
        //    if (!horizontal.Equals(Align.None))
        //        _excelRange.HorizontalAlignment = horizontal;

        //    if (borderType == BorderType.None)
        //        return;
        //    if (borderType == BorderType.BorderOutside)
        //        _excelRange.BorderAround(borderStyle, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexNone, _missing);
        //    else
        //    {
        //        _excelRange.Borders.LineStyle = borderStyle;
        //    }
        //}

        /// <summary>
        /// Get the value of a cell e.g  A1
        /// </summary>
        public string GetCellValue(string location)
        {
            return _excelWorksheet.get_Range(location, _missing).Value2.ToString();
        }

        /// <summary>
        /// Set the value of a cell e.g  A1
        /// </summary>
        public void SetCellValue(string location, string value)
        {
            _excelWorksheet.get_Range(location, _missing).Value2 = value;
        }


        /// <summary>
        /// Formats the font in a cell, bold italic and underline take a bool as a value.
        /// Fontsize font color and font type are all nullable so you can write null if you dont want to specify
        /// </summary>
        public void FormatCellFont(string location, bool bold, bool italic, bool underline, double? fontsize, Color? fontcolor, string fontname)
        {
            _excelRange = _excelWorksheet.get_Range(location, _missing);

            _excelRange.Font.Bold = bold;
            _excelRange.Font.Italic = italic;
            _excelRange.Font.Underline = underline;

            if (fontsize != null)
                _excelRange.Font.Size = fontsize;
            if (fontcolor != null)
                _excelRange.Font.Color = System.Drawing.ColorTranslator.ToOle(fontcolor.Value);
            if (!string.IsNullOrEmpty(fontname))
                _excelRange.Font.Name = fontname;
        }

        /// <summary>
        /// Prints the current worksheet
        /// </summary>
        public void PrintWorksheet(int copies)
        {
            _excelWorksheet.PrintOut(_missing, _missing, copies, _missing, true, _missing, _missing, _missing);
        }

        /// <summary>
        /// Prints all the worksheets 
        /// </summary>
        public void PrintAllWorksheets(int copies)
        {
            int count = WorksheetCount;

            for (int i = 1; i < count + 1; i++)
            {
                Excel.Worksheet worksheetPrint = (Excel.Worksheet)_excelWorksheets.get_Item(i);
                worksheetPrint.PrintOut(_missing, _missing, copies, _missing, true, _missing, _missing, _missing);
            }
        }

        public int GetColumnIndexByAddress(string name)
        {
            int position = 0;

            var chars = name.ToUpperInvariant().ToCharArray().Reverse().ToArray();
            for (var index = 0; index < chars.Length; index++)
            {
                var c = chars[index] - 64;
                position += index == 0 ? c : (c * (int)Math.Pow(26, index));
            }

            return position;
        }

        public string GetColumnAddressByIndex(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        public void Page()
        {
            // Định dạng trang giấy
            _excelWorksheet.EnablePivotTable = true;
            _excelWorksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            _excelWorksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;

            //excelSheet.PageSetup.Zoom = false;
            //excelSheet.PageSetup.FitToPagesTall = false;
            //excelSheet.PageSetup.FitToPagesWide = 1;
        }

        public void PageParameter(Excel.XlPaperSize _page = Excel.XlPaperSize.xlPaperA3)
        {
            // Định dạng trang giấy
            _excelWorksheet.EnablePivotTable = true;
            _excelWorksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            _excelWorksheet.PageSetup.PaperSize = _page;
        }

        public void SetTitleRows()
        {
            _excelWorksheet.PageSetup.PrintTitleRows = this.GetRangeAddress;
        }

        /// <summary>
        /// Xóa dòng trong khoảng Range.
        /// </summary>
        /// <param name="range">Vùng Range cần xử lý.</param>
        public void DeleteRow(Excel.Range range)
        {
            range.EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
        }

        /// <summary>
        /// Xóa cột trong khoảng Range.
        /// </summary>
        /// <param name="range">Vùng Range cần xử lý.</param>
        public void DeleteColumn(Excel.Range range)
        {
            range.EntireColumn.Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft);
        }

        /// <summary>
        /// Set độ phóng to/thu nhỏ của cửa sổ Excel.
        /// </summary>
        /// <param name="zoomPercentage">% phóng to/thu nhỏ.</param>
        public void SetZoom(int zoomPercentage)
        {
            _excelWindow.Zoom = zoomPercentage;
        }

        public void FreezePanes(int splitRow, int scrollRow, int splitColumn, int scrollColumn)
        {
            _excelWindow.SplitRow = splitRow;
            _excelWindow.ScrollRow = scrollRow;
            _excelWindow.SplitColumn = splitColumn;
            _excelWindow.ScrollColumn = scrollColumn;
            _excelWindow.FreezePanes = true;
        }

        /// <summary>
        /// Set font.
        /// </summary>
        /// <param name="range">Vùng Range cần xử lý.</param>
        /// <param name="family">Family font name.</param>
        /// <param name="size">Kích cỡ font.</param>
        public void SetFontFamily(string family)
        {
            _excelRange.Font.Name = family;
        }

        public ExcelManager SetFontSize(int size)
        {
            _excelRange.Font.Size = size;
            return this;
        }

        /// <summary>
        /// Set font style.
        /// </summary>
        public ExcelManager SetFontColor(Color color)
        {
            _excelRange.Font.Color = System.Drawing.ColorTranslator.ToOle(color);
            return this;
        }

        /// <summary>
        /// Set font style.
        /// </summary>
        public ExcelManager SetFontStyle(bool bold, bool italic, bool underline)
        {
            _excelRange.Font.Bold = bold;
            _excelRange.Font.Underline = underline;
            _excelRange.Font.Italic = italic;
            return this;
        }

        /// <summary>
        /// Set màu nền.
        /// </summary>
        /// <param name="range">Vùng Range cần xử lý.</param>
        /// <param name="color">Màu nền.</param>
        public void SetBackgroundColor(Excel.Range range, Color color)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.ToOle(color);
        }

        /// <summary>
        /// Set chuỗi định dạng số.
        /// </summary>
        public void SetNumberFormat(string numberFormat)
        {
            _excelRange.NumberFormat = numberFormat;
        }

        public ExcelManager Merge()
        {
            _excelRange.Merge();
            return this;
        }

        public ExcelManager SetBorder(int value)
        {
            _excelRange.Borders.Value = value;
            return this;
        }

        public ExcelManager SetBorderWeight(int value)
        {
            // Lỗi khi ser weight = 5
            _excelRange.Borders.Weight = value;
            return this;
        }

        public ExcelManager InsertRow(int row)
        {
            for (int i = 0; i < row; i++)
            {
                _excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
            }
            return this;
        }

        //public void SetPattern(string startCell, string endCell, string pattern)
        //{
        //    Excel.Range range = worksheet.get_Range(startCell, endCell);

        //    try
        //    {
        //        Excel.XlPattern xlPattern = namePatternMap[pattern];
        //        range.Interior.Pattern = xlPattern;
        //    }
        //    catch
        //    {
        //        range.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
        //    }
        //}

        //public void InsertPicture(string path, float left, float top, float width, float height)
        //{
        //    worksheet.Shapes.AddPicture(path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue,
        //        left, top, width, height);
        //}

        //public void SetText(string cell, string text)
        //{
        //    Excel.Range range = worksheet.get_Range(cell, cell);
        //    range.Cells[1, 1] = text;
        //}

        //public void SetFormula(string cell, string formula)
        //{
        //    Excel.Range range = worksheet.get_Range(cell, cell);
        //    range.Formula = formula;
        //}

        public void SetBorderAround(string lineStyle, string borderWeight, string borderColorName)
        {
            //Excel.Range range = worksheet.get_Range(startCell, endCell);

            try
            {
                object borderColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromName(borderColorName));
                _excelRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic,
                    Color.Red);
                //range.BorderAround(nameLineStyleMap[lineStyle], nameBorderWeightMap[borderWeight], Excel.XlColorIndex.xlColorIndexAutomatic, borderColor);
            }
            catch
            {
                //object borderColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromName("Black"));
                //range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, borderColor);
            }
        }

        public void SetRowHeight(string cell, float height)
        {
            _excelRange.RowHeight = height;
        }

        public void SetColumnWidth(string cell, float width)
        {
            _excelRange.ColumnWidth = width;
        }

        //public void SetBorderInternal(string startCell, string endCell, string lineStyle, string borderWeight, string borderColorName)
        //{
        //    Excel.Range range = worksheet.get_Range(startCell, endCell);

        //    try
        //    {
        //        object borderColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromName(borderColorName));
        //        range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = nameLineStyleMap[lineStyle];
        //        range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = nameBorderWeightMap[borderWeight];
        //        range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Color = borderColor;
        //        range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = nameLineStyleMap[lineStyle];
        //        range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = nameBorderWeightMap[borderWeight];
        //        range.Borders[Excel.XlBordersIndex.xlInsideVertical].Color = borderColor;
        //    }
        //    catch
        //    {
        //        object borderColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromName("Black"));
        //        range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, borderColor);
        //        range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;
        //        range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlHairline;
        //        range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Color = borderColor;
        //        range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;
        //        range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = Excel.XlBorderWeight.xlHairline;
        //        range.Borders[Excel.XlBordersIndex.xlInsideVertical].Color = borderColor;
        //    }
        //}

        public ExcelManager SetHorizontalAlignment(Excel.XlHAlign horizontalAlign)
        {
            _excelRange.HorizontalAlignment = horizontalAlign;
            return this;
        }

        public ExcelManager SetVerticalAlignment(Excel.XlVAlign verticalAlign)
        {
            _excelRange.VerticalAlignment = verticalAlign;
            return this;
        }



        /// <summary>
        /// Returns a multidimensional array of the range
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public object[,] GetRangeValue(string value)
        {
            return (object[,])_excelRange.Value2;
        }



        public string GetAddressByNum(int row, int column)
        {
            return String.Format("{0}{1}", this.GetColumnAddressByIndex(column), row);
        }

        public ExcelManager SetWrapText(bool wrap)
        {
            _excelRange.WrapText = wrap;
            return this;
        }

        #region "Gridband 2 Excel"
        public int GridBand2Excel(GridBand band, int maxLevel, bool printColumnHeader = true,
            int startRow = 1, int startColumn = 1)
        {
            if (!band.Visible)
                return 0;

            int width = XtraGridUtils.GetWidth(band) - 1;
            string caption = band.Caption;

            if (!band.HasChildren)
            {
                // Print band caption
                this.SelectRange(startRow, startColumn, startRow + maxLevel, startColumn + width)
                    .Merge()
                    .SetWrapText(true)
                    .SetHorizontalAlignment(Excel.XlHAlign.xlHAlignCenter)
                    .SetVerticalAlignment(Excel.XlVAlign.xlVAlignCenter)
                    .SetBorder(1)
                    .SetFontStyle(true, false, false)
                    .SetRangeValue("'" + caption);

                // Print column caption
                if (printColumnHeader)
                {
                    for (int i = 0; i < band.Columns.VisibleColumnCount; i++)
                    {
                        this.SelectRange(startRow + maxLevel + 1, startColumn, startRow + maxLevel + 1, startColumn)
                            .SetWrapText(true)
                            .SetBorder(1)
                            .SetHorizontalAlignment(Excel.XlHAlign.xlHAlignCenter)
                            .SetVerticalAlignment(Excel.XlVAlign.xlVAlignCenter)
                            .SetRangeValue(band.Columns.Count == 0 ? "" : "'" + band.Columns[i].Caption);
                        startColumn++;
                    }
                }
                return width;
            }

            // In band hiện tại
            this.SelectRange(startRow, startColumn, startRow, startColumn + width)
                .Merge()
                .SetWrapText(true)
                .SetHorizontalAlignment(Excel.XlHAlign.xlHAlignCenter)
                .SetVerticalAlignment(Excel.XlVAlign.xlVAlignCenter)
                .SetBorder(1)
                .SetFontStyle(true, false, false)
                .SetRangeValue(caption);

            foreach (GridBand bnd in band.Children)
            {
                this.GridBand2Excel(bnd, maxLevel - 1, printColumnHeader, startRow + 1, startColumn);
                startColumn += XtraGridUtils.GetWidth(bnd);
                //if (!bnd.HasChildren || bnd.Children.Count == 1)
                //{
                //    if (bnd.Columns.VisibleColumnCount < 1)
                //    {
                //        startColumn++;
                //    }
                //    else
                //    {
                //        startColumn += bnd.Columns.VisibleColumnCount;
                //    }
                //}
                //else
                //{
                //    startColumn += bnd.Children.Count + bnd.Columns.VisibleColumnCount;
                //}
            }

            return width;
        }

        private int GetWidthBand(GridBand band)
        {
            if (!_lstBandSize.ContainsKey(band))
            {
                _lstBandSize.Add(band, new Size(XtraGridUtils.GetWidth(band), 0));
            }
            else
            {
                Size s = _lstBandSize[band];
                if (s.Width == 0)
                {
                    s.Width = XtraGridUtils.GetWidth(band);
                }
            }

            return _lstBandSize[band].Width;
        }

        private int GetHeightBand(GridBand band)
        {
            if (!_lstBandSize.ContainsKey(band))
            {
                _lstBandSize.Add(band, new Size(XtraGridUtils.GetLevel(band), 0));
            }
            else
            {
                Size s = _lstBandSize[band];
                if (s.Width == 0)
                {
                    s.Width = XtraGridUtils.GetWidth(band);
                }
            }

            return _lstBandSize[band].Width;
        }


        public void ParseGrid2Excel(BandedGridView view)
        {

        }

        public void GridHeader2Excel(GridView view, int startRow = 1, int startColumn = 1,
            string headerRangeName = "", bool useFieldName = false)
        {
            int headerStartRow = startRow;
            int headerStartColumn = startColumn;
            int headerEndRow = startRow;
            int headerEndColumn = startColumn;

            for (int i = 0; i < view.VisibleColumns.Count; i++)
            {
                string caption = useFieldName == true ?
                    view.VisibleColumns[i].FieldName : view.VisibleColumns[i].Caption;
                this.SelectRange(startRow, startColumn + i, startRow, startColumn + i)
                    .Merge()
                    .SetHorizontalAlignment(Excel.XlHAlign.xlHAlignCenter)
                    .SetVerticalAlignment(Excel.XlVAlign.xlVAlignCenter)
                    .SetBorder(1)
                    .SetRangeValue(caption);
                headerEndColumn++;
            }

            headerEndColumn = headerEndColumn - 1;
            headerEndRow = startRow;

            // Save header range
            if (!String.IsNullOrEmpty(headerRangeName))
            {
                this.SelectRange(headerStartRow, headerStartColumn,
                    headerEndRow, headerEndColumn);
                this.SetRangeName(headerRangeName);
            }
        }

        public void BandedGridHeader2Excel(BandedGridView view, bool printColumnHeader = true,
            int startRow = 1, int startColumn = 1, string headerRangeName = "")
        {
            int headerStartRow = startRow;
            int headerStartColumn = startColumn;
            int headerEndRow = startRow;
            int headerEndColumn = startColumn;
            int maxLevel = XtraGridUtils.GetMaxLevel(view.Bands);

            // Print band
            foreach (GridBand band in view.Bands)
            {
                if (band.Visible)
                {
                    int width = this.GridBand2Excel(band, maxLevel, printColumnHeader,
                        headerStartRow, headerEndColumn);
                    headerEndColumn += width + 1;
                }
            }
            headerEndColumn = headerEndColumn - 1;
            headerEndRow = startRow + maxLevel;
            if (printColumnHeader)
                headerEndRow += 1;

            // Save header range
            if (!String.IsNullOrEmpty(headerRangeName))
            {
                this.SelectRange(headerStartRow, headerStartColumn,
                    headerEndRow, headerEndColumn);
                this.SetRangeName(headerRangeName);
            }
        }

        public void BandedGridData2Excel(BandedGridView view, int startRow = 1,
            int startColumn = 1, string dataRangeName = "", bool saveColumnRange = false)
        {
            int dataStartRow = startRow;
            int dataStartColumn = startColumn;
            int dataEndRow = dataStartRow + view.RowCount - 1;
            int dataEndCoumn = dataStartColumn + view.VisibleColumns.Count - 1;
            object[,] data = new object[view.RowCount, view.VisibleColumns.Count];
            List<int> groupRowIndex = new List<int>();

            for (int i = 0; i < view.RowCount; i++)
            {
                int rowHandle = view.GetVisibleRowHandle(i);
                if (view.IsGroupRow(rowHandle))
                {
                    var text = view.GetGroupRowDisplayText(rowHandle);
                    if (this.Encode == ExcelManager.EncodeType.TCVN3)
                    {
                        text = TextConverter.Convert(text);
                    }
                    for (int j = 0; j < view.VisibleColumns.Count; j++)
                    {
                        data[i, j] = text;
                    }
                    groupRowIndex.Add(dataStartRow + i);
                }

                if (view.IsDataRow(rowHandle))
                {
                    for (int j = 0; j < view.VisibleColumns.Count; j++)
                    {
                        var text = view.GetRowCellDisplayText(rowHandle, view.VisibleColumns[j]);
                        DateTime date;
                        //if (DateTime.TryParse(text, out date))
                        //if (view.VisibleColumns[j].FieldName == "NGAYKHAM")
                        //{
                        //    //text = date.ToString("MM/dd/yyyy");
                        //    text = "'" + text;
                        //}
                        if (this.Encode == ExcelManager.EncodeType.TCVN3)
                        {
                            text = TextConverter.Convert(text);
                        }
                        if (view.VisibleColumns[j].ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit)
                        {
                            object value = view.GetRowCellValue(rowHandle, view.VisibleColumns[j]);
                            if (!string.IsNullOrEmpty(value + string.Empty))
                            {
                                value = Convert.ToDecimal(value) > 0 ? value : null;
                                data[i, j] = value;
                            }
                        }
                        else
                        {
                            data[i, j] = text;
                        }
                    }
                }
            }

            // Lưu địa chỉ column range
            if (saveColumnRange)
            {
                for (int j = 0; j < view.VisibleColumns.Count; j++)
                {
                    string fieldName = view.VisibleColumns[j].FieldName;
                    this.SelectRange(dataStartRow, j + 1, dataEndRow, j + 1)
                        .SetRangeName(fieldName);
                }
            }

            // Print data
            this.SelectRange(dataStartRow, dataStartColumn, dataEndRow, dataEndCoumn)
                .SetBorder(1)
                .SetRangeValue(data);

            // Save data range
            if (!String.IsNullOrEmpty(dataRangeName))
            {
                this.SetRangeName(dataRangeName);
            }

            // Group row
            foreach (var index in groupRowIndex)
            {
                this.SelectRange(index, dataStartColumn, index, dataEndCoumn)
                    .SetFontStyle(true, false, false)
                    .SetFontSize(12)
                    //.SetFontColor(Color.Red)
                    .SetHorizontalAlignment(Excel.XlHAlign.xlHAlignLeft)
                    .Merge();
            }
        }

        public void GridData2Excel(GridView view, int startRowExcel = 1,
            int startColumnExcel = 1, bool useSummaryGroup = false, bool useSummaryFooter = false,
            string dataRangeName = "", bool saveColumnRange = false, bool showSummaryGroupMaxLevel = false, int numberRowGroupMaxLevel = 0) 
        {
            //showSummaryGroupMaxLevel : hiển thị dòng tổng cộng của Group cha
            //numberRowGroupMaxLevel : Số dòng Group cha

            int maxRowLevel = this.GetMaxRowLevel(view);
            int groupRowCount = this.GetGroupRowCount(view);
            int rowCapacity = view.DataRowCount + groupRowCount;
            int colCapacity = view.VisibleColumns.Count;
            if (useSummaryGroup)
            {
                rowCapacity += groupRowCount;
            }

            if (useSummaryFooter)
            {
                if (showSummaryGroupMaxLevel)
                    rowCapacity += (numberRowGroupMaxLevel + 6);
                else
                    rowCapacity += 1; //rowCapacity += 15;
            }
            int dataStartRow = startRowExcel;
            int dataStartColumn = startColumnExcel;
            int dataEndRow = dataStartRow + rowCapacity - 1;
            int dataEndCoumn = dataStartColumn + colCapacity - 1;
            object[,] data = new object[rowCapacity, colCapacity];
            List<int> groupRowIndex = new List<int>();
            List<int> summaryGroupRowIndex = new List<int>();
            List<GridExcelIndex> gridExcelIndexData = new List<GridExcelIndex>();

            int prevRowHandle = -1;
            int prevRowLevel = -1;
            int currentRowIndex = 0;

            #region "Có sử dụng SummaryGroup"
            if (useSummaryGroup)
            {
                List<int> lstParentRowHandle = new List<int>();
                for (int i = 0; i < view.RowCount; i++)
                {
                    int rowHandle = view.GetVisibleRowHandle(i);
                    int rowLevel = view.GetRowLevel(rowHandle);
                    if (rowHandle != -1)
                    {
                        prevRowLevel = view.GetRowLevel(prevRowHandle);
                        if (prevRowLevel > rowLevel)
                        {
                            int deltaLevel = prevRowLevel - rowLevel;
                            lstParentRowHandle = this.GetParentRowHandle(view, deltaLevel, prevRowHandle);
                            for (int k = 0; k < lstParentRowHandle.Count; k++)
                            {
                                var groupRowHasSummaryLevel = view.GetRowLevel(lstParentRowHandle[k]);
                                // In dòng summary
                                for (int j = 0; j < view.VisibleColumns.Count; j++)
                                {
                                    var columnName = view.VisibleColumns[j].Name;
                                    string colAddress = this.GetColumnAddressByIndex(dataStartColumn + j);
                                    object summaryValue = null;
                                    foreach (GridGroupSummaryItem item in view.GroupSummary)
                                    {
                                        if (item.ShowInGroupColumnFooterName == columnName)
                                        {
                                            if (item.SummaryType == DevExpress.Data.SummaryItemType.Sum
                                                || item.SummaryType == DevExpress.Data.SummaryItemType.Count)
                                            {
                                                var rowIndexStart = gridExcelIndexData.FirstOrDefault(p => p.GridRowHandle == lstParentRowHandle[k])
                                                        .ExcelIndex + 1;
                                                if (groupRowHasSummaryLevel == maxRowLevel - 1) // Group chứa datarow
                                                {
                                                    var rowIndexEnd = dataStartRow + currentRowIndex - 1;
                                                    string formula = String.Empty;
                                                    if (item.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                                                    {
                                                        formula = String.Format("=SUM({0}{1}:{0}{2})", colAddress,
                                                        rowIndexStart, rowIndexEnd);
                                                    }
                                                    else
                                                    {
                                                        formula = String.Format("=COUNTA({0}{1}:{0}{2})", colAddress,
                                                       rowIndexStart, rowIndexEnd);
                                                    }

                                                    summaryValue = formula;
                                                }
                                                else // Các group cha có Summary
                                                {
                                                    var lst = from p in gridExcelIndexData
                                                              where p.ExcelIndex >= rowIndexStart
                                                                && p.ExcelIndex < dataStartRow + currentRowIndex
                                                                && p.GridRowLevel == groupRowHasSummaryLevel + 1
                                                                && p.IsSummaryGroup == true
                                                              select p;
                                                    StringBuilder sb = new StringBuilder();
                                                    sb.Append("=");
                                                    foreach (var it in lst)
                                                    {
                                                        sb.Append(String.Format("{0}{1}", colAddress, it.ExcelIndex));
                                                        if (it != lst.Last())
                                                        {
                                                            sb.Append("+");
                                                        }
                                                    }
                                                    summaryValue = sb.ToString();
                                                }
                                            }
                                            else
                                            {
                                                summaryValue = view.GetGroupSummaryValue(lstParentRowHandle[k], item);
                                            }
                                            break;
                                        }
                                    }

                                    if (summaryValue is string && this.Encode == ExcelManager.EncodeType.TCVN3)
                                    {
                                        summaryValue = TextConverter.Convert(summaryValue as string);
                                    }

                                    if (j == 0)
                                    {
                                        summaryValue = "Cộng " + view.GetGroupRowDisplayText(lstParentRowHandle[k]);
                                    }

                                    data[currentRowIndex, j] = summaryValue;
                                }
                                summaryGroupRowIndex.Add(dataStartRow + currentRowIndex);
                                gridExcelIndexData.Add(new GridExcelIndex()
                                {
                                    ExcelIndex = dataStartRow + currentRowIndex,
                                    GridRowHandle = Int32.MinValue,
                                    GridRowLevel = view.GetRowLevel(lstParentRowHandle[k]),
                                    IsSummaryGroup = true,
                                    IsSummaryFooter = false,
                                    GroupValue = view.GetGroupRowValue(lstParentRowHandle[k])
                                });
                                currentRowIndex++;
                            }
                        }
                    }

                    if (view.IsGroupRow(rowHandle))
                    {
                        var text = view.GetGroupRowDisplayText(rowHandle);
                        if (this.Encode == ExcelManager.EncodeType.TCVN3)
                        {
                            text = TextConverter.Convert(text);
                        }
                        data[currentRowIndex, 0] = text;
                        groupRowIndex.Add(dataStartRow + currentRowIndex);
                        gridExcelIndexData.Add(new GridExcelIndex()
                        {
                            ExcelIndex = dataStartRow + currentRowIndex,
                            GridRowHandle = rowHandle,
                            GridRowLevel = view.GetRowLevel(rowHandle),
                            IsSummaryGroup = false,
                            IsSummaryFooter = false,
                            GroupValue = view.GetGroupRowValue(rowHandle)
                        });
                        currentRowIndex++;
                    }

                    if (view.IsDataRow(rowHandle))
                    {
                        for (int j = 0; j < view.VisibleColumns.Count; j++)
                        {
                            var text = view.GetRowCellDisplayText(rowHandle, view.VisibleColumns[j]);
                            if (this.Encode == ExcelManager.EncodeType.TCVN3)
                            {
                                text = TextConverter.Convert(text);
                            }

                            Type columnType = view.VisibleColumns[j].ColumnType;
                            if (columnType == typeof(DateTime) || columnType == typeof(DateTime?) || columnType == typeof(String))
                            {
                                //data[currentRowIndex, j] = "'" + text;
                                data[currentRowIndex, j] =  text;
                            }
                            else
                            {
                                //DateTime date;
                                //if (DateTime.TryParse(text, out date))
                                if (view.VisibleColumns[j].ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit)
                                {
                                    object value = view.GetRowCellValue(rowHandle, view.VisibleColumns[j]);
                                    if (!string.IsNullOrEmpty(value + string.Empty))
                                    {
                                        value = Convert.ToDecimal(value) > 0 ? value : null;
                                        data[currentRowIndex, j] = value;
                                    }
                                }
                                else
                                {
                                    data[currentRowIndex, j] = text;
                                }
                            }
                        }
                        gridExcelIndexData.Add(new GridExcelIndex()
                        {
                            ExcelIndex = dataStartRow + currentRowIndex,
                            GridRowHandle = rowHandle,
                            GridRowLevel = view.GetRowLevel(rowHandle),
                            IsSummaryGroup = false,
                            IsSummaryFooter = false,
                            GroupValue = null
                        });
                        currentRowIndex++;
                    }

                    prevRowHandle = rowHandle;
                }

                // Thêm các dòng summary cuối grid
                lstParentRowHandle = this.GetParentRowHandle(view, view.GroupCount, prevRowHandle);
                if (lstParentRowHandle != null)
                {
                    foreach (int parentRowHandle in lstParentRowHandle)
                    {
                        var groupRowHasSummaryLevel = view.GetRowLevel(parentRowHandle);
                        // In dòng summary
                        for (int j = 0; j < view.VisibleColumns.Count; j++)
                        {
                            var columnName = view.VisibleColumns[j].Name;
                            string colAddress = this.GetColumnAddressByIndex(dataStartColumn + j);
                            object summaryValue = null;
                            foreach (GridGroupSummaryItem item in view.GroupSummary)
                            {
                                if (item.ShowInGroupColumnFooterName == columnName)
                                {
                                    if (item.SummaryType == DevExpress.Data.SummaryItemType.Sum
                                        || item.SummaryType == DevExpress.Data.SummaryItemType.Count)
                                    {
                                        var rowIndexStart = gridExcelIndexData.FirstOrDefault(p => p.GridRowHandle == parentRowHandle)
                                                .ExcelIndex + 1;
                                        if (groupRowHasSummaryLevel == maxRowLevel - 1) // Group chứa datarow
                                        {
                                            var rowIndexEnd = dataStartRow + currentRowIndex - 1;
                                            string formula = String.Empty;
                                            if (item.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                                            {
                                                formula = String.Format("=SUM({0}{1}:{0}{2})", colAddress,
                                               rowIndexStart, rowIndexEnd);
                                            }
                                            else
                                            {
                                                formula = String.Format("=COUNTA({0}{1}:{0}{2})", colAddress,
                                               rowIndexStart, rowIndexEnd);
                                            }
                                            summaryValue = formula;
                                        }
                                        else // Các group cha có Summary
                                        {
                                            var lst = from p in gridExcelIndexData
                                                      where p.ExcelIndex >= rowIndexStart
                                                        && p.ExcelIndex < dataStartRow + currentRowIndex
                                                        && p.GridRowLevel == groupRowHasSummaryLevel + 1
                                                        && p.IsSummaryGroup == true
                                                      select p;
                                            StringBuilder sb = new StringBuilder();
                                            sb.Append("=");
                                            foreach (var it in lst)
                                            {
                                                sb.Append(String.Format("{0}{1}", colAddress, it.ExcelIndex));
                                                if (it != lst.Last())
                                                {
                                                    sb.Append("+");
                                                }
                                            }
                                            summaryValue = sb.ToString();
                                        }
                                    }
                                    else
                                    {
                                        summaryValue = view.GetGroupSummaryValue(parentRowHandle, item);
                                    }
                                    break;
                                }
                            }

                            if (summaryValue is string && this.Encode == ExcelManager.EncodeType.TCVN3)
                            {
                                summaryValue = TextConverter.Convert(summaryValue as string);
                            }
                            if (j == 0)
                            {
                                summaryValue = "Cộng " + view.GetGroupRowDisplayText(parentRowHandle);
                            }
                            data[currentRowIndex, j] = summaryValue;
                        }

                        summaryGroupRowIndex.Add(dataStartRow + currentRowIndex);
                        gridExcelIndexData.Add(new GridExcelIndex()
                        {
                            ExcelIndex = dataStartRow + currentRowIndex,
                            GridRowHandle = Int32.MinValue,
                            GridRowLevel = view.GetRowLevel(parentRowHandle),
                            IsSummaryGroup = true,
                            IsSummaryFooter = false,
                            GroupValue = view.GetGroupRowValue(parentRowHandle)
                        });
                        currentRowIndex++;
                    }
                }

                // In dòng Summary footer
                if (useSummaryFooter)
                {
                    for (int j = 0; j < view.VisibleColumns.Count; j++)
                    {
                        object summaryValue = null;
                        string colAddress = this.GetColumnAddressByIndex(dataStartColumn + j);
                        GridSummaryItem summaryItem = view.VisibleColumns[j].SummaryItem;
                        if (summaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                        {
                            if (summaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum
                                || summaryItem.SummaryType == DevExpress.Data.SummaryItemType.Count)
                            {
                                var lst = from p in gridExcelIndexData
                                          where p.ExcelIndex < dataStartRow + currentRowIndex
                                            && p.GridRowLevel == 0
                                            && p.IsSummaryGroup == true
                                          select p;
                                StringBuilder sb = new StringBuilder();
                                sb.Append("=");
                                foreach (var it in lst)
                                {
                                    sb.Append(String.Format("{0}{1}", colAddress, it.ExcelIndex));
                                    if (it != lst.Last())
                                    {
                                        sb.Append("+");
                                    }
                                }
                                summaryValue = sb.ToString();
                            }
                            else
                            {
                                summaryValue = summaryItem.SummaryValue;
                            }

                            if (summaryValue is string && this.Encode == ExcelManager.EncodeType.TCVN3)
                            {
                                summaryValue = TextConverter.Convert(summaryValue as string);
                            }

                            if (j == 0)
                            {
                                summaryValue = "Tổng Cộng";
                            }

                            data[currentRowIndex, j] = summaryValue;
                        }
                        if (j == 0)
                        {
                            summaryValue = "Tổng Cộng";
                        }

                        data[currentRowIndex, j] = summaryValue;
                    }
                    summaryGroupRowIndex.Add(dataStartRow + currentRowIndex); //ththo
                    gridExcelIndexData.Add(new GridExcelIndex()
                    {
                        ExcelIndex = dataStartRow + currentRowIndex,
                        GridRowHandle = Int32.MinValue,
                        GridRowLevel = Int32.MinValue,
                        IsSummaryGroup = false,
                        IsSummaryFooter = true,
                        GroupValue = "Tổng Cộng"
                    });

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (showSummaryGroupMaxLevel) //Hiển thị dòng sum group cha
                    {
                        #region in cac tong cuoi dong - NTuan

                        currentRowIndex += 2;

                        var lstSubTotal = (from p in gridExcelIndexData
                                           where p.ExcelIndex < dataStartRow + currentRowIndex
                                                       && p.GridRowLevel == 0
                                                       && p.IsSummaryGroup == true
                                                       && p.IsSummaryFooter == false
                                           select p).ToList();
                        foreach (var subTotal in lstSubTotal)
                        {
                            for (int j = 0; j < view.VisibleColumns.Count; j++)
                            {
                                object summaryValue = null;
                                string colAddress = this.GetColumnAddressByIndex(dataStartColumn + j);
                                GridSummaryItem summaryItem = view.VisibleColumns[j].SummaryItem;
                                if (summaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                                {
                                    if (summaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum
                                        || summaryItem.SummaryType == DevExpress.Data.SummaryItemType.Count)
                                    {
                                        //var lst = from p in gridExcelIndexData
                                        //          where p.ExcelIndex < dataStartRow + currentRowIndex
                                        //            && p.GridRowLevel == 0
                                        //            && p.IsSummaryGroup == true
                                        //          select p;
                                        StringBuilder sb = new StringBuilder();
                                        sb.Append("=");
                                        //foreach (var it in lst)
                                        {
                                            sb.Append(String.Format("{0}{1}", colAddress, subTotal.ExcelIndex));
                                            //if (it != lst.Last())
                                            //{
                                            //    sb.Append("+");
                                            //}
                                        }
                                        summaryValue = sb.ToString();
                                    }
                                    else
                                    {
                                        summaryValue = summaryItem.SummaryValue;
                                    }

                                    if (summaryValue is string && this.Encode == ExcelManager.EncodeType.TCVN3)
                                    {
                                        summaryValue = TextConverter.Convert(summaryValue as string);
                                    }

                                    if (j == 0)
                                    {
                                        summaryValue = "Tổng Cộng " + subTotal.GroupValue;
                                    }

                                    data[currentRowIndex, j] = summaryValue;
                                }
                                if (j == 0)
                                {
                                    summaryValue = "Tổng Cộng " + subTotal.GroupValue;
                                }

                                data[currentRowIndex, j] = summaryValue;
                            }
                            summaryGroupRowIndex.Add(dataStartRow + currentRowIndex); //ththo
                            gridExcelIndexData.Add(new GridExcelIndex()
                            {
                                ExcelIndex = dataStartRow + currentRowIndex,
                                GridRowHandle = Int32.MinValue,
                                GridRowLevel = Int32.MinValue,
                                IsSummaryGroup = false,
                                IsSummaryFooter = true,
                                GroupValue = "Tổng Cộng " + subTotal.GroupValue
                            });
                            currentRowIndex++;
                        }


                        #region Tổng cộng hàng nội hàng ngoại
                        
                        currentRowIndex += 2;


                        for (int j = 0; j < view.VisibleColumns.Count; j++)
                        {
                            object summaryValue = null;
                            string colAddress = this.GetColumnAddressByIndex(dataStartColumn + j);
                            GridSummaryItem summaryItem = view.VisibleColumns[j].SummaryItem;
                            if (summaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                            {
                                if (summaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum
                                    || summaryItem.SummaryType == DevExpress.Data.SummaryItemType.Count)
                                {
                                    var lst = from p in gridExcelIndexData
                                              where p.ExcelIndex < dataStartRow + currentRowIndex
                                                && p.GridRowLevel == 1
                                                && p.IsSummaryGroup == true
                                                && p.GroupValue.AsString().Contains("Nội") == true
                                              select p;
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append("=");
                                    foreach (var it in lst)
                                    {
                                        sb.Append(String.Format("{0}{1}", colAddress, it.ExcelIndex));
                                        if (it != lst.Last())
                                        {
                                            sb.Append("+");
                                        }
                                    }
                                    summaryValue = sb.ToString();
                                }
                                else
                                {
                                    summaryValue = summaryItem.SummaryValue;
                                }

                                if (summaryValue is string && this.Encode == ExcelManager.EncodeType.TCVN3)
                                {
                                    summaryValue = TextConverter.Convert(summaryValue as string);
                                }

                                if (j == 0)
                                {
                                    summaryValue = "Tổng Cộng hàng nội";
                                }

                                data[currentRowIndex, j] = summaryValue;
                            }
                            if (j == 0)
                            {
                                summaryValue = "Tổng Cộng hàng nội";
                            }

                            data[currentRowIndex, j] = summaryValue;
                        }
                        summaryGroupRowIndex.Add(dataStartRow + currentRowIndex); //ththo
                        gridExcelIndexData.Add(new GridExcelIndex()
                        {
                            ExcelIndex = dataStartRow + currentRowIndex,
                            GridRowHandle = Int32.MinValue,
                            GridRowLevel = Int32.MinValue,
                            IsSummaryGroup = false,
                            IsSummaryFooter = true,
                            GroupValue = "Tổng Cộng hàng nội"
                        });
                        currentRowIndex++;

                        for (int j = 0; j < view.VisibleColumns.Count; j++)
                        {
                            object summaryValue = null;
                            string colAddress = this.GetColumnAddressByIndex(dataStartColumn + j);
                            GridSummaryItem summaryItem = view.VisibleColumns[j].SummaryItem;
                            if (summaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                            {
                                if (summaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum
                                    || summaryItem.SummaryType == DevExpress.Data.SummaryItemType.Count)
                                {
                                    var lst = from p in gridExcelIndexData
                                              where p.ExcelIndex < dataStartRow + currentRowIndex
                                                && p.GridRowLevel == 1
                                                && p.IsSummaryGroup == true
                                                && p.GroupValue.AsString().Contains("Nội") != true
                                              select p;
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append("=");
                                    foreach (var it in lst)
                                    {
                                        sb.Append(String.Format("{0}{1}", colAddress, it.ExcelIndex));
                                        if (it != lst.Last())
                                        {
                                            sb.Append("+");
                                        }
                                    }
                                    summaryValue = sb.ToString();
                                }
                                else
                                {
                                    summaryValue = summaryItem.SummaryValue;
                                }

                                if (summaryValue is string && this.Encode == ExcelManager.EncodeType.TCVN3)
                                {
                                    summaryValue = TextConverter.Convert(summaryValue as string);
                                }

                                if (j == 0)
                                {
                                    summaryValue = "Tổng Cộng hàng ngoại";
                                }

                                data[currentRowIndex, j] = summaryValue;
                            }
                            if (j == 0)
                            {
                                summaryValue = "Tổng Cộng hàng ngoại";
                            }

                            data[currentRowIndex, j] = summaryValue;
                        }
                        summaryGroupRowIndex.Add(dataStartRow + currentRowIndex); //ththo
                        gridExcelIndexData.Add(new GridExcelIndex()
                        {
                            ExcelIndex = dataStartRow + currentRowIndex,
                            GridRowHandle = Int32.MinValue,
                            GridRowLevel = Int32.MinValue,
                            IsSummaryGroup = false,
                            IsSummaryFooter = true,
                            GroupValue = "Tổng Cộng hàng ngoại"
                        });
                        currentRowIndex++;
                        #endregion

                        #endregion
                    }
                }

                // Lưu địa chỉ column range
                if (saveColumnRange)
                {
                    for (int j = 0; j < view.VisibleColumns.Count; j++)
                    {
                        string fieldName = view.VisibleColumns[j].FieldName;
                        this.SelectRange(dataStartRow, j + 1, dataEndRow, j + 1)
                            .SetRangeName(fieldName);
                    }
                }

                // Print data
                this.SelectRange(dataStartRow, dataStartColumn, dataEndRow, dataEndCoumn)
                    .SetBorder(1)
                    .SetRangeValue(data);

                // Save data range name
                if (!String.IsNullOrEmpty(dataRangeName))
                {
                    this.SetRangeName(dataRangeName);
                }

                // Format Group row
                foreach (var index in groupRowIndex)
                {
                    this.SelectRange(index, dataStartColumn, index, dataEndCoumn)
                        .SetFontStyle(true, false, false)
                        .SetFontSize(12)
                        .SetHorizontalAlignment(Excel.XlHAlign.xlHAlignLeft)
                        .Merge();
                }

                // Format Summary group row
                foreach (var index in summaryGroupRowIndex)
                {
                    this.SelectRange(index, dataStartColumn, index, dataEndCoumn)
                        .SetFontStyle(true, false, false);
                }

                // Format Summary footer
                if (useSummaryFooter)
                {
                    this.SelectRange(dataEndRow, dataStartColumn, dataEndRow, dataEndCoumn)
                        .SetFontStyle(true, false, false);
                }

                return;
            }
            #endregion

            #region "Không sử dụng SummaryGroup"
            for (int i = 0; i < view.RowCount; i++)
            {
                int rowHandle = view.GetVisibleRowHandle(i);
                if (view.IsGroupRow(rowHandle))
                {
                    var text = view.GetGroupRowDisplayText(rowHandle);
                    if (this.Encode == ExcelManager.EncodeType.TCVN3)
                    {
                        text = TextConverter.Convert(text);
                    }
                    data[currentRowIndex, 0] = text;
                    groupRowIndex.Add(dataStartRow + currentRowIndex);
                    currentRowIndex++;
                }

                if (view.IsDataRow(rowHandle))
                {
                    for (int j = 0; j < view.VisibleColumns.Count; j++)
                    {
                        var text = view.GetRowCellDisplayText(rowHandle, view.VisibleColumns[j]);
                        if (this.Encode == ExcelManager.EncodeType.TCVN3)
                        {
                            text = TextConverter.Convert(text);
                        }

                        Type columnType = view.VisibleColumns[j].ColumnType;
                        if (columnType == typeof(DateTime) || columnType == typeof(DateTime?) || columnType == typeof(String))
                        {
                            //data[currentRowIndex, j] = "'" + text;
                            data[currentRowIndex, j] = text;
                        }
                        else
                        {
                            //DateTime date;
                            //if (DateTime.TryParse(text, out date))
                            if (view.VisibleColumns[j].ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit)
                            {
                                object value = view.GetRowCellValue(rowHandle, view.VisibleColumns[j]);
                                if (!string.IsNullOrEmpty(value + string.Empty))
                                {
                                    value = Convert.ToDecimal(value) > 0 ? value : null;
                                    data[currentRowIndex, j] = value;
                                }
                            }
                            else if (view.VisibleColumns[j].ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit)
                            {
                                object value = view.GetRowCellValue(rowHandle, view.VisibleColumns[j]);
                                if (value == null)
                                {
                                    data[currentRowIndex, j] = value;
                                }
                                else
                                {
                                    data[currentRowIndex, j] = Convert.ToBoolean(value) == true ? "X" : "";
                                }
                            }
                            else
                            {
                                data[currentRowIndex, j] = text;
                            }
                        }
                    }
                    currentRowIndex++;
                }

                prevRowHandle = rowHandle;
            }

            // In dòng Summary footer
            if (useSummaryFooter)
            {
                for (int j = 0; j < view.VisibleColumns.Count; j++)
                {
                    GridSummaryItem summaryItem = view.VisibleColumns[j].SummaryItem;
                    if (summaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                    {
                        object summaryValue = summaryItem.SummaryValue;
                        if (summaryValue is string && this.Encode == ExcelManager.EncodeType.TCVN3)
                        {
                            summaryValue = TextConverter.Convert(summaryValue as string);
                        }
                        data[currentRowIndex, j] = summaryValue;
                    }
                }
            }

            // Lưu địa chỉ column range
            if (saveColumnRange)
            {
                for (int j = 0; j < view.VisibleColumns.Count; j++)
                {
                    string fieldName = view.VisibleColumns[j].FieldName.Remove(" ");
                    this.SelectRange(dataStartRow, j + 1, dataEndRow, j + 1)
                        .SetRangeName(fieldName);
                }
            }

            // Print data
            this.SelectRange(dataStartRow, dataStartColumn, dataEndRow, dataEndCoumn)
                .SetBorder(1)
                .SetRangeValue(data);

            // Save data range name
            if (!String.IsNullOrEmpty(dataRangeName))
            {
                this.SetRangeName(dataRangeName);
            }

            // Format Group row
            foreach (var index in groupRowIndex)
            {
                this.SelectRange(index, dataStartColumn, index, dataEndCoumn)
                    .SetFontStyle(true, false, false)
                    .SetFontSize(12)
                    .SetHorizontalAlignment(Excel.XlHAlign.xlHAlignLeft)
                    .Merge();
            }

            // Format Summary group row
            foreach (var index in summaryGroupRowIndex)
            {
                this.SelectRange(index, dataStartColumn, index, dataEndCoumn)
                    .SetFontStyle(true, false, false);
            }

            // Format Summary footer
            if (useSummaryFooter)
            {
                this.SelectRange(dataEndRow, dataStartColumn, dataEndRow, dataEndCoumn)
                    .SetFontStyle(true, false, false);
            }
            #endregion
        }

        public List<int> GetParentRowHandle(GridView view, int numCall, int rowHandle)
        {
            if (numCall == 0)
            {
                return null;
            }

            List<int> result = new List<int>();
            int parentRowHandle = view.GetParentRowHandle(rowHandle);
            if (view.IsValidRowHandle(parentRowHandle))
            {
                result.Add(parentRowHandle);
            }

            List<int> temp = this.GetParentRowHandle(view, numCall - 1, parentRowHandle);
            if (temp != null)
            {
                result.AddRange(temp);
            }
            return result;
        }

        public int GetMaxRowLevel(GridView view)
        {
            if (view.RowCount == 0)
            {
                return -1;
            }

            return view.GetRowLevel(0); //Dòng data
        }

        public int GetGroupRowCount(GridView view)
        {
            int rHandle = -1;
            int groupRowCount = 0;
            while (view.IsValidRowHandle(rHandle))
            {
                groupRowCount++;
                rHandle--;
            }

            return groupRowCount;
        }
        #endregion


        #endregion
        /* --------------------------------------------------------------------------- */

        /* --------------------------- Event handlers--------------------------------- */
        #region "Event handlers"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* ------------------------------ Sub classes -------------------------------- */
        #region "Sub classes"
        public class GridExcelIndex
        {
            public int ExcelIndex { get; set; }
            public int GridRowLevel { get; set; }
            public int GridRowHandle { get; set; }
            public bool IsSummaryGroup { get; set; }
            public bool IsSummaryFooter { get; set; }
            public object GroupValue { get; set; }
            //public bool IsHangNoi { get; set; }
        }
        #endregion
        /* --------------------------------------------------------------------------- */

        /* --------------------------------- Test ------------------------------------ */
        #region "Tests"
        // Method test code
        public void Test()
        {
            // Todo: test code here
            _excelRange.Characters[0, 2].Font.Color = Color.Red;
            _excelRange.Characters[0, 2].Font.Name = "Times new roman";
        }

        //public static Excel.XlHAlign GetExcelHAlign(GridColumn column)
        //{
        //    switch (column.AppearanceCell.HAlignment)
        //    {
        //        case DevExpress.Utils.HorzAlignment.Center:
        //            return Excel.XlHAlign.xlHAlignCenter;

        //        case DevExpress.Utils.HorzAlignment.Far:
        //            return Excel.XlHAlign.xlHAlignRight;

        //        default:
        //            return Excel.XlHAlign.xlHAlignLeft;
        //    }

        //}

        public void FormatGridBand(GridBand band)
        {

        }
        #endregion
        /* --------------------------------------------------------------------------- */

        #region IDisposable Members
        public void Dispose()
        {
            //CleanUp();
        }
        #endregion

    }
}